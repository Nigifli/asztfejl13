namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class EarbudListViewModel(IEarbudService earbudService)
{
    #region life cycle commands
    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);
    #endregion

    #region paging commands
    public ICommand PreviousPageCommand { get; private set; }
    public ICommand NextPageCommand { get; private set; }
    #endregion

    #region component commands
    public IAsyncRelayCommand DeleteCommand => new AsyncRelayCommand<string>((id) => OnDeleteAsync(id));
    #endregion

    [ObservableProperty]
    private ObservableCollection<EarbudModel> earbuds;

    private int page = 1;
    private bool isLoading = false;
    private bool hasNextPage = false;
    private int numberOfEarbudsInDB = 0;

    private async Task OnAppearingAsync()
    {
        PreviousPageCommand = new Command(async () => await OnPreviousPageAsync(), () => page > 1 && !isLoading);
        NextPageCommand = new Command(async () => await OnNextPageAsync(), () => !isLoading && hasNextPage);

        await LoadEarbudsAsync();
    }

    private async Task OnDisappearingAsync()
    { }

    private async Task OnPreviousPageAsync()
    {
        if (isLoading) return;

        page = page <= 1 ? 1 : --page;
        await LoadEarbudsAsync();
    }

    private async Task OnNextPageAsync()
    {
        if (isLoading) return;

        page++;
        await LoadEarbudsAsync();
    }

    private async Task LoadEarbudsAsync()
    {
        isLoading = true;

        var result = await earbudService.GetPagedAsync(page);

        if (result.IsError)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Earbuds not loaded!", "OK");
            return;
        }

        Earbuds = new ObservableCollection<EarbudModel>(result.Value.Items);
        numberOfEarbudsInDB = result.Value.Count;

        hasNextPage = numberOfEarbudsInDB - (page * 10) > 0;
        isLoading = false;

        ((Command)PreviousPageCommand).ChangeCanExecute();
        ((Command)NextPageCommand).ChangeCanExecute();
    }

    private async Task OnDeleteAsync(string? id)
    { 
        var result = await earbudService.DeleteAsync(id);

        var message = result.IsError ? result.FirstError.Description : "Earbud deleted.";
        var title = result.IsError ? "Error" : "Information";

        if (!result.IsError)
        {
            var earbud = earbuds.SingleOrDefault(x => x.Id == id);
            earbuds.Remove(earbud);

            if(earbuds.Count == 0)
            {
                await LoadEarbudsAsync();
            }
        }

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }
}
