using System.Windows.Input;

namespace MyProject;

public partial class HealthMonitoringPage : ContentPage
{

    public Command FlyoutCommand { get; set; }
    public HealthProfile HealthProfile { get; set; }
    public Command SaveCommand { get; set; }

    public HealthMonitoringPage()
    {
        InitializeComponent();

        FlyoutCommand = new Command(() =>
        {
            if (Application.Current.MainPage is FlyoutPage flyoutPage)
            {
                flyoutPage.IsPresented = true;
            }
        });
       
        HealthProfile = new HealthProfile();
        SaveCommand = new Command(OnSave);

        BindingContext = this;
    }

    public void OnSave()
    {
        DisplayAlert("Успешно", "Ваши данные сохранены!", "OK");

    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
