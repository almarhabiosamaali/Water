using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    class partner_cost_dtl
    {
        public void ADD_PARTNER_COST_DTL(string cost_id, string partner_id, string doc_type, string partner_name, 
            int? allocated_hours, int? minutes, double? allocated_amount, string note)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[8];
            
            param[0] = new SqlParameter("@cost_id", SqlDbType.VarChar, 50);
            param[0].Value = string.IsNullOrWhiteSpace(cost_id) ? DBNull.Value : (object)cost_id;

            param[1] = new SqlParameter("@partner_id", SqlDbType.VarChar, 50);
            param[1].Value = string.IsNullOrWhiteSpace(partner_id) ? DBNull.Value : (object)partner_id;

            param[2] = new SqlParameter("@doc_type", SqlDbType.VarChar, 50);
            param[2].Value = string.IsNullOrWhiteSpace(doc_type) ? DBNull.Value : (object)doc_type;

            param[3] = new SqlParameter("@partner_name", SqlDbType.VarChar, 255);
            param[3].Value = string.IsNullOrWhiteSpace(partner_name) ? DBNull.Value : (object)partner_name;

            param[4] = new SqlParameter("@allocated_hours", SqlDbType.Int);
            param[4].Value = (object)allocated_hours ?? DBNull.Value;

            param[5] = new SqlParameter("@minutes", SqlDbType.Int);
            param[5].Value = (object)minutes ?? DBNull.Value;

            param[6] = new SqlParameter("@allocated_amount", SqlDbType.Float);
            param[6].Value = (object)allocated_amount ?? DBNull.Value;

            param[7] = new SqlParameter("@note", SqlDbType.VarChar, 255);
            param[7].Value = string.IsNullOrWhiteSpace(note) ? DBNull.Value : (object)note;

            DAL.ExecuteCommand("partner_cost_dtl_insert", param);
            DAL.Close();
        }

        public DataTable VIEW_PARTNER_COST_DTL(string cost_id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@cost_id", SqlDbType.VarChar, 50);
            param[0].Value = string.IsNullOrWhiteSpace(cost_id) ? DBNull.Value : (object)cost_id;

            DataTable dt = DAL.SelectData("partner_cost_dtl_viewById", param);
            DAL.Close();
            return dt;
        }

        public DataTable GET_ALL_PARTNER_COST_DTL()
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            DataTable dt = DAL.SelectData("partner_cost_dtl_viewAll", null);
            DAL.Close();
            return dt;
        }

        public void UPDATE_PARTNER_COST_DTL(string cost_id, string partner_id, string doc_type, string partner_name, 
            int? allocated_hours, int? minutes, double? allocated_amount, string note)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[8];
            
            param[0] = new SqlParameter("@cost_id", SqlDbType.VarChar, 50);
            param[0].Value = string.IsNullOrWhiteSpace(cost_id) ? DBNull.Value : (object)cost_id;

            param[1] = new SqlParameter("@partner_id", SqlDbType.VarChar, 50);
            param[1].Value = string.IsNullOrWhiteSpace(partner_id) ? DBNull.Value : (object)partner_id;

            param[2] = new SqlParameter("@doc_type", SqlDbType.VarChar, 50);
            param[2].Value = string.IsNullOrWhiteSpace(doc_type) ? DBNull.Value : (object)doc_type;

            param[3] = new SqlParameter("@partner_name", SqlDbType.VarChar, 255);
            param[3].Value = string.IsNullOrWhiteSpace(partner_name) ? DBNull.Value : (object)partner_name;

            param[4] = new SqlParameter("@allocated_hours", SqlDbType.Int);
            param[4].Value = (object)allocated_hours ?? DBNull.Value;

            param[5] = new SqlParameter("@minutes", SqlDbType.Int);
            param[5].Value = (object)minutes ?? DBNull.Value;

            param[6] = new SqlParameter("@allocated_amount", SqlDbType.Float);
            param[6].Value = (object)allocated_amount ?? DBNull.Value;

            param[7] = new SqlParameter("@note", SqlDbType.VarChar, 255);
            param[7].Value = string.IsNullOrWhiteSpace(note) ? DBNull.Value : (object)note;

            DAL.ExecuteCommand("partner_cost_dtl_update", param);
            DAL.Close();
        }

        public void DELETE_PARTNER_COST_DTL(string cost_id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@cost_id", SqlDbType.VarChar, 50);
            param[0].Value = string.IsNullOrWhiteSpace(cost_id) ? DBNull.Value : (object)cost_id;

            DAL.ExecuteCommand("partner_cost_dtl_delete", param);
            DAL.Close();
        }

        public void DELETE_ALL_PARTNER_COST_DTL_BY_COST_ID(string cost_id)
        {
            // استخدام نفس الـ procedure لحذف جميع التفاصيل حسب cost_id
            DELETE_PARTNER_COST_DTL(cost_id);
        }

        public DataTable AllocateDowntimeAmountToPartners(string downTimeId)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@downtimeId", SqlDbType.VarChar, 50);
            param[0].Value = string.IsNullOrWhiteSpace(downTimeId) ? DBNull.Value : (object)downTimeId;

            DataTable dt = DAL.SelectData("AllocateDowntimeAmountToPartners", param);
            DAL.Close();
            return dt;
        }

         public void ADD_POST(string action, string doc_type, string doc_no,  string doc_no_type, string period_id,
           string cus_part_type, string cus_part_no, string cus_part_name, double dr_amt, double cr_amt,
           DateTime date,string note ,string user_id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();

            SqlParameter[] param = new SqlParameter[13];

            param[0] = new SqlParameter("@action", SqlDbType.NVarChar, 20);
            param[0].Value = action;

            param[1] = new SqlParameter("@doc_type", SqlDbType.VarChar, 50);
            param[1].Value = doc_type;

            param[2] = new SqlParameter("@doc_no", SqlDbType.VarChar, 50);
            param[2].Value = doc_no;

            param[3] = new SqlParameter("@doc_no_type", SqlDbType.VarChar, 50);
            param[3].Value = doc_no_type;

            param[4] = new SqlParameter("@period_id", SqlDbType.VarChar, 50);
            param[4].Value = period_id;

            param[5] = new SqlParameter("@cus_part_type", SqlDbType.VarChar, 50);
            param[5].Value = cus_part_type;

            param[6] = new SqlParameter("@cus_part_no", SqlDbType.VarChar, 50);
            param[6].Value = cus_part_no;

            param[7] = new SqlParameter("@cus_part_name", SqlDbType.VarChar, 200);
            param[7].Value = cus_part_name;

            param[8] = new SqlParameter("@dr_amt", SqlDbType.Decimal);
            param[8].Value = dr_amt;

            param[9] = new SqlParameter("@cr_amt", SqlDbType.Decimal);
            param[9].Value = cr_amt;

            param[10] = new SqlParameter("@date", SqlDbType.Date);
            param[10].Value = date;

            param[11] = new SqlParameter("@note", SqlDbType.VarChar, 500);
            param[11].Value = (object)note ?? DBNull.Value;
            param[12] = new SqlParameter("@user_id", SqlDbType.VarChar, 20);
            param[12].Value = user_id;
            DAL.ExecuteCommand("sp_post_crud", param);
            DAL.Close();
        }

        public void DELETE_POST(string action, string doc_type, string doc_no)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@action", SqlDbType.NVarChar, 20);
            param[0].Value = action;

            param[1] = new SqlParameter("@doc_type", SqlDbType.VarChar, 50);
            param[1].Value = doc_type;

            param[2] = new SqlParameter("@doc_no", SqlDbType.VarChar, 50);
            param[2].Value = doc_no;
            DAL.ExecuteCommand("sp_post_crud", param);
            DAL.Close();
        }


        
    }
}

