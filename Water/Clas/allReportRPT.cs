using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Water.Clas
{
    class allReportRPT
    {
        public DataTable PRINT_ALL_MOVEMENT(string p_where)
        {

            Clas.DataAccessLayer DBL = new Clas.DataAccessLayer();
            DBL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@p_where", SqlDbType.VarChar, 500);
            param[0].Value = p_where;



            DataTable dt = new DataTable();
            dt = DBL.SelectData("proc_all_movements_RPT", param);



            DBL.Close();
            return dt;
        }


        public DataTable PRINT_CUSTOMER_MOVEMENT(string p_where)
        {

            Clas.DataAccessLayer DBL = new Clas.DataAccessLayer();
            DBL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@p_where", SqlDbType.VarChar, 500);
            param[0].Value = p_where;



            DataTable dt = new DataTable();
            dt = DBL.SelectData("proc_customer_movements_RPT", param);



            DBL.Close();
            return dt;
        }
    }
}
