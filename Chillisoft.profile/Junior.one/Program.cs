// See https://aka.ms/new-console-template for more information

using Junior.one;
using Junior.one.HtmlStringManipulation;
using Junior.one.NullableGenerics;
using Junior.one.ReferenceTypes;
using System.Net.Http.Json;
using System.Text.Json;

//Console.WriteLine("Hello world");
//int jack = 5;
//DoSomeStuff(ref jack);
//Console.WriteLine(jack.ToString());
DisplayToken();

void DoSomeStuff(ref int bob)
{
    bob = 45;
}

void DisplayToken()
{
    var test = new PopulateTokenWithHtml();
    var token = test.PopulateTokenWithHtmlTags(HtmlInput());
    RecursiveTokenLoop(token, 0);
}
static void RecursiveTokenLoop(Token token, int depth)
{
    // Print the token at the current depth
    Console.WriteLine($"{new string(' ', depth * 2)}{token.Name}");
    if (token.Children?.Count == 0)
    {
        return;
    }
    // Recursive call for each child token
    foreach (var child in token.Children)
    {
        RecursiveTokenLoop(child, depth + 1);
    }
}
string HtmlInput()
{
    return
        "<div>" +
            "<parent>" +
                "<child>" +
                    "<grandchild>" +
                    "</grandchild>" +
                "</child>" +
                "<child2>" +
                "</child2>" +
            "</parent>" +
            "<uncle>" +
                "<niece>" +
                "</niece>" +
                "<nephew>" +
                "</nephew>" +
            "</uncle>" +
        "</div>"; 
}
// Generic repo
//new TestGenericListWithStaff().TestGenericRepoWithStaff();


// generic nullables
// new WriteNullable().write();

// statics
//new DifferenceBetweenStaticAndNonStaticVariableWritter().write();
//new StaticVariables().write();

// reference types and value types
//new References().ReferencesWritter();
//new References().ValueTypeWriter();

//funcs and action delegate methods
//Func<List<int>, int> AverageFunc = FuncsAndActions.CalculateAvarage;
//Action<string> WriteResults = Console.WriteLine;
//new DeelegateFunc().WriteMAx(AverageFunc, WriteResults, new List<int>() { 1, 2, 3, 4, 7, 1100 });

