using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ReciclajeDetalle.Aplicacion.Venta;
using static Reciclaje.Api.Routes.ApiRoutes;
using dominio = Venta.Dominio.Entidades;

namespace ReciclajeDetalle.Api.Controllers
{
    [ApiController]
    public class ReciclajeDetalleController : ControllerBase
    {

        private readonly IReciclajeDetalleService _service;

        public ReciclajeDetalleController(IReciclajeDetalleService service)
        {
            _service = service;
        }

        [HttpGet(RouteDetalleVenta.GetAll)]
        public IEnumerable<dominio.ReciclajeDetalle> ListarReciclajeVenta()
        {

            var listaVenta = _service.ListarReciclajeDetalle();
            return listaVenta;
        }

        [HttpGet(RouteDetalleVenta.GetById)]
        public dominio.ReciclajeDetalle BuscarVenta(int id)
        {
            var objVenta = _service.ReciclajeDetalle(id);

            return objVenta;
        }

        [HttpPost(RouteDetalleVenta.Create)]
        public ActionResult<dominio.ReciclajeDetalle> CrearVenta([FromBody] dominio.ReciclajeDetalle venta)
        {
            _service.RegistrarReciclajeDetalle(venta);

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

        [HttpDelete(RouteDetalleVenta.Delete)]
        public ActionResult<dominio.Reciclaje> EliminarVenta(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }
}
