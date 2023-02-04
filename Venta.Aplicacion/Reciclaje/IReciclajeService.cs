using dominio = Venta.Dominio.Entidades;

namespace Venta.Aplicacion.Reciclaje
{
    public interface IReciclajeService
    {
        List<dominio.Reciclaje> ListarReciclaje();

        dominio.Reciclaje Reciclaje(int idReciclaje);

        bool RegistrarReciclaje(dominio.Reciclaje reciclaje);

        //bool ModificarCategoria(dominio.Categoria categoria);

        void Eliminar(int idReciclaje);
    }
}
