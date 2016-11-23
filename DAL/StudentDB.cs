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
        private SqlCommandBuilder comandBuilder;
        private SqlDataAdapter daAdapter;
        private DataTable dtTable;

        public StudentDB()
        {
            dtTable = new DataTable();
        }
        public DataTable SelectAll()
        {
            daAdapter = new SqlDataAdapter("SINHVIEN_GETALL", DBConnection.Connection());
            daAdapter.Fill(dtTable);
            return dtTable;
        }
    }
}
