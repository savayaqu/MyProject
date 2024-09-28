namespace MyProject;

public partial class WorkoutsPage : ContentPage
{
    public Command FlyoutCommand { get; set; }
    public WorkoutsPage()
	{
		InitializeComponent();
        FlyoutCommand = new Command(() =>
        {
            if (Application.Current.MainPage is FlyoutPage flyoutPage)
            {
                // Open menu
                flyoutPage.IsPresented = true;
            }
        });
        BindingContext = this;
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}