﻿// C# Collections
// Refer to:
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/collections

using static CollectionExamples;

class CollectionExamples
{
    public class Galaxy
    {
        public string Name { get; set; }
        public int MegaLightYears { get; set; }
    }

    public class Element
    {
        public required string Symbol { get; init; }
        public required string Name { get; init; }
        public required int AtomicNumber { get; init; }
    }

    private static Dictionary<string, Element> BuildDictionary() =>
        new()
        {
        {"K",
            new (){ Symbol="K", Name="Potassium", AtomicNumber=19}},
        {"Ca",
            new (){ Symbol="Ca", Name="Calcium", AtomicNumber=20}},
        {"Sc",
            new (){ Symbol="Sc", Name="Scandium", AtomicNumber=21}},
        {"Ti",
            new (){ Symbol="Ti", Name="Titanium", AtomicNumber=22}}
        };

    public class Fish
    {
        // Create a list of strings by using a
        // collection initializer.

        private List<string> salmons = ["chinook", "coho", "pink", "sockeye"];

        private List<int> numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

        public void IterateTheList()
        {
            // Iterate through the list.
            foreach (var salmon in salmons)
            {
                Console.Write(salmon + " ");
            }
            Console.WriteLine("\n\n");
            // Output: chinook coho pink sockeye

            // Remove an element from the list by specifying
            // the object.
            salmons.Remove("coho");


            // Iterate using the index:
            for (var index = 0; index < salmons.Count; index++)
            {
                Console.Write(salmons[index] + " ");
            }
            Console.WriteLine("\n\n");
            // Output: chinook pink sockeye

            // Add the removed element
            salmons.Add("coho");
            // Iterate through the list.
            foreach (var salmon in salmons)
            {
                Console.Write(salmon + " ");
            }
            Console.WriteLine("\n\n");
            // Output: chinook pink sockeye coho

        }
    }

    public class Numbers
    {
        List<int> numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

        public void RemoveOddNumbers()
        {
            // Remove odd numbers.
            for (var index = numbers.Count - 1; index >= 0; index--)
            {
                if (numbers[index] % 2 == 1)
                {
                    // Remove the element by specifying
                    // the zero-based index in the list.
                    numbers.RemoveAt(index);
                }
            }
        }

        public void IterateTheNumbers()
        {
            // Iterate through the list.
            // A lambda expression is placed in the ForEach method
            // of the List(T) object.
            numbers.ForEach(
            number => Console.Write(number + " "));
            // Output: 0 2 4 6 8
            Console.WriteLine("\n\n");
        }

        public void ListEvenNumbers()
        {
            foreach (int number in EvenSequence(5, 18))
            {
                Console.Write(number.ToString() + " ");
            }
            Console.WriteLine("\n\n");
            // Output: 6 8 10 12 14 16 18
        }

        private static IEnumerable<int> EvenSequence(
            int firstNumber, int lastNumber)
        {
            // Yield even numbers in the range.
            for (var number = firstNumber; number <= lastNumber; number++)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
            Console.WriteLine("\n\n");
        }
    }

    public class Elements
    {
        public Dictionary<string, Element> BuildDictionary() =>
            new()
            {
                {"K",
                    new (){ Symbol="K", Name="Potassium", AtomicNumber=19}},
                {"Ca",
                    new (){ Symbol="Ca", Name="Calcium", AtomicNumber=20}},
                {"Sc",
                    new (){ Symbol="Sc", Name="Scandium", AtomicNumber=21}},
                {"Ti",
                    new (){ Symbol="Ti", Name="Titanium", AtomicNumber=22}}
            };

        public void IterateThruDictionary()
        {
            Dictionary<string, Element> elements = BuildDictionary();

            foreach (KeyValuePair<string, Element> kvp in elements)
            {
                Element theElement = kvp.Value;

                Console.WriteLine("key: " + kvp.Key);
                Console.WriteLine("values: " + theElement.Symbol + " " +
                    theElement.Name + " " + theElement.AtomicNumber);
            }
            Console.WriteLine("\n\n");
        }

        public class Element
        {
            public required string Symbol { get; init; }
            public required string Name { get; init; }
            public required int AtomicNumber { get; init; }
        }

        public void ShowLINQ()
        {
            List<Element> elements = BuildList();

            // LINQ Query.
            var subset = from theElement in elements
                         where theElement.AtomicNumber < 22
                         orderby theElement.Name
                         select theElement;

            foreach (Element theElement in subset)
            {
                Console.WriteLine(theElement.Name + " " + theElement.AtomicNumber);
            }
            Console.WriteLine("\n\n");

            // Output:
            //  Calcium 20
            //  Potassium 19
            //  Scandium 21
        }

        private static List<Element> BuildList() => new()
        {
            { new(){ Symbol="K", Name="Potassium", AtomicNumber=19}},
            { new(){ Symbol="Ca", Name="Calcium", AtomicNumber=20}},
            { new(){ Symbol="Sc", Name="Scandium", AtomicNumber=21}},
            { new(){ Symbol="Ti", Name="Titanium", AtomicNumber=22}}
        };

    }

    static void Main()
    {
        Fish theFish = new Fish();

        theFish.IterateTheList();

        Numbers theNumbers = new Numbers();

        theNumbers.IterateTheNumbers();
        theNumbers.RemoveOddNumbers();
        theNumbers.IterateTheNumbers();
        theNumbers.ListEvenNumbers();

        var theGalaxies = new List<Galaxy>
        {
            new (){ Name="Tadpole", MegaLightYears=400},
            new (){ Name="Pinwheel", MegaLightYears=25},
            new (){ Name="Milky Way", MegaLightYears=0},
            new (){ Name="Andromeda", MegaLightYears=3}
        };

        foreach (Galaxy theGalaxy in theGalaxies)
        {
            Console.WriteLine(theGalaxy.Name + "  " + theGalaxy.MegaLightYears);
        }
        Console.WriteLine("\n\n");

        // Output:
        //  Tadpole  400
        //  Pinwheel  25
        //  Milky Way  0
        //  Andromeda  3

        List<string> symbols = ["K", "Na", "Ca", "Cl", "Sc", "Ti"];

        Elements theElements = new Elements();

        Console.WriteLine("IterateThruDictionary");
        theElements.IterateThruDictionary();

        Console.WriteLine("LINQ and collections");
        theElements.ShowLINQ();

        Dictionary<string, Element> elements = BuildDictionary();

        Console.WriteLine("foreach(symbols)");
        foreach (string symbol in symbols)
        {
            if (elements.ContainsKey(symbol) == false)
            {
                Console.WriteLine(symbol + " not found");
            }
            else
            {
                Element theElement = elements[symbol];
                Console.WriteLine("found: " + theElement.Name);
            }
        }
        Console.WriteLine("\n\n");

        Console.WriteLine("foreach()");
        foreach (string symbol in symbols)
        {
            if (elements.TryGetValue(symbol, out Element? theElement) == false)
                Console.WriteLine(symbol + " not found");
            else
                Console.WriteLine("found: " + theElement.Name);
        }
        Console.WriteLine("\n\n");
    }
}

