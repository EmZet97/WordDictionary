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

        public Letter GetLetter(char c)
        {
            foreach (Letter l in letters)
            {
                // If letter exist
                if (l.ToChar() == c)
                    return l;

            }

            //If doesnt exist return null
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
