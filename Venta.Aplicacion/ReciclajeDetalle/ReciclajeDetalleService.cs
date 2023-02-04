using MongoDB.Driver;
using ReciclajeDetalle.Aplicacion.Venta;
using Release.MongoDB.Repository;
using System.Linq.Expressions;
using dominio = Venta.Dominio.Entidades;

namespace Venta.Aplicacion.ReciclajeDetalle
{
    public class ReciclajeDetalleService : IReciclajeDetalleService
    {
        private readonly ICollectionContext<dominio.ReciclajeDetalle> _venta;
        private readonly IBaseRepository<dominio.ReciclajeDetalle> _ventaR;

        public ReciclajeDetalleService(ICollectionContext<dominio.ReciclajeDetalle> venta, 
                                IBaseRepository<dominio.ReciclajeDetalle> ventaR)
        {
            _venta = venta;
            _ventaR = ventaR;
        }

        public dominio.ReciclajeDetalle ReciclajeDetalle(int idVenta)
        {
            Expression<Func<dominio.ReciclajeDetalle, bool>> filter = s => s.esEliminado == false && s.idReciclajeDetalle == idVenta;
            var item = (_venta.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idVenta)
        {
            Expression<Func<dominio.ReciclajeDetalle, bool>> filter = s => s.esEliminado == false && s.idReciclajeDetalle == idVenta;
            var item = (_venta.Context().FindOneAndDelete(filter, null));
        }

        public List<dominio.ReciclajeDetalle> ListarReciclajeDetalle()
        {
            Expression<Func<dominio.ReciclajeDetalle, bool>> filter = s => s.esEliminado == false;
            var items = (_venta.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool ModificarREciclajeDetalle(dominio.ReciclajeDetalle venta)
        {
            throw new NotImplementedException();
        }

        public bool RegistrarReciclajeDetalle(dominio.ReciclajeDetalle venta)
        {
            venta.esEliminado = false;
            venta.fechaCreacion = DateTime.Now;
            venta.esActivo = true;

            var p = _ventaR.InsertOne(venta);

            return true;
        }
    }
}
