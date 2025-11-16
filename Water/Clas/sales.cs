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
        public void ADD_SALES(string id, string bill_type, string period_id, string customer_id, DateTime start_time, 
            DateTime end_time, double hours, double minutes, double water_hour_price, double diesel_hour_price,
            double water_total, double diesel_total, double total_amount, double due_amount, 
            double paid_amount, double remaining_amount)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[16];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@bill_type", SqlDbType.VarChar, 50);
            param[1].Value = bill_type;

            param[2] = new SqlParameter("@period_id", SqlDbType.VarChar, 50);
            param[2].Value = period_id;

            param[3] = new SqlParameter("@customer_id", SqlDbType.VarChar, 50);
            param[3].Value = customer_id;

            param[4] = new SqlParameter("@start_time", SqlDbType.DateTime);
            param[4].Value = start_time;

            param[5] = new SqlParameter("@end_time", SqlDbType.DateTime);
            param[5].Value = end_time;

            param[6] = new SqlParameter("@hours", SqlDbType.Float);
            param[6].Value = hours;

            param[7] = new SqlParameter("@minutes", SqlDbType.Float);
            param[7].Value = minutes;

            param[8] = new SqlParameter("@water_hour_price", SqlDbType.Float);
            param[8].Value = water_hour_price;

            param[9] = new SqlParameter("@diesel_hour_price", SqlDbType.Float);
            param[9].Value = diesel_hour_price;

            param[10] = new SqlParameter("@water_total", SqlDbType.Float);
            param[10].Value = water_total;

            param[11] = new SqlParameter("@diesel_total", SqlDbType.Float);
            param[11].Value = diesel_total;

            param[12] = new SqlParameter("@total_amount", SqlDbType.Float);
            param[12].Value = total_amount;

            param[13] = new SqlParameter("@due_amount", SqlDbType.Float);
            param[13].Value = due_amount;

            param[14] = new SqlParameter("@paid_amount", SqlDbType.Float);
            param[14].Value = paid_amount;

            param[15] = new SqlParameter("@remaining_amount", SqlDbType.Float);
            param[15].Value = remaining_amount;

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

        public void UPDATE_SALES(string id, string bill_type, string period_id, string customer_id, DateTime start_time, 
            DateTime end_time, double hours, double minutes, double water_hour_price, double diesel_hour_price,
            double water_total, double diesel_total, double total_amount, double due_amount, 
            double paid_amount, double remaining_amount)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[16];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@bill_type", SqlDbType.VarChar, 50);
            param[1].Value = bill_type;

            param[2] = new SqlParameter("@period_id", SqlDbType.VarChar, 50);
            param[2].Value = period_id;

            param[3] = new SqlParameter("@customer_id", SqlDbType.VarChar, 50);
            param[3].Value = customer_id;

            param[4] = new SqlParameter("@start_time", SqlDbType.DateTime);
            param[4].Value = start_time;

            param[5] = new SqlParameter("@end_time", SqlDbType.DateTime);
            param[5].Value = end_time;

            param[6] = new SqlParameter("@hours", SqlDbType.Float);
            param[6].Value = hours;

            param[7] = new SqlParameter("@minutes", SqlDbType.Float);
            param[7].Value = minutes;

            param[8] = new SqlParameter("@water_hour_price", SqlDbType.Float);
            param[8].Value = water_hour_price;

            param[9] = new SqlParameter("@diesel_hour_price", SqlDbType.Float);
            param[9].Value = diesel_hour_price;

            param[10] = new SqlParameter("@water_total", SqlDbType.Float);
            param[10].Value = water_total;

            param[11] = new SqlParameter("@diesel_total", SqlDbType.Float);
            param[11].Value = diesel_total;

            param[12] = new SqlParameter("@total_amount", SqlDbType.Float);
            param[12].Value = total_amount;

            param[13] = new SqlParameter("@due_amount", SqlDbType.Float);
            param[13].Value = due_amount;

            param[14] = new SqlParameter("@paid_amount", SqlDbType.Float);
            param[14].Value = paid_amount;

            param[15] = new SqlParameter("@remaining_amount", SqlDbType.Float);
            param[15].Value = remaining_amount;

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

