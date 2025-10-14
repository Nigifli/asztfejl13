namespace Solution.DesktopApp.Views;

public partial class EarbudListView : ContentPage
{
	public EarbudListViewModel ViewModel => this.BindingContext as EarbudListViewModel;

	public static string Name => nameof(EarbudListView);

    public EarbudListView(EarbudListViewModel viewModel)
	{
		this.BindingContext = viewModel;

		InitializeComponent();
	}
}