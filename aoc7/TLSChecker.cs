namespace aoc7
{
    public class TLSChecker
    {
        public string Line { private get; set; }

        public bool CheckSupportTLS()
        {
            var pairFound = false;
            for (int i = 0, j = 1; j < Line.Length; i++, j = i+1)
            {
                if (pairFound && Line[i] != '[')     continue;
                if (Line[i] == '[')
                    if (!CheckSquareBrackets(ref i))
                        return false;
                if (i != 0 && j != Line.Length-1 && Line[i] == Line[j] && !pairFound)
                    pairFound = CheckABBA(i);
            }
            return pairFound;
        }

        private bool CheckABBA(int i) => (Line[i - 1] == Line[i + 2] && Line[i-1] != Line[i]);

        private bool CheckSquareBrackets(ref int i)
        {
            var pairFound = false;
            while (Line[++i] != ']')
                if (Line[i] == Line[i+1] && !pairFound)
                    pairFound = CheckABBA(i);
            return !pairFound;
        }
    }
}