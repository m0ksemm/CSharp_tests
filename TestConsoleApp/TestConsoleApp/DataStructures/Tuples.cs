using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsoleApp.DataStructures
{
    public class Tuples
    {
        public static void Show()
        {
            Console.WriteLine(1);
            //Tupples

            // Tuple with named elements
            (string Name, int Age) person1 = ("Test Name", 1);
            Console.WriteLine(person1.Name + " " + person1.Age);

            // Tuple with default element names (Item1, Item2)
            (string, int) test = ("testttt", 32);
            Console.WriteLine(test.Item1 + " " + test.Item2);

            // Tuple declared with var and inline names
            var tupple = (Name: "Seatle", Population: 749_256);
            Console.WriteLine(tupple.Name + " " + tupple.Population);

            Console.WriteLine("\n\n"+2);
            var name1 = "Carol";
            var age = 28;

            // The compiler infers element names from the variable names
            var person2 = (name1, age);
            Console.WriteLine($"{person2.name1} is {person2.age}");

            static (double Minimum, double Maximum, double Average) ComputeStats(List<double> values)
            {
                var min = values.Min();
                var max = values.Max();
                var avg = values.Average();
                return (min, max, avg);
            }

            var touple = ComputeStats([1, 2, 3, 4, 5, 6, 7, 8, 9]);
            Console.WriteLine(touple.Minimum + " " + touple.Maximum + " " + touple.Average);

            Console.WriteLine("\n\n" + 3);

            var point = (X: 3, Y: 7);

            // Deconstruct with var (infer all types)
            var (x, y) = point;
            Console.WriteLine($"x={x}, y={y}");

            // Deconstruct with explicit types
            (int px, int py) = point;
            Console.WriteLine($"px={px}, py={py}");

            // Deconstruct into existing variables
            int a, b;
            (a, b) = point;
            Console.WriteLine($"a={a}, b={b}");

            // Deconstruct a method return value directly
            List<double> data = [10.0, 20.0, 30.0];
            var (min, max, avg) = ComputeStats(data);
            Console.WriteLine($"Min: {min}, Max: {max}, Avg: {avg}");


            Console.WriteLine("\n\n" + 4);
            // You can deconstruct tuples directly in foreach loops,
            // which makes iterating over collections of grouped values concise:
            List<(string Name, int Score)> results =
            [
                ("Alice", 92),
                ("Bob", 87),
                ("Carol", 95)
            ];

            foreach (var (name, score) in results)
            {
                Console.WriteLine($"{name}: {score}");
            }


            Console.WriteLine("\n\n" + 5);
            //When you don't need every element, use a discard (_)
            //in place of each value you want to ignore. Use a separate _ for each discarded position:
            List<double> values = [5.0, 10.0, 15.0];
            var (_, max2, _) = ComputeStats(values);
            Console.WriteLine($"Only need the max: {max2}");
            // Output: Only need the max: 15


            Console.WriteLine("\n\n" + 6);
            //You can compare tuples using == and !=. These operators compare each element in order,
            //so two tuples are equal when all their corresponding elements are equal:

            var order1 = (Product: "Widget", Quantity: 5);
            var order2 = (Product: "Widget", Quantity: 5);
            var order3 = (Product: "Gadget", Quantity: 3);

            Console.WriteLine(order1 == order2); // True
            Console.WriteLine(order1 == order3); // False

            // Element names don't affect equality—only values matter
            var named = (X: 1, Y: 2);
            var different = (A: 1, B: 2);
            Console.WriteLine(named == different); // True


            Console.WriteLine("\n\n" + 7);
            //The with expression creates a copy of a tuple with one or more elements changed, leaving the original unchanged:
            var original = (Name: "Widget", Price: 19.99m, InStock: true);
            var discounted = original with { Price = 14.99m };

            Console.WriteLine($"Original: {original.Name} at {original.Price:C}");
            Console.WriteLine($"Discounted: {discounted.Name} at {discounted.Price:C}");
            // Output:
            // Original: Widget at $19.99
            // Discounted: Widget at $14.99


            Console.WriteLine("\n\n" + 8);
            //Tuples make convenient dictionary values when you need to associate a key with multiple pieces of data:
            var sizeChart = new Dictionary<string, (int Min, int Max)>
            {
                ["Small"] = (0, 50),
                ["Medium"] = (51, 100),
                ["Large"] = (101, 200)
            };

            if (sizeChart.TryGetValue("Medium", out var range))
            {
                Console.WriteLine($"Medium: {range.Min}–{range.Max}");
            }
            // Output: Medium: 51–100


            Console.WriteLine("\n\n" + 9);
            //Tuples also work as dictionary keys, giving you a composite key without defining a custom type.
            //Because tuples implement structural equality, lookups match on the combined values of all elements:
            var grid = new Dictionary<(int Row, int Column), string>
            {
                [(0, 0)] = "Origin",
                [(1, 3)] = "Sensor A",
                [(2, 5)] = "Sensor B"
            };

            var target = (Row: 1, Column: 3);
            if (grid.TryGetValue(target, out var label))
            {
                Console.WriteLine($"({target.Row}, {target.Column}): {label}");
            }
            // Output: (1, 3): Sensor A

        }
    }
}
