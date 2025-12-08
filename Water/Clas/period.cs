using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    class period
    {
        public void ADD_PERIOD(string id, DateTime start_date, DateTime end_date, int? base_days, 
            string downtime_hours, int? extended_days, int? total_hours)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[7];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@start_date", SqlDbType.DateTime);
            param[1].Value = start_date;

            param[2] = new SqlParameter("@end_date", SqlDbType.DateTime);
            param[2].Value = end_date;

            param[3] = new SqlParameter("@base_days", SqlDbType.Int);
            param[3].Value = (object)base_days ?? DBNull.Value;

            param[4] = new SqlParameter("@downtime_hours", SqlDbType.VarChar, 50);
            param[4].Value = downtime_hours;

            param[5] = new SqlParameter("@extended_days", SqlDbType.Int);
            param[5].Value = (object)extended_days ?? DBNull.Value;

            param[6] = new SqlParameter("@total_hours", SqlDbType.Int);
            param[6].Value = (object)total_hours ?? DBNull.Value;

            DAL.ExecuteCommand("period_insert", param);
            DAL.Close();
        }

        public DataTable VIEW_PERIOD(string id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            DataTable dt = DAL.SelectData("period_view", param);
            DAL.Close();
            return dt;
        }

        public DataTable GET_ALL_PERIODS()
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            DataTable dt = DAL.SelectData("periods_getAll", null);
            DAL.Close();
            return dt;
        }

        public void UPDATE_PERIOD(string id, DateTime start_date, DateTime end_date, int? base_days, 
            string downtime_hours, int? extended_days, int? total_hours)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[7];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@start_date", SqlDbType.DateTime);
            param[1].Value = start_date;

            param[2] = new SqlParameter("@end_date", SqlDbType.DateTime);
            param[2].Value = end_date;

            param[3] = new SqlParameter("@base_days", SqlDbType.Int);
            param[3].Value = (object)base_days ?? DBNull.Value;

            param[4] = new SqlParameter("@downtime_hours", SqlDbType.VarChar, 50);
            param[4].Value = downtime_hours;

            param[5] = new SqlParameter("@extended_days", SqlDbType.Int);
            param[5].Value = (object)extended_days ?? DBNull.Value;

            param[6] = new SqlParameter("@total_hours", SqlDbType.Int);
            param[6].Value = (object)total_hours ?? DBNull.Value;

            DAL.ExecuteCommand("period_update", param);
            DAL.Close();
        }

        public void DELETE_PERIOD(string id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            DAL.ExecuteCommand("period_delete", param);
            DAL.Close();
        }

        public string GET_NEXT_PERIOD_CODE()
        {
            return AutoNumberHelper.GetNextNumber("periods", "id");
        }

        /// <summary>
        /// تطبيق التوقف على الفترة الحالية وتعديل الفترات التالية
        /// </summary>
        /// <param name="period_id">معرف الفترة</param>
        /// <param name="downtime_id">معرف التوقف (اختياري)</param>
        /// <param name="added_days">عدد الأيام المضافة</param>
        /// <param name="added_hours">عدد الساعات المضافة</param>
        /// <param name="added_minutes">عدد الدقائق المضافة</param>
        public void ApplyDowntimeToPeriod(string period_id, string downtime_id, int added_days, int added_hours, int added_minutes)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[5];
            
            param[0] = new SqlParameter("@period_id", SqlDbType.VarChar, 50);
            param[0].Value = period_id;

            param[1] = new SqlParameter("@downtime_id", SqlDbType.VarChar, 50);
            param[1].Value = (object)downtime_id ?? DBNull.Value;

            param[2] = new SqlParameter("@added_days", SqlDbType.Int);
            param[2].Value = added_days;

            param[3] = new SqlParameter("@added_hours", SqlDbType.Int);
            param[3].Value = added_hours;

            param[4] = new SqlParameter("@added_minutes", SqlDbType.Int);
            param[4].Value = added_minutes;

            DAL.ExecuteCommand("period_apply_downtime", param);
            DAL.Close();
        }

        /// <summary>
        /// إلغاء التعديلات التي تمت على الفترة بسبب التوقف
        /// </summary>
        /// <param name="period_id">معرف الفترة</param>
        /// <param name="downtime_id">معرف التوقف</param>
        /// <param name="removed_days">عدد الأيام المراد إزالتها</param>
        /// <param name="removed_hours">عدد الساعات المراد إزالتها</param>
        /// <param name="removed_minutes">عدد الدقائق المراد إزالتها</param>
        public void ReverseDowntimeFromPeriod(string period_id, string downtime_id, int removed_days, int removed_hours, int removed_minutes)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[5];
            
            param[0] = new SqlParameter("@period_id", SqlDbType.VarChar, 50);
            param[0].Value = period_id;

            param[1] = new SqlParameter("@downtime_id", SqlDbType.VarChar, 50);
            param[1].Value = (object)downtime_id ?? DBNull.Value;

            param[2] = new SqlParameter("@removed_days", SqlDbType.Int);
            param[2].Value = removed_days;

            param[3] = new SqlParameter("@removed_hours", SqlDbType.Int);
            param[3].Value = removed_hours;

            param[4] = new SqlParameter("@removed_minutes", SqlDbType.Int);
            param[4].Value = removed_minutes;

            DAL.ExecuteCommand("period_reverse_downtime", param);
            DAL.Close();
        }
    }
}

