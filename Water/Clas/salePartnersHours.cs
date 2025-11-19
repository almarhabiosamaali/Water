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
            string hoursCount, string minutesCount, string hoursAvalible, string minutesAvalible, string totalHours)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[9];
            
            param[0] = new SqlParameter("@BillNo", SqlDbType.VarChar, 50);
            param[0].Value = billNo;

            param[1] = new SqlParameter("@Id", SqlDbType.Int);
            param[1].Value = id;

            param[2] = new SqlParameter("@PartnerNumber", SqlDbType.VarChar, 50);
            param[2].Value = partnerNumber;

            param[3] = new SqlParameter("@PartnerName", SqlDbType.VarChar, 50);
            param[3].Value = partnerName;

            param[4] = new SqlParameter("@HoursCount", SqlDbType.VarChar, 50);
            param[4].Value = hoursCount;

            param[5] = new SqlParameter("@MinutesCount", SqlDbType.VarChar, 50);
            param[5].Value = minutesCount;

            param[6] = new SqlParameter("@HoursAvalible", SqlDbType.VarChar, 50);
            param[6].Value = hoursAvalible;

            param[7] = new SqlParameter("@MinutesAvalible", SqlDbType.VarChar, 50);
            param[7].Value = minutesAvalible;

            param[8] = new SqlParameter("@TotalHours", SqlDbType.VarChar, 50);
            param[8].Value = totalHours;

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
            string hoursCount, string minutesCount, string hoursAvalible, string minutesAvalible, string totalHours)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[9];
            
            param[0] = new SqlParameter("@BillNo", SqlDbType.VarChar, 50);
            param[0].Value = billNo;

            param[1] = new SqlParameter("@Id", SqlDbType.Int);
            param[1].Value = id;

            param[2] = new SqlParameter("@PartnerNumber", SqlDbType.VarChar, 50);
            param[2].Value = partnerNumber;

            param[3] = new SqlParameter("@PartnerName", SqlDbType.VarChar, 50);
            param[3].Value = partnerName;

            param[4] = new SqlParameter("@HoursCount", SqlDbType.VarChar, 50);
            param[4].Value = hoursCount;

            param[5] = new SqlParameter("@MinutesCount", SqlDbType.VarChar, 50);
            param[5].Value = minutesCount;

            param[6] = new SqlParameter("@HoursAvalible", SqlDbType.VarChar, 50);
            param[6].Value = hoursAvalible;

            param[7] = new SqlParameter("@MinutesAvalible", SqlDbType.VarChar, 50);
            param[7].Value = minutesAvalible;

            param[8] = new SqlParameter("@TotalHours", SqlDbType.VarChar, 50);
            param[8].Value = totalHours;

            DAL.ExecuteCommand("salePartnersHours_update", param);
            DAL.Close();
        }

        public void UPDATE_SALE_PARTNER_HOURS_BY_BILLNO(string billNo, int id, string partnerNumber, string partnerName, 
            string hoursCount, string minutesCount, string hoursAvalible, string minutesAvalible, string totalHours)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[9];
            
            param[0] = new SqlParameter("@BillNo", SqlDbType.VarChar, 50);
            param[0].Value = billNo;

            param[1] = new SqlParameter("@Id", SqlDbType.Int);
            param[1].Value = id;

            param[2] = new SqlParameter("@PartnerNumber", SqlDbType.VarChar, 50);
            param[2].Value = partnerNumber;

            param[3] = new SqlParameter("@PartnerName", SqlDbType.VarChar, 50);
            param[3].Value = partnerName;

            param[4] = new SqlParameter("@HoursCount", SqlDbType.VarChar, 50);
            param[4].Value = hoursCount;

            param[5] = new SqlParameter("@MinutesCount", SqlDbType.VarChar, 50);
            param[5].Value = minutesCount;

            param[6] = new SqlParameter("@HoursAvalible", SqlDbType.VarChar, 50);
            param[6].Value = hoursAvalible;

            param[7] = new SqlParameter("@MinutesAvalible", SqlDbType.VarChar, 50);
            param[7].Value = minutesAvalible;

            param[8] = new SqlParameter("@TotalHours", SqlDbType.VarChar, 50);
            param[8].Value = totalHours;

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
    }
}

