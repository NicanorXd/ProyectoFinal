namespace Gateway.Aplicacion.MaterialesClient
{
    public partial class Client
    {

        public Client(System.Net.Http.IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MsMateriales");
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
        }

    }
}
