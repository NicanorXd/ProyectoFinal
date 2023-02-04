using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Venta.Dominio.Entidades
{
    [CollectionProperty("Reciclaje")]
    [BsonIgnoreExtraElements]
    public class Reciclaje : EntityToLower<ObjectId>
    {        
        public int idReciclaje { get; set; }

        public int idCliente { get; set; }

        public decimal total { get; set; }


    }
}
