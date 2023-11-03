// See https://aka.ms/new-console-template for more information

using Junior.one;
using Junior.one.Delegates;
using Junior.one.NullableGenerics;
using Junior.one.ReferenceTypes;
using Junior.one.Statics;

Console.WriteLine("Hello world");
// Generic repo
//new TestPerson().testPerson();


// generic nullables
//new NullableWriter().write();

// statics
//new DifferenceBetweenStaticAndNonStaticVariableWritter().write();
//new StaticVariables().write();

// reference types and value types
//new References().ReferencesWritter();
//new References().ValueTypeWriter();

//funcs and action delegate methods
Func<List<int>, int> AverageFunc = FuncsAndActions.CalculateAvarage;
Action<string> WriteResults = Console.WriteLine;
new DeelegateFunc().WriteMAx(AverageFunc, WriteResults, new List<int>() { 1, 2, 3, 4, 7, 1100 });

