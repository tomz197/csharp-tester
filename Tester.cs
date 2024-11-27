using System;
using System.Text.Json;
using System.Collections.Generic;

namespace tester
{
    class Tester
    {
        public Tester(string name, bool printSuccess = true)
        {
            Name = name;
            Passed = 0;
            Failed = 0;

            DefaultColor = Console.ForegroundColor;
            PrintSuccess = printSuccess;
            PassedColor = ConsoleColor.Green;
            FailedColor = ConsoleColor.Red;

            Console.WriteLine($"\nRunning tests for {Name}...");
        }

        private string Name { get; set; }
        private bool PrintSuccess { get; set; }
        private int Passed { get; set; }
        private int Failed { get; set; }

        private ConsoleColor DefaultColor { get; set; }
        private ConsoleColor PassedColor { get; set; }
        private ConsoleColor FailedColor { get; set; }

        public void Test<T>(T expected, T actual)
        {
            if (IsDictionary(expected))
            {
                throw new ArgumentException("For testing Distionaries use `TestDictionary` method");

            }

            string expectedStr = JsonSerializer.Serialize(expected);
            string actualStr = JsonSerializer.Serialize(actual);

            if (expectedStr != actualStr)
            {
                Failed++;
                PrintWrongResult(() => Console.WriteLine(expectedStr), () => Console.WriteLine(actualStr));
                return;
            }
            Passed++;
            PrintSuccessResult();
        }

        private bool IsDictionary<T>(T val)
        {
            return val.GetType().IsGenericType && val.GetType().GetGenericTypeDefinition() == typeof(Dictionary<,>);
        }

        private void PrintWrongResult(Action printExpected, Action printActual)
        {
            Console.ForegroundColor = FailedColor;
            Console.WriteLine("Test failed:");
            Console.WriteLine("Expected:");
            printExpected();
            Console.WriteLine("Actual:");
            printActual();
            Console.WriteLine("Stack trace:");
            Console.WriteLine(Environment.StackTrace);
            Console.ForegroundColor = DefaultColor;
        }

        private void PrintSuccessResult()
        {
            if (!PrintSuccess)
            {
                return;
            }
            Console.ForegroundColor = PassedColor;
            Console.WriteLine("Test passed.");
            Console.ForegroundColor = DefaultColor;
        }

        public void PrintDictionary<TK, TV>(Dictionary<TK, TV> dict)
        {
            foreach (var kvp in dict)
            {
                string keyStr = JsonSerializer.Serialize(kvp.Key);
                string ValueStr = JsonSerializer.Serialize(kvp.Value);
                Console.WriteLine($"{keyStr} -> {ValueStr}");
            }
        }

        public void TestDictionary<TK, TV>(Dictionary<TK, TV> expected, Dictionary<TK, TV> actual)
        {
            if (expected.Count != actual.Count)
            {
                Failed++;
                PrintWrongResult(() => PrintDictionary(expected), () => PrintDictionary(actual));
                return;
            }

            foreach (var kvp in expected)
            {
                if (!actual.ContainsKey(kvp.Key) || actual[kvp.Key].ToString() != kvp.Value.ToString())
                {
                    Failed++;
                    PrintWrongResult(() => PrintDictionary(expected), () => PrintDictionary(actual));
                    return;
                }
            }

            Passed++;
            PrintSuccessResult();
        }

        public void PrintResults()
        {
            Console.WriteLine($"Results for {Name}:\n Passed: {Passed}\n Failed: {Failed}\n");
        }
    }
}

