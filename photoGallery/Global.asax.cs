using photoGallery.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace photoGallery
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();            
            //System.Data.Entity.Database.SetInitializer<GalleryContext>(new photoGallery.Models.SampleData());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<GalleryContext>()); //DB First方式佈署時請註解掉
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // https://stack247.wordpress.com/2013/02/22/antiforgerytoken-a-claim-of-type-nameidentifier-or-identityprovider-was-not-present-on-provided-claimsidentity/ 
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;

        }
    }
}
