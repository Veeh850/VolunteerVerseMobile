using VolunteerVerseMobile.Views;

namespace VolunteerVerseMobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(EventListPage), typeof(EventListPage));
        }
    }
}
