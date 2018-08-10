using System.Web.Mvc;

namespace GenerateDll.Areas.uploadFile
{
    public class uploadFileAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "uploadFile";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "uploadFile_default",
                "uploadFile/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}