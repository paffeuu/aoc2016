using System;
using System.IO;
using System.Text;

namespace aoc6
{
    internal static class Program
    {
        private const int Shift = 97;
        
        public static void Main(string[] args)
        {
            var input = GetInput("../../input.txt");
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < input[0].Length; i++)
                //stringBuilder.Append(CheckMostFrequentChar(input, i));
                stringBuilder.Append(CheckLeastFrequentChar(input, i));
            Console.WriteLine("The message is: " + stringBuilder);
        }

        private static char[][] GetInput(string fileDir)
        {
            var lines = File.ReadAllLines(fileDir);
            var chars = new char[lines.Length][];
            for (int i = 0; i < chars.Length; i++)
                chars[i] = lines[i].ToCharArray();
            return chars;
        }

        private static char CheckMostFrequentChar(char[][] input, int i)
        {
            var frequentChars = new int[26];
            foreach (var chars in input)
                frequentChars[chars[i] - Shift]++;
            var max = int.MinValue;
            var index = -1;
            for (int j = 0; j < frequentChars.Length; j++)
                if (max <= frequentChars[j])
                {
                    max = frequentChars[j];
                    index = j;
                }
            return (char)(index + Shift);
        }

        private static char CheckLeastFrequentChar(char[][] input, int i)
        {
            var frequentChars = new int[26];
            foreach (var chars in input)
                frequentChars[chars[i] - Shift]++;
            var min = int.MaxValue;
            var index = -1;
            for (int j = 0; j < frequentChars.Length; j++)
                if (min >= frequentChars[j] && frequentChars[j] > 0)
                {
                    min = frequentChars[j];
                    index = j;
                }
            return (char)(index + Shift);
        }
    }
}