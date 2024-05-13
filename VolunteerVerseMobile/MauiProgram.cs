using Microsoft.Extensions.Logging;
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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		//builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<IEventApiService, EventApiService>();
            builder.Services.AddTransient<IAuthorizationApiService, AuthorizationApiService>();

            builder.Services.AddTransient<EventListViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<EventDetailsViewModel>();

            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<EventListPage>();
            builder.Services.AddTransient<EventDetailsPage>();

            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

            return builder.Build();
        }
    }
}
