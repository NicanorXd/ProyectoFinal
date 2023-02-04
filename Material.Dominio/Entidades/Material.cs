using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Material.Dominio.Entidades
{
    [CollectionProperty("AgregadoMaterial")]
    [BsonIgnoreExtraElements]
    public class Material : EntityToLower<ObjectId>
    {        
        public int idMaterial { get; set; }

        public int unidadMedida { get; set; }

        
        public string tipoMaterial { get; set; }


        public int cantidadMaterial { get; set; }
    }
}
