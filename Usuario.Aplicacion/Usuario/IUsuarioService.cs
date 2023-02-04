using dominio = Usuario.Dominio.Entidades;

namespace Usuario.Aplicacion.Usuario
{
    public interface IUsuarioService
    {
        List<dominio.Usuario> ListarUsuarios();
        bool Registrarusuario(dominio.Usuario usuario);
        dominio.Usuario Usuario(int idUsuario);
        void Eliminar(int idUsuario);
    }
}
