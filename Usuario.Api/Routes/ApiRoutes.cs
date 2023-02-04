namespace Usuario.Api.Routes
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteUsuario
        {
            // Read
            public const string GetAll = Base + "/usuarios/all";
            public const string GetById = Base + "/usuario/{id}";

            // Write
            public const string Create = Base + "/usuario/create";
            public const string Update = Base + "/usuario/update";
            public const string Delete = Base + "/usuario/delete";

        }

        //public static class RouteCategoria
        //{
        //    // Read
        //    public const string GetAll = Base + "/categoria/all";
        //    public const string GetById = Base + "/categoria/{id}";

        //    // Write
        //    public const string Create = Base + "/categoria/create";
        //    public const string Update = Base + "/categoria/update";
        //    public const string Delete = Base + "/categoria/delete";

        //}
    }
}
