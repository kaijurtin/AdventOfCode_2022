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
            //get all monkeys
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
                            monks[num].items.Add(ite);
                        }
                    things.Clear();
                //formula
                    var form = _inputData[i+2].Split(' ').ToList();
                    var formula = "item="+form[5]+form[6]+form[7];
                        formula = formula.Replace("old", "item");
                        monks[num].formula = formula;
                        
                //test
                var test = monks[num].testnum = Convert.ToInt32(_inputData[i + 3].Split(' ').Last()); ;
                //true
                monks[num].montrue= Convert.ToInt32(_inputData[i + 4].Split(' ').Last());
                //false
                monks[num].monfalse = Convert.ToInt32(_inputData[i + 5].Split(' ').Last());
            }

            //find new divisor
            var divisor = monks.Select(m => m.testnum).Aggregate((a, b) => a * b);
            Console.WriteLine("divisor: "+divisor);
            //get a round done
            for (int i = 0; i < 10000; i++)
            {
                foreach (var monk in monks)
                {
                    while (monk.items.Any())
                    {
                        monk.inspects++;
                        long newval = monkeyCalc(monk, monk.items.First());
                        double calc = Math.Floor((double)newval % divisor);
                        var newmonk = 0;
                        if (calc % monk.testnum == 0)
                            newmonk = monk.montrue;
                        else newmonk = monk.monfalse;
                        monks[newmonk].items.Add((int)calc);
                        monk.items.Remove(monk.items.First());
                    }
                }
            }

            var mostinspects = monks.OrderByDescending(x => x.inspects).Take(2);
            var result = mostinspects.First().inspects * mostinspects.Last().inspects;


            foreach (var monk in monks)
            {
                Console.WriteLine("Monkey: " + monk.number);
                foreach (var item in monk.items)
                {
                    Console.WriteLine("item: " + item);
                }
                Console.WriteLine("inspects: " + monk.inspects);
                Console.WriteLine("formula: " + monk.formula);
                Console.WriteLine("Test number: " + monk.testnum);
                Console.WriteLine("if true: " + monk.montrue);
                Console.WriteLine("if false: " + monk.monfalse);
                Console.WriteLine("\n");
                Console.WriteLine("RESULT: "+result);
            }
        

            Console.WriteLine("ENDE");
            Console.ReadKey();

        }
        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }


        private static long monkeyCalc(Monkey monkey, long item)
        {
            long result = 0;
            //var nextMonkey = 0;
           // var item = monkey.items.First();
            var formula = monkey.formula;

            if (formula.Contains("+"))
            {
                result = item + long.Parse(formula.Split('+').Last());
            }
            else
            {
                if (formula.Split('*').Last() != "item")
                {
                    result = item * long.Parse(formula.Split('*').Last());
                }
                else result = item * item;
            }

            return result;
        }
    }
    
     public class Monkey
    {
        public int num;

        //public List<int> items = new List<int>();
        //public static int calcNew(int item)
        //{
        //    item = item + formula;
        //}
        public Monkey(int num)
        {
            number = num;
            items = new List<long>();
            inspects = 0;
            formula = "0";
            montrue = 0;
            monfalse = 0;
            testnum = 0;

        }
        public  int number { get; set; }
        public  List<long> items { get; set; }
        public  string formula { get; set; }
        public  long testnum { get; set; }
        public  int montrue { get; set; }
        public  int monfalse { get; set; }
        public long inspects { get; set; }
    }
}
    


