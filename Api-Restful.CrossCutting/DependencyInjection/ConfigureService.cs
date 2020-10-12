using Api_Restful.Service.Services;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.User;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace Api_Restful.DependencyInjection.CrossCutting
{
    public class ConfigureService
    {
        public static void ConfigureDependeciesService(IServiceCollection serviceColletion)
        {
            serviceColletion.AddTransient<IUserService, UserService>();
            serviceColletion.AddTransient<ILoginService, LoginService>();
        }
    }
}
