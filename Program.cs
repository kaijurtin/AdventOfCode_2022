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
            var first = 0;
            var last = 0;


            foreach (string line in _inputData)
	        {
                var pairs = line.Split(',');
                var pairOne = pairs[0].Split('-').ToList();
                var pairTwo = pairs[1].Split('-').ToList();

                List<int> one = pairOne.ConvertAll(i => int.Parse(i));  
                List<int> two = pairTwo.ConvertAll(i => int.Parse(i));  

                

                if(one.First() <= two.First() && one.Last() >= two.Last())
                    { 
                    total++;
                    first++;
                    //Console.WriteLine("first pair contains second pair fully");
                    continue;
                    }

                if(two.First() <= one.First() && two.Last() >= one.Last())
                    {
                    total++;
                    last++;
                    //Console.WriteLine("second pair contains first pair fully");
                    continue;
                    }

	        }

            Console.WriteLine("total: " + total);
            Console.WriteLine("first: " + first);
            Console.WriteLine("last: " + last);

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
