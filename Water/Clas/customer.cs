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
        public void ADD_CUSTOMER(string id, string name, string type, int? allocated_hours, int? minutes, string phone, string notes)
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

            param[3] = new SqlParameter("@allocated_hours", SqlDbType.Int);
            param[3].Value = allocated_hours.HasValue ? (object)allocated_hours.Value : DBNull.Value;

            param[4] = new SqlParameter("@minutes", SqlDbType.Int);
            param[4].Value = minutes.HasValue ? (object)minutes.Value : DBNull.Value;

            param[5] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            param[5].Value = phone;

            param[6] = new SqlParameter("@notes", SqlDbType.VarChar, 255);
            param[6].Value = notes;

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

        public void UPDATE_CUSTOMER(string id, string name, string type, int? allocated_hours, int? minutes, string phone, string notes)
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

            param[3] = new SqlParameter("@allocated_hours", SqlDbType.Int);
            param[3].Value = allocated_hours.HasValue ? (object)allocated_hours.Value : DBNull.Value;

            param[4] = new SqlParameter("@minutes", SqlDbType.Int);
            param[4].Value = minutes.HasValue ? (object)minutes.Value : DBNull.Value;

            param[5] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            param[5].Value = phone;

            param[6] = new SqlParameter("@notes", SqlDbType.VarChar, 255);
            param[6].Value = notes;

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
