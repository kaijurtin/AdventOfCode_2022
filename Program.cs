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
        private static List<string> _inputData;


        static void Main(string[] args)
        {
            readInput();

            var stopwatch = Stopwatch.StartNew();

            //var data =
            //    (from line in File.ReadAllLines("input.txt")
            //        where !string.IsNullOrWhiteSpace(line)
            //        select line.ToArray()).ToArray();

            Tuple<string, string, int> couple = new Tuple<string, string, int>(null, null, 0);
            List<int> correct = new List<int>();
            var num = 0;


            for (int i = 0; i < _inputData.Count; i = i + 3)
            {
                foreach (var c in correct)
                {
                    Console.WriteLine(c);
                }

                if (_inputData[i] != string.Empty)
                {
                    num++;
                    couple = Tuple.Create(_inputData[i], _inputData[i + 1], num);
                }

                var left = couple.Item1;//.ToCharArray();
                var right = couple.Item2;//.ToCharArray();
                //compare
                while (left != null && right != null)
                {
                    int lf = 0;
                    int rg = 0;

                    right = cleanString(right);
                    if (right != null)
                    {
                        try
                        {
                            rg = int.Parse(right.Substring(0,2).ToString());
                        }
                        catch
                        {
                            int.TryParse(right.First().ToString(), out rg);
                        }
                    }
                    else
                    {
                        continue;
                    }


                    left = cleanString(left);
                    if (left != null)
                    {
                        try
                        {
                            lf = int.Parse(left.Substring(0, 2).ToString());
                        }
                        catch
                        {
                        int.TryParse(left.First().ToString(), out lf);
                        }

                    }
                    else
                    {
                        correct.Add(num);
                        break;
                    }


                   
                    
                    if (lf < rg)
                    {
                        correct.Add(num);
                        break;
                    }

                    if (rg < lf)
                    {
                        break;
                    }


                    left = left.Remove(0, 1);
                    right = right.Remove(0, 1);
                    if (left != null && right == null)
                    {
                        break;
                    }
                    if (right != null && left == null)
                    {
                        correct.Add(num);
                        break;
                    }

                }
            }





            //long GetPart1() => 0;
            //long GetPart2() => 0;
            //Console.WriteLine($"[{stopwatch.Elapsed}] Pre-compute");

            //stopwatch = Stopwatch.StartNew();
            //var part1Result = GetPart1();
            //Console.WriteLine($"[{stopwatch.Elapsed}] Part 1: {part1Result}");

            //stopwatch = Stopwatch.StartNew();
            //var part2Result = GetPart2();
            //Console.WriteLine($"[{stopwatch.Elapsed}] Part 2: {part2Result}");



            var part1Result = correct.Sum();
            Console.WriteLine($"[{stopwatch.Elapsed}] Part 1: {part1Result}");

            Console.WriteLine("ENDE");
            Console.ReadKey();


        }

        private static void check(string left, string right)
        {

        }
        private static string cleanString(string str)
        {
            var result = "";
            if (!String.IsNullOrEmpty(str))
            {
                while (str.First().Equals(',') || str.First().Equals('[') || str.First().Equals(']'))
                {
                    if (!String.IsNullOrEmpty(str) && str.Length > 1)
                    {
                        str = str.Substring(1, str.Length - 1);
                    }
                    else
                    {
                        str = null;
                        break;
                    }
                }
                result = str;
            }
            else result = null;
            return result;
        }

        private static string removeBrackets(string str)
        {
            while (str.First().Equals('['))
            {
                str = str.Substring(1, str.Length - 1);
            }
            return str;
        }

        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }



    }
}



