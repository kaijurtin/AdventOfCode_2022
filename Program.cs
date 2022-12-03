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

            
            
            var total = 0;
            for (int i = 0; i < _inputData.Count; i=i+3)
            {
                var one = _inputData[i];
                var two = _inputData[i + 1];    
                var three = _inputData[i + 2];

                var listOfCharsInOne = one.Distinct().ToList();
                foreach (char c in listOfCharsInOne)
                {
                    if (two.Contains(c) && three.Contains(c))
                    {
                        Console.WriteLine("common Letter: " + c);
                        var value = findValue(c);
                        Console.WriteLine("value: " + value);
                        total += value;


                        Console.WriteLine("total: " + total);
                    }
                }

            }





            //keep console open
            Console.WriteLine("Hit any key to close this window...");
                Console.ReadKey();
            
        }
        private static int findValue(char c)
        {
            var valueString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return valueString.IndexOf(c) + 1 ;
        }
        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }
    }
}
