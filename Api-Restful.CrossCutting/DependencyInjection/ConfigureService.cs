using Api_Restful.Service.Services;
using Domain.Interfaces.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace Api_Restful.DependencyInjection.CrossCutting
{
    public class ConfigureService
    {
        public static void ConfigureDependeciesService(IServiceCollection serviceColletion)
        {
            serviceColletion.AddTransient<IUserService, UserService>();
        }
    }
}
