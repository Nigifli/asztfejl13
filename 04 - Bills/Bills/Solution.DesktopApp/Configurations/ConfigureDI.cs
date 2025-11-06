namespace Solution.DesktopApp.Configurations;

public static class ConfigureDI
{
    public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MainView>();

        builder.Services.AddTransient<BillListViewModel>();
        builder.Services.AddTransient<CreateOrEditBillViewModel>();
        builder.Services.AddTransient<IBillService, BillService>();

        builder.Services.AddScoped<IGoogleDriveService, GoogleDriveService>();



       

        return builder;
    }
}
