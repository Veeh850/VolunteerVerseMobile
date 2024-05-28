using Microsoft.Extensions.Logging;
using UraniumUI;
using VolunteerVerseMobile.Interfaces;
using VolunteerVerseMobile.Services;
using VolunteerVerseMobile.ViewModels;
using VolunteerVerseMobile.Views;

namespace VolunteerVerseMobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddMaterialIconFonts();
                });

#if DEBUG
    		//builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<IEventApiService, EventApiService>();
            builder.Services.AddTransient<IAuthorizationApiService, AuthorizationApiService>();
            builder.Services.AddTransient<IAccountApiService, AccountApiService>();
            builder.Services.AddTransient<IOrganizationApiService, OrganizationApiService>();

            builder.Services.AddTransient<EventListViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<EventDetailsViewModel>();
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<OrganizationListViewModel>();
            builder.Services.AddTransient<OrganizationDetailsViewModel>();
            builder.Services.AddTransient<SignupViewModel>();

            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<EventListPage>();
            builder.Services.AddTransient<EventDetailsPage>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<OrganizationListPage>();
            builder.Services.AddTransient<OrganizationDetailsPage>();
            builder.Services.AddTransient<SignupPage>();

            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

            return builder.Build();
        }
    }
}
