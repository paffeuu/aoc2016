using System;
using System.IO;

namespace aoc1
{
    internal static class Program
    {
        private static int _direction;
        //private static int _north;
        //private static int _east;

        private static readonly bool[,] Xy;
        private static int _lastX;
        private static int _lastY;

        private const int SizeOfArray = 601;

        static Program()
        {
            Xy = new bool[SizeOfArray,SizeOfArray];
            _lastX = SizeOfArray/2;
            _lastY = SizeOfArray/2;
            Xy[_lastX, _lastY] = true;
        }

        public static void Main()
        {
            var input = GetInput("../../source.txt");
            //foreach (var instruction in input)
            //    AnalyzeInstruction(instruction);
            //Console.WriteLine("Eastern Bunny HQ is " + (Math.Abs(_north) + Math.Abs(_east)) + " blocks away.");
            foreach (var instruction in input)
            {
                var result = AnalyzeInstructionExtended(instruction);
                if (result == null) continue;
                var blocksAway = Math.Abs(result[0] - SizeOfArray / 2) + Math.Abs(result[1] - SizeOfArray / 2);
                Console.WriteLine($"Eastern Bunny HQ is {blocksAway} blocks away.");
                break;
            }     
        }

        private static string[] GetInput(string fileDir) => File.ReadAllLines(fileDir)[0].Replace(" ","").Split(',');

        /*private static void AnalyzeInstruction(string instruction)
        {
            var rl = instruction[0];
            int.TryParse(instruction.Substring(1), out var number);
            _direction = (rl == 'R') ? (_direction + 1) % 4 : (_direction + (4-1)) % 4;
            switch (_direction)
            {
                case 0:
                    _north += number;
                    break;
                case 1:
                    _east += number;
                    break;
                case 2:
                    _north -= number;
                    break;
                case 3:
                    _east -= number;
                    break;
            }
        }*/

        private static int[] AnalyzeInstructionExtended(string instruction)
        {
            var rl = instruction[0];
            int.TryParse(instruction.Substring(1), out var number);
            _direction = (rl == 'R') ? (_direction + 1) % 4 : (_direction + (4-1)) % 4;
            switch (_direction)
            {
                case 0:
                    for (var i = 1; i <= number; i++)
                    {
                        if (Xy[_lastX, --_lastY]) return new[] {_lastX, _lastY};
                        Xy[_lastX, _lastY] = true;
                    }
                    break;
                case 1:
                    for (var i = 1; i <= number; i++)
                    {
                        if (Xy[++_lastX, _lastY]) return new[] {_lastX, _lastY};
                        Xy[_lastX, _lastY] = true;
                    }
                    break;
                case 2:
                    for (var i = 1; i <= number; i++)
                    {
                        if (Xy[_lastX, ++_lastY]) return new[] {_lastX, _lastY};
                        Xy[_lastX, _lastY] = true;
                    }
                    break;
                case 3:
                    for (var i = 1; i <= number; i++)
                    {
                        if (Xy[--_lastX, _lastY]) return new[] {_lastX, _lastY};
                        Xy[_lastX, _lastY] = true;
                    }
                    break;
            }
            return null;
        }
    }
}