using System;
using System.Configuration;

namespace Maticsoft.DBUtility
{
    /// <summary>
    /// 公共工具类
    /// </summary>
    public class PubConstant
    {        
        /// <summary>
        /// 获取固定连接字符串
        /// </summary>
        public static string ConnectionString
        {           
            get 
            {
                string _connectionString = ConfigurationManager.ConnectionStrings["MySQLconnStr"].ConnectionString; 
                return _connectionString; 
            }
        }

        /// <summary>
        /// 动态得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
         
            return connectionString;
        }


    }
}
