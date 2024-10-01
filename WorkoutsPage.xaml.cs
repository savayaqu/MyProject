using System.Collections.ObjectModel;
using System.Globalization;

namespace MyProject;

public partial class WorkoutsPage : ContentPage
{
    public Command FlyoutCommand { get; set; }
    public ObservableCollection<Workout> Workouts { get; set; }


    public WorkoutsPage()
    {
        InitializeComponent();

        FlyoutCommand = new Command(() =>
        {
            if (Application.Current.MainPage is FlyoutPage flyoutPage)
            {
                flyoutPage.IsPresented = true;
            }
        });
        Workouts = new ObservableCollection<Workout>
{
    new Workout { Name = "������", Duration = "30 ���" },
    new Workout { Name = "������� ����������", Duration = "45 ���" },
    new Workout { Name = "����", Duration = "60 ���" },
    new Workout { Name = "���", Duration = "30 ���" },
    new Workout { Name = "��������", Duration = "35 ���" },
};


        BindingContext = this;
    }


    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnStartWorkoutClicked(object sender, EventArgs e)
    {
        var workout = (sender as Button).BindingContext as Workout;
        await DisplayAlert("������ ����������", $"�� ������: {workout.Name}", "OK");
    }
    
}
