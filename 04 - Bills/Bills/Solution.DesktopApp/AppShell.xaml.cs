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
        Routing.RegisterRoute(BillListView.Name, typeof(BillListView));
        Routing.RegisterRoute(CreateOrEditBillView.Name, typeof(CreateOrEditBillView));;
    }
}
