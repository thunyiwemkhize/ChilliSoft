// See https://aka.ms/new-console-template for more information
using Junior.One.Token;

MakeToken makeToken = new MakeToken();

// Print tokens for verification
foreach (var token in makeToken.makeToken())
{
    Console.WriteLine($"Type: {token.Type}, Content: '{token.Content}', First Character: {token.FirstCharacter}, Last Character: {token.LastCharacter}");
}
Console.WriteLine("Hello, World!");

