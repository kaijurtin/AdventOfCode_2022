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




var currentDirectory = new List<string>();

    string createCurrentDirectory(){
        string dir = string.Join("/",currentDirectory);
        dir = dir.Replace("//", "/");
        return dir;
    }

    var directorySize = new Dictionary<string,int>();

    foreach (var line in input){
        if (line.Substring(0,1) == "$"){
            var command = line.Split(' ');

            if (command[1] == "cd"){
                if (command[2] == ".."){
                    currentDirectory.RemoveAt(currentDirectory.Count-1);
                }
                else {
                    currentDirectory.Add(command[2]);
                }
            }
        }
        else if (line.Substring(0,3) != "dir"){
            var file = line.Split(' ');
            if (!directorySize.ContainsKey(createCurrentDirectory())){
                directorySize[createCurrentDirectory()] = 0;
            }
            string dir = createCurrentDirectory();
            while (dir.Contains("/")){
                if (!directorySize.ContainsKey(dir)){
                    directorySize[dir] = 0;
                }
                directorySize[dir] += Convert.ToInt32(file[0]);

                if (dir == "/") break;

                var dirSplit = dir.Split('/').ToList();
                dirSplit.RemoveAt(dirSplit.Count-1);
                dir = string.Join("/",dirSplit);
            }
        }
    }

    int output = 0;

    foreach(var item in directorySize)
    {
        if (item.Value <= 100000){
            output += item.Value;
        }
    }

    Console.WriteLine(output.ToString());
            Console.ReadKey();
        }
        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }
    }
}


