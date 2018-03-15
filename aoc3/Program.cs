using System;
using System.Collections.Generic;
using System.IO;

namespace aoc3
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var input = GetInput("../../source.txt");
            var triangleList = new List<Triangle>();
            /*foreach (var edges in input)
            {
                var triangle = Triangle.Create(edges);
                if (triangle != null)    triangleList.Add(triangle);
            }*/
            for (var k = 0; k < 3; k++)
            {
                for (var i = 0; i < input.GetLength(0); i += 3)
                {
                    var edges = new int[3];
                    for (var j = 0; j < 3; j++)
                        edges[j] = input[i + j, k];
                    var triangle = Triangle.Create(edges);
                    if (triangle != null)    triangleList.Add(triangle);
                }
            }
            Console.WriteLine("We have {0} triangles.", triangleList.Count);
        }

        /*private static int[][] GetInput(string fileDir)
        {
            var lines = File.ReadAllLines(fileDir);
            var values = new int[lines.Length][];
            for (var i = 0; i < lines.Length; i++)
            {
                values[i] = new int[3];
                for (var j = 0; j < 3; j++)
                    int.TryParse(lines[i].Substring(2+5*j,3).Trim(), out values[i][j]);
            }
            return values;
        }*/
        
        private static int[,] GetInput(string fileDir)
        {
            var lines = File.ReadAllLines(fileDir);
            var values = new int[lines.Length, 3];
            for (var i = 0; i < lines.Length; i++)
                for (var j = 0; j < 3; j++)
                    int.TryParse(lines[i].Substring(2+5*j,3).Trim(), out values[i,j]);
            return values;
        }
        
    }
}