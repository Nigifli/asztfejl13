﻿

namespace Solution.Api.Configurations;

public static class DIConfigurations
{
    public static WebApplicationBuilder ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddTransient<IEarbudService, EarbudService>();

        builder.Services.AddTransient<IManufacturerService, ManufacturerService>();

        builder.Services.AddTransient<ITypeService, TypeService>();

        return builder;
    }
}
