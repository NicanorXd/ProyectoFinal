namespace Material.Api.Routes
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteMaterial
        {
            // Read
            public const string GetAll = Base + "/material/all";
            public const string GetById = Base + "/material/{id}";

            // Write
            public const string Create = Base + "/material/create";
            public const string Update = Base + "/material/update";
            public const string Delete = Base + "/material/delete";

        }

    }
}
