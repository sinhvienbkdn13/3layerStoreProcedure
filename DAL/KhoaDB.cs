using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class KhoaDB
    {
        private SqlDataAdapter dtAdapter;
        private DataTable dtTableMajor;
        private DataTable dtMajorStudent;
        private SqlConnection connect = DBConnection.Connection();
        public DataTable SelectlistMajor()
        {
            dtTableMajor = new DataTable();
            dtAdapter = new SqlDataAdapter("Khoa_GetAll",connect);
            dtAdapter.Fill(dtTableMajor);
            return dtTableMajor;
        }
        public DataTable SelectMajorStudent()
        {
            dtMajorStudent = new DataTable();
            dtAdapter = new SqlDataAdapter("GET_KHOA", connect);
            dtAdapter.Fill(dtMajorStudent);
            return dtMajorStudent;
        }
    }
}
