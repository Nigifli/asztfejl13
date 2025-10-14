namespace Solution.DesktopApp.Components;

public partial class EarbudListComponent : ContentView
{
    public static readonly BindableProperty EarbudProperty = BindableProperty.Create(
         propertyName: nameof(Earbud),
         returnType: typeof(EarbudModel),
         declaringType: typeof(EarbudListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.OneWay
    );

    public EarbudModel Earbud
    {
        get => (EarbudModel)GetValue(EarbudProperty);
        set => SetValue(EarbudProperty, value);
    }

    public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
         propertyName: nameof(DeleteCommand),
         returnType: typeof(IAsyncRelayCommand),
         declaringType: typeof(EarbudListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.OneWay
    );

    public IAsyncRelayCommand DeleteCommand
    {
        get => (IAsyncRelayCommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
         propertyName: nameof(CommandParameter),
         returnType: typeof(string),
         declaringType: typeof(EarbudListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.TwoWay
        );

    public string CommandParameter
    {
        get => (string)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public IAsyncRelayCommand EditCommand => new AsyncRelayCommand(OnEditAsync);

    public EarbudListComponent()
	{
		InitializeComponent();
	}

    private async Task OnEditAsync()
    {
        ShellNavigationQueryParameters navigationQueryParameter = new ShellNavigationQueryParameters
        {
            { "Earbud", this.Earbud}
        };

        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(CreateOrEditEarbudView.Name, navigationQueryParameter);
    }
}