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
        public void ADD_SALES(string bill_no, string doc_type, string period_id, string cus_part_no, string cus_part_name, 
            string cus_part_type, DateTime start_time, DateTime end_time, double hours, double minutes, 
            double water_hour_price, double diesel_hour_price, double water_minutes_price, double diesel_minutes_price, 
            double dieselUsedInHour, double dieselUsedInMinute, double water_total, double diesel_total, 
            double total_amount, double due_amount, double paid_amount, double remaining_amount, 
            string bill_type, string lvlPrice, DateTime created_date, string note)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[26];
            
            // الترتيب يجب أن يطابق Stored Procedure بالضبط
            param[0] = new SqlParameter("@bill_no", SqlDbType.VarChar, 50);
            param[0].Value = bill_no;

            param[1] = new SqlParameter("@doc_type", SqlDbType.VarChar, 50);
            param[1].Value = string.IsNullOrWhiteSpace(doc_type) ? DBNull.Value : (object)doc_type;

            param[2] = new SqlParameter("@period_id", SqlDbType.VarChar, 50);
            param[2].Value = string.IsNullOrWhiteSpace(period_id) ? DBNull.Value : (object)period_id;

            param[3] = new SqlParameter("@cus_part_no", SqlDbType.VarChar, 50);
            param[3].Value = string.IsNullOrWhiteSpace(cus_part_no) ? DBNull.Value : (object)cus_part_no;

            param[4] = new SqlParameter("@cus_part_name", SqlDbType.VarChar, 200);
            param[4].Value = string.IsNullOrWhiteSpace(cus_part_name) ? DBNull.Value : (object)cus_part_name;

            param[5] = new SqlParameter("@cus_part_type", SqlDbType.VarChar, 50);
            param[5].Value = string.IsNullOrWhiteSpace(cus_part_type) ? DBNull.Value : (object)cus_part_type;

            param[6] = new SqlParameter("@start_time", SqlDbType.DateTime);
            param[6].Value = start_time;

            param[7] = new SqlParameter("@end_time", SqlDbType.DateTime);
            param[7].Value = end_time;

            param[8] = new SqlParameter("@hours", SqlDbType.Float);
            param[8].Value = hours;

            param[9] = new SqlParameter("@minutes", SqlDbType.Float);
            param[9].Value = minutes;

            param[10] = new SqlParameter("@water_hour_price", SqlDbType.Float);
            param[10].Value = water_hour_price;

            param[11] = new SqlParameter("@diesel_hour_price", SqlDbType.Float);
            param[11].Value = diesel_hour_price;

            param[12] = new SqlParameter("@water_total", SqlDbType.Float);
            param[12].Value = water_total;

            param[13] = new SqlParameter("@diesel_total", SqlDbType.Float);
            param[13].Value = diesel_total;

            param[14] = new SqlParameter("@total_amount", SqlDbType.Float);
            param[14].Value = total_amount;

            param[15] = new SqlParameter("@due_amount", SqlDbType.Float);
            param[15].Value = due_amount;

            param[16] = new SqlParameter("@paid_amount", SqlDbType.Float);
            param[16].Value = paid_amount;

            param[17] = new SqlParameter("@remaining_amount", SqlDbType.Float);
            param[17].Value = remaining_amount;

            param[18] = new SqlParameter("@bill_type", SqlDbType.VarChar, 50);
            param[18].Value = bill_type;

            param[19] = new SqlParameter("@water_Minutes_price", SqlDbType.Float);
            param[19].Value = water_minutes_price;

            param[20] = new SqlParameter("@diesel_Minutes_price", SqlDbType.Float);
            param[20].Value = diesel_minutes_price;

            param[21] = new SqlParameter("@DieselUsedInHour", SqlDbType.Float);
            param[21].Value = dieselUsedInHour;

            param[22] = new SqlParameter("@DieselUsedInMinute", SqlDbType.Float);
            param[22].Value = dieselUsedInMinute;

            param[23] = new SqlParameter("@lvlPrice", SqlDbType.VarChar, 50);
            param[23].Value = string.IsNullOrWhiteSpace(lvlPrice) ? DBNull.Value : (object)lvlPrice;

            param[24] = new SqlParameter("@created_date", SqlDbType.DateTime);
            param[24].Value = created_date;

            param[25] = new SqlParameter("@note", SqlDbType.VarChar, 50);
            param[25].Value = string.IsNullOrWhiteSpace(note) ? DBNull.Value : (object)note;

            DAL.ExecuteCommand("sales_insert", param);
            DAL.Close();
        }

        public DataTable VIEW_SALES(string bill_no)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@bill_no", SqlDbType.VarChar, 50);
            param[0].Value = bill_no;

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

        public void UPDATE_SALES(string bill_no, string doc_type, string period_id, string cus_part_no, string cus_part_name, 
            string cus_part_type, DateTime start_time, DateTime end_time, double hours, double minutes, 
            double water_hour_price, double diesel_hour_price, double water_minutes_price, double diesel_minutes_price, 
            double dieselUsedInHour, double dieselUsedInMinute, double water_total, double diesel_total, 
            double total_amount, double due_amount, double paid_amount, double remaining_amount, 
            string bill_type, string lvlPrice, DateTime created_date, string note)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[26];
            
            // الترتيب يجب أن يطابق Stored Procedure بالضبط
            param[0] = new SqlParameter("@bill_no", SqlDbType.VarChar, 50);
            param[0].Value = bill_no;

            param[1] = new SqlParameter("@doc_type", SqlDbType.VarChar, 50);
            param[1].Value = string.IsNullOrWhiteSpace(doc_type) ? DBNull.Value : (object)doc_type;

            param[2] = new SqlParameter("@period_id", SqlDbType.VarChar, 50);
            param[2].Value = string.IsNullOrWhiteSpace(period_id) ? DBNull.Value : (object)period_id;

            param[3] = new SqlParameter("@cus_part_no", SqlDbType.VarChar, 50);
            param[3].Value = string.IsNullOrWhiteSpace(cus_part_no) ? DBNull.Value : (object)cus_part_no;

            param[4] = new SqlParameter("@cus_part_name", SqlDbType.VarChar, 200);
            param[4].Value = string.IsNullOrWhiteSpace(cus_part_name) ? DBNull.Value : (object)cus_part_name;

            param[5] = new SqlParameter("@cus_part_type", SqlDbType.VarChar, 50);
            param[5].Value = string.IsNullOrWhiteSpace(cus_part_type) ? DBNull.Value : (object)cus_part_type;

            param[6] = new SqlParameter("@start_time", SqlDbType.DateTime);
            param[6].Value = start_time;

            param[7] = new SqlParameter("@end_time", SqlDbType.DateTime);
            param[7].Value = end_time;

            param[8] = new SqlParameter("@hours", SqlDbType.Float);
            param[8].Value = hours;

            param[9] = new SqlParameter("@minutes", SqlDbType.Float);
            param[9].Value = minutes;

            param[10] = new SqlParameter("@water_hour_price", SqlDbType.Float);
            param[10].Value = water_hour_price;

            param[11] = new SqlParameter("@diesel_hour_price", SqlDbType.Float);
            param[11].Value = diesel_hour_price;

            param[12] = new SqlParameter("@water_total", SqlDbType.Float);
            param[12].Value = water_total;

            param[13] = new SqlParameter("@diesel_total", SqlDbType.Float);
            param[13].Value = diesel_total;

            param[14] = new SqlParameter("@total_amount", SqlDbType.Float);
            param[14].Value = total_amount;

            param[15] = new SqlParameter("@due_amount", SqlDbType.Float);
            param[15].Value = due_amount;

            param[16] = new SqlParameter("@paid_amount", SqlDbType.Float);
            param[16].Value = paid_amount;

            param[17] = new SqlParameter("@remaining_amount", SqlDbType.Float);
            param[17].Value = remaining_amount;

            param[18] = new SqlParameter("@bill_type", SqlDbType.VarChar, 50);
            param[18].Value = bill_type;

            param[19] = new SqlParameter("@water_Minutes_price", SqlDbType.Float);
            param[19].Value = water_minutes_price;

            param[20] = new SqlParameter("@diesel_Minutes_price", SqlDbType.Float);
            param[20].Value = diesel_minutes_price;

            param[21] = new SqlParameter("@DieselUsedInHour", SqlDbType.Float);
            param[21].Value = dieselUsedInHour;

            param[22] = new SqlParameter("@DieselUsedInMinute", SqlDbType.Float);
            param[22].Value = dieselUsedInMinute;

            param[23] = new SqlParameter("@lvlPrice", SqlDbType.VarChar, 50);
            param[23].Value = string.IsNullOrWhiteSpace(lvlPrice) ? DBNull.Value : (object)lvlPrice;

            param[24] = new SqlParameter("@created_date", SqlDbType.DateTime);
            param[24].Value = created_date;

            param[25] = new SqlParameter("@note", SqlDbType.VarChar, 50);
            param[25].Value = string.IsNullOrWhiteSpace(note) ? DBNull.Value : (object)note;

            DAL.ExecuteCommand("sales_update", param);
            DAL.Close();
        }

        public void DELETE_SALES(string bill_no)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@bill_no", SqlDbType.VarChar, 50);
            param[0].Value = bill_no;

            DAL.ExecuteCommand("sales_delete", param);
            DAL.Close();
        }
    }
}
