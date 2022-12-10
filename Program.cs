using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace AdventOfCodeStartProject
{
    static public class AdventOfCode
    {
        //this field contains whats written in your input.txt
        //each line in the list of strings represents one line in the txt file
        //copy the data you get on the adventofcode website into the txt file and start coding!
        private static List<string> _inputData;
        private static List<int> sums = new List<int>();

        static void Main(string[] args)
        {
            readInput();
            var cycle = 0;
            var cc = 0;
            var x = 1;
            

            foreach(string l in _inputData)
            {
                //l.Split(' ');
                if (l.Substring(0,4).Equals("noop"))
                {
                    cycle++;
                    checkCycle(cycle,x);
                    Console.WriteLine("cycle: " + cycle);
                }

                if (l.Substring(0, 4).Equals("addx"))
                {
                    cycle++;
                    checkCycle(cycle, x);
                    cycle++;
                    checkCycle(cycle, x);
                    Console.WriteLine("cycle: " + cycle);
                    x += Convert.ToInt32(l.Substring(5, l.Length-5));
                    Console.WriteLine("X: " + x);

                }








            }
            foreach (var item in sums)
            {
            Console.WriteLine("sums: " + item);
            }
            Console.WriteLine("total: " + sums.Sum());
            Console.WriteLine("ENDE");
            Console.ReadKey();

        }
        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }
        private static void checkCycle(int cycle, int x)
        {
            var cyclechecks = new List<int>() { 20, 60, 100, 140, 180, 220 };
            if (cyclechecks.Contains(cycle))
            {
                var num = cycle * x;
                sums.Add(num);
            }
        }
        private static string position(int x, int y)
        {
            return $"{x.ToString()},{y.ToString()}";
        }

    }
}
    


