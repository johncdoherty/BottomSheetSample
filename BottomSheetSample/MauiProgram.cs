using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;
using Plugin.Maui.BottomSheet.Hosting;

namespace BottomSheetSample
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
                })
                .UseBottomSheet();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<IBottomSheet1, BottomSheet1>();
            builder.Services.AddSingleton<IBottomSheet2, BottomSheet2>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            

            // Build the Maui app
            var mauiApp = builder.Build();

            // Initialize service helper to access IoC services anywhere
            ServiceHelper.Initialize(mauiApp.Services);

            return mauiApp;
        }
    }

    /// <summary>
    /// Provides helper methods for accessing services in the application.
    /// </summary>
    public static class ServiceHelper
    {
        /// <summary>
        /// Gets the service provider for the application.
        /// </summary>
        public static IServiceProvider Services { get; private set; }

        /// <summary>
        /// Initializes the service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider to initialize.</param>
        public static void Initialize(IServiceProvider serviceProvider) =>
            Services = serviceProvider;

        /// <summary>
        /// Gets a service of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of service to get.</typeparam>
        /// <returns>The service of the specified type.</returns>
        public static T GetService<T>() => Services.GetService<T>();

        /// <summary>
        /// Gets a keyed service of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of service to get.</typeparam>
        /// <param name="key">The key of the service to get.</param>
        /// <returns>The keyed service of the specified type.</returns>
        //public static T GetKeyedService<T>(object? key) => Services.GetKeyedService<T>(key);
    }
}
