using MongoDB.Driver;
using Release.MongoDB.Repository;
using System.Linq.Expressions;
using dominio = Venta.Dominio.Entidades;

namespace Venta.Aplicacion.Venta
{
    public class VentaService : IVentaService
    {
        private readonly ICollectionContext<dominio.Venta> _venta;
        private readonly IBaseRepository<dominio.Venta> _ventaR;

        public VentaService(ICollectionContext<dominio.Venta> venta, 
                                IBaseRepository<dominio.Venta> ventaR)
        {
            _venta = venta;
            _ventaR = ventaR;
        }

        public dominio.Venta Venta(int idVenta)
        {
            Expression<Func<dominio.Venta, bool>> filter = s => s.esEliminado == false && s.idMaterialReciclaje == idVenta;
            var item = (_venta.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idVenta)
        {
            Expression<Func<dominio.Venta, bool>> filter = s => s.esEliminado == false && s.idMaterialReciclaje == idVenta;
            var item = (_venta.Context().FindOneAndDelete(filter, null));
        }

        public List<dominio.Venta> ListarVentas()
        {
            Expression<Func<dominio.Venta, bool>> filter = s => s.esEliminado == false;
            var items = (_venta.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool ModificarVenta(dominio.Venta venta)
        {
            throw new NotImplementedException();
        }

        public bool RegistrarVenta(dominio.Venta venta)
        {
            venta.esEliminado = false;
            venta.fechaCreacion = DateTime.Now;
            venta.esActivo = true;

            var p = _ventaR.InsertOne(venta);

            return true;
        }
    }
}
