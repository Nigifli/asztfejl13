

namespace Solution.Api.Configurations;

public static class DIConfigurations
{
    public static WebApplicationBuilder ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddTransient<IBillService, BillService>();

        builder.Services.AddTransient<IManufacturerService, ManufacturerService>();

        builder.Services.AddTransient<ITypeService, ItemService>();

        return builder;
    }
}
