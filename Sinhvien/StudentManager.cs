using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace Sinhvien
{
    public partial class StudentManager : Form
    {
        private KhoaBUS newKhoa;
        private DataTable newTableSinhvien;
        private List<string> TableKhoaName;
        private List<string> TableKhoaID;
        private DataTable majorForStudent;
        private StudentBUS newStudent;
        private int index;
        private DataGridViewRow dgvRow;

        public StudentManager()
        {
            newKhoa = new KhoaBUS();
            newStudent = new StudentBUS();
            majorForStudent = new DataTable();
            TableKhoaName = new List<string>();
            TableKhoaID = new List<string>();
            InitializeComponent();
        }
        private void Init()
        {
            newTableSinhvien = newStudent.GetList();
            
            //Add Data to List Name
            foreach(DataRow row in newKhoa.GetlistMajor().Rows)
            {
                TableKhoaName.Add(row[1].ToString());
            }

            foreach (DataRow row in newKhoa.GetlistMajor().Rows)
            {
                TableKhoaID.Add(row[0].ToString());
            }
            majorForStudent = newKhoa.SelectMajorForStudent();

            dgvStudentlist.AutoGenerateColumns = false;
            dgvStudentlist.Columns.Add("clStudentID", "Student ID");
            dgvStudentlist.Columns[0].DataPropertyName = "ID";
            dgvStudentlist.Columns.Add("clSurname", "Surname");
            dgvStudentlist.Columns[1].DataPropertyName = "Surname";
            dgvStudentlist.Columns.Add("clFirstname", "First Name");
            dgvStudentlist.Columns[2].DataPropertyName = "Firstname";
            dgvStudentlist.Columns.Add("clBirthday", "Birthday");
            dgvStudentlist.Columns[3].DataPropertyName = "Birthday";
            // Check Box
            DataGridViewCheckBoxColumn clSex = new DataGridViewCheckBoxColumn();
            clSex.HeaderText = "Gender";
            dgvStudentlist.Columns.Add(clSex);
            dgvStudentlist.Columns[4].DataPropertyName = "Sex";
            // End Check box

            // combobox Major Name
            DataGridViewComboBoxColumn clMajorName = new DataGridViewComboBoxColumn();
            clMajorName.HeaderText = "Major Name";
            clMajorName.DataSource = TableKhoaName;
            dgvStudentlist.Columns.Add(clMajorName);

            // combobox
            dgvStudentlist.Columns.Add("clsMajorID", "Major ID");
            dgvStudentlist.Columns[6].DataPropertyName = "Major_ID";
            dgvStudentlist.Columns[6].Visible = false;

            // Add DataSource
            dgvStudentlist.DataSource = newTableSinhvien;


            // add Major_ID to combobox
            cboMajor.DataSource = TableKhoaID;
            
            
            foreach (DataGridViewColumn col in dgvStudentlist.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            int i = 0;
            foreach (DataRow row in majorForStudent.Rows)
            {
                DataGridViewComboBoxCell cellcombo = (DataGridViewComboBoxCell)dgvStudentlist.Rows[i].Cells[5];
                for (int j = 0; j < cellcombo.Items.Count; j++)
                {
                    if (cellcombo.Items[j].ToString() == (row[0].ToString()))
                    {
                        cellcombo.Value = cellcombo.Items[j].ToString();
                        break;
                    }
                }
                i++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (newStudent.InsertStudent())
            {
                MessageBox.Show("Insert Successfully");
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        private void dgvStudentlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            dgvRow = dgvStudentlist.Rows[index];
            if (index >= 0)
            {
                txtStudentID.Text = dgvRow.Cells[0].Value.ToString();
                txtSurname.Text = dgvRow.Cells[1].Value.ToString();
                txtFirstname.Text = dgvRow.Cells[2].Value.ToString();
                if (!string.IsNullOrEmpty(dgvRow.Cells[3].Value.ToString()) && !string.IsNullOrEmpty(dgvRow.Cells[4].Value.ToString()) && !string.IsNullOrEmpty(dgvRow.Cells[6].Value.ToString()))
                {
                    dtpBirthday.Value = DateTime.Parse(dgvRow.Cells[3].Value.ToString());

                    txtSex.Text = (Boolean.Parse(dgvRow.Cells[4].Value.ToString()) == true) ? "Nam" : "Nữ";
                    // Choose which MajorID can show

                    int i = 0;
                    while (dgvRow.Cells[6].Value.ToString() != cboMajor.Items[i].ToString())
                    {
                        i++;
                    }
                    cboMajor.SelectedIndex = i;
                }
            }
        }
    }
}
