using Solution.DesktopApp.ViewModels;

namespace Solution.DesktopApp.Views;

public partial class CreateOrEditEarbudView : ContentPage
{
	public CreateOrEditEarbudViewModel ViewModel => this.BindingContext as CreateOrEditEarbudViewModel;

	public static string Name => nameof(CreateOrEditEarbudView);

    public CreateOrEditEarbudView(CreateOrEditEarbudViewModel viewModel)
	{
		this.BindingContext = viewModel;

		InitializeComponent();
	}
}