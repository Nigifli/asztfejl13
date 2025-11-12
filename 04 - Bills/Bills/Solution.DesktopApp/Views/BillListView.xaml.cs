namespace Solution.DesktopApp.Views;

public partial class BillListView : ContentPage
{
	public BillListViewModel ViewModel => this.BindingContext as BillListViewModel;

	public static string Name => nameof(BillListView);

    public BillListView(BillListViewModel viewModel)
	{
		this.BindingContext = viewModel;

		InitializeComponent();
	}
}