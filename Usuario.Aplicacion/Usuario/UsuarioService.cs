using MongoDB.Driver;
using Release.MongoDB.Repository;
using System.Linq.Expressions;
using dominio = Usuario.Dominio.Entidades;

namespace Usuario.Aplicacion.Usuario
{

    public class UsuarioService : IUsuarioService
    {
        private readonly ICollectionContext<dominio.Usuario> _usuario;
        private readonly IBaseRepository<dominio.Usuario> _usuarioR;

        public UsuarioService(ICollectionContext<dominio.Usuario> usuario, 
                                IBaseRepository<dominio.Usuario> usuarioR)
        {
            _usuario = usuario;
            _usuarioR = usuarioR;
        }

        public List<dominio.Usuario> ListarUsuarios()
        {
            Expression<Func<dominio.Usuario, bool>> filter = s => s.esEliminado == false;
            var items = (_usuario.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool Registrarusuario(dominio.Usuario usuario)
        {
            usuario.esEliminado = false;
            usuario.fechaCreacion =DateTime.Now;
            usuario.esActivo = true;

           // _producto.Context().InsertOne(producto);                       

            var p = _usuarioR.InsertOne(usuario);

            return true;
        }

        public dominio.Usuario Usuario(int idUsuario)
        {
            Expression<Func<dominio.Usuario, bool>> filter = s => s.esEliminado == false && s.idUsuario == idUsuario;
            var item = (_usuario.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idUsuario)
        {
            Expression<Func<dominio.Usuario, bool>> filter = s => s.esEliminado == false && s.idUsuario == idUsuario;
            var item = (_usuario.Context().FindOneAndDelete(filter, null));
            
        }
    }
}
