using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Extensions;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using RoomakuRepository;

namespace Roomaku
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            builder.EntitySet<tblT_Roomaku>("tblT_RoomakuOData");

            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
