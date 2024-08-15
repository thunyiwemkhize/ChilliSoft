// See https://aka.ms/new-console-template for more information

using Faker;

public class DataGenerator
{
    public int CreateRandomYear()
    {
        return NumberFaker.Number(1980, 2006);
    }
    public string CreateRandomString()
    {
        return TextFaker.Sentence().Substring(5, 30);
    }

    public string CreateName()
    {
        return NameFaker.Name();
    }
}
