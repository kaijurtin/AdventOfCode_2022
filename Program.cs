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
            var movex = new List<int>() { hx,0,0,0,0,0,0,0,0,tx};
            var movey = new List<int>() { hy,0,0,0,0,0,0,0,0,ty};
            var diffx = new List<int>() { 0,0,0,0,0,0,0,0,0,0};
            var diffy = new List<int>() { 0,0,0,0,0,0,0,0,0,0};
            var beforex = new List<int>() { 0,0,0,0,0,0,0,0,0,0};
            var beforey = new List<int>() { 0,0,0,0,0,0,0,0,0,0};

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
                    for (int g = 0; g < movex.Count; g++)
                    {
                        beforex[g]=movex[g];
                        beforey[g]=movey[g];
                    }

                    switch (dir)
                    { 
                        case "R":
                        movex[0]++;
                        break;
                        case "L":
                        movex[0]--;
                        break;
                        case "U":
                        movey[0]++;
                        break;
                        case "D":                        
                        movey[0]--;
                        break;
                        default:
                            break;
                    }
                
                    //tail move
                    for(int k=0; k < movex.Count-1; k++)
                    {
                        diffx[k] = movex[k]-movex[k+1]; 
                        diffy[k] = movey[k]-movey[k+1];
                        
                        if(Math.Abs(diffx[k]) > 1 || Math.Abs(diffy[k]) > 1)
                        {
                                movex[k+1]=beforex[k];
                                movey[k+1]=beforey[k];

                        }
                    }
                    pos.Add(Tuple.Create(movex[9],movey[9]));

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


