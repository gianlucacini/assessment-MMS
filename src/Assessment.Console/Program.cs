// See https://aka.ms/new-console-template for more information

global using static System.Console;
using Assessment.Console.BusinessLogic;

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

    #region Reader

    var reader = new Reader(path, extension, separator);
    var users = reader.GetUsersFromCsv();

    #endregion

    #region Retriever

    var retriever = new Retriever(origin);
    var completeUsers = retriever.GetCompleteUsers(users);

    #endregion

    #region Writer

    var writer = new Writer(path, extension);
    writer.WriteUsersToFile(completeUsers);

    #endregion
}