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
    public partial class Form1 : Form
    {
        private StudentBUS newStudent;
        public Form1()
        {
            newStudent = new StudentBUS();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvStudentlist.DataSource = newStudent.GetList();
        }
    }
}
