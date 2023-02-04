using MongoDB.Driver;
using Release.MongoDB.Repository;
using System.Linq.Expressions;
using dominio = Material.Dominio.Entidades;

namespace Material.Aplicacion.Material
{

    public class MaterialService : IMaterialService
    {
        private readonly ICollectionContext<dominio.Material> _material;
        private readonly IBaseRepository<dominio.Material> _materialR;

        public MaterialService(ICollectionContext<dominio.Material> material, 
                                IBaseRepository<dominio.Material> materialR)
        {
            _material = material;
            _materialR = materialR;
        }

        public List<dominio.Material> ListarMateriales()
        {
            Expression<Func<dominio.Material, bool>> filter = s => s.esEliminado == false;
            var items = (_material.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool RegistraMaterial(dominio.Material material)
        {
            material.esEliminado = false;
            material.fechaCreacion =DateTime.Now;
            material.esActivo = true;

           // _producto.Context().InsertOne(producto);                       

            var p = _materialR.InsertOne(material);

            return true;
        }

        public dominio.Material Material(int idMaterial)
        {
            Expression<Func<dominio.Material, bool>> filter = s => s.esEliminado == false && s.idMaterial == idMaterial;
            var item = (_material.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idMaterial)
        {
            Expression<Func<dominio.Material, bool>> filter = s => s.esEliminado == false && s.idMaterial == idMaterial;
            var item = (_material.Context().FindOneAndDelete(filter, null));
            
        }
    }
}
