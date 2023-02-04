using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Venta.Aplicacion.Venta;
using static Venta.Api.Routes.ApiRoutes;
using dominio = Venta.Dominio.Entidades;

namespace Venta.Api.Controllers
{
    [ApiController]
    public class VentaController : ControllerBase
    {

        private readonly IVentaService _service;

        public VentaController(IVentaService service)
        {
            _service = service;
        }

        [HttpGet(RouteVenta.GetAll)]
        public IEnumerable<dominio.Venta> ListarVentas()
        {

            var listaVenta = _service.ListarVentas();
            return listaVenta;
        }

        [HttpGet(RouteVenta.GetById)]
        public dominio.Venta BuscarVenta(int id)
        {
            var objVenta = _service.Venta(id);

            return objVenta;
        }

        [HttpPost(RouteVenta.Create)]
        public ActionResult<dominio.Venta> CrearVenta([FromBody] dominio.Venta venta)
        {
            _service.RegistrarVenta(venta);

            return Ok();
        }

        //[HttpPut(RouteCategoria.Update)]
        //public ActionResult<dominio.Categoria> ModificarCategoria(dominio.Categoria producto)
        //{
        //    #region Conexión a base de datos
        //    var client = new MongoClient("mongodb://localhost:27017");
        //    var database = client.GetDatabase("TDB_productos");
        //    var collection = database.GetCollection<dominio.Categoria>("producto");
        //    #endregion

        //    collection.FindOneAndReplace(x => x._id == producto._id, producto);

        //    //var oldCategoria = collection.Find(x => x.IdCategoria == producto.IdCategoria).FirstOrDefault();
        //    //oldCategoria.Nombre = producto.Nombre;
        //    //oldCategoria.Precio = producto.Precio;
        //    //oldCategoria.Cantidad = producto.Cantidad;
        //    //collection.ReplaceOne(x=>x.IdCategoria == oldCategoria.IdCategoria, oldCategoria);


        //    //Categoria productoModificado = listaCategoria.Single(x => x.IdCategoria == producto.IdCategoria);
        //    //productoModificado.Nombre = producto.Nombre;
        //    //productoModificado.Cantidad = producto.Cantidad;
        //    //productoModificado.Precio= producto.Precio;
        //    //return CreatedAtAction("ModificarCategoria", productoModificado);
        //    return Ok();
        //}

        [HttpDelete(RouteVenta.Delete)]
        public ActionResult<dominio.Venta> EliminarVenta(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }
}
