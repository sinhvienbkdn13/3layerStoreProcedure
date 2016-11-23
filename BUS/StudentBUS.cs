using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class StudentBUS
    {
        StudentDB StudentDAL = new StudentDB();

        public DataTable GetList()
        {
            return StudentDAL.SelectAll();
        }
    }
}
