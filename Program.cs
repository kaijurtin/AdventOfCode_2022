using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace AdventOfCodeStartProject
{
    static public class AdventOfCode
    {
        //this field contains whats written in your input.txt
        //each line in the list of strings represents one line in the txt file
        //copy the data you get on the adventofcode website into the txt file and start coding!
        // private static List<string> _inputData;


        static void Main(string[] args)
        {
            //readInput();
            //Console.WriteLine("ENDE");
            //Console.ReadKey();

            var stopwatch = Stopwatch.StartNew();

            var data =
                (from line in File.ReadAllLines("input.txt")
                    where !string.IsNullOrWhiteSpace(line)
                    select line.ToArray()).ToArray();

            var start = (x: -1, y: -1);
            var end = (x: -1, y: -1);

            for (int x = 0; x < data.Length; ++x)
            for (int y = 0; y < data[0].Length; ++y)
            {
                if (data[x][y] == 'S')
                {
                    start = (x, y);
                    data[x][y] = 'a';
                }

                if (data[x][y] == 'E')
                {
                    end = (x, y);
                    data[x][y] = 'z';
                }
            }

            Dictionary<(int, int), int> distanceCache = new Dictionary<(int, int), int>() { { end, 0 } };

            void ComputeCost(int x, int y)
            {
                if (!distanceCache.TryGetValue((x, y), out var currentCost))
                    throw new InvalidOperationException($"Cannot compute cost for neighbors of {x},{y}");

                void ComputeNeighbor(int newX, int newY)
                {
                    if (newX < 0 || newX >= data.Length || newY < 0 || newY >= data[0].Length)
                        return;

                    if (data[newX][newY] + 1 >= data[x][y])
                    {
                        if (!distanceCache.TryGetValue((newX, newY), out var currentNeighborCost) ||
                            currentNeighborCost > currentCost + 1)
                        {
                            distanceCache[(newX, newY)] = currentCost + 1;
                            ComputeCost(newX, newY);
                        }
                    }
                }

                ComputeNeighbor(x - 1, y);
                ComputeNeighbor(x + 1, y);
                ComputeNeighbor(x, y - 1);
                ComputeNeighbor(x, y + 1);
            }

            ComputeCost(end.x, end.y);

            long GetPart1() =>
                distanceCache[(start.x, start.y)];

            long GetPart2()
            {
                var result = long.MaxValue;

                for (int x = 0; x < data.Length; ++x)
                for (int y = 0; y < data[0].Length; ++y)
                    if (data[x][y] == 'a' && distanceCache.TryGetValue((x, y), out var potential))
                        if (potential < result)
                            result = potential;

                return result;
            }

            Console.WriteLine($"[{stopwatch.Elapsed}] Pre-compute");

            stopwatch = Stopwatch.StartNew();
            var part1Result = GetPart1();
            Console.WriteLine($"[{stopwatch.Elapsed}] Part 1: {part1Result}");

            stopwatch = Stopwatch.StartNew();
            var part2Result = GetPart2();
            Console.WriteLine($"[{stopwatch.Elapsed}] Part 2: {part2Result}");

            Console.ReadKey();

        }

        //private static void readInput()
        //{
        //    _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        //}



    }
}
    


