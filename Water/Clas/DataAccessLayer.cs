using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    class DataAccessLayer
    {
        SqlConnection sqlconnection;
        public DataAccessLayer()
        {





           // sqlconnection = new SqlConnection(@"Server=" + Properties.Settings.Default.Server + "; Database=" +
             //                              Properties.Settings.Default.Database + "; Integrated Security=false; User ID=" +
               //                            Properties.Settings.Default.ID + "; Password=" + Properties.Settings.Default.Password + "");

            sqlconnection = new SqlConnection(@"Server=LAPTOP-UDOB2GCQ ; Database=Water; Integrated Security=false; User ID=sa; Password=osama@123");







        }
        //Method to open the connection
        public void Open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {

                sqlconnection.Open();
            }
        }

        //Method to close the connection
        public void Close()
        {
            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }

        //Method To Read Data From Database
        public DataTable SelectData(string stored_procedure, SqlParameter[] param)
        {


            SqlCommand sqlCommand = new SqlCommand();
            SqlCommand sqlcmd = sqlCommand;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;





        }

        //Method to Insert, Update, and Delete Data From Database
        public void ExecuteCommand(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();
        }
    }
}
