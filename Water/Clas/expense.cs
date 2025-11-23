using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    class expense
    {
        public void ADD_EXPENSE(string id, DateTime date, string type, string Account_Type, string account_id,
            string Account_name, double amount, string period_id, string description, string notes)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@date", SqlDbType.Date);
            param[1].Value = date;

            param[2] = new SqlParameter("@type", SqlDbType.VarChar, 50);
            param[2].Value = type;

            param[3] = new SqlParameter("@Account_Type", SqlDbType.VarChar, 50);
            param[3].Value = Account_Type;

            param[4] = new SqlParameter("@account_id", SqlDbType.VarChar, 50);
            param[4].Value = account_id;

            param[5] = new SqlParameter("@Account_name", SqlDbType.VarChar, 255);
            param[5].Value = Account_name;

            param[6] = new SqlParameter("@amount", SqlDbType.Float);
            param[6].Value = amount;

            param[7] = new SqlParameter("@period_id", SqlDbType.VarChar, 50);
            param[7].Value = period_id;

            param[8] = new SqlParameter("@description", SqlDbType.VarChar, 255);
            param[8].Value = description;

            param[9] = new SqlParameter("@notes", SqlDbType.VarChar, 255);
            param[9].Value = notes;

            DAL.ExecuteCommand("expense_insert", param);
            DAL.Close();
        }

        public DataTable VIEW_EXPENSE(string id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            DataTable dt = DAL.SelectData("expense_view", param);
            DAL.Close();
            return dt;
        }

        public DataTable GET_ALL_EXPENSES()
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            DataTable dt = DAL.SelectData("expenses_getAll", null);
            DAL.Close();
            return dt;
        }

        public void UPDATE_EXPENSE(string id, DateTime date, string type, string Account_Type, string account_id,
            string Account_name, double amount, string period_id, string description, string notes)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@date", SqlDbType.Date);
            param[1].Value = date;

            param[2] = new SqlParameter("@type", SqlDbType.VarChar, 50);
            param[2].Value = type;

            param[3] = new SqlParameter("@Account_Type", SqlDbType.VarChar, 50);
            param[3].Value = Account_Type;

            param[4] = new SqlParameter("@account_id", SqlDbType.VarChar, 50);
            param[4].Value = account_id;

            param[5] = new SqlParameter("@Account_name", SqlDbType.VarChar, 255);
            param[5].Value = Account_name;

            param[6] = new SqlParameter("@amount", SqlDbType.Float);
            param[6].Value = amount;

            param[7] = new SqlParameter("@period_id", SqlDbType.VarChar, 50);
            param[7].Value = period_id;

            param[8] = new SqlParameter("@description", SqlDbType.VarChar, 255);
            param[8].Value = description;

            param[9] = new SqlParameter("@notes", SqlDbType.VarChar, 255);
            param[9].Value = notes;

            DAL.ExecuteCommand("expense_update", param);
            DAL.Close();
        }

        public void DELETE_EXPENSE(string id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;

            DAL.ExecuteCommand("expense_delete", param);
            DAL.Close();
        }

        public void ADD_POST(string action, string doc_type, string doc_no, string doc_no_type,
                             string period_id, string cus_part_type, string cus_part_no,
                             string cus_part_name, double dr_amt, double cr_amt,
                             DateTime date, string note, string user_id)
        {
            Clas.DataAccessLayer DAL = new Clas.DataAccessLayer();
            DAL.Open();

            SqlParameter[] param = new SqlParameter[13];

            param[0] = new SqlParameter("@action", SqlDbType.NVarChar, 20) { Value = action };
            param[1] = new SqlParameter("@doc_type", SqlDbType.VarChar, 50) { Value = doc_type };
            param[2] = new SqlParameter("@doc_no", SqlDbType.VarChar, 50) { Value = doc_no };
            param[3] = new SqlParameter("@doc_no_type", SqlDbType.VarChar, 50) { Value = doc_no_type };
            param[4] = new SqlParameter("@period_id", SqlDbType.VarChar, 50) { Value = period_id };
            param[5] = new SqlParameter("@cus_part_type", SqlDbType.VarChar, 50) { Value = cus_part_type };
            param[6] = new SqlParameter("@cus_part_no", SqlDbType.VarChar, 50) { Value = cus_part_no };
            param[7] = new SqlParameter("@cus_part_name", SqlDbType.VarChar, 200) { Value = cus_part_name };
            param[8] = new SqlParameter("@dr_amt", SqlDbType.Decimal) { Value = dr_amt };
            param[9] = new SqlParameter("@cr_amt", SqlDbType.Decimal) { Value = cr_amt };
            param[10] = new SqlParameter("@date", SqlDbType.Date) { Value = date };
            param[11] = new SqlParameter("@note", SqlDbType.VarChar, 500) { Value = (object)note ?? DBNull.Value };
            param[12] = new SqlParameter("@user_id", SqlDbType.VarChar, 20) { Value = user_id };

            DAL.ExecuteCommand("sp_post_crud", param);
            DAL.Close();
        }

    }
}

