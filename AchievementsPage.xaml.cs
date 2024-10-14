using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace MyProject
{
    public partial class AchievementsPage : ContentPage
    {
        public Command FlyoutCommand { get; set; }
        public ObservableCollection<Achievements> Achievements { get; set; }

        public AchievementsPage()
        {
            InitializeComponent();

            FlyoutCommand = new Command(() =>
            {
                if (Application.Current.MainPage is FlyoutPage flyoutPage)
                {
                    flyoutPage.IsPresented = true;
                }
            });

            Achievements = new ObservableCollection<Achievements>
            {
                new Achievements { Description = "Вы зашли в приложение", Date = DateTime.Now },
                new Achievements { Description = "Вы кто", Date = DateTime.Parse("01.01.0001 01:01:01") },
                new Achievements { Description = "Вы успешно закончили тренировку: Йога", Date = DateTime.Parse("08.08.2024 13:12:01") },
            };
            BindingContext = this;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnAddAchievementClicked(object sender, EventArgs e)
        {
            // Запрашиваем описание достижения
            string description = await DisplayPromptAsync("Добавить достижение", "Введите описание достижения:");

            // Проверяем, введено ли описание
            if (!string.IsNullOrWhiteSpace(description))
            {
                // Создаем новое достижение с текущей датой
                var newAchievement = new Achievements
                {
                    Description = description,
                    Date = DateTime.Now
                };

                // Добавляем новое достижение в коллекцию
                Achievements.Add(newAchievement);
            }
        }

    }
}
