using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    public class salePartnersHours
    {
        public void ADD_SALE_PARTNER_HOURS(string billNo, int id, string partnerNumber, string partnerName, 
            int? hoursCount, int? minutesCount, int? hoursAvalible, int? minutesAvalible, int? totalHours , bool allocateHours)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[10];
            
            param[0] = new SqlParameter("@BillNo", SqlDbType.VarChar, 50);
            param[0].Value = billNo;

            param[1] = new SqlParameter("@Id", SqlDbType.Int);
            param[1].Value = id;

            param[2] = new SqlParameter("@PartnerNumber", SqlDbType.VarChar, 50);
            param[2].Value = partnerNumber;

            param[3] = new SqlParameter("@PartnerName", SqlDbType.VarChar, 50);
            param[3].Value = partnerName;

            param[4] = new SqlParameter("@HoursCount", SqlDbType.Int);
            param[4].Value = (object)hoursCount ?? DBNull.Value;

            param[5] = new SqlParameter("@MinutesCount", SqlDbType.Int);
            param[5].Value = (object)minutesCount ?? DBNull.Value;

            param[6] = new SqlParameter("@HoursAvalible", SqlDbType.Int);
            param[6].Value = (object)hoursAvalible ?? DBNull.Value;

            param[7] = new SqlParameter("@MinutesAvalible", SqlDbType.Int);
            param[7].Value = (object)minutesAvalible ?? DBNull.Value;

            param[8] = new SqlParameter("@TotalHours", SqlDbType.Int);
            param[8].Value = (object)totalHours ?? DBNull.Value;

            param[9] = new SqlParameter("@AllocateHours", SqlDbType.Bit); // ✅
            param[9].Value = allocateHours;

            DAL.ExecuteCommand("salePartnersHours_insert", param);
            DAL.Close();
        }

        public DataTable VIEW_SALE_PARTNER_HOURS(string billNo, int id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[2];
            
            param[0] = new SqlParameter("@BillNo", SqlDbType.VarChar, 50);
            param[0].Value = billNo;

            param[1] = new SqlParameter("@Id", SqlDbType.Int);
            param[1].Value = id;

            DataTable dt = DAL.SelectData("salePartnersHours_view", param);
            DAL.Close();
            return dt;
        }

        public DataTable GET_ALL_SALE_PARTNER_HOURS(string billNo)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@BillNo", SqlDbType.VarChar, 50);
            param[0].Value = billNo;

            DataTable dt = DAL.SelectData("salePartnersHours_View", param);
            DAL.Close();
            return dt;
        }

        public void UPDATE_SALE_PARTNER_HOURS(string billNo, int id, string partnerNumber, string partnerName, 
            int? hoursCount, int? minutesCount, int? hoursAvalible, int? minutesAvalible, int? totalHours , bool allocateHours)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[10];
            
            param[0] = new SqlParameter("@BillNo", SqlDbType.VarChar, 50);
            param[0].Value = billNo;

            param[1] = new SqlParameter("@Id", SqlDbType.Int);
            param[1].Value = id;

            param[2] = new SqlParameter("@PartnerNumber", SqlDbType.VarChar, 50);
            param[2].Value = partnerNumber;

            param[3] = new SqlParameter("@PartnerName", SqlDbType.VarChar, 50);
            param[3].Value = partnerName;

            param[4] = new SqlParameter("@HoursCount", SqlDbType.Int);
            param[4].Value = (object)hoursCount ?? DBNull.Value;

            param[5] = new SqlParameter("@MinutesCount", SqlDbType.Int);
            param[5].Value = (object)minutesCount ?? DBNull.Value;

            param[6] = new SqlParameter("@HoursAvalible", SqlDbType.Int);
            param[6].Value = (object)hoursAvalible ?? DBNull.Value;

            param[7] = new SqlParameter("@MinutesAvalible", SqlDbType.Int);
            param[7].Value = (object)minutesAvalible ?? DBNull.Value;

            param[8] = new SqlParameter("@TotalHours", SqlDbType.Int);
            param[8].Value = (object)totalHours ?? DBNull.Value;

            param[9] = new SqlParameter("@AllocateHours", SqlDbType.Bit); // ✅
            param[9].Value = allocateHours;

            DAL.ExecuteCommand("salePartnersHours_update", param);
            DAL.Close();
        }

        public void UPDATE_SALE_PARTNER_HOURS_BY_BILLNO(string billNo, int id, string partnerNumber, string partnerName, 
            int? hoursCount, int? minutesCount, int? hoursAvalible, int? minutesAvalible, int? totalHours , bool allocateHours)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[10];
            
            param[0] = new SqlParameter("@BillNo", SqlDbType.VarChar, 50);
            param[0].Value = billNo;

            param[1] = new SqlParameter("@Id", SqlDbType.Int);
            param[1].Value = id;

            param[2] = new SqlParameter("@PartnerNumber", SqlDbType.VarChar, 50);
            param[2].Value = partnerNumber;

            param[3] = new SqlParameter("@PartnerName", SqlDbType.VarChar, 50);
            param[3].Value = partnerName;

            param[4] = new SqlParameter("@HoursCount", SqlDbType.Int);
            param[4].Value = (object)hoursCount ?? DBNull.Value;

            param[5] = new SqlParameter("@MinutesCount", SqlDbType.Int);
            param[5].Value = (object)minutesCount ?? DBNull.Value;

            param[6] = new SqlParameter("@HoursAvalible", SqlDbType.Int);
            param[6].Value = (object)hoursAvalible ?? DBNull.Value;

            param[7] = new SqlParameter("@MinutesAvalible", SqlDbType.Int);
            param[7].Value = (object)minutesAvalible ?? DBNull.Value;

            param[8] = new SqlParameter("@TotalHours", SqlDbType.Int);
            param[8].Value = (object)totalHours ?? DBNull.Value;

            param[9] = new SqlParameter("@AllocateHours", SqlDbType.Bit); // ✅
            param[9].Value = allocateHours;

            DAL.ExecuteCommand("salePartnersHours_Update", param);
            DAL.Close();
        }

        public void DELETE_SALE_PARTNER_HOURS(string billNo)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@BillNo", SqlDbType.VarChar, 50);
            param[0].Value = billNo;

            DAL.ExecuteCommand("salePartnersHours_delete", param);
            DAL.Close();
        }

        public void ADD_POST(string action, string doc_type, string doc_no, string doc_no_type, string period_id,
           string cus_part_type, string cus_part_no, string cus_part_name, double dr_amt, double cr_amt,
           DateTime date, DateTime start_time, DateTime end_time, double hours,
           double minutes, double water_hour_price, double diesel_hour_price, double water_Minutes_price,
           double diesel_Minutes_price, double water_total, double diesel_total, double total_amount, string note, string user_id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();

            SqlParameter[] param = new SqlParameter[23];

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

            param[15] = new SqlParameter("@water_hour_price", SqlDbType.Decimal);
            param[15].Value = water_hour_price;

            param[16] = new SqlParameter("@diesel_hour_price", SqlDbType.Decimal);
            param[16].Value = diesel_hour_price;

            param[17] = new SqlParameter("@water_Minutes_price", SqlDbType.Decimal);
            param[17].Value = water_Minutes_price;

            param[18] = new SqlParameter("@diesel_Minutes_price", SqlDbType.Decimal);
            param[18].Value = diesel_Minutes_price;

            param[19] = new SqlParameter("@water_total", SqlDbType.Decimal);
            param[19].Value = water_total;

            param[20] = new SqlParameter("@diesel_total", SqlDbType.Decimal);
            param[20].Value = diesel_total;

            param[21] = new SqlParameter("@total_amount", SqlDbType.Decimal);
            param[21].Value = total_amount;

            param[22] = new SqlParameter("@note", SqlDbType.VarChar, 500);
            param[22].Value = (object)note ?? DBNull.Value;

            DAL.ExecuteCommand("sp_post_crud", param);
            DAL.Close();
        }
    }
}

