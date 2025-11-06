namespace Solution.DesktopApp.Views;

public partial class MotorcycleListView : ContentPage
{
	public BillListViewModel ViewModel => this.BindingContext as BillListViewModel;

	public static string Name => nameof(MotorcycleListView);

    public MotorcycleListView(BillListViewModel viewModel)
	{
		this.BindingContext = viewModel;

		InitializeComponent();
	}
}