using System.Text;

namespace aoc4
{
    public class Room
    {
        public int SectorId { get; }
        public string Description { get; }
        
        private readonly int[] _letters;
        private readonly string _firstFive;
        private readonly string _cipheredDescription;

        private Room(int[] letters, string firstFive, int sectorId, string cipheredDescription)
        {
            _letters = letters;
            _firstFive = firstFive;
            SectorId = sectorId;
            _cipheredDescription = cipheredDescription;
            Description = Decipher();
        }

        public static Room Create(string line)
        {
            var parts = line.Split('[');
            var temp = parts[0].Replace("-", "");

            var cipheredDescription = parts[0].Replace('-', ' ');
            
            var firstPart = temp.Substring(0, temp.Length - 3);
            var secondPart = temp.Substring(temp.Length - 3);
            var thirdPart = parts[1].Substring(0, 5);
            
            var letters = new int[26];
            foreach (var ch in firstPart)
                letters[ch - 97]++;
            int.TryParse(secondPart, out var sectorId);
            var firstFive = FindFirstFive(letters);
            
            return (thirdPart.Equals(firstFive)) ? new Room(letters, firstFive, sectorId, cipheredDescription) : null;
        }

        private string Decipher()
        {
            var decipheredDescription = new StringBuilder();
            var cipheredDescription = _cipheredDescription.ToCharArray();
            foreach (var ch in cipheredDescription)
                decipheredDescription.Append( (ch == ' ') ? (' ') : (char)(((ch - 97 + SectorId) % 26) + 97));
            return decipheredDescription.ToString();
        }
        
        private static string FindFirstFive(int[] letters)
        {
            var firstFive = new[]{-1, -1, -1, -1, -1};
            for (var i = 0; i < letters.Length; i++)
                for (var j = 0; j < 5; j++)
                    if (firstFive[j] == -1 || letters[i] > letters[firstFive[j]])
                    {
                        for (var k = 4; k > j; k--)
                            firstFive[k] = firstFive[k-1];
                        firstFive[j] = i;
                        break;
                    }
            var firstFiveChars = new char[5];
            for (var i = 0; i < 5; i++)
                firstFiveChars[i] = (char)(firstFive[i] + 97);
            return new string(firstFiveChars);
        }
        
    }
}