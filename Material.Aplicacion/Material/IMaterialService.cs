using dominio = Material.Dominio.Entidades;

namespace Material.Aplicacion.Material
{
    public interface IMaterialService
    {
        List<dominio.Material> ListarMateriales();
        bool RegistraMaterial(dominio.Material material);
        dominio.Material Material(int idMaterial);
        void Eliminar(int idMaterial);
    }
}
