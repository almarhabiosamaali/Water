using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    class partners
    {
        public void ADD_PARTNER(string id, string name, string allocated_hours, string minutes, string phone, string address, string notes, DateTime? date)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[8];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@name", SqlDbType.VarChar, 255);
            param[1].Value = name;

            param[2] = new SqlParameter("@allocated_hours", SqlDbType.Int);
            param[2].Value = string.IsNullOrWhiteSpace(allocated_hours) ? DBNull.Value : (object)Convert.ToInt32(allocated_hours);

            param[3] = new SqlParameter("@minutes", SqlDbType.Int);
            param[3].Value = string.IsNullOrWhiteSpace(minutes) ? DBNull.Value : (object)Convert.ToInt32(minutes);

            param[4] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            param[4].Value = phone;

            param[5] = new SqlParameter("@address", SqlDbType.VarChar, 255);
            param[5].Value = address;

            param[6] = new SqlParameter("@notes", SqlDbType.VarChar, 255);
            param[6].Value = notes;

            param[7] = new SqlParameter("@created_date", SqlDbType.DateTime);
            param[7].Value = date.HasValue ? (object)date.Value : DBNull.Value;

            DAL.ExecuteCommand("partner_insert", param);
            DAL.Close();
        }

        public DataTable VIEW_PARTNER(string id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            DataTable dt = DAL.SelectData("partner_getById", param);
            DAL.Close();
            return dt;
        }

        public DataTable GET_ALL_PARTNERS()
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            DataTable dt = DAL.SelectData("partner_getAll", null);
            DAL.Close();
            return dt;
        }

        public void UPDATE_PARTNER(string id, string name, string allocated_hours, string minutes, string phone, string address, string notes, DateTime? date)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[8];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@name", SqlDbType.VarChar, 255);
            param[1].Value = name;

            param[2] = new SqlParameter("@allocated_hours", SqlDbType.Int);
            param[2].Value = string.IsNullOrWhiteSpace(allocated_hours) ? DBNull.Value : (object)Convert.ToInt32(allocated_hours);

            param[3] = new SqlParameter("@minutes", SqlDbType.Int);
            param[3].Value = string.IsNullOrWhiteSpace(minutes) ? DBNull.Value : (object)Convert.ToInt32(minutes);

            param[4] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            param[4].Value = phone;

            param[5] = new SqlParameter("@address", SqlDbType.VarChar, 255);
            param[5].Value = address;

            param[6] = new SqlParameter("@notes", SqlDbType.VarChar, 255);
            param[6].Value = notes;

            param[7] = new SqlParameter("@created_date", SqlDbType.DateTime);
            param[7].Value = date.HasValue ? (object)date.Value : DBNull.Value;

            DAL.ExecuteCommand("partner_update", param);
            DAL.Close();
        }

        public void DELETE_PARTNER(string id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            DAL.ExecuteCommand("partner_delete", param);
            DAL.Close();
        }

        public string GET_NEXT_PARTNER_CODE()
        {
            return AutoNumberHelper.GetNextNumber("partners", "id");
        }
    }
}

