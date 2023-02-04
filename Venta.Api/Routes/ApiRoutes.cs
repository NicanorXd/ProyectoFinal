namespace Venta.Api.Routes
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteVenta
        {
            // Read
            public const string GetAll = Base + "/venta/all";
            public const string GetById = Base + "/venta/{id}";

            // Write
            public const string Create = Base + "/venta/create";
            public const string Update = Base + "/venta/update";
            public const string Delete = Base + "/venta/delete";

        }

    }
}
