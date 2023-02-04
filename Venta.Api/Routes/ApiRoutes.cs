namespace Reciclaje.Api.Routes
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteVenta
        {
            // Read
            public const string GetAll = Base + "/reciclaje/all";
            public const string GetById = Base + "/reciclaje/{id}";

            // Write
            public const string Create = Base + "/reciclaje/create";
            public const string Update = Base + "/reciclaje/update";
            public const string Delete = Base + "/reciclaje/delete";

        }

        public static class RouteDetalleVenta
        {
            // Read
            public const string GetAll = Base + "/detalleReciclaje/all";
            public const string GetById = Base + "/detalleReciclaje/{id}";

            // Write
            public const string Create = Base + "/detalleReciclaje/create";
            public const string Update = Base + "/detalleReciclaje/update";
            public const string Delete = Base + "/detalleReciclaje/delete";

        }

    }
}
