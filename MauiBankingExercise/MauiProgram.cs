using Microsoft.Extensions.Logging;
using MauiBankingExercise.Services;
using MauiBankingExercise.ViewModels;
using MauiBankingExercise.Views;
using Microsoft.Extensions.Http;

namespace MauiBankingExercise
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
            builder.Services.AddLogging(configure => configure.AddDebug());
#endif

            // Add HttpClient for API calls
            builder.Services.AddHttpClient();

            // Register services
            builder.Services.AddSingleton<DatabaseService>();

            // Register ViewModels
            builder.Services.AddTransient<CustomerSelectionViewModel>();
            builder.Services.AddTransient<CustomerDashboardViewModel>();
            builder.Services.AddTransient<TransactionViewModel>();

            // Register Views
            builder.Services.AddTransient<CustomerSelectionPage>();
            builder.Services.AddTransient<CustomerDashboardPage>();
            builder.Services.AddTransient<TransactionPage>();

            return builder.Build();
        }
    }
}