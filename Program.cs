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


                    foreach (var line in _inputData)
                    {
                        for (int i = 0; i < line.Length-3; i++)
			            {
                            if (line[i] != line[i+1] && line[i] != line[i+2] && line[i] != line[i+3])
                                {
                                Console.WriteLine(line[i].ToString() + line[i+1] + line[i+2] + line[i+3]);
                                var j = i+1;    
                                if (line[j] != line[j+1] && line[j] != line[j+2])
                                    {
                                    var k = j+1;    
                                    if (line[k] != line[k+1])
                                        {
                                        position = k+2; 
                                        Console.WriteLine(line[i].ToString() + line[i+1] + line[i+2] + line[i+3]);
                                        break;
                                        }
                                    else continue;
                                    }
                                else continue;
                                }
                            else continue;
                         }
                    }
                

            
	            
                Console.WriteLine("Position: " + position);
	       



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
