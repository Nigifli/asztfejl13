using Solution.Core.Interfaces;

namespace Solution.DesktopApp.Configurations;

public static class ConfigureDI
{
    public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MainView>();

        builder.Services.AddTransient<EarbudListViewModel>();
        builder.Services.AddTransient<EarbudListView>();
        builder.Services.AddTransient<CreateOrEditEarbudViewModel>();
        builder.Services.AddTransient<CreateOrEditEarbudView>();
        builder.Services.AddTransient<IEarbudService, EarbudService>();

        builder.Services.AddTransient<AddManufacturerViewModel>();
        builder.Services.AddTransient<AddManufacturerView>();
        builder.Services.AddTransient<ManufacturerListViewModel>(); //
        builder.Services.AddTransient<IManufacturerService, ManufacturerService>();

        builder.Services.AddTransient<AddTypeViewModel>();
        builder.Services.AddTransient<AddTypeView>();
        builder.Services.AddTransient<TypeListViewModel>();
        builder.Services.AddTransient<ITypeService, TypeService>();

        builder.Services.AddScoped<IGoogleDriveService, GoogleDriveService>();



       

        return builder;
    }
}
