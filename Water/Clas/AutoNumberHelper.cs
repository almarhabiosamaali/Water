using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Water.Clas
{
    /// <summary>
    /// كلاس مساعد موحد لتوليد الأرقام التلقائية من قاعدة البيانات
    /// </summary>
    public static class AutoNumberHelper
    {
        /// <summary>
        /// الحصول على الرقم التالي التلقائي من جدول معين
        /// </summary>
        /// <param name="tableName">اسم الجدول (مثال: "expenses", "sales")</param>
        /// <param name="columnName">اسم العمود (مثال: "id", "bill_no")</param>
        /// <param name="schemaName">اسم الـ Schema (افتراضي: "dbo")</param>
        /// <param name="databaseName">اسم قاعدة البيانات (افتراضي: "Water")</param>
        /// <returns>الرقم التالي كـ string</returns>
        public static string GetNextNumber(string tableName, string columnName, string schemaName = "dbo", string databaseName = "Water")
        {
            try
            {
                DataAccessLayer DAL = new DataAccessLayer();
                DAL.Open();
                
                // بناء استعلام SQL للحصول على آخر رقم
                string sqlQuery = string.Format(
                    "SELECT ISNULL(MAX(CAST([{0}] AS INT)), 0) + 1 AS NextNumber FROM [{1}].[{2}].[{3}] WHERE ISNUMERIC([{0}]) = 1",
                    columnName, databaseName, schemaName, tableName);
                
                object result = DAL.ExecuteScalar(sqlQuery);
                
                DAL.Close();
                
                if (result != null && result != DBNull.Value)
                {
                    return result.ToString();
                }
                return "1";
            }
            catch
            {
                return "1";
            }
        }

        /// <summary>
        /// الحصول على الرقم التالي التلقائي من جدول معين (بدون تحديد Schema و Database)
        /// </summary>
        /// <param name="tableName">اسم الجدول</param>
        /// <param name="columnName">اسم العمود</param>
        /// <returns>الرقم التالي كـ string</returns>
        public static string GetNextNumberSimple(string tableName, string columnName)
        {
            return GetNextNumber(tableName, columnName);
        }
    }
}

