using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using ReciclajeDetalle.Aplicacion.Venta;
using Release.MongoDB.Repository;
using Venta.Aplicacion.Reciclaje;
using Venta.Aplicacion.ReciclajeDetalle;
using Venta.Infraestructura;
using dominio = Venta.Dominio.Entidades;

namespace Venta.Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration) 
        {
            #region Mongo

            string cs = configuration.GetSection("DBSettings:ConnectionString").Value;
            var dbUrl = new MongoUrl(cs);

            services.AddScoped<IDbContext>(x => new DbContext(dbUrl));

            //Entidades            
            services.TryAddScoped<ICollectionContext<dominio.Reciclaje>>(x => new CollectionContext<dominio.Reciclaje>(x.GetService<IDbContext>()));
           services.TryAddScoped<ICollectionContext<dominio.ReciclajeDetalle>>(x => new CollectionContext<dominio.ReciclajeDetalle>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Reciclaje>>(x => new BaseRepository<dominio.Reciclaje>(x.GetService<IDbContext>()));
            services.TryAddScoped<IBaseRepository<dominio.ReciclajeDetalle>>(x => new BaseRepository<dominio.ReciclajeDetalle>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IReciclajeService, ReciclajeService>();
            services.AddScoped<IReciclajeDetalleService, ReciclajeDetalleService>();
            

            #endregion

            return services;
        }

    }
}
