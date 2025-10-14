namespace Solution.DesktopApp;

public partial class AppShell : Shell
{
    public AppShellViewModel ViewModel => this.BindingContext as AppShellViewModel;

    public AppShell(AppShellViewModel viewModel)
    {
        this.BindingContext = viewModel;

        InitializeComponent();

        ConfigureShellNavigation();
    }

    private static void ConfigureShellNavigation()
    {
        Routing.RegisterRoute(MainView.Name, typeof(MainView));
        Routing.RegisterRoute(EarbudListView.Name, typeof(EarbudListView));
        Routing.RegisterRoute(CreateOrEditEarbudView.Name, typeof(CreateOrEditEarbudView));
        Routing.RegisterRoute(AddManufacturerView.Name, typeof(AddManufacturerView));
        Routing.RegisterRoute(AddTypeView.Name, typeof(AddTypeView));
        Routing.RegisterRoute(TypeListView.Name, typeof(TypeListView));
        Routing.RegisterRoute(ManufacturerListView.Name, typeof(ManufacturerListView));//
    }
}
