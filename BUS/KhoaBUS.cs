using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BUS
{
    public class KhoaBUS
    {
        KhoaDB khoaDAL = new KhoaDB();
        public DataTable GetlistMajor()
        {
            return khoaDAL.SelectlistMajor();
        }
        public DataTable SelectMajorForStudent()
        {
            return khoaDAL.SelectMajorStudent();
        }
    }
}
