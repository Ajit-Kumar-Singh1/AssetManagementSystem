using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementSystem.Helpers
{
    public class connectionString
    {
        private IConfiguration _config;

        public connectionString(IConfiguration config)
        {
            _config = config;
        }

        public bool UserAlreadyExists(string query)
        {
            bool flag = false;
            string connectionString = _config["ConnectionStrings:AMSConnection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = query;
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader rd = command.ExecuteReader();

                if(rd.HasRows)
                {
                    flag = true;
                }

                connection.Close();
            }
            return flag;
        }

        public int DMLTransaction(string Query)
        {
            int Result;
            string connectionString = _config["ConnectionStrings:AMSConnection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = Query;
                SqlCommand command = new SqlCommand(sql, connection);
                Result = command.ExecuteNonQuery();
                connection.Close();
            }
            return Result;
        }

        public bool DataAlreadyExists(string query)
        {
            bool flag = false;
            string connectionString = _config["ConnectionStrings:AMSConnection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = query;
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader rd = command.ExecuteReader();

                if (rd.HasRows)
                {
                    flag = true;
                }

                connection.Close();
            }
            return flag;
        }

        public object ExecuteSqlString(string sqlstring)
        {
            string connectionString = _config["ConnectionStrings:AMSConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataSet ds = new DataSet();
                SqlCommand objcmd = new SqlCommand(sqlstring, connection);
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                objAdp.Fill(ds);
                return ds;
            }
        }
    }
}
