using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Model;

namespace Venta.Dominio.Entidades
{
    [CollectionProperty("DetalleReciclaje")]
    [BsonIgnoreExtraElements]
    public class Venta : EntityToLower<ObjectId>
    {        
        public int idMaterialReciclaje { get; set; }

        public int unidadMedida { get; set; }

        
        public decimal precioMaterial { get; set; }

        public int cantidadMaterial { get; set; }


    }
}
