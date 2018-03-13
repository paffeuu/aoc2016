using System;
using System.IO;
using System.Linq;

namespace aoc2
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var input = GetInput("../../source.txt");     // ../../example.txt lub ../../source.txt
            int[] lastPos = null;
            for (int i = 0; i < input.Length; i++)
            {
                lastPos = GetPos(input[i], lastPos);
                Console.Write(GetButton(lastPos) + " ");
            }
        }

        private static char[][] GetInput(string fileDir)
        {
            var lines = File.ReadAllLines(fileDir);
            var values = new char[lines.Length][];
            var i = 0;
            foreach (var line in lines)
                values[i++] = line.ToCharArray();
            return values;
        }

        /*private static int[] GetPos(char[] line, int[] pos)
        {
            if (pos == null)    pos = new[] {1, 1};
            foreach (var ch in line)
            {
                switch (ch)
                {
                    case 'U':
                        if (pos[1] != 0) pos[1]--;
                        break;
                    case 'R':
                        if (pos[0] != 2) pos[0]++;
                        break;
                    case 'D':
                        if (pos[1] != 2) pos[1]++;
                        break;
                    case 'L':
                        if (pos[0] != 0) pos[0]--;
                        break;
                }
            }
            return pos;
        }*/
        
        private static int[] GetPos(char[] line, int[] pos)
        {
            if (pos == null)    pos = new[] {0, 2};    // zaczynamy na '5'
            foreach (var ch in line)
            {
                switch (ch)
                {
                    case 'U':
                        if (!(pos.SequenceEqual(new[] {0, 2}) ||
                              pos.SequenceEqual(new[] {1, 1}) ||
                              pos.SequenceEqual(new[] {2, 0}) ||
                              pos.SequenceEqual(new[] {3, 1}) ||
                              pos.SequenceEqual(new[] {4, 2})))
                            {pos[1]--;}
                        break;
                    case 'R':
                        if (!(pos.SequenceEqual(new[] {2, 0}) ||
                              pos.SequenceEqual(new[] {3, 1}) ||
                              pos.SequenceEqual(new[] {4, 2}) ||
                              pos.SequenceEqual(new[] {3, 3}) ||
                              pos.SequenceEqual(new[] {2, 4}))) 
                            {pos[0]++;}
                        break;
                    case 'D':
                        if (!(pos.SequenceEqual(new[] {0, 2}) ||
                              pos.SequenceEqual(new[] {1, 3}) ||
                              pos.SequenceEqual(new[] {2, 4}) ||
                              pos.SequenceEqual(new[] {3, 3}) ||
                              pos.SequenceEqual(new[] {4, 2}))) 
                            {pos[1]++;}
                        break;
                    case 'L':
                        if (!(pos.SequenceEqual(new[] {2, 0}) ||
                              pos.SequenceEqual(new[] {1, 1}) ||
                              pos.SequenceEqual(new[] {0, 2}) ||
                              pos.SequenceEqual(new[] {1, 3}) ||
                              pos.SequenceEqual(new[] {2, 4}))) 
                            {pos[0]--;}
                        break;
                }
            }
            return pos;
        }

        /*private static int GetButton(int[] pos)
        {
            switch (pos[1])
            {
                case 0 when pos[0] == 0:
                    return 1;
                case 0 when pos[0] == 1:
                    return 2;
                case 0 when pos[0] == 2:
                    return 3;
                case 1 when pos[0] == 0:
                    return 4;
                case 1 when pos[0] == 1:
                    return 5;
                case 1 when pos[0] == 2:
                    return 6;
                case 2 when pos[0] == 0:
                    return 7;
                case 2 when pos[0] == 1:
                    return 8;
                case 2 when pos[0] == 2:
                    return 9;
            }
            return 0;
        }*/
        
        private static char GetButton(int[] pos)
        {
            switch (pos[1])
            {
                case 0 when pos[0] == 2:
                    return '1';
                case 1 when pos[0] == 1:
                    return '2';
                case 1 when pos[0] == 2:
                    return '3';
                case 1 when pos[0] == 3:
                    return '4';
                case 2 when pos[0] == 0:
                    return '5';
                case 2 when pos[0] == 1:
                    return '6';
                case 2 when pos[0] == 2:
                    return '7';
                case 2 when pos[0] == 3:
                    return '8';
                case 2 when pos[0] == 4:
                    return '9';
                case 3 when pos[0] == 1:
                    return 'A';
                case 3 when pos[0] == 2:
                    return 'B';
                case 3 when pos[0] == 3:
                    return 'C';
                case 4 when pos[0] == 2:
                    return 'D';
            }
            return '0';
        }
    }
}