using Microsoft.Extensions.Logging;

namespace ShoppingListAW4E
{
    // Ten plik odpowiada za konfigurację aplikacji przed jej uruchomieniem.
    // Proste wyjaśnienie:
    // - Tworzymy "builder", który konfiguruje aplikację (czcionki, usługi, logowanie).
    // - Na końcu wywołujemy Build(), aby przygotować aplikację do uruchomienia.
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            MauiAppBuilder builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
