using System.Web.Mvc;
using System.Web.UI;

namespace MPositive.Areas.SyncApi
{
    public class SyncApiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SyncApi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SyncApi_default",
                "SyncApi/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}