using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Gateway.Api.Routes.ApiRoutes;
using Materiales = Gateway.Aplicacion.MaterialesClient;
//using Clientes = Gateway.Aplicacion.MaterialesClient;
using Gateway.Aplicacion.Materiales.Request;
using System.IO;
using System;

namespace Gateway.Api.Controllers
{
    [ApiController]
    public class MaterialController : ControllerBase
    {

        private readonly Materiales.IClient _materialesClient;
        //private readonly Clientes.IClient _clientesClient;

        public MaterialController(Materiales.IClient materialsClient)
        {
            _materialesClient = materialsClient;
        }

        //public materialController(materials.IClient materialsClient, Clientes.IClient clientesClient)
        //{
        //    _materialsClient = materialsClient;
        //    _clientesClient = clientesClient;
        //}

        [HttpGet(RouteMaterial.GetAll)]
        public ICollection<Materiales.Material> ListarMateriales()
        {
            var listamaterial = _materialesClient.ApiV1MaterialAllAsync().Result;
            return listamaterial;
        }

        [HttpPost(RoutePedido.RegistrarPedido)]
        public async void RegistrarPedido(RegistrarPedidoRequest request)
        {
            
            //var cliente = _clientesClient.ApiV1ClienteAsync(request.idCliente);
            //var material = await _materialesClient.ApiV1MaterialAsync(request.idMaterial);

            // Llamar a PedidosClient para crear el pedido
            // Llamar a PedidosClient para crear el detalle del pedido

            //var pedido = _materialsClient.ApiV1materialUpdateStockAsync(material);
            try
            {
                var material = await _materialesClient.ApiV1MaterialAsync(request.idMaterial);


            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter("error.log", true))
                {
                    writer.WriteLine(ex.ToString());
                }

            }
        }
    }
}
