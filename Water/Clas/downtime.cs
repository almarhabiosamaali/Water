using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    class downtime
    {
        public void ADD_DOWNTIME(string id, string period_id, DateTime date, string dayesCount, string hours, string minutes, DateTime? startTime, DateTime? endTime, double? amount, string note, string description, int? isProcessed)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[12];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@period_id", SqlDbType.VarChar, 50);
            param[1].Value = (object)period_id ?? DBNull.Value;

            param[2] = new SqlParameter("@date", SqlDbType.Date);
            param[2].Value = date;

            param[3] = new SqlParameter("@dayesCount", SqlDbType.Int);
            param[3].Value = (object)dayesCount ?? DBNull.Value;

            param[4] = new SqlParameter("@hours", SqlDbType.Int);
            param[4].Value = (object)hours ?? DBNull.Value;

            param[5] = new SqlParameter("@minutes", SqlDbType.Int);
            param[5].Value = (object)minutes ?? DBNull.Value;

            param[6] = new SqlParameter("@startTime", SqlDbType.DateTime);
            param[6].Value = (object)startTime ?? DBNull.Value;

            param[7] = new SqlParameter("@endTime", SqlDbType.DateTime);
            param[7].Value = (object)endTime ?? DBNull.Value;

            param[8] = new SqlParameter("@amount", SqlDbType.Float);
            param[8].Value = (object)amount ?? DBNull.Value;

            param[9] = new SqlParameter("@note", SqlDbType.VarChar, 255);
            param[9].Value = (object)note ?? DBNull.Value;

            param[10] = new SqlParameter("@description", SqlDbType.VarChar, 255);
            param[10].Value = (object)description ?? DBNull.Value;

            param[11] = new SqlParameter("@isProcessed", SqlDbType.Int);
            param[11].Value = (object)isProcessed ?? DBNull.Value;

            DAL.ExecuteCommand("downtime_insert", param);
            DAL.Close();
        }

        public DataTable VIEW_DOWNTIME(string id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            DataTable dt = DAL.SelectData("downtime_view", param);
            DAL.Close();
            return dt;
        }

        public DataTable GET_ALL_DOWNTIMES()
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            DataTable dt = DAL.SelectData("downtime_getAll", null);
            DAL.Close();
            return dt;
        }

        public void UPDATE_DOWNTIME(string id, string period_id, DateTime date,string dayesCount, string hours, string minutes, DateTime? startTime, DateTime? endTime, double? amount, string note, string description, int? isProcessed)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[12];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@period_id", SqlDbType.VarChar, 50);
            param[1].Value = (object)period_id ?? DBNull.Value;

            param[2] = new SqlParameter("@date", SqlDbType.Date);
            param[2].Value = date;

            param[3] = new SqlParameter("@dayesCount", SqlDbType.Int);
            param[3].Value = (object)dayesCount ?? DBNull.Value;

            param[4] = new SqlParameter("@hours", SqlDbType.Int);
            param[4].Value = (object)hours ?? DBNull.Value;

            param[5] = new SqlParameter("@minutes", SqlDbType.Int);
            param[5].Value = (object)minutes ?? DBNull.Value;

            param[6] = new SqlParameter("@startTime", SqlDbType.DateTime);
            param[6].Value = (object)startTime ?? DBNull.Value;

            param[7] = new SqlParameter("@endTime", SqlDbType.DateTime);
            param[7].Value = (object)endTime ?? DBNull.Value;

            param[8] = new SqlParameter("@amount", SqlDbType.Float);
            param[8].Value = (object)amount ?? DBNull.Value;

            param[9] = new SqlParameter("@note", SqlDbType.VarChar, 255);
            param[9].Value = (object)note ?? DBNull.Value;

            param[10] = new SqlParameter("@description", SqlDbType.VarChar, 255);
            param[10].Value = (object)description ?? DBNull.Value;

            param[11] = new SqlParameter("@isProcessed", SqlDbType.Int);
            param[11].Value = (object)isProcessed ?? DBNull.Value;

            DAL.ExecuteCommand("downtime_update", param);
            DAL.Close();
        }

        public void DELETE_DOWNTIME(string id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            DAL.ExecuteCommand("downtime_delete", param);
            DAL.Close();
        }

        public string GET_NEXT_DOWNTIME_CODE()
        {
            return AutoNumberHelper.GetNextNumber("downtime", "id");
        }
    }
}

