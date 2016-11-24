using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class StudentDB 
    {
        private SqlDataAdapter daAdapter;
        private DataTable dtTable;

        public StudentDB()
        {
            daAdapter = new SqlDataAdapter("SINHVIEN_GETALL", DBConnection.Connection());
            dtTable = new DataTable();
        }
        public DataTable SelectAll()
        {
            daAdapter.Fill(dtTable);
            return dtTable;
        }
        public bool Insert()
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(daAdapter);
            int k = daAdapter.Update(dtTable);
            if (k == 1) return true;
            return false;
        }
    }
}
