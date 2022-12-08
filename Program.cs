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
            //EXAMPLE CODE
            //hit F5 to run it

            //read data from input.txt and write it into inputdata field
            readInput();
            //var intlist = _inputData.Select(i => int.Parse(i)).ToList();
            //lets write the contents of the input.txt into the console

            //Console.WriteLine("Content of input.txt:");
            //_inputData.ForEach(i => Console.WriteLine(i));
            //Console.WriteLine($"--END OF FILE--{Environment.NewLine}");
            
            //List<int> _inputData = _inputData.ConvertAll(item => int.Parse(item));
            //List<Dictionary> main = new List<Dictionary>(); //this is the "/" dir
            

            var columns = _inputData.First().Length;
            var rows = _inputData.Count;
            var outertrees = columns * 2 + rows * 2 -4;
            var fromLeft = 0;
            var fromRight = 0;
            var fromTop = 0;    
            var fromBottom = 0;
            bool stopLeft = false;
            bool stopRight = false;
            bool stopTop = false;
            bool stopBottom = false;
            var maxrow = new List<int>();
            var maxcol = new List<int>();


            int[,] data = new int[rows,columns]; 

            for (int i = 0; i < rows; i++)
			{
            var line =_inputData[i].ToCharArray();
                for (int j = 0; j < line.Length; j++)
                {
                    data[i,j] = Convert.ToInt32(line[j].ToString());
                }
			}
            
         //IEnumerable<int> allValues = data.Cast<int>();

            for (int i = 1; i < rows-1; i++)
            {
                var temp = new List<int>();
                for (int j = 1; j < columns-1; j++)
                {
                    var value = (data[i,j]);
                    temp.Add(value);
                }
                maxrow.Add(temp.Max());
                temp.Clear();
                Console.WriteLine(maxrow[i-1]);
            }
            for (int i = 1; i < columns-1; i++)
            {
                var temp = new List<int>();
                for (int j = 1; j < rows-1; j++)
                {
                    var value = (data[j,i]);
                    temp.Add(value);
                }
                maxcol.Add(temp.Max());
                temp.Clear();
                Console.WriteLine(maxcol[i-1]);
            }



var templeft = new List<int>();
var tempright = new List<int>();
var temptop = new List<int>();  
var tempbottom = new List<int>();

            for (int i = 1; i < rows-1; i++)
            {
                for (int j = 0; j < columns-2; j++)
			    {
                    templeft.Add(data[i,j]);
                    Console.WriteLine(data[i,j+1] +":"+ templeft.Max());
                    if(data[i,j+1] > templeft.Max()) fromLeft++;
                    
                }
                 Console.WriteLine("from Left: " +fromLeft);
                templeft.Clear();
			
                for (int k = columns-1 ; k > 1; k--)
			    {
                    tempright.Add(data[i,k]);
                    Console.WriteLine(data[i,k-1] +":"+ tempright.Max());
                    if(data[i,k-1] > tempright.Max()) fromRight++;
                }
                Console.WriteLine("from Right: " +fromRight);
                tempright.Clear();

            }
            for (int i = 1; i < columns-1; i++)
			{
                for (int j = 0; j < rows-2; j++)
                {
                    temptop.Add(data[j,i]);
                    Console.WriteLine(data[j+1,i] +":"+ temptop.Max());
                    if(data[j+1,i] > temptop.Max()) fromTop++;
                }
                Console.WriteLine("from Top: " +fromTop);
                temptop.Clear();
                for (int k = rows-1; k > 1; k--)
			    {
                    tempbottom.Add(data[k,i]);
                    Console.WriteLine(data[k-1,i] +":"+ tempbottom.Max());
                    if(data[k-1,i] > tempbottom.Max()) fromBottom++;
			    }
                Console.WriteLine("from Bottom: " +fromBottom);
                tempbottom.Clear();

			}


            var sum = fromLeft + fromRight + fromTop + fromBottom + outertrees;
            
            Console.WriteLine("SUM: " +  sum);
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


