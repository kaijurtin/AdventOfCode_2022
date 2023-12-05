using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;


namespace AdventOfCodeStartProject
{
    static public class AdventOfCode
    {
        //this field contains whats written in your input.txt
        //each line in the list of strings represents one line in the txt file
        //copy the data you get on the adventofcode website into the txt file and start coding!
        private static List<string> _inputData;

            enum num
        {
            zero = 0,
            one = 1,
            two = 2,
            three = 3,
            four = 4,
            five = 5,
            six = 6,
            seven = 7,
            eight = 8,
            nine = 9
        }

        static void Main(string[] args)
        {
            readInput();

            var stopwatch = Stopwatch.StartNew();

            //var data =
            //    (from line in File.ReadAllLines("input.txt")
            //        where !string.IsNullOrWhiteSpace(line)
            //        select line.ToArray()).ToArray();
        

        var val = string.Empty;
        int sum = 0;

        foreach (string line in _inputData)
            {       
                var row = string.Empty;

                for (int i = 0; i<line.Length; i++) 
                {
                    if (char.IsDigit(line[i]))
                        row += line[i];
                    if()
                }
                if(row.Length > 0)
                {
                    val = String.Concat(row[0], row[row.Length - 1]); 
                sum += Convert.ToInt32(val);
                }
                
            }
            Console.WriteLine(sum);
Console.ReadLine();
        
        
        
        }


        private static void readInput()
{
    _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
}



    }
}



