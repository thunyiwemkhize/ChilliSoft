// See https://aka.ms/new-console-template for more information

using CleanArchitechure.InMemoryDB;
using CleanArchitecture.Domain;
using Newtonsoft.Json;

InMemoryUserGateway _usersGateWay = new InMemoryUserGateway();

void addUser()
{
    Console.WriteLine("Enter email address");
    var emailAddress = Console.ReadLine();
    var createUserUseCase = new CreateUserUseCase(_usersGateWay);
    var request = new CreateUserRequest()
    {
        EmailAddress = emailAddress
    };
    createUserUseCase.Execute(request, new PrefixedConsolePresenter("Added "));
}

while (true)
{
    Console.WriteLine("Press 1 to add user, press 2 to list users");
    var menuOption = Console.ReadLine();
    if (menuOption == "1")
    {
       addUser();
    }
    else if (menuOption == "2")
    {
        printUser();
    }
    else
    {
        break;
    }

}

void printUser()
{
    foreach (var user in _usersGateWay.FindAllUsers())
    {
        Console.WriteLine(JsonConvert.SerializeObject(user));
    }
}

public class PrefixedConsolePresenter: IPresenter
{
    private string _prefix;
    public PrefixedConsolePresenter(string prefix)
    {
        _prefix = prefix;
    }

    public void Error(string error)
    {
        Console.WriteLine($"added {error}");
    }

    public void Success(CreateUserResponse response)
    {
        Console.WriteLine($"added {JsonConvert.SerializeObject(response)}");
    }
}