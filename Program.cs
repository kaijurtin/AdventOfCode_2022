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
        private static List<int> sums = new List<int>();

        static void Main(string[] args)
        {
            readInput();
            int cycles = 0;

            int registerX = 0;

            var crtScreen = new string[6, 40];

            foreach (var instruction in _inputData)
            {
                if (cycles == (6 * 40) - 1) break;

                if (instruction == "noop")
                {
                    crtScreen = DrawCRT(cycles, crtScreen, registerX);
                    cycles++;
                    continue;
                }

                for (int i = 0; i < 2; i++)
                {
                    crtScreen = DrawCRT(cycles, crtScreen, registerX);
                    cycles++;
                    if (i == 1)
                    {
                        registerX += Convert.ToInt32(instruction.Split(' ')[1]);
                    }
                }
            }

            for (int row = 0; row < 6; row++)
            {
                string rowBuild = "";
                for (int col = 0; col < 40; col++)
                {
                    rowBuild += crtScreen[row, col];
                }
                Console.WriteLine(rowBuild);
            }
            Console.WriteLine("ENDE");
            Console.ReadKey();

        }
        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }
        private static string[,] DrawCRT(int cycles, string[,] crtScreen, int registerX)
        {
            var character = GetSpritePosition(registerX, cycles).Contains(cycles) ? "#" : ".";

            Console.WriteLine($"{cycles}: {registerX} - [{(cycles / 40).ToString()}] - [{(cycles % 40).ToString()}]");

            crtScreen[cycles / 40, cycles % 40] = character;
            Console.WriteLine(crtScreen[cycles / 40, cycles % 40]);

            return crtScreen;

        }
        private static int[] GetSpritePosition(int registerX, int cycles)
        {
            registerX += (cycles / 40) * 40;
            return new int[]
            {
                registerX,
                registerX+1,
                registerX+2
            };
        }
    }
}
    


