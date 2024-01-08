// See https://aka.ms/new-console-template for more information

global using static System.Console;
using Assessment.Console.BusinessLogic;
using Assessment.Console.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

string? path;

while (true)
    try
    {
        Work();
    }
    catch (Exception e)
    {
        WriteLine("An error occurred: {0}", e.Message);
    }

void Work()
{
    do
    {
        WriteLine("Please enter a valid path, for txt template");
        path = ReadLine();
    } while (string.IsNullOrEmpty(path) || path.Length < 3);

    var services = new ServiceCollection();

    var builder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

    IConfiguration configuration = builder.Build();

    services.AddScoped<IConfiguration>(_ => configuration);

    services.AddOptions<UserApiSettings>()
        .BindConfiguration(nameof(UserApiSettings));

    services.AddOptions<FileReaderSettings>()
        .BindConfiguration(nameof(FileReaderSettings));

    services.PostConfigure<FileReaderSettings>(settings =>
    {
        settings.FilePath = path;
    });

    services.AddHttpClient<IUserApiClient, UserApiClient>((sp,client) =>
    {
        var settings = sp.GetRequiredService<IOptions<UserApiSettings>>().Value;
        client.BaseAddress = new Uri(settings.BaseUrl);
    });

    services.AddTransient<IReader, Reader>();
    services.AddTransient<IRetriever,Retriever>();
    services.AddTransient<IWriter, Writer>();

    var serviceProvider = services.BuildServiceProvider();

    #region Reader

    var reader = serviceProvider.GetRequiredService<IReader>();
    var users = reader.GetUsersFromCsv();

    #endregion

    #region Retriever

    var retriever = serviceProvider.GetRequiredService<IRetriever>();
    var completeUsers = retriever.GetCompleteUsers(users);

    #endregion

    #region Writer

    var writer = serviceProvider.GetRequiredService<IWriter>();
    writer.WriteUsersToFile(completeUsers);

    #endregion
}