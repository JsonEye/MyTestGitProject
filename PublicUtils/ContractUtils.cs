using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicUtils.CommonUtils;

namespace PublicUtils
{
    public class ContractUtils
    {
        RegexUtils regexutils = new RegexUtils();
        public string findContractNo()
        {
            string contractNo = "";
            if (regexutils.isMail("asdga"))
            {
                contractNo = "001";
            }
            else
            {
                contractNo = "002";
            }
            return contractNo;
        }
    }
}
