using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    class partner_cost_mst
    {
        public void ADD_PARTNER_COST_MST(int cost_id, int? doc_type, DateTime? date, string down_timeId, 
            string down_timeNote, int? period_id, int? dayesCount, int? hours, int? minutes, 
            DateTime? startTime, DateTime? endTime, double? amount, string note)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[13];
            
            param[0] = new SqlParameter("@cost_id", SqlDbType.Int);
            param[0].Value = cost_id;

            param[1] = new SqlParameter("@doc_type", SqlDbType.Int);
            param[1].Value = (object)doc_type ?? DBNull.Value;

            param[2] = new SqlParameter("@date", SqlDbType.Date);
            param[2].Value = (object)date ?? DBNull.Value;

            param[3] = new SqlParameter("@down_timeId", SqlDbType.VarChar, 50);
            param[3].Value = string.IsNullOrWhiteSpace(down_timeId) ? DBNull.Value : (object)down_timeId;

            param[4] = new SqlParameter("@down_timeNote", SqlDbType.VarChar, 255);
            param[4].Value = string.IsNullOrWhiteSpace(down_timeNote) ? DBNull.Value : (object)down_timeNote;

            param[5] = new SqlParameter("@period_id", SqlDbType.Int);
            param[5].Value = (object)period_id ?? DBNull.Value;

            param[6] = new SqlParameter("@dayesCount", SqlDbType.Int);
            param[6].Value = (object)dayesCount ?? DBNull.Value;

            param[7] = new SqlParameter("@hours", SqlDbType.Int);
            param[7].Value = (object)hours ?? DBNull.Value;

            param[8] = new SqlParameter("@minutes", SqlDbType.Int);
            param[8].Value = (object)minutes ?? DBNull.Value;

            param[9] = new SqlParameter("@startTime", SqlDbType.DateTime);
            param[9].Value = (object)startTime ?? DBNull.Value;

            param[10] = new SqlParameter("@endTime", SqlDbType.DateTime);
            param[10].Value = (object)endTime ?? DBNull.Value;

            param[11] = new SqlParameter("@amount", SqlDbType.Float);
            param[11].Value = (object)amount ?? DBNull.Value;

            param[12] = new SqlParameter("@note", SqlDbType.VarChar, 255);
            param[12].Value = string.IsNullOrWhiteSpace(note) ? DBNull.Value : (object)note;

            DAL.ExecuteCommand("partner_cost_mst_insert", param);
            DAL.Close();
        }

        public DataTable VIEW_PARTNER_COST_MST(int cost_id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@cost_id", SqlDbType.Int);
            param[0].Value = cost_id;

            DataTable dt = DAL.SelectData("partner_cost_mst_viewById", param);
            DAL.Close();
            return dt;
        }

        public DataTable GET_ALL_PARTNER_COST_MST()
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            DataTable dt = DAL.SelectData("partner_cost_mst_viewAll", null);
            DAL.Close();
            return dt;
        }

        public void UPDATE_PARTNER_COST_MST(int cost_id, int? doc_type, DateTime? date, string down_timeId, 
            string down_timeNote, int? period_id, int? dayesCount, int? hours, int? minutes, 
            DateTime? startTime, DateTime? endTime, double? amount, string note)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[13];
            
            param[0] = new SqlParameter("@cost_id", SqlDbType.Int);
            param[0].Value = cost_id;

            param[1] = new SqlParameter("@doc_type", SqlDbType.Int);
            param[1].Value = (object)doc_type ?? DBNull.Value;

            param[2] = new SqlParameter("@date", SqlDbType.Date);
            param[2].Value = (object)date ?? DBNull.Value;

            param[3] = new SqlParameter("@down_timeId", SqlDbType.VarChar, 50);
            param[3].Value = string.IsNullOrWhiteSpace(down_timeId) ? DBNull.Value : (object)down_timeId;

            param[4] = new SqlParameter("@down_timeNote", SqlDbType.VarChar, 255);
            param[4].Value = string.IsNullOrWhiteSpace(down_timeNote) ? DBNull.Value : (object)down_timeNote;

            param[5] = new SqlParameter("@period_id", SqlDbType.Int);
            param[5].Value = (object)period_id ?? DBNull.Value;

            param[6] = new SqlParameter("@dayesCount", SqlDbType.Int);
            param[6].Value = (object)dayesCount ?? DBNull.Value;

            param[7] = new SqlParameter("@hours", SqlDbType.Int);
            param[7].Value = (object)hours ?? DBNull.Value;

            param[8] = new SqlParameter("@minutes", SqlDbType.Int);
            param[8].Value = (object)minutes ?? DBNull.Value;

            param[9] = new SqlParameter("@startTime", SqlDbType.DateTime);
            param[9].Value = (object)startTime ?? DBNull.Value;

            param[10] = new SqlParameter("@endTime", SqlDbType.DateTime);
            param[10].Value = (object)endTime ?? DBNull.Value;

            param[11] = new SqlParameter("@amount", SqlDbType.Float);
            param[11].Value = (object)amount ?? DBNull.Value;

            param[12] = new SqlParameter("@note", SqlDbType.VarChar, 255);
            param[12].Value = string.IsNullOrWhiteSpace(note) ? DBNull.Value : (object)note;

            DAL.ExecuteCommand("partner_cost_mst_update", param);
            DAL.Close();
        }

        public void DELETE_PARTNER_COST_MST(int cost_id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@cost_id", SqlDbType.Int);
            param[0].Value = cost_id;

            DAL.ExecuteCommand("partner_cost_mst_delete", param);
            DAL.Close();
        }

        public string GET_NEXT_PARTNERCOST_CODE()
        {
            return AutoNumberHelper.GetNextNumber("partner_cost_mst", "cost_id");
        }

        public void ADD_POST(string action, string doc_type, string doc_no,  string doc_no_type, string period_id,
           string cus_part_type, string cus_part_no, string cus_part_name, double dr_amt, double cr_amt,
           DateTime date, DateTime start_time, DateTime end_time, double hours,
           double minutes, string note ,string user_id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();

            SqlParameter[] param = new SqlParameter[17];

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

            param[11] = new SqlParameter("@start_time", SqlDbType.Time);
            param[11].Value = start_time.TimeOfDay;

            param[12] = new SqlParameter("@end_time", SqlDbType.Time);
            param[12].Value = end_time.TimeOfDay;

            param[13] = new SqlParameter("@hours", SqlDbType.Int);
            param[13].Value = hours;

            param[14] = new SqlParameter("@minutes", SqlDbType.Int);
            param[14].Value = minutes;
            param[15] = new SqlParameter("@note", SqlDbType.VarChar, 500);
            param[15].Value = (object)note ?? DBNull.Value;
            param[16] = new SqlParameter("@user_id", SqlDbType.VarChar, 20);
            param[16].Value = user_id;
            DAL.ExecuteCommand("sp_post_crud", param);
            DAL.Close();
        }
    }
}

