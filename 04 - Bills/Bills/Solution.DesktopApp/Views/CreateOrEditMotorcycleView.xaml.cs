namespace Solution.DesktopApp.Views;

public partial class CreateOrEditMotorcycleView : ContentPage
{
	public CreateOrEditBillViewModel ViewModel => this.BindingContext as CreateOrEditBillViewModel;

	public static string Name => nameof(CreateOrEditMotorcycleView);

    public CreateOrEditMotorcycleView(CreateOrEditBillViewModel viewModel)
	{
		this.BindingContext = viewModel;

		InitializeComponent();
	}
}