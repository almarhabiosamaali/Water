using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    class sales
    {
        public void ADD_SALES(string id, string period_id, string customer_id, DateTime start_time, 
            DateTime end_time, double hours, double minutes, double water_hour_price, double diesel_hour_price,
            double water_minutes_price, double diesel_minutes_price, double dieselUsedInHour, double dieselUsedInMinute,
            double water_total, double diesel_total, double total_amount, double due_amount, 
            double paid_amount, double remaining_amount, string bill_type, string lvlPrice, DateTime created_date)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[22];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@period_id", SqlDbType.VarChar, 50);
            param[1].Value = period_id;

            param[2] = new SqlParameter("@customer_id", SqlDbType.VarChar, 50);
            param[2].Value = customer_id;

            param[3] = new SqlParameter("@start_time", SqlDbType.DateTime);
            param[3].Value = start_time;

            param[4] = new SqlParameter("@end_time", SqlDbType.DateTime);
            param[4].Value = end_time;

            param[5] = new SqlParameter("@hours", SqlDbType.Float);
            param[5].Value = hours;

            param[6] = new SqlParameter("@minutes", SqlDbType.Float);
            param[6].Value = minutes;

            param[7] = new SqlParameter("@water_hour_price", SqlDbType.Float);
            param[7].Value = water_hour_price;

            param[8] = new SqlParameter("@diesel_hour_price", SqlDbType.Float);
            param[8].Value = diesel_hour_price;

            param[9] = new SqlParameter("@water_minutes_price", SqlDbType.Float);
            param[9].Value = water_minutes_price;

            param[10] = new SqlParameter("@diesel_minutes_price", SqlDbType.Float);
            param[10].Value = diesel_minutes_price;

            param[11] = new SqlParameter("@DieselUsedInHour", SqlDbType.Float);
            param[11].Value = dieselUsedInHour;

            param[12] = new SqlParameter("@DieselUsedInMinute", SqlDbType.Float);
            param[12].Value = dieselUsedInMinute;

            param[13] = new SqlParameter("@water_total", SqlDbType.Float);
            param[13].Value = water_total;

            param[14] = new SqlParameter("@diesel_total", SqlDbType.Float);
            param[14].Value = diesel_total;

            param[15] = new SqlParameter("@total_amount", SqlDbType.Float);
            param[15].Value = total_amount;

            param[16] = new SqlParameter("@due_amount", SqlDbType.Float);
            param[16].Value = due_amount;

            param[17] = new SqlParameter("@paid_amount", SqlDbType.Float);
            param[17].Value = paid_amount;

            param[18] = new SqlParameter("@remaining_amount", SqlDbType.Float);
            param[18].Value = remaining_amount;

            param[19] = new SqlParameter("@bill_type", SqlDbType.VarChar, 50);
            param[19].Value = bill_type;

            param[20] = new SqlParameter("@lvlPrice", SqlDbType.VarChar, 50);
            param[20].Value = lvlPrice;

            param[21] = new SqlParameter("@created_date", SqlDbType.DateTime);
            param[21].Value = created_date;

            DAL.ExecuteCommand("sales_insert", param);
            DAL.Close();
        }

        public DataTable VIEW_SALES(string id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            DataTable dt = DAL.SelectData("sales_view", param);
            DAL.Close();
            return dt;
        }

        public DataTable GET_ALL_SALES()
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            DataTable dt = DAL.SelectData("sales_getAll", null);
            DAL.Close();
            return dt;
        }

        public void UPDATE_SALES(string id, string period_id, string customer_id, DateTime start_time, 
            DateTime end_time, double hours, double minutes, double water_hour_price, double diesel_hour_price,
            double water_minutes_price, double diesel_minutes_price, double dieselUsedInHour, double dieselUsedInMinute,
            double water_total, double diesel_total, double total_amount, double due_amount, 
            double paid_amount, double remaining_amount, string bill_type, string lvlPrice, DateTime created_date)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[22];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@period_id", SqlDbType.VarChar, 50);
            param[1].Value = period_id;

            param[2] = new SqlParameter("@customer_id", SqlDbType.VarChar, 50);
            param[2].Value = customer_id;

            param[3] = new SqlParameter("@start_time", SqlDbType.DateTime);
            param[3].Value = start_time;

            param[4] = new SqlParameter("@end_time", SqlDbType.DateTime);
            param[4].Value = end_time;

            param[5] = new SqlParameter("@hours", SqlDbType.Float);
            param[5].Value = hours;

            param[6] = new SqlParameter("@minutes", SqlDbType.Float);
            param[6].Value = minutes;

            param[7] = new SqlParameter("@water_hour_price", SqlDbType.Float);
            param[7].Value = water_hour_price;

            param[8] = new SqlParameter("@diesel_hour_price", SqlDbType.Float);
            param[8].Value = diesel_hour_price;

            param[9] = new SqlParameter("@water_minutes_price", SqlDbType.Float);
            param[9].Value = water_minutes_price;

            param[10] = new SqlParameter("@diesel_minutes_price", SqlDbType.Float);
            param[10].Value = diesel_minutes_price;

            param[11] = new SqlParameter("@DieselUsedInHour", SqlDbType.Float);
            param[11].Value = dieselUsedInHour;

            param[12] = new SqlParameter("@DieselUsedInMinute", SqlDbType.Float);
            param[12].Value = dieselUsedInMinute;

            param[13] = new SqlParameter("@water_total", SqlDbType.Float);
            param[13].Value = water_total;

            param[14] = new SqlParameter("@diesel_total", SqlDbType.Float);
            param[14].Value = diesel_total;

            param[15] = new SqlParameter("@total_amount", SqlDbType.Float);
            param[15].Value = total_amount;

            param[16] = new SqlParameter("@due_amount", SqlDbType.Float);
            param[16].Value = due_amount;

            param[17] = new SqlParameter("@paid_amount", SqlDbType.Float);
            param[17].Value = paid_amount;

            param[18] = new SqlParameter("@remaining_amount", SqlDbType.Float);
            param[18].Value = remaining_amount;

            param[19] = new SqlParameter("@bill_type", SqlDbType.VarChar, 50);
            param[19].Value = bill_type;

            param[20] = new SqlParameter("@lvlPrice", SqlDbType.VarChar, 50);
            param[20].Value = lvlPrice;

            param[21] = new SqlParameter("@created_date", SqlDbType.DateTime);
            param[21].Value = created_date;

            DAL.ExecuteCommand("sales_update", param);
            DAL.Close();
        }

        public void DELETE_SALES(string id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            DAL.ExecuteCommand("sales_delete", param);
            DAL.Close();
        }
    }
}

