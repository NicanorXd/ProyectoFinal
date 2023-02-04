using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Venta.Dominio.Entidades
{
    [CollectionProperty("ReciclajeDetalle")]
    [BsonIgnoreExtraElements]
    public class ReciclajeDetalle : EntityToLower<ObjectId>
    {        
        public int idReciclajeDetalle { get; set; }

        public int idReciclaje { get; set; }

        
        public int idMaterial { get; set; }

        public decimal peso { get; set; }

        public decimal precio { get; set; }
    }
}
