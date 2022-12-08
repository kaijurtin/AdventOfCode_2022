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
//var inputFile = File.ReadAllLines("../input/input_08.txt");
        var input = _inputData;//new List<string>(inputFile);




         var grid = new List<List<int>>();
            foreach (var line in input)
            {
                var row = new List<int>();

                foreach(var tree in line){
                    row.Add(Convert.ToInt32(tree));
                }

                grid.Add(row);
            }

            int bestScenicScore = 0;

            for (int row = 0; row < grid.Count; row++)
            {
                for (int col = 0; col < grid[row].Count; col++)
                {
                    int currentHeight = grid[row][col];

                    int left = 0;
                    int right = 0;
                    int up = 0;
                    int down = 0;


                    //left check
                    for(int leftCol = col-1; leftCol >= 0; leftCol--)
                    {
                        left++;
                        if(grid[row][leftCol] >= currentHeight){
                            break;
                        }
                    }
            
                    //right check
                    for(int rightCol = col+1; rightCol < grid[row].Count; rightCol++)
                    {
                        right++;
                        if(grid[row][rightCol] >= currentHeight){
                            break;
                        }
                    }
            
                    //up check
                    for(int upRow = row-1; upRow >= 0; upRow--)
                    {
                        up++;
                        if(grid[upRow][col] >= currentHeight){
                            break;
                        }
                    }
            
                    //down check
                    for(int downRow = row+1; downRow < grid.Count; downRow++)
                    {
                        down++;
                        if(grid[downRow][col] >= currentHeight){
                            break;
                        }
                    }

                    int scenicScore = left * right * up * down;

                    if (scenicScore > bestScenicScore)
                    {
                        bestScenicScore = scenicScore;
                    }
                }
            }
            Console.WriteLine(bestScenicScore.ToString());
            Console.ReadLine();



        }
        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }
    }
}


