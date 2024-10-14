using System.Windows.Input;

namespace MyProject;

public partial class HealthMonitoringPage : ContentPage
{
    public ICommand FlyoutCommand { get; set; }
    public HealthProfile HealthProfile { get; set; }

    public HealthMonitoringPage()
    {
        InitializeComponent();
        HealthProfile = new HealthProfile();
        HealthProfile.Weight = null;
        HealthProfile.Height = null;

        // ������������� ������� Flyout � SaveCommand
        FlyoutCommand = new Command(() =>
        {
            if (Application.Current.MainPage is FlyoutPage flyoutPage)
            {
                flyoutPage.IsPresented = true;
            }
        });
        
            BindingContext = this; // �������� ��������� ������
    }



    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void Button_SaveClicked(object sender, EventArgs e)
    {

        if (HealthProfile.Weight > 0 && HealthProfile.Height > 0)
        {
            BmiLabel.IsVisible = true;
            await DisplayAlert("���������", $"������� ���, ��� ��� �����������, ��� ���� BMI: {HealthProfile.BMI:F2}", "���");
        }
        else
        {
            await DisplayAlert("���", $"������� ��� ����", "���");

        }

    }
}
