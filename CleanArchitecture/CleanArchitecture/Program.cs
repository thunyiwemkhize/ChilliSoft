// See https://aka.ms/new-console-template for more information

using CleanArchitechure.InMemoryDB;
using CleanArchitecture.Domain;
using Newtonsoft.Json;

InMemoryUserGateway _usersGateWay = new InMemoryUserGateway();

User addUser()
{
    Console.WriteLine("Enter email address");
    var emailAddress = Console.ReadLine();
    var createUserUseCase = new CreateUserUseCase(_usersGateWay);
    var request = new CreateUserRequest()
    {
        EmailAddress = emailAddress
    };
    return createUserUseCase.Execute(request);
}

while (true)
{
    Console.WriteLine("Press 1 to add user, press 2 to list users");
    var menuOption = Console.ReadLine();
    if (menuOption == "1")
    {
       var newUser = addUser();
       Console.WriteLine($"added {JsonConvert.SerializeObject(newUser)}");
    }
    else if (menuOption == "2")
    {
        prinUser();
    }
    else
    {
        break;
    }

}

void prinUser()
{
    foreach (var user in _usersGateWay.FindAllUsers())
    {
        Console.WriteLine(JsonConvert.SerializeObject(user));
    }
}