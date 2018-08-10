using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Utils.Type;
using HMS.Utils.Http;
using HMS.Utils.asp;
using Newtonsoft.Json;

namespace NHMS.Web.App_Start.webStack
{
    public class MvcPortFilter : ActionFilterAttribute
    {
        JurisdictionUtils u_JurisdictionUtils = new JurisdictionUtils();
        TypeJudgment u_TypeJudgmentUtils = new TypeJudgment();
        OaUtils u_OaUtils = new OaUtils();

        public string LoginValidate(string token)
        {
            string result = "";
            try
            {
                var json = u_JurisdictionUtils.UserValidationApi(token);
                UserValidateResult userValidateResult = JsonConvert.DeserializeObject<UserValidateResult>(json);
                UserValidate userValidate = userValidateResult.uservaliDate;

                SessionUtils.Add("userCode", userValidate.UserCode);
                SessionUtils.Add("departmentId", userValidate.DepartmentId);
                SessionUtils.Add("token", token);
                SessionUtils.Add("token_r", userValidate.Token_R);

                string responsibleDepartment = u_JurisdictionUtils.ResponsibleDepartmentApi(userValidate.Token_R, userValidate.UserCode);  ///负责部门
                if (u_TypeJudgmentUtils.IsNullOrEmptyObj(responsibleDepartment) == false)
                {
                    SessionUtils.Add("responsibleDepartment", responsibleDepartment);
                }
            }
            catch (Exception ex)
            {
                result = "{\"code\":\"0\",\"msg\":\"后台出错" + ex + "\"}";
            }
            return result;
        }
        private bool _isEnable = true;

        public MvcPortFilter()
        {
            _isEnable = true;
        }

        public MvcPortFilter(bool IsEnable)
        {
            _isEnable = IsEnable;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_isEnable)
            {
                var request = HttpContext.Current.Request;
                string token = request.Form["token"];
                if (u_TypeJudgmentUtils.IsNullOrEmptyObj(token) == true)
                {
                    filterContext.Result = new ContentResult() { Content = "{\"code\":2,\"msg\":\"token失效\"}" };
                }
                else
                {
                    if (GetSession("token") == null)
                    {
                        string msg = LoginValidate(token);
                        if (msg != "")
                        {
                            filterContext.Result = new ContentResult() { Content = msg };
                        }
                    }
                    else
                    {
                        if (GetSession("token") != token)
                        {
                            string msg = LoginValidate(token);
                            if (msg != "")
                            {
                                filterContext.Result = new ContentResult() { Content = msg };
                            }
                        }
                        else
                        {
                            if (GetSession("userCode") == null || GetSession("departmentId") == null || GetSession("token_r") == null)
                            {
                                string msg = LoginValidate(token);
                                if (msg != "")
                                {
                                    filterContext.Result = new ContentResult() { Content = msg };
                                }
                            }
                        }
                    }
                }
            }
        }
        public static string GetSession(string SessionName)
        {
            if (HttpContext.Current.Session[SessionName] == null)
            {
                return null;
            }
            else
            {
                return HttpContext.Current.Session[SessionName].ToString();
            }
        }
    }
    public class UserValidateResult
    {
        public string code { get; set; }
        public string msg { get; set; }
        public UserValidate uservaliDate { get; set; }
    }
}