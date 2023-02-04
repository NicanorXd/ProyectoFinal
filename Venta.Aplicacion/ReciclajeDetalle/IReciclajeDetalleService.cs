using dominio = Venta.Dominio.Entidades;

namespace ReciclajeDetalle.Aplicacion.Venta
{
    public interface IReciclajeDetalleService
    {
        List<dominio.ReciclajeDetalle> ListarReciclajeDetalle();

        dominio.ReciclajeDetalle ReciclajeDetalle(int idReciclajeDetalle);

        bool RegistrarReciclajeDetalle(dominio.ReciclajeDetalle reciclajeDetalle);

        //bool ModificarCategoria(dominio.Categoria categoria);

        void Eliminar(int idReciclajeDetalle);
    }
}
