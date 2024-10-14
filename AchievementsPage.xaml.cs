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
                new Achievements { Description = "�� ����� � ����������", Date = DateTime.Now },
                new Achievements { Description = "�� ���", Date = DateTime.Parse("01.01.0001 01:01:01") },
                new Achievements { Description = "�� ������� ��������� ����������: ����", Date = DateTime.Parse("08.08.2024 13:12:01") },
            };
            BindingContext = this;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnAddAchievementClicked(object sender, EventArgs e)
        {
            // ����������� �������� ����������
            string description = await DisplayPromptAsync("�������� ����������", "������� �������� ����������:");

            // ���������, ������� �� ��������
            if (!string.IsNullOrWhiteSpace(description))
            {
                // ������� ����� ���������� � ������� �����
                var newAchievement = new Achievements
                {
                    Description = description,
                    Date = DateTime.Now
                };

                // ��������� ����� ���������� � ���������
                Achievements.Add(newAchievement);
            }
        }

    }
}
