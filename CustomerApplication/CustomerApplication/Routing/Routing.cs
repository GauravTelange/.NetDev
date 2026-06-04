namespace CustomerApplication.Routing
{
    public static class Routing
    {
        public static void loadRoutes(WebApplication app)
        {

            app.MapControllerRoute(
             name: "route1",
            pattern: "Customer/Add",
            defaults: new { controller = "Customer", action = "Add" });

            app.MapControllerRoute(
                    name: "route2",
                    pattern: "Customer/New/{id}",
                    defaults: new { controller = "Customer", action = "Add" });
        }
    }
}
