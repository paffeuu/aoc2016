using System;
using System.IO;

namespace aoc8
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            
            //var interpreter = new InstructionsInterpreter(GetInput("../../example.txt"));
            var interpreter = new InstructionsInterpreter(GetInput("../../input.txt"));
            //var displayProgrammer = new DisplayCoder(interpreter, 7, 3);
            var displayProgrammer = new DisplayCoder(interpreter, 50, 6);
            displayProgrammer.Code();
            Console.WriteLine(displayProgrammer.Display());
            Console.WriteLine(displayProgrammer.CountOnPixels() + " pixels are lit.");
        }

        private static string[] GetInput(string fileDir) => File.ReadAllLines(fileDir);
    }
}