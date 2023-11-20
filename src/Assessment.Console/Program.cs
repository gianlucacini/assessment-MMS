// See https://aka.ms/new-console-template for more information

global using static System.Console;
using Assessment.Console.BusinessLogic;
using Microsoft.Extensions.DependencyInjection;

const string origin = "http://localhost:5000/";
const string separator = ";";
const string extension = ".txt";

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

    var services = new ServiceCollection()
    .AddTransient<IReader>(rdr => new Reader(path, extension, separator))
    .AddTransient<IRetriever>(ret => new Retriever(origin))
    .AddTransient<IWriter>(wri => new Writer(path, extension));

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