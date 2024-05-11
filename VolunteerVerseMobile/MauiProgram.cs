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

            builder.Services.AddSingleton<IEventApiService, EventApiService>();

            builder.Services.AddSingleton<EventListViewModel>();


            builder.Services.AddTransient<EventListPage>();

            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

            return builder.Build();
        }
    }
}
