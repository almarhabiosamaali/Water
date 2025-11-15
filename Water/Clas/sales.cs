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
            double water_total, double diesel_total, double total_amount, double due_amount, 
            double paid_amount, double remaining_amount)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[15];
            
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

            param[9] = new SqlParameter("@water_total", SqlDbType.Float);
            param[9].Value = water_total;

            param[10] = new SqlParameter("@diesel_total", SqlDbType.Float);
            param[10].Value = diesel_total;

            param[11] = new SqlParameter("@total_amount", SqlDbType.Float);
            param[11].Value = total_amount;

            param[12] = new SqlParameter("@due_amount", SqlDbType.Float);
            param[12].Value = due_amount;

            param[13] = new SqlParameter("@paid_amount", SqlDbType.Float);
            param[13].Value = paid_amount;

            param[14] = new SqlParameter("@remaining_amount", SqlDbType.Float);
            param[14].Value = remaining_amount;

            DAL.ExecuteCommand("sales_insert", param);
            DAL.Close();
        }
    }
}

