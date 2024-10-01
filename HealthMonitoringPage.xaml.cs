using System.Windows.Input;

namespace MyProject;

public partial class HealthMonitoringPage : ContentPage
{
    public ICommand FlyoutCommand { get; set; }
    public HealthProfile HealthProfile { get; set; }
    public ICommand SaveCommand { get; set; }

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

        // Инициализация HealthProfile и установка его в качестве BindingContext
        HealthProfile = new HealthProfile();
        SaveCommand = new Command(OnSave); // Привязываем команду SaveCommand

        BindingContext = this;
    }

    private void OnSave()
    {
        // Проверяем, заданы ли значения для веса и роста
        if (HealthProfile.Weight > 0 && HealthProfile.Height > 0)
        {
            // Отображаем метку с ИМТ
            BmiLabel.IsVisible = true;
            DisplayAlert("Успешно", $"Ваш ИМТ: {HealthProfile.BMI:F2}", "OK");
        }
        else
        {
            DisplayAlert("Ошибка", "Пожалуйста, введите корректные значения для веса и роста.", "OK");
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
