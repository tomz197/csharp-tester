# csharp-tester

Simple class for c# testing

## Usage

1. Copy the `Tester.cs` file to your project
2. Update namespace to suit your project
3. Create a new instance of the `Tester` class
4. Test your code
5. Print the results

## Example

> [!NOTE]
> Testing dictionaries is not supported by the `Test` method. Use the `TestDictionary` method instead.

```csharp
using System;
using System.Collections.Generic;

namespace csharp_tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Tester tester = new Tester("My tester");

            // correct tests
            tester.Test(2, 2);
            tester.Test("nice", "nice");
            tester.Test(new
            {
                Name = "John",
                Age = 25,
                Adress = new
                {
                    Street = "1234",
                    City = "New York"
                }
            }, new
            {
                Name = "John",
                Age = 25,
                Adress = new
                {
                    Street = "1234",
                    City = "New York"
                }
            });

            // testing dictionaries
            tester.TestDictionary(new System.Collections.Generic.Dictionary<string, int>
            {
                { "two", 2 },
                { "one", 1 },
                { "three", 3 }
            }, new System.Collections.Generic.Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 }
            });

            // incorrect tests
            tester.Test(2, 3);

            tester.PrintResults();
        }
    }
}
```

## Output

```
Running tests for My tester...
Test passed.
Test passed.
Test passed.
Test passed.
Test failed:
Expected:
2
Actual:
3
Stack trace:
   at System.Environment.get_StackTrace()
   at tester.Tester.PrintWrongResult(Action printExpected, Action printActual) in /csharp-tester/Tester.cs:line 67
   at tester.Tester.Test[T](T expected, T actual) in /csharp-tester/Tester.cs:line 46
   at tester.Examples.Readme1() in /csharp-tester/Examples.cs:line 125
   at tester.Program.Main(String[] args) in /csharp-tester/Program.cs:line 12
Results for My tester:
 Passed: 4
 Failed: 1
```

