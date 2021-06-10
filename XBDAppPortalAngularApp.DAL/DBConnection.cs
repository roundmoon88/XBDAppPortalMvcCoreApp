using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace XBDAppPortalMvcCoreApp.DAL
{
    public class DBConnection
    {
        private string connStr;

        public DBConnection()
        {
            //connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            //DefaultConnection
            //connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //connStr = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connStr = "Server = RICHARD-PC\\RICHARD; Database=XDb; User Id =ribo_job; Password =zmkmzmkm; ";
        }

        public DataSet GetDataSet(string strCmdTxt)
        {
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connStr;
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.CommandText = strCmdTxt;
                    comm.Connection = conn;
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(comm);
                    adapter.Fill(ds);
                    conn.Close();
                }
            }



            return ds;

        }






        public DataSet GetDataSet(string strCmdTxt, IList<SqlParameter> parameters)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connStr;
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    conn.Open();
                    comm.CommandText = strCmdTxt;
                    comm.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter p in parameters)
                    {
                        comm.Parameters.Add(p);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(comm);

                    adapter.Fill(ds);

                    conn.Close();

                }
                return ds;
            }
        }
        public DataSet GetDataSet(string strCmdTxt, SqlParameter parameter)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connStr;
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    conn.Open();
                    comm.CommandText = strCmdTxt;
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Add(parameter);

                    SqlDataAdapter adapter = new SqlDataAdapter(comm);

                    adapter.Fill(ds);

                    conn.Close();

                }
                return ds;
            }
        }



    }
}
