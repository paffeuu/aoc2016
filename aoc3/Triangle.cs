namespace aoc3
{
    public class Triangle
    {
        private int[] _edges;

        private Triangle(int[] edges)
        {
            _edges = edges;
        }

        public static Triangle Create(int[] edges)
        {
            var max = FindMax(edges);
            return (edges[max] < edges[(max + 1) % 3] + edges[(max + 2) % 3]) ? new Triangle(edges) : null;
        }

        private static int FindMax(int[] numbers)        // returns index of the highest value in array
        {
            var max = -1;
            var j = -1;
            for (var i = 0; i < numbers.Length; i++)
                if (numbers[i] > max)
                {
                    max = numbers[i];
                    j = i;
                }
            return j;
        }
    }
}