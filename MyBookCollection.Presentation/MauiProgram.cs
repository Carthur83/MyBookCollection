using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyBookCollection.Business.Interfaces;
using MyBookCollection.Business.Services;
using MyBookCollection.Data.Contexts;
using MyBookCollection.Data.Interfaces;
using MyBookCollection.Data.Repositories;

namespace MyBookCollection.Presentation
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
                });

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "books.db");

            builder.Services.AddSingleton<DataContext>(x =>
            {
                var context = new DataContext(dbPath);
                context.Database.Migrate();
                Console.WriteLine($"Database path: {dbPath}");

                return context;
            });

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBookService, BookService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
