using System.Collections.Generic;

namespace aoc7
{
    public class SSLChecker
    {
        public string Line { private get; set; }
        private HashSet<string> _abaFound, _babFound;

        public bool CheckSupportSSL()
        {
            ClearSets();
            for (int i = 1; i < Line.Length-1; i++)
            {
                if (Line[i] == '[')
                    CheckSquareBrackets(ref i);
                else
                    CheckABA(i);
            }
            foreach (var aba in _abaFound)
                if (_babFound.Contains(ToCorrespondingString(aba)))
                    return true;
            return false;
        }

        private void CheckABA(int i)
        {
            if (Line[i - 1] == Line[i + 1] && Line[i] != Line[i - 1])
                _abaFound.Add(Line.Substring(i - 1, 3));
        }

        private void CheckBAB(int i)
        {
            if (Line[i - 1] == Line[i + 1] && Line[i] != Line[i - 1])
                _babFound.Add(Line.Substring(i - 1, 3));
        }

        private void CheckSquareBrackets(ref int i)
        {
            i++; // jumping to the inside-brackets '1' position
            while (Line[++i] != ']')
                CheckBAB(i);
            i++; // jumping to the outside-brackets '1' position
        }

        private void ClearSets()
        {
            _abaFound = new HashSet<string>();
            _babFound = new HashSet<string>();
        }
        
        private string ToCorrespondingString(string aba) => new string(new []{aba[1], aba[0], aba[1]});
    }
}