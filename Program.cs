using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace AdventOfCodeStartProject
{
    static class AdventOfCode
    {
        //this field contains whats written in your input.txt
        //each line in the list of strings represents one line in the txt file
        //copy the data you get on the adventofcode website into the txt file and start coding!
        private static List<string> _inputData;

        static void Main(string[] args)
        {
            //EXAMPLE CODE
            //hit F5 to run it

            //read data from input.txt and write it into inputdata field
            readInput();
            //var intlist = _inputData.Select(i => int.Parse(i)).ToList();
            //lets write the contents of the input.txt into the console

            //Console.WriteLine("Content of input.txt:");
            //_inputData.ForEach(i => Console.WriteLine(i));
            //Console.WriteLine($"--END OF FILE--{Environment.NewLine}");
            //List<int> _inputDataINT = _inputData.ConvertAll(item => int.Parse(item));
            int points = 0;
            int total = 0;
            //var intList = _inputData.Where(i => !string.IsNullOrEmpty(i)).Select(i => int.Parse(i)).ToList();
            //var intList = _inputData.Where(i => !string.IsNullOrEmpty(i)).Select(i => int.Parse(i)).ToList();
            foreach (string s in _inputData)
            {
                switch (s)
	            {

		            case "A X":
                        points = 1 + 3;
                        break;
                        case "A Y":
                        points = 2 + 6;
                        break;
                        case "A Z":
                        points = 3 + 0;
                        break;
                        case "B X":
                        points = 1 + 0;
                        break;
                        case "B Y":
                        points = 2 + 3;
                        break;
                        case "B Z":
                        points = 3 + 6;
                        break;
                        case "C X":
                        points = 1 + 6;
                        break;
                        case "C Y":
                        points = 2 + 0;
                        break;
                        case "C Z":
                        points = 3 + 3;
                        break;

                    default: points = 0;
                break;
	            }
            total += points;

            }

            Console.WriteLine("total: " + total);
            
            
            
            //keep console open
            Console.WriteLine("Hit any key to close this window...");
                Console.ReadKey();
            
        }
        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }
    }
}
