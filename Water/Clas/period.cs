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
        public void ADD_PERIOD(string id, DateTime start_date, DateTime end_date, int base_days, 
            string downtime_hours, int extended_days, double total_hours)
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
            param[3].Value = base_days;

            param[4] = new SqlParameter("@downtime_hours", SqlDbType.VarChar, 50);
            param[4].Value = downtime_hours;

            param[5] = new SqlParameter("@extended_days", SqlDbType.Int);
            param[5].Value = extended_days;

            param[6] = new SqlParameter("@total_hours", SqlDbType.Float);
            param[6].Value = total_hours;

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

        public void UPDATE_PERIOD(string id, DateTime start_date, DateTime end_date, int base_days, 
            string downtime_hours, int extended_days, double total_hours)
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
            param[3].Value = base_days;

            param[4] = new SqlParameter("@downtime_hours", SqlDbType.VarChar, 50);
            param[4].Value = downtime_hours;

            param[5] = new SqlParameter("@extended_days", SqlDbType.Int);
            param[5].Value = extended_days;

            param[6] = new SqlParameter("@total_hours", SqlDbType.Float);
            param[6].Value = total_hours;

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
            return AutoNumberHelper.GetNextNumber("period", "id");
        }
    }
}

