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

            
            var listLength = 0;    


           foreach (var line in _inputData)
	       {
                if (line.Contains("["))
                    listLength ++;
                else break;
           }
           var numberList = _inputData[listLength].Split(' ').ToList();
            var numberOfLists = int.Parse(numberList.Max());

            Console.WriteLine("number of Lists: " + numberOfLists);

            var staples = _inputData.Where(x => x.Contains("[")).ToList();
            List<List<string>> lists = new List<List<string>>();
            for (int i = 1; i < numberOfLists +1 ; i++)
			{
                lists.Add(new List<string>());
			}
            Console.WriteLine("number of lists: " + lists.Count);



            foreach (var staple in staples)
			{
                var charlist = new List<string>(staple.Select(c => c.ToString()));
                if (lists.Count >= 1) 
                    lists[0].Add(charlist[1]);
                if (lists.Count >= 2)
                    lists[1].Add(charlist[5]);
                if (lists.Count >= 3)
                    lists[2].Add(charlist[9]);
                if (lists.Count >= 4)
                    lists[3].Add(charlist[13]);
                if (lists.Count >= 5)
                    lists[4].Add(charlist[17]);
                if (lists.Count >= 6)
                    lists[5].Add(charlist[21]);
                if (lists.Count >= 7)
                    lists[6].Add(charlist[25]);
                if (lists.Count >= 8)
                    lists[7].Add(charlist[29]);
                if (lists.Count >= 9)
                    lists[8].Add(charlist[33]);

			}

            for (int i = 0; i < lists.Count; i++)
			{
            lists[i].Reverse();
                lists[i].RemoveAll(x => string.IsNullOrEmpty(x));
                lists[i].RemoveAll(x => x == " ");
			}
            
            /*foreach (var list in lists)
	        {
                Console.WriteLine("List #" + "[" + lists.IndexOf(list) + "]");
                foreach (var item in list)
	            {
                    Console.WriteLine("[" + list.IndexOf(item) + "]" + item);
	            }
	        }
            */

            foreach (var line in _inputData)
	        {
                //var line = new List<string>(l.Select(c => c.ToString()));
                //if(line.First().Equals("m"))
                if (!String.IsNullOrEmpty(line) && line.StartsWith("m"))
                {
                var linearray = line.Split(' ').ToArray();
                var qty = int.Parse(linearray[1].ToString());
                var start = int.Parse(linearray[3].ToString()) -1;
                var goal = int.Parse(linearray[5].ToString()) -1;



                var movinglist = new List<string>();
                    for (int i = 0; i < qty; i++)
			        {
                        movinglist.Add(lists[start].Last());
                        lists[start].RemoveAt(lists[start].Count - 1);
			        }
                    movinglist.Reverse();
                        
                        
                    foreach(var item in movinglist)
                    {
                        lists[goal].Add(item);
                        //Console.WriteLine("[" + movinglist.IndexOf(item) + "]" + item);
                    }

                    movinglist.Clear();
                }

	        }

            var result = "";
            foreach (var x in lists)
	            {
                if(x.Count > 0 && !String.IsNullOrEmpty(x.Last()))
                result = result + x.Last();
	            }

            
	       
                Console.WriteLine("Result: " + result);
	       



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
