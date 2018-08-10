using System;
using System.Configuration;

namespace Maticsoft.DBUtility
{
    /// <summary>
    /// ����������
    /// </summary>
    public class PubConstant
    {        
        /// <summary>
        /// ��ȡ�̶������ַ���
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
        /// ��̬�õ�web.config������������ݿ������ַ�����
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
