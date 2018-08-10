using System.Text.RegularExpressions;


namespace PublicUtils.CommonUtils
{
    /// <summary>
    /// 通用正则验证
    /// </summary>
    public class RegexUtils
    {
        /// <summary>
        /// 正则验证字符串是否为邮箱格式
        /// </summary>
        /// <param name="str">传递的参数</param>
        /// <returns>布尔类型</returns>
        public bool isMail(string str)
        {
            bool ismail = false;
            Regex r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            if (r.IsMatch(str))
            {
                ismail = true;
            }
            return ismail;
        }
    }
}
