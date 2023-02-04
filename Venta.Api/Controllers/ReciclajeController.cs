using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Venta.Aplicacion.Reciclaje;
using static Reciclaje.Api.Routes.ApiRoutes;
using dominio = Venta.Dominio.Entidades;

namespace Reciclaje.Api.Controllers
{
    [ApiController]
    public class ReciclajeController : ControllerBase
    {

        private readonly IReciclajeService _service;

        public ReciclajeController(IReciclajeService service)
        {
            _service = service;
        }

        [HttpGet(RouteVenta.GetAll)]
        public IEnumerable<dominio.Reciclaje> ListarVentas()
        {

            var listaVenta = _service.ListarReciclaje();
            return listaVenta;
        }

        [HttpGet(RouteVenta.GetById)]
        public dominio.Reciclaje BuscarVenta(int id)
        {
            var objVenta = _service.Reciclaje(id);

            return objVenta;
        }

        [HttpPost(RouteVenta.Create)]
        public ActionResult<dominio.Reciclaje> CrearVenta([FromBody] dominio.Reciclaje venta)
        {
            _service.RegistrarReciclaje(venta);

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
        public ActionResult<dominio.Reciclaje> EliminarVenta(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }
}
