using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordDictionary
{
    class Letter
    {
        private char letter;
        private List<Letter> letters;

        public Letter(char letter)
        {
            letters = new List<Letter>();
            this.letter = letter;
        }

        public char ToChar()
        {
            return this.letter;
        }

        public Letter GetLetter(char c)
        {
            foreach(Letter l in letters)
            {
                // If letter exist
                if (l.ToChar() == c)
                    return l;

            }

            //If doesnt exist create new and return
            return null;
        }

        public void GetChildWords(string startWord, string buildedWord, ref List<string> wordList)
        {
            Console.WriteLine(startWord + " - " + buildedWord);
            if(letters.Count == 0 && startWord.Length == 0 && buildedWord.Length>0)
            {
                // End recursion
                wordList.Add(buildedWord);
                return;
            }
            
            if(startWord.Length == 0)
            {
                // Find every word builded from startWord
                foreach(Letter l in letters)
                {
                    //Console.WriteLine("Ide dalej: " + buildedWord + this.ToChar());
                    l.GetChildWords("", buildedWord + this.ToChar(), ref wordList);
                }
            }
            else
            {
                Letter l = GetLetter(startWord[0]);
                Console.WriteLine((l == null).ToString());
                if(l != null)
                {
                    string nextString = startWord.Remove(0, 1);
                    l.GetChildWords(nextString, buildedWord + this.ToChar(), ref wordList);
                }
            }
        }

        public Letter AddLetter(char c)
        {
            if (GetLetter(c) != null)
            {
                //Console.Write("(e)");
                return GetLetter(c);

            }

            Letter new_letter = new Letter(c);
            letters.Add(new_letter);
            //Console.Write("(n)");
            return new_letter;
        }
    }
}
