namespace Solution.DesktopApp.Views;

public partial class ManufacturerListView : ContentPage
{
    public TypeListViewModel ViewModel => this.BindingContext as TypeListViewModel;

    public static string Name => nameof(TypeListView);

    public ManufacturerListView(ManufacturerListViewModel viewModel)
    {
        this.BindingContext = viewModel;

        InitializeComponent();
    }
}