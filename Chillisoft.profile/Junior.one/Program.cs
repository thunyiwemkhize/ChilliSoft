// See https://aka.ms/new-console-template for more information

using Junior.one;
using Junior.one.NullableGenerics;
using Junior.one.ReferenceTypes;

Console.WriteLine("Hello world");
int jack = 5;
DoSomeStuff(ref jack);
Console.WriteLine(jack.ToString());

void DoSomeStuff(ref int bob)
{
    bob = 45;
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

