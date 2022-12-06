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

            
            var position = 0;    
            var checklist = new List<char>();

                    foreach (var line in _inputData)
                    {
                        for (int i = 0; i < line.Length-13; i++)
			            {
                            checklist.Clear();

                            for (int j = 0; j < 14; j++)
			                {
                                checklist.Add(line[i+j]);
			                }
                            var hasdoubles = checklist.GroupBy(x=>x).Any(g=>g.Count() > 1);
                            if(hasdoubles) continue;
                            else 
                            {   
                                position = i+14;
                                Console.WriteLine("Position: " + position);
                                break;
                            }
                        }
                    }
                

            
	            
                
	       



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
