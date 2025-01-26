using GrooveandNeedle.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace GrooveandNeedle
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Agregar HttpClient para la API
            builder.Services.AddHttpClient();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            return builder.Build();
        }
    }
}
