using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordDictionary
{
    class BaseLetterSet
    {
        private List<Letter> letters;

        public BaseLetterSet()
        {
            letters = new List<Letter>();
        }

        public Letter GetLetter(char c)
        {
            foreach (Letter l in letters)
            {
                // If letter exist
                if (l.ToChar() == c)
                    return l;

            }

            //If doesnt exist return new
            return AddLetter(c);
        }

        public void GetChildWords(string startWord, ref List<string> wordList)
        {
            if(startWord.Length > 0)
            {
                string nextString = startWord.Remove(0, 1);
                Letter l = GetLetter(startWord[0]);
                Console.WriteLine("Zaczynam szukanie:\n");
                l.GetChildWords(nextString, "", ref wordList);
            }
        }

        private Letter AddLetter(char c)
        {
            Letter new_letter = new Letter(c);
            letters.Add(new_letter);
            return new_letter;
        }
    }
}
