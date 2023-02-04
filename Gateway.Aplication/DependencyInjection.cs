using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using Material.Aplicacion.Material;
using Material.Infraestructura;
using dominio = Material.Dominio.Entidades;

namespace Material.Aplicacion
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
            services.TryAddScoped<ICollectionContext<dominio.Material>>(x => new CollectionContext<dominio.Material>(x.GetService<IDbContext>()));
            //services.TryAddScoped<ICollectionContext<dominio.Categoria>>(x => new CollectionContext<dominio.Categoria>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Material>>(x => new BaseRepository<dominio.Material>(x.GetService<IDbContext>()));
            //services.TryAddScoped<IBaseRepository<dominio.Categoria>>(x => new BaseRepository<dominio.Categoria>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IMaterialService, MaterialService>();
            //services.AddScoped<ICategoriaService, CategoriaService>();

            #endregion

            return services;
        }

    }
}
