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
        
        static void Main(string[] args)
        {
            readInput();
            var input = _inputData;
            int hx = 0;
            int hy = 0;
            int tx = 0;
            int ty = 0; 
            var resty = 0;
            var restx=0;


            var pos = new List<Tuple<int,int>>();
            pos.Add(new Tuple<int,int>(hx,hy));
            
            foreach (var line in input)
            {
                line.Split(' ');
                var dir = line[0].ToString();
                int steps = Convert.ToInt32(line.Substring(2));
            
                //moving right
                for (int i = steps; i > 0; i--)
			    {
                    var beforehx=hx;
                    var beforehy=hy;    

                    switch (dir)
                    { 
                        case "R":
                        hx++;
                        break;
                        case "L":
                        hx--;
                        break;
                        case "U":
                        hy++;
                        break;
                        case "D":                        
                        hy--;
                        break;
                        default:
                            break;
                    }
                
                    //tail move
                    int difx = hx-tx; 
                    int dify = hy-ty;

                    if(Math.Abs(difx) > 1 || Math.Abs(dify) > 1)
                    {
                        tx=beforehx;
                        ty=beforehy;
                    }
                    pos.Add(Tuple.Create(tx,ty));

                }
            }
            var sum = pos.Distinct().Count();
            

            Console.WriteLine("SUM: " + sum);
            Console.WriteLine("ENDE");
            Console.ReadKey();

        }
        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }
    }
}


