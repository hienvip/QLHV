using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class SQLConnector
    {
        private static string m_str_Server, m_str_Database;
        public static string ConnectionString = string.Empty;
        public static void SetConnectionInfo(string str_Server, string str_Database)
        {
            m_str_Server = str_Server;
            m_str_Database = str_Database;

            SetConnectionString();
        }

        public static bool is_login;
        public static string username;
        public static bool is_admin;
        public static bool checkRegistry;
        private static void SetConnectionString()
        {
            string ConnectionTemplate = @"Server={0};Database={1};Trusted_Connection=True;";
            ConnectionString = string.Format(ConnectionTemplate, m_str_Server, m_str_Database);
        }
        public static bool TestConnection()
        {

            using (SqlConnection connection = new SqlConnection(
         ConnectionString))
            {
                connection.Open();
                connection.Close();
                return true;
            }

        }

        public static DataTable ExecuteReturnDataTable(string spName, params object[] args)
        {
            using (SqlConnection conn = new SqlConnection(
         ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spName;
                    cmd.Connection = conn;
                    //params: 0 :name ; 1:val : 2:name ; 3:val
                    if (args.Length % 2 != 0)
                    {
                        throw new Exception("prs need % 2 ==0");
                    }
                    if (args.Length > 0)

                        for (int i = 0; i < args.Length; i += 2)
                        {
                            SqlParameter pr = new SqlParameter(args[i].ToString(), args[i + 1].ToString());
                            cmd.Parameters.Add(pr);
                        }

                    using (SqlDataAdapter adap = new SqlDataAdapter())
                    {
                        adap.SelectCommand = cmd;
                        using (DataTable dttmp = new DataTable())
                        {
                            adap.Fill(dttmp);
                            if (dttmp == null)
                            {
                                throw new Exception("ExecuteDataTable --> null table");
                            }
                            return dttmp;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="agrs">username,password,is_admin</param>
        //public static void InsertData(params object[] agrs)
        //{
        //    string cmdText = "insert into dbo.Account(username,Pass,is_admin) values(@param1,@param2,@param3)";
        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(cmdText, conn);
                
        //            cmd.Parameters.Add("@param1", agrs[0]);
        //            cmd.Parameters.Add("@param2", agrs[1]);
        //            cmd.Parameters.Add("@param3", agrs[2]);
        //            cmd.ExecuteNonQuery();
                
        //    }
        //}
    }
}
