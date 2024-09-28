namespace MyProject
{
    public partial class MainPage : FlyoutPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnHomeClicked(object sender, EventArgs e)
        {
            //Go to main page
            Detail = new NavigationPage(new MainPage());
            //Close menu
            IsPresented = false;
        }
        private async void OnPageWorkoutsClicked(object sender, EventArgs e)
        {
            await (Detail as NavigationPage).PushAsync(new WorkoutsPage());
            //Close menu
            IsPresented = false;
        }
        private async void OnPageAchievementsClicked(object sender, EventArgs e)
        {
            await (Detail as NavigationPage).PushAsync(new AchievementsPage());
            //Close menu
            IsPresented = false;
        }
        private async void OnPageHealthMonitoringClicked(object sender, EventArgs e)
        {
            await (Detail as NavigationPage).PushAsync(new HealthMonitoringPage());
            //Close menu
            IsPresented = false;
        }
    }

}
