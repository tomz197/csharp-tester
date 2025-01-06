# csharp-tester

Simple class for c# testing

## Usage

1. Copy the [Tester.cs](/Tester.cs) file to your project
2. Update namespace to suit your project
3. Create a new instance of the `Tester` class
4. Test your code
5. Print the results

## Example

> [!IMPORTANT]
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

> [!NOTE]
> `Test passed.` is printed in green and errors in red.

![image](https://github.com/user-attachments/assets/91818a0a-555d-4078-994d-b8a0aca20d36)

