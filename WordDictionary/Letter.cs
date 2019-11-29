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

        public Letter AddLetter(char c)
        {
            Letter new_letter = new Letter(c);
            letters.Add(new_letter);
            return new_letter;
        }
    }
}
