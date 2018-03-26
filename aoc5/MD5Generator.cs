using System;
using System.Security.Cryptography;
using System.Text;

namespace aoc5
{
    public class MD5Generator
    {
        private int _counter;
        private readonly string _doorID;
        private readonly MD5 _md5;

        public MD5Generator(string doorID)
        {
            _counter = 0;
            _doorID = doorID;
            _md5 = MD5.Create();
        }

        /*public string LookForPassword()
        {
            var passwordBuilder = new StringBuilder();
            for (int i = 0; i < 8; i++)
                passwordBuilder.Append(LookForCharacter());
            return passwordBuilder.ToString();
        }*/
        
        public string LookForPassword()
        {
            var passwordBuilder = "________".ToCharArray();
            var lettersFound = 0;
            while (lettersFound < 8)
            {
                var charFound = LookForCharacter();
                var pos = charFound[0] - 48;
                if (pos < 0 || pos > 7 || passwordBuilder[pos] != '_')    continue;
                passwordBuilder[pos] = charFound[1];
                lettersFound++;
                Console.WriteLine($"pos = {pos}, char = {charFound[1]}, lettersFound = {lettersFound}");
            }
            return new string(passwordBuilder);
        }
        
        /*private char LookForCharacter()
        {
            while (true)
            {
                var hash = CreateMD5String();
                var zeroCounter = 0;
                for (int i = 0; i < 5; i++)
                    if (hash[i] == '0')    zeroCounter++;
                    else                   break;
                if (zeroCounter == 5)
                    return hash[5];
            }
        }*/
        
        private string LookForCharacter()
        {
            while (true)
            {
                var hash = CreateMD5String();
                var zeroCounter = 0;
                for (int i = 0; i < 5; i++)
                    if (hash[i] == '0')    zeroCounter++;
                    else                   break;
                if (zeroCounter == 5)
                    return hash.Substring(5, 2);
            }
        }

        private string CreateMD5String()
        {
            var hashStringSrc = new StringBuilder(_doorID).Append(_counter++).ToString();
            var hashBytes = _md5.ComputeHash(Encoding.UTF8.GetBytes(hashStringSrc));
            var hashStringBuilder = new StringBuilder();
            for (int i = 0; i < 6; i++)     // we need only first 6 characters
                hashStringBuilder.Append(hashBytes[i].ToString("x2"));
            return hashStringBuilder.ToString();
        }
    }
}