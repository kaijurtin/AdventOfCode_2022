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

       //     var data =
       //         (from line in File.ReadAllLines("input.txt")
       //             where !string.IsNullOrWhiteSpace(line)
       //            select line.ToArray()).ToArray();


        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }
var row = new List<int>();

        foreach (var line in File.ReadAllLines("input.txt")
        {
            for (int i = 0; i < line.Length; i++)
            {
            if (Char.IsDigit(line[i]))
               row += line[i];
        }

         
             }
}



