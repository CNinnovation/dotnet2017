using CSharp7Samples;
using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        //BinaryLiteralsAndDigitSeparators();
        //RefLocalAndRefReturn();
        //OutVars();
        //LocalFunctions();
        // LambdaExpressionsEverywhere();
        // FlexibleAwaitAsync();
        // ThrowExpressions(42);
        // PatternMatching();
        TuplesAndDeconstruction();
        Console.WriteLine("press return to exit");
        Console.ReadLine();
    }



    private static void BinaryLiteralsAndDigitSeparators()
    {
        Console.WriteLine(nameof(BinaryLiteralsAndDigitSeparators));

        long l1 = 98_7654_3210L;
        long b1 = 0b1111_0000_1010_0101;
        Console.WriteLine($"{b1:X}");


        Console.WriteLine();
    }

    private static void RefLocalAndRefReturn()
    {
        Console.WriteLine(nameof(RefLocalAndRefReturn));
        int[] data = { 1, 2, 3, 4 };
        ref int result = ref GetByIndex(data, 2);
        result = 42;
        Console.WriteLine($"result: {result}");
        Console.WriteLine($"orig array element: {data[2]}");

        Console.WriteLine();
    }

    private static ref int GetByIndex(int[] data, int ix)
    {
        ref int a = ref data[ix];
        return ref a;
    }


    private static void OutVars()
    {
        Console.WriteLine(nameof(OutVars));
        Console.WriteLine("enter a number:");
        string input = Console.ReadLine();

        bool success = int.TryParse(input, out int result);
        if (success)
        {
            Console.WriteLine($"this number: {result}");
        }
        else
        {
            Console.WriteLine("NaN");
        }

        Console.WriteLine();
    }

    private static void LocalFunctions()
    {
        Console.WriteLine(nameof(LocalFunctions));

        //Func<int, int, int> add = (x, y) =>
        //{
        //    return x + y;
        //};

        int a = 3;

        int add(int x, int y) => x + y + a;
        //{
        //    return x + y + a;
        //}


        int result = add(1, 2);
        Console.WriteLine(result);

        Console.WriteLine();
    }


    private static void LambdaExpressionsEverywhere()
    {
        Console.WriteLine(nameof(LambdaExpressionsEverywhere));
        var p1 = new Person("Katharina Nagel");
        Console.WriteLine($"{p1.FirstName}");

        var p2 = new Person("Matthias Nagel") { Age = 6 };
        Console.WriteLine($"{p2.FirstName} {p2.Age}");

        Console.WriteLine();
    }

    private static async void FlexibleAwaitAsync()
    {
        Console.WriteLine(nameof(FlexibleAwaitAsync));

        int result = await MyBackgroundTask();
        Console.WriteLine(result);


        Console.WriteLine();
    }

    private static ValueTask<int> MyBackgroundTask()
    {

        return new ValueTask<int>(42);
    }

    private static void ThrowExpressions(object o)
    {
//        if (o == null) throw new ArgumentNullException(nameof(o));
        Console.WriteLine(nameof(ThrowExpressions));
        int x = 42;

        //int y = 0;
        //if (x <= 42)
        //{
        //    y = x;
        //}
        //else
        //{
        //    throw new Exception("bad value");
        //}

        int y = x <= 42 ? x : throw new Exception("bad value");

        object a = o ?? throw new ArgumentNullException(nameof(o));

        Console.WriteLine($"y: {y}");
        Console.WriteLine();
    }

    private static void PatternMatching()
    {
        Console.WriteLine(nameof(PatternMatching));
        object[] data = { 42, new Person("Stephanie Nagel"), null, "demo" };

        foreach (var item in data)
        {
            IsPattern(item);
        }
        Console.WriteLine();
        Console.WriteLine();

        foreach (var item in data)
        {
            SwitchPattern(item);
        }


        Console.WriteLine();
    }

    public static void IsPattern(object o)
    {
        if (o is null) Console.WriteLine("const pattern - o is null");
        if (o is 42) Console.WriteLine("const pattern - 42");
        if (o is int i) Console.WriteLine($"type pattern - int: {i}");
        if (o is Person p) Console.WriteLine($"type pattern - it's a Person: {p.FirstName}");
        if (o is Person p1 && p1.FirstName == "Stephanie") Console.WriteLine($"person Stephanie");
        if (o is var v1) Console.WriteLine($"var pattern - {v1?.GetType().Name}");
    }

    public static void SwitchPattern(object o)
    {
        switch (o)
        {
            case null:
                Console.WriteLine("const pattern - it's null");
                break;
            case int i:
                Console.WriteLine($"type pattern - int: {i}");
                break;
            case Person p when p.FirstName == "Stephanie":
                Console.WriteLine($"it's Stephanie");
                break;
            case Person p:
                Console.WriteLine($"Person {p.FirstName}");
                break;
            case var v1:
                Console.WriteLine($"var pattern {v1?.GetType().Name}");
                break;
            default:
                Console.WriteLine("default");
                break;

        }
    }

    private static void TuplesAndDeconstruction()
    {
        Console.WriteLine(nameof(TuplesAndDeconstruction));

        //        Tuple<int, string> t1 = Tuple.Create(42, "abc");

        (int i, string s) t1 = (42, "magic");
        Console.WriteLine(t1.i);
        Console.WriteLine(t1.s);

        (int res, int rem) = Divide(4, 3);
        Console.WriteLine($"result: {res}, remainder: {rem}");
        var t2 = Divide(7, 3);
        Console.WriteLine($"result: {t2.result}, remainder: {t2.remainder}");

        // Tuple is immutable
        Tuple<int, string> t3 = Tuple.Create(11, "abc");
        // t3.Item1 = 42;

        // ValueTuple is mutable, public fields - ok to break rules :-)
        (int i2, string s2) t4 = (11, "abc");
        t4.i2 = 42;

        var p1 = new Person("Stephanie Nagel");
        (string first, string last) = p1;

        Console.WriteLine($"{first} {last}");


        Console.WriteLine();
    }

    public static (int result, int remainder) Divide(int x, int y)
    {
        int res = x / y;
        int rem = x % y;
        return (res, rem);
    }



}