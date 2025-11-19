using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    class customer
    {
        public void ADD_CUSTOMER(string id, string name, string type, string phone, string address, string notes, DateTime? created_date)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[7];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@name", SqlDbType.VarChar, 255);
            param[1].Value = name;

            param[2] = new SqlParameter("@type", SqlDbType.VarChar, 50);
            param[2].Value = type;

            param[3] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            param[3].Value = phone;

            param[4] = new SqlParameter("@address", SqlDbType.VarChar, 255);
            param[4].Value = address;

            param[5] = new SqlParameter("@notes", SqlDbType.VarChar, 255);
            param[5].Value = notes;

            param[6] = new SqlParameter("@created_date", SqlDbType.DateTime);
            param[6].Value = created_date.HasValue ? (object)created_date.Value : DBNull.Value;

            DAL.ExecuteCommand("customer_insert", param);
            DAL.Close();
        }

        public DataTable VIEW_CUSTOMER(string id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            DataTable dt = DAL.SelectData("customer_view", param);
            DAL.Close();
            return dt;
        }

        public DataTable GET_ALL_CUSTOMERS()
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            DataTable dt = DAL.SelectData("customer_getAll", null);
            DAL.Close();
            return dt;
        }

        public void UPDATE_CUSTOMER(string id, string name, string type, string phone, string address, string notes, DateTime? created_date)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[7];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@name", SqlDbType.VarChar, 255);
            param[1].Value = name;

            param[2] = new SqlParameter("@type", SqlDbType.VarChar, 50);
            param[2].Value = type;

            param[3] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            param[3].Value = phone;

            param[4] = new SqlParameter("@address", SqlDbType.VarChar, 255);
            param[4].Value = address;

            param[5] = new SqlParameter("@notes", SqlDbType.VarChar, 255);
            param[5].Value = notes;

            param[6] = new SqlParameter("@created_date", SqlDbType.DateTime);
            param[6].Value = created_date.HasValue ? (object)created_date.Value : DBNull.Value;

            DAL.ExecuteCommand("customer_update", param);
            DAL.Close();
        }

        public void DELETE_CUSTOMER(string id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            DAL.ExecuteCommand("customer_delete", param);
            DAL.Close();
        }
    }
}
