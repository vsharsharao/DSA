using System.Collections.Generic;
using System.Linq;

namespace HashTables
{
    public class HashTableExcercises
    {
        public static char GetFirstNonRepeatedCharacter(string text)
        {
            #region Using GroupBy (LINQ)
            // var charArrayGroup = text.ToCharArray().Select(i => i.ToString().ToLower()).GroupBy(i => i);
            // var firstNonRepeat = charArrayGroup.Where(i => i.Count() == 1).FirstOrDefault();
            // return firstNonRepeat.Key[0];
            #endregion

            //O[2n]
            Dictionary<char, int> charMapper = new Dictionary<char, int>();
            var charArray = text.ToCharArray().Select(i => i.ToString().ToLower().First());
            //O[n]
            foreach (var ch in charArray)
            {
                var count = charMapper.ContainsKey(ch) ? charMapper[ch] : 0;
                charMapper[ch] = count + 1;
            }

            //O[n]
            foreach (var ch in charArray)
            {
                if (charMapper[ch] == 1)
                    return ch;
            }

            return char.MinValue;
        }

        //O[n]
        public static char GetFirstRepeatedCharacter(string text)
        {
            HashSet<int> charSet = new HashSet<int>();
            var charArray = text.ToCharArray().Select(i => i.ToString().ToLower().First());

            foreach (var ch in charArray)
            {
                if (charSet.Contains(ch))
                    return ch;

                charSet.Add(ch);
            }

            return char.MinValue;
        }
    }
}