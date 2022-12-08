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
            
            //List<int> _inputDataINT = _inputData.ConvertAll(item => int.Parse(item));

            //List<Dictionary> main = new List<Dictionary>(); //this is the "/" dir
            
            Dir mainDir = new Dir("main"); 
            Dir currentDIR = mainDir;
            List<Dir> allDirs = new List<Dir>();

            for (int i = 1; i < _inputData.Count; i++)
            {
                var aline = _inputData[i].Split(' ').ToList();
                if(aline[0] == "$")
                { 
                    if(aline[1] == "cd")
                    {
                        if(aline[2] == "..")
                        {
                            if(currentDIR.name != "main")
                            currentDIR = currentDIR.parent;//mainDir.directories.Find(x=>x.directories.Contains(currentDIR));
                            continue;
                        }
                        
                        else
                        { 
                            currentDIR = allDirs.Find(x=>x.name == aline[2].ToString());                            
                            continue;
                        }
                    }
                    if(aline[1]=="ls")
                    {
                        continue;
                    }
                }
                //continue;
                if(aline[0]=="dir")
                {
                    Dir dr = new Dir(aline[1].ToString(), currentDIR);
                    currentDIR.directories.Add(dr);
                    allDirs.Add(dr);
                    continue;
                }
                else
                {
                    currentDIR.files.Add(new File(aline[1].ToString(), int.Parse(aline[0])));
                    continue;
                }
             } 
            for (int i = 0; i < allDirs.Count; i++)
			{
                allDirs[i].dirsize = allDirs[i].files.Sum(x=>x.size);
			}                
            for (int i = 0; i < allDirs.Count; i++)
            {
                allDirs[i].parent.dirsize += allDirs[i].dirsize;
            }
            var sum = 0;
            for (int i = 0; i < allDirs.Count; i++)
            {
                if (allDirs[i].dirsize <= 100000) sum += allDirs[i].dirsize;
            }
            foreach (Dir dir in allDirs)
	        {
                Console.WriteLine("DIR Name: " + dir.name);
                Console.WriteLine("DIR Size: " + dir.dirsize);
                Console.WriteLine("number of files: " + dir.files.Count);
                if (dir.dirsize <= 100000) sum += dir.dirsize;
    	    }
            Console.WriteLine(sum);

            /*var closest = 10000000;
            var diff = 100000;
            var candidates = allDirs.FindAll(x=>x.dirsize<100000);
            var sizes = new List<int>();
            foreach (Dir d in candidates)
	        {
                sizes.Add(d.dirsize);
                //diff = 100000 - d.dirsize;
                //sizes.Remove(d.dirsize);
            }
            foreach (int s in sizes)
	        {
                if (s < diff)
                {
                    diff = diff - s;
                    //sizes.Remove(s);
                }
                //else sizes.Remove(s);
	        }
            closest = 100000 - diff;    
	        */
            Console.WriteLine("SUM: "+ sum);

            
	            
                
	       



            //keep console open
            Console.WriteLine("Hit any key to close this window...");
                Console.ReadKey();
            
        }
        
        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }
            
    }
    public class Dir
    {
        public string name;
        public List<File> files = new List<File>();
        public List<Dir> directories = new List<Dir>();
        public Dir parent;
        public int dirsize;
        
        public Dir (string name, Dir parent)
        {
            this.name = name;
            this.parent = parent;
        }
        public Dir (string name)
        {
            this.name = name;
        }


    }
    public class File
    {
        public string name;
        public int size;
        public File(string name, int size)
        {
            this.name = name;
            this.size = size;
        }
    }
        
}
