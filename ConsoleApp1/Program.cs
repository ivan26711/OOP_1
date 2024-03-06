using static Program;

public static class Program
{
    public static void Main()
    {
        chiclo a1 = new chiclo(1,1);
        chiclo a2 = new chiclo(2, 2);
        var c = new chiclo(1, 2);
        Console.WriteLine(c);
        chiclo sum = a1 + a2;
        chiclo dif = a1 - a2;
        chiclo prod = a1 * a2;
        chiclo quot = a1 / a2;
        chiclo g = -a1;
        Console.WriteLine($"Сумма: , {sum}");
        Console.WriteLine($"Разность: , {dif.ToString()}");
        Console.WriteLine($"Умножение: , {prod.ToString()}");
        Console.WriteLine($"Деление: , {quot.ToString()}");
        Console.WriteLine($"Унарный минус: , {g.ToString()}");


        Console.WriteLine(a1 == a2);
        Console.WriteLine(a1 != a2);
        Console.WriteLine(a1 < a2);
        Console.WriteLine(a1 <= a2);
        Console.WriteLine(a1 > a2);
        Console.WriteLine(a1 >= a2);
    }
}

public class chiclo
{
    //private int numerator;
    //public int Numerator
    //{
    //    get
    //    {
    //        return numerator;
    //    }
    //    private set
    //    {
    //        numerator = value;
    //    }
    //}
    //private int denominator;
    //public int Denominator
    //{
    //    get
    //    {
    //        return denominator; ;
    //    }
    //    private set
    //    {
    //        denominator = value;
    //    }
    //}
    public int Numerator { get; private set; }

    public int Denominator { get; private set; }

    public chiclo(int a1, int a2)
    {
        if (a2 == 0)
            throw new ArgumentException("Argument Exception", nameof(a2));

        Numerator = a1;
        Denominator = a2;
    }

    //public override string ToString()
    //{
    //   return $"{Numerator}/{Denominator}";
    //}
    private int FindGreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public override string ToString()
    {
        int gcd = FindGreatestCommonDivisor(Numerator, Denominator);
        int simplifiedNumerator = Numerator / gcd;
        int simplifiedDenominator = Denominator / gcd;

        int whole = simplifiedNumerator / simplifiedDenominator;
        int remainder = simplifiedNumerator % simplifiedDenominator;

        if (remainder == 0)
        {
            return $"{whole}";
        }
        else if (whole == 0)
        {
            return $"{simplifiedNumerator}/{simplifiedDenominator}";
        }
        else
        {
            return $"{whole} {Math.Abs(remainder)}/{simplifiedDenominator}";
        }
    }



    public static chiclo operator +(chiclo a1, chiclo a2)
    {
        return new chiclo(a1.Numerator * a2.Denominator + a2.Numerator * a1.Denominator, a1.Denominator * a2.Denominator);
    }

    public static chiclo operator -(chiclo a1, chiclo a2)
    {
        return new chiclo(a1.Numerator * a2.Denominator - a2.Numerator * a1.Denominator, a1.Denominator * a2.Denominator);
    }

    public static chiclo operator *(chiclo a1, chiclo a2)
    {
        return new chiclo(a1.Numerator * a2.Numerator, a1.Denominator * a2.Denominator);
    }

    public static chiclo operator /(chiclo a1, chiclo a2)
    {
        return new chiclo(a1.Numerator * a2.Denominator, a2.Numerator * a1.Denominator);
    }
    public static chiclo operator - (chiclo a1)
    {
        return new chiclo(-a1.Numerator, a1.Denominator);
    }

    public static bool operator == (chiclo a1,chiclo a2)
    {
        return (a1.Numerator  == a2.Numerator) && (a1.Denominator == a2.Denominator);   
    }

    public static bool operator !=(chiclo a1, chiclo a2)
    {
        return !(a1.ToString() != a2.ToString());
    }

    public static bool operator <(chiclo a1, chiclo a2)
    {
        return (a1.Numerator * a2.Denominator < a2.Numerator* a1.Denominator);
    }

    public static bool operator <=(chiclo a1, chiclo a2)
    {
        return a1<a2 || a1==a2;
    }

    public static bool operator >(chiclo a1, chiclo a2)
    {
        return !(a1 < a2);
    }


    public static bool operator >=(chiclo a1, chiclo a2)
    {
        return !(a1 <= a2);
    }

}