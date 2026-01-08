using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Solution.WebAPI.Configurations;

public static class DependencInjectionConfiguration
{
    extension(IHostApplicationBuilder builder)
    {
        public IHostApplicationBuilder ConfigureDI()
        {
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient();

            builder.Services.AddTransient<ISecurityService, SecurityService>();
            builder.Services.AddTransient<IUserService, UserService>();

            return builder;
        }
    }
}

