using Microsoft.Extensions.DependencyInjection;
using Sharprompt;
using Sharprompt.Fluent;
using SongLyrics.Console.Contract;
using SongLyrics.Console.Models.ServiceConfigurations;

public class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            await Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");   
        }        
    }

    private static async Task Run()
    {
        // Note: Artist API will returns only three artist for this demo app.
        // For sake of simplicity, App provided the list of existing artists. 
        // User needs to select an artist from the list
        // if you donot select any, then default will be Michael Jackson
        var artistName = Prompt.Select<string>(a => a.WithMessage("Please select an Artist")
                                            .WithItems(new[] { "Michael Jackson", "Justin Bieber", "Taylor Swift" })
                                            .WithDefaultValue("Michael Jackson"));

        var builder = ServiceConfiguration.HostBuilder();

        var host = builder.Build();
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        var managerService = services.GetService<IServiceManager>();

        var result = await managerService.ArtistAndSongService.GetArtistSongsAndCountLyrics(artistName, services);

        Console.WriteLine(result);

        Console.WriteLine();
        var answer = Prompt.Confirm("Do you want to search another Artist?");
        if (answer)
            await Run();
        else
            Environment.Exit(0);
    }   
}