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
        public void ADD_PARTNER_COST_DTL(int cost_id, int? partner_id, int? doc_type, string partner_name, 
            int? allocated_hours, int? minutes, double? allocated_amount, string note)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[8];
            
            param[0] = new SqlParameter("@cost_id", SqlDbType.Int);
            param[0].Value = cost_id;

            param[1] = new SqlParameter("@partner_id", SqlDbType.Int);
            param[1].Value = (object)partner_id ?? DBNull.Value;

            param[2] = new SqlParameter("@doc_type", SqlDbType.Int);
            param[2].Value = (object)doc_type ?? DBNull.Value;

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

        public DataTable VIEW_PARTNER_COST_DTL(int cost_id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@cost_id", SqlDbType.Int);
            param[0].Value = cost_id;

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

        public void UPDATE_PARTNER_COST_DTL(int cost_id, int? partner_id, int? doc_type, string partner_name, 
            int? allocated_hours, int? minutes, double? allocated_amount, string note)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[8];
            
            param[0] = new SqlParameter("@cost_id", SqlDbType.Int);
            param[0].Value = cost_id;

            param[1] = new SqlParameter("@partner_id", SqlDbType.Int);
            param[1].Value = (object)partner_id ?? DBNull.Value;

            param[2] = new SqlParameter("@doc_type", SqlDbType.Int);
            param[2].Value = (object)doc_type ?? DBNull.Value;

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

        public void DELETE_PARTNER_COST_DTL(int cost_id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@cost_id", SqlDbType.Int);
            param[0].Value = cost_id;

            DAL.ExecuteCommand("partner_cost_dtl_delete", param);
            DAL.Close();
        }

        public void DELETE_ALL_PARTNER_COST_DTL_BY_COST_ID(int cost_id)
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
    }
}

