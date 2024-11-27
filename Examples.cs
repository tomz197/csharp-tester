using System;
using System.Collections.Generic;

namespace tester
{
    class Examples
    {
        public static void Successfull()
        {
            Tester tester = new Tester("Succesfull Example");

            tester.Test(1, 1);
            tester.Test(1.0, 1.0);
            tester.Test(true, true);
            tester.Test("nice", "nice");

            tester.Test(new[] { 1, 2, 3 }, new[] { 1, 2, 3 });
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
            tester.Test(Examples.TestGenerator(5), Examples.TestGenerator(5));


            // For testing dictionaries use `TestDictionary` method
            tester.TestDictionary(new System.Collections.Generic.Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 }
            }, new System.Collections.Generic.Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 }
            });

            tester.PrintResults();
        }

        public static void SuccessfullWithoutPrint()
        {
            Tester tester = new Tester("Succesfull without print Example", true);

            tester.Test(1, 1);
            tester.Test(1.0, 1.0);
            tester.Test(true, true);
            tester.Test("nice", "nice");

            tester.PrintResults();
        }

        public static void Failed()
        {
            Tester tester = new Tester("Faild Example", true);

            tester.Test(1, 2);
            tester.TestDictionary(new System.Collections.Generic.Dictionary<string, int>
            {
                { "two", 2 },
                { "one", 1 },
                { "three", 3 }
            }, new System.Collections.Generic.Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 4 }
            });

            tester.PrintResults();
        }

        public static void Readme1()
        {
            Tester tester = new Tester("My tester");

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

            tester.Test(2, 3);

            tester.PrintResults();
        }


        static private IEnumerable<int> TestGenerator(int n)
        {
            for (int i = 0; i < n; i++)
            {
                yield return i;
            }
        }
    }
}
