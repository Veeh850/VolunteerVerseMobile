using VolunteerVerseMobile.Views;

namespace VolunteerVerseMobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(EventListPage), typeof(EventListPage));
            Routing.RegisterRoute(nameof(EventDetailsPage), typeof(EventDetailsPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(OrganizationListPage), typeof(OrganizationListPage));
            Routing.RegisterRoute(nameof(OrganizationDetailsPage), typeof(OrganizationDetailsPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        }
    }
}
