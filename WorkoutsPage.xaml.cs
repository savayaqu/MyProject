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
    new Workout { Name = "Кардио", Duration = "30 мин" },
    new Workout { Name = "Силовая тренировка", Duration = "45 мин" },
    new Workout { Name = "Йога", Duration = "60 мин" },
    new Workout { Name = "Бег", Duration = "30 мин" },
    new Workout { Name = "Кроссфит", Duration = "35 мин" },
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
        await DisplayAlert("Начало тренировки", $"Вы начали: {workout.Name}", "OK");
    }
    
}
