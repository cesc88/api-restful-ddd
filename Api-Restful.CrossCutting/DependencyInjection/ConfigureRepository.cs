using Api_Restful.Data.Context;
using Api_Restful.Data.Repository;
using Api_Restful.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependeciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql("Server=localhost;Port=3306;Uid=root;Pwd=carlos36;Database=dbRestful")
           );
        }
    }
}
