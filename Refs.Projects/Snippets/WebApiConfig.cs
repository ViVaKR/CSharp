public static class WebApiConfig
{
    public class CustomJsonFormatter : JsonMediaTypeFormatter
    {
        public CustomJsonFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }
    public static void Register(HttpConfiguration config)
    {
        config.MapHttpAttributeRoutes();

        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "svc/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
        //// Cors 해결방법 (1)
        //var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
        //config.Formatters.Insert(0, jsonpFormatter);

        // Cores 해결방법 (2)
        EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
        config.EnableCors(cors);

        // Cores 해결방법 (3)
        app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

        // install Microsoft.owin.cors package
        // 궁극의  Json return
        config.Formatters.Add(new CustomJsonFormatter());

        // Only Json Return (2가지 방법)
        config.Formatters.Remove(config.Formatters.XmlFormatter);
        config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

        // Only Xml Return
        config.Formatters.Remove(config.Formatters.JsonFormatter);

        config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    }
}
