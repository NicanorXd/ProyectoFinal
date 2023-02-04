using dominio = Venta.Dominio.Entidades;

namespace Venta.Aplicacion.Venta
{
    public interface IVentaService
    {
        List<dominio.Venta> ListarVentas();

        dominio.Venta Venta(int idPedido);

        bool RegistrarVenta(dominio.Venta venta);

        //bool ModificarCategoria(dominio.Categoria categoria);

        void Eliminar(int idVenta);
    }
}
