using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Material.Aplicacion.Material;
using static Material.Api.Routes.ApiRoutes;
using dominio = Material.Dominio.Entidades;

namespace Material.Api.Controllers
{
    [ApiController]
    public class MaterialController : ControllerBase
    {

        private readonly IMaterialService _service;

        public MaterialController(IMaterialService service)
        {
            _service = service;
        }

        [HttpGet(RouteMaterial.GetAll)]
        public IEnumerable<dominio.Material> ListarMateriales()
        {           

            var listaMaterial =_service.ListarMateriales();
            return listaMaterial;
        }

        [HttpGet(RouteMaterial.GetById)]
        public dominio.Material BuscarMaterial(int id)
        {           
            var objMaterial = _service.Material(id);

            return objMaterial;
        }

        [HttpPost(RouteMaterial.Create)]
        public ActionResult<dominio.Material> CrearMaterial([FromBody] dominio.Material material)
        {
            _service.RegistraMaterial(material);

            return Ok();
        }

        //[HttpPut(RouteProducto.Update)]
        //public ActionResult<dominio.Producto> ModificarProducto(dominio.Producto producto)
        //{
        //    #region Conexión a base de datos
        //    var client = new MongoClient("mongodb://localhost:27017");
        //    var database = client.GetDatabase("TDB_productos");
        //    var collection = database.GetCollection<dominio.Producto>("producto");
        //    #endregion

        //    collection.FindOneAndReplace(x => x._id == producto._id, producto);

        //    //var oldProducto = collection.Find(x => x.IdProducto == producto.IdProducto).FirstOrDefault();
        //    //oldProducto.Nombre = producto.Nombre;
        //    //oldProducto.Precio = producto.Precio;
        //    //oldProducto.Cantidad = producto.Cantidad;
        //    //collection.ReplaceOne(x=>x.IdProducto == oldProducto.IdProducto, oldProducto);


        //    //Producto productoModificado = listaProducto.Single(x => x.IdProducto == producto.IdProducto);
        //    //productoModificado.Nombre = producto.Nombre;
        //    //productoModificado.Cantidad = producto.Cantidad;
        //    //productoModificado.Precio= producto.Precio;
        //    //return CreatedAtAction("ModificarProducto", productoModificado);
        //    return Ok();
        //}

        [HttpDelete(RouteMaterial.Delete)]
        public ActionResult<dominio.Material> Eliminar(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }
}
