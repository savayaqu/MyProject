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

        // ������������� HealthProfile � ��������� ��� � �������� BindingContext
        HealthProfile = new HealthProfile();
        SaveCommand = new Command(OnSave); // ����������� ������� SaveCommand

        BindingContext = this;
    }

    private void OnSave()
    {
        // ���������, ������ �� �������� ��� ���� � �����
        if (HealthProfile.Weight > 0 && HealthProfile.Height > 0)
        {
            // ���������� ����� � ���
            BmiLabel.IsVisible = true;
            DisplayAlert("�������", $"��� ���: {HealthProfile.BMI:F2}", "OK");
        }
        else
        {
            DisplayAlert("������", "����������, ������� ���������� �������� ��� ���� � �����.", "OK");
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
