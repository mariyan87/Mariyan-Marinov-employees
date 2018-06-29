using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using CsvParser = DataAccessLayer.CsvParser;

namespace UI
{
    public partial class EmployeeView : Form
    {
        private const string DEFAULT_CSV_FILE = "employees.csv";
        public EmployeeView()
        {
            InitializeComponent();

            InitializeOpenDialog();

            InitializeComboDateFormat();
        }

        private void InitializeComboDateFormat()
        {
            cbDateFormat.DataSource = CsvParser.DATE_FORMATS.ToList();
            cbDateFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDateFormat.SelectedValueChanged += CbDateFormat_SelectedValueChanged;
        }

        private void CbDateFormat_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dgvAllEmployees.DataSource == null || dgvAllEmployees.Columns.Count < 4)
            {
                return;
            }

            UpdateDateCellsFormat();
        }

        private void UpdateDateCellsFormat()
        {
            dgvAllEmployees.Columns[2].DefaultCellStyle.Format = cbDateFormat.SelectedValue.ToString();
            dgvAllEmployees.Columns[3].DefaultCellStyle.Format = cbDateFormat.SelectedValue.ToString();
        }

        private void InitializeOpenDialog()
        {
            openFileDialog1.Title = "Select file";
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.FileName = DEFAULT_CSV_FILE;
            openFileDialog1.Filter = "Text and CSV Files(*.txt, *.csv)|*.txt;*.csv|Text Files(*.txt)|*.txt|CSV Files(*.csv)|*.csv";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
        }

        private void btnOpenCsv_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                dgvLongestWork.DataSource = null;
                dgvAllEmployees.DataSource = null;
                return;
            }

            LoadData(openFileDialog1.FileName);
        }

        private void EmployeeView_Load(object sender, EventArgs e)
        {
            //Програмата да може да се пусне без да е необходимо да се правят каквито и да е промени в кода
            string filename = Directory.GetCurrentDirectory() + "\\" + DEFAULT_CSV_FILE;
            if (!File.Exists(filename))
            {
                MessageBox.Show("Default CSV file not found in executable dir!" + Environment.NewLine +
                                "Please, select a valid file!");
                return;
            }
            
            LoadData(filename);
        }

        private void LoadData(string filename)
        {
            textBox1.Text = filename;

            DataTable dt = null;
            try
            {
                dt = CsvParser.GetDataTableFromCsv(filename);
            }
            catch (FormatException e)
            {
                Debug.WriteLine(e);
                MessageBox.Show("Error occurred while parsing data from CSV file!" + e.Message);
                return;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                MessageBox.Show("Error occurred while parsing data from CSV file!");
                return;
            }
            List<Employee> allEmployees = EmployeeParser.GetEmployeesFromDatatable(dt);
            dgvAllEmployees.DataSource = allEmployees;

            var longestWorkByPairs = FindWorkTogether(allEmployees);
            dgvLongestWork.DataSource = longestWorkByPairs;

            UpdateDateCellsFormat();
        }

        private List<WorkTogether> FindWorkTogether(List<Employee> allEmployees)
        {
            //Tuple<EmployeeID #1, EmployeeID #2>, Dictionary<Project IDs, Days worked>
            Dictionary<Tuple<int, int>, Dictionary<int, int>> d = new Dictionary<Tuple<int, int>, Dictionary<int, int>>();
            var emplGroupedByProject = allEmployees
                .GroupBy(u => u.ProjectID)
                .Select(grp => grp.OrderBy(o => o.DateFrom).ToList())
                .Where(lst => lst.Count > 1) //remove employees worked alone
                .ToList();

            List<WorkTogether> allWorkTogether = new List<WorkTogether>();

            foreach (List<Employee> employeesPerProject in emplGroupedByProject)
            {
                var employeesByID = employeesPerProject
                    .GroupBy(u => u.ID)
                    .Select(grp => grp.ToList())
                    .ToList();

                for (int i = 0; i < employeesByID.Count; i++)
                {
                    var emplList1 = employeesByID[i];
                    //emplList1.ForEach(em => Console.WriteLine(em.ToString()));

                    foreach (Employee employee1 in emplList1)
                    {
                        DateTime start1 = employee1.DateFrom;
                        DateTime end1 = employee1.DateTo;

                        //compare current employee work with next employees work
                        for (int j = i + 1; j < employeesByID.Count; j++)
                        {
                            var emplList2 = employeesByID[j];
                            emplList2.ForEach(em => Debug.WriteLine(em.ToString()));

                            foreach (Employee employee2 in emplList2)
                            {
                                DateTime start2 = employee2.DateFrom;
                                DateTime end2 = employee2.DateTo;

                                Debug.WriteLine($"ID1={employee1.ID} ProjectID={employee1.ProjectID} DateFrom={employee1.DateFrom} DateTo={employee1.DateTo} ");
                                Debug.WriteLine($"ID2={employee2.ID} ProjectID={employee2.ProjectID} DateFrom={employee2.DateFrom} DateTo={employee2.DateTo} ");

                                //all employee2 works are after employee1 current work, so no further overlaps 
                                if (start2 > end1)
                                {
                                    //break;
                                }

                                if (start1 > end2 || end1 < start2)
                                {
                                    continue; // no overlap
                                }

                                var daysTogether = CalcDaysTogetherForPair(start1, start2, end1, end2);

                                if (daysTogether > 0)
                                {
                                    allWorkTogether.Add(new WorkTogether
                                    {
                                        ID1 = employee1.ID,
                                        ID2 = employee2.ID,
                                        ProjectID = employee1.ProjectID,
                                        Days = daysTogether
                                    });
                                }
                            }
                        }
                    }
                }

                //employeesPerProject.ForEach(em => Console.WriteLine(em.ToString()));
            }

            //allWorkTogether.ForEach(em => Debug.WriteLine(em.ToString()));

            var workByPairs = allWorkTogether.GroupBy(gr => new {gr.ID1, gr.ID2}).Select(
                g => new WorkTogether()
                {
                    ID1 = g.Key.ID1,
                    ID2 = g.Key.ID2,
                    Days = g.Sum(s => s.Days),//sum for all projects for pair of employees
                    ProjectID = g.First().ProjectID
                }).OrderByDescending(o => o.Days).ToList();

            return workByPairs;
        }

        private int CalcDaysTogetherForPair(DateTime start1, DateTime start2, DateTime end1, DateTime end2)
        {
            int daysTogether = 0;

            if (start1 <= start2 && end1 <= end2)
            {
                daysTogether = CalcDaysDiff(start2, end1);
            }
            else if (start1 >= start2 && end1 >= end2)
            {
                daysTogether = CalcDaysDiff(start1, end2);
            }
            else if (start1 >= start2 && end1 <= end2)
            {
                daysTogether = CalcDaysDiff(start1, end1);
            }
            else if (start1 <= start2 && end1 >= end2)
            {
                daysTogether = CalcDaysDiff(start2, end2);
            }
            return daysTogether;
        }

        private struct WorkTogether
        {
            public int ID1 { get; set; }
            public int ID2 { get; set; }
            public int ProjectID { get; set; }
            public int Days { get; set; }

            public override string ToString()
            {
                return $"ID1={ID1} ID2={ID2} ProjectID={ProjectID} Days={Days} ";
            }
        }

        private int CalcDaysDiff(DateTime start, DateTime end)
        {
            return (int)(end - start).TotalDays;
        }

        private void dgvLongestWork_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //just to mark the row with the pair of employees who worked longest on common projects
            if (e.RowIndex == 0)
            {
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                e.CellStyle.ForeColor = Color.DarkBlue;
            }
        }
    }
}
