using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    public class pricing
    {
        public void ADD_PRICING(string priceLevelId, string levelName, DateTime pricingDate, 
            double? dieselHourPrice, double? dieselMinutePrice, double? dieselUsedHour, double? dieselUsedMinute,
            double? waterHourPrice, double? waterMinutePrice, string notes)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[10];
            
            param[0] = new SqlParameter("@PriceLevleId", SqlDbType.VarChar, 50);
            param[0].Value = priceLevelId;

            param[1] = new SqlParameter("@LevelName", SqlDbType.VarChar, 255);
            param[1].Value = levelName;

            param[2] = new SqlParameter("@PricingDate", SqlDbType.Date);
            param[2].Value = pricingDate.Date; // استخدام Date فقط بدون الوقت

            param[3] = new SqlParameter("@DieselHourPrice", SqlDbType.Float);
            param[3].Value = dieselHourPrice.HasValue ? (object)dieselHourPrice.Value : DBNull.Value;

            param[4] = new SqlParameter("@DieselMinutePrice", SqlDbType.Float);
            param[4].Value = dieselMinutePrice.HasValue ? (object)dieselMinutePrice.Value : DBNull.Value;

            param[5] = new SqlParameter("@DieselUsedHour", SqlDbType.Float);
            param[5].Value = dieselUsedHour.HasValue ? (object)dieselUsedHour.Value : DBNull.Value;

            param[6] = new SqlParameter("@DieselUsedMinute", SqlDbType.Float);
            param[6].Value = dieselUsedMinute.HasValue ? (object)dieselUsedMinute.Value : DBNull.Value;

            param[7] = new SqlParameter("@WaterHourPrice", SqlDbType.Float);
            param[7].Value = waterHourPrice.HasValue ? (object)waterHourPrice.Value : DBNull.Value;

            param[8] = new SqlParameter("@WaterMinutePrice", SqlDbType.Float);
            param[8].Value = waterMinutePrice.HasValue ? (object)waterMinutePrice.Value : DBNull.Value;

            param[9] = new SqlParameter("@Notes", SqlDbType.VarChar, 500);
            param[9].Value = string.IsNullOrWhiteSpace(notes) ? DBNull.Value : (object)notes;

            DAL.ExecuteCommand("pricing_insert", param);
            DAL.Close();
        }

        public DataTable VIEW_PRICING(string priceLevelId)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@PriceLevleId", SqlDbType.VarChar, 50);
            param[0].Value = priceLevelId;

            DataTable dt = DAL.SelectData("pricing_get_by_id", param);
            DAL.Close();
            return dt;
        }

        public DataTable GET_ALL_PRICINGS()
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            DataTable dt = DAL.SelectData("pricing_get_all", null);
            DAL.Close();
            return dt;
        }

        public void UPDATE_PRICING(string priceLevelId, string levelName, DateTime pricingDate, 
            double? dieselHourPrice, double? dieselMinutePrice, double? dieselUsedHour, double? dieselUsedMinute,
            double? waterHourPrice, double? waterMinutePrice, string notes)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[10];
            
            param[0] = new SqlParameter("@PriceLevleId", SqlDbType.VarChar, 50);
            param[0].Value = priceLevelId;

            param[1] = new SqlParameter("@LevelName", SqlDbType.VarChar, 255);
            param[1].Value = levelName;

            param[2] = new SqlParameter("@PricingDate", SqlDbType.Date);
            param[2].Value = pricingDate.Date; // استخدام Date فقط بدون الوقت

            param[3] = new SqlParameter("@DieselHourPrice", SqlDbType.Float);
            param[3].Value = dieselHourPrice.HasValue ? (object)dieselHourPrice.Value : DBNull.Value;

            param[4] = new SqlParameter("@DieselMinutePrice", SqlDbType.Float);
            param[4].Value = dieselMinutePrice.HasValue ? (object)dieselMinutePrice.Value : DBNull.Value;

            param[5] = new SqlParameter("@DieselUsedHour", SqlDbType.Float);
            param[5].Value = dieselUsedHour.HasValue ? (object)dieselUsedHour.Value : DBNull.Value;

            param[6] = new SqlParameter("@DieselUsedMinute", SqlDbType.Float);
            param[6].Value = dieselUsedMinute.HasValue ? (object)dieselUsedMinute.Value : DBNull.Value;

            param[7] = new SqlParameter("@WaterHourPrice", SqlDbType.Float);
            param[7].Value = waterHourPrice.HasValue ? (object)waterHourPrice.Value : DBNull.Value;

            param[8] = new SqlParameter("@WaterMinutePrice", SqlDbType.Float);
            param[8].Value = waterMinutePrice.HasValue ? (object)waterMinutePrice.Value : DBNull.Value;

            param[9] = new SqlParameter("@Notes", SqlDbType.VarChar, 500);
            param[9].Value = string.IsNullOrWhiteSpace(notes) ? DBNull.Value : (object)notes;

            DAL.ExecuteCommand("pricing_update", param);
            DAL.Close();
        }

        public void DELETE_PRICING(string priceLevelId)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@PriceLevleId", SqlDbType.VarChar, 50);
            param[0].Value = priceLevelId;

            DAL.ExecuteCommand("pricing_delete", param);
            DAL.Close();
        }
    }
}

