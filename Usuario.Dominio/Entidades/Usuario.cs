using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Usuario.Dominio.Entidades
{
    [CollectionProperty("AgregadoUsuario")]
    [BsonIgnoreExtraElements]
    public class Usuario : EntityToLower<ObjectId>
    {        
        public int idUsuario { get; set; }

 
        public string nombre { get; set; }

        public string apellido { get; set; }
        public string dni { get; set; }

        public string correo { get; set; }
    }
}
