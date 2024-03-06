using System;
using System.Globalization;



public class EuropeanDateTimePrinter
{
    public string PrintDateTime(DateTime dateTime)
    {
        CultureInfo cultureInfo = new CultureInfo("ru-RU"); 
        return dateTime.ToString("f", cultureInfo); 
    }
}

public class AmericanDateTimePrinter
{
    public string PrintDateTime(DateTime dateTime)
    {
        CultureInfo cultureInfo = new CultureInfo("en-US"); 
        return dateTime.ToString("f", cultureInfo); 
    }
}


public class SymbolDecorator
{
    private string symbol;

    public SymbolDecorator(string symbol)
    {
        this.symbol = symbol;
    }

    public string Decorate(string input)
    {
        StringBuilder builder = new StringBuilder(input);
        builder.Append(symbol);
        return builder.ToString();
    }
}

class Program
{
    static void Main()
    {
        DateTime currentDateTime = DateTime.Now;

        EuropeanDateTimePrinter europeanPrinter = new EuropeanDateTimePrinter();
        AmericanDateTimePrinter americanPrinter = new AmericanDateTimePrinter();

        string europeanDateTime = europeanPrinter.PrintDateTime(currentDateTime);
        string americanDateTime = americanPrinter.PrintDateTime(currentDateTime);

        Console.WriteLine("European Style: " + europeanDateTime);
        Console.WriteLine("American Style: " + americanDateTime);


        SymbolDecorator decorator1 = new SymbolDecorator(" - ");
        SymbolDecorator decorator2 = new SymbolDecorator("*");

        SymbolDecorator decorator3 = new SymbolDecorator("/");
        SymbolDecorator decorator4 = new SymbolDecorator("papa");


        string decoratedEuropeanDateTime = decorator2.Decorate(decorator1.Decorate(europeanDateTime));
        string decoratedAmericanDateTime = decorator3.Decorate(decorator2.Decorate(americanDateTime));

        string decoratedAmericanDateTimee = decorator4.Decorate(americanDateTime);

        Console.WriteLine("Decorated European Style: " + decoratedEuropeanDateTime);
        Console.WriteLine("Decorated American Style: " + decoratedAmericanDateTime);
        Console.WriteLine("Decorated American Style: " + decoratedAmericanDateTimee);
    }
}
