using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using Venta.Infraestructura;
using dominio = Venta.Dominio.Entidades;
using Venta.Aplicacion.Venta;

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
            services.TryAddScoped<ICollectionContext<dominio.Venta>>(x => new CollectionContext<dominio.Venta>(x.GetService<IDbContext>()));
           // services.TryAddScoped<ICollectionContext<dominio.DetallePedido>>(x => new CollectionContext<dominio.DetallePedido>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Venta>>(x => new BaseRepository<dominio.Venta>(x.GetService<IDbContext>()));
           // services.TryAddScoped<IBaseRepository<dominio.DetallePedido>>(x => new BaseRepository<dominio.DetallePedido>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IVentaService, VentaService>();
            //services.AddScoped<IDetallePedidoService, DetallePedidoService>();
            

            #endregion

            return services;
        }

    }
}
