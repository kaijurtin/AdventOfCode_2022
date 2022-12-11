using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;


namespace AdventOfCodeStartProject
{
    static public class AdventOfCode
    {
        //this field contains whats written in your input.txt
        //each line in the list of strings represents one line in the txt file
        //copy the data you get on the adventofcode website into the txt file and start coding!
        private static List<string> _inputData;
        private static List<int> sums = new List<int>();
        

        static void Main(string[] args)
        {
            readInput();
            List <Monkey> monks = new List<Monkey>();
            List<string>things = new List<string>();  

            for (int i = 0; i < _inputData.Count; i=i+7)
            {
                    
                //monkey class
                    int num = Convert.ToInt32((_inputData[i].Split(' ')[1]).Replace(":", ""));
                    monks.Add(new Monkey(num));
                //items
                    things = _inputData[i+1].Split(' ').ToList();
                    things.RemoveRange(0, 4);
                        foreach (var item in things)
                        {
                            var ite = Convert.ToInt32(item.Replace(",", ""));
                            monks[num].Items.Add(ite);
                        }
                    things.Clear();
                //formula
                    var form = _inputData[i+2].Split(' ').ToList();
                    var formula = "item="+form[5]+form[6]+form[7];
                        formula = formula.Replace("old", "item");
                    Monkey.formula = formula;
                        
                //test
                var test = Monkey.testnum = Convert.ToInt32(_inputData[i + 3].Split(' ').Last()); ;
                //true
                    Monkey.monTrue= Convert.ToInt32(_inputData[i + 4].Split(' ').Last());
               //false
                    Monkey.monFalse = Convert.ToInt32(_inputData[i + 5].Split(' ').Last());
            }

            foreach (var monk in monks)
            {
            Console.WriteLine("Monkey: " + monk.Nummer);
                foreach (var item in monk.Items)
                {
                Console.WriteLine("item: " + item);
                }
            Console.WriteLine("formula: " + monk.Formel);
            Console.WriteLine("Test number: " + monk.TestNummer);
            Console.WriteLine("if true: " + monk.MonkeyTrue);
            Console.WriteLine("if false: " + monk.MonkeyFalse);

            }

            Console.WriteLine("ENDE");
            Console.ReadKey();

        }
        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }
    }
    
     public class Monkey
    {
        public static int num;
        public static List<int> items = new List<int>();
        public static string formula;
        public static int testnum;
        public static int monTrue;
        public static int monFalse;
        //public static int calcNew(int item)
        //{
        //    item = item + formula;
        //}
        public Monkey(int num)
        {
            num = Nummer;   
        }
        public int Nummer { get { return num; } }
        public List<int> Items { get { return items; } }
        public string Formel { get { return formula; } }   
        public int TestNummer { get { return testnum; } }
        public int MonkeyTrue { get { return monTrue; } }
        public int MonkeyFalse { get { return monFalse; } }
        public static void addItem(int item)
        { 
            items.Add(item);
        }
    }
}
    


