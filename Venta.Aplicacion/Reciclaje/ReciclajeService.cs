using MongoDB.Driver;
using Release.MongoDB.Repository;
using System.Linq.Expressions;
using dominio = Venta.Dominio.Entidades;

namespace Venta.Aplicacion.Reciclaje
{
    public class ReciclajeService : IReciclajeService
    {
        private readonly ICollectionContext<dominio.Reciclaje> _venta;
        private readonly IBaseRepository<dominio.Reciclaje> _ventaR;

        public ReciclajeService(ICollectionContext<dominio.Reciclaje> venta, 
                                IBaseRepository<dominio.Reciclaje> ventaR)
        {
            _venta = venta;
            _ventaR = ventaR;
        }

        public dominio.Reciclaje Reciclaje(int idVenta)
        {
            Expression<Func<dominio.Reciclaje, bool>> filter = s => s.esEliminado == false && s.idReciclaje == idVenta;
            var item = (_venta.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idVenta)
        {
            Expression<Func<dominio.Reciclaje, bool>> filter = s => s.esEliminado == false && s.idReciclaje == idVenta;
            var item = (_venta.Context().FindOneAndDelete(filter, null));
        }

        public List<dominio.Reciclaje> ListarReciclaje()
        {
            Expression<Func<dominio.Reciclaje, bool>> filter = s => s.esEliminado == false;
            var items = (_venta.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool ModificarReciclaje(dominio.Reciclaje venta)
        {
            throw new NotImplementedException();
        }

        public bool RegistrarReciclaje(dominio.Reciclaje venta)
        {
            venta.esEliminado = false;
            venta.fechaCreacion = DateTime.Now;
            venta.esActivo = true;

            var p = _ventaR.InsertOne(venta);

            return true;
        }
    }
}
