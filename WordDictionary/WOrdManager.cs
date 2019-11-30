using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WordDictionary
{
    class WordManager
    {
        private readonly string fileName = @"../../Words.xml";
        private List<String> words;

        private BaseLetterSet baseLetter;
        public WordManager()
        {
            words = new List<string>();
            foreach(string s in GetWordFromFile())
            {
                words.Add(s.ToLower());
            }

            baseLetter = new BaseLetterSet();

            foreach (string s in words)
            {
                AddWord(s);
            }

        }

        public void AddWord(string word)
        {
            string new_word = word + "."; // '.' - word end symbol

            Letter l = null;
            foreach(char c in new_word)
            {
                // If char isn't first letter of word
                if(l != null)
                {
                    l.AddLetter(c);
                    l = l.GetLetter(c);
                }
                else
                {
                    l = baseLetter.GetLetter(c);
                }                
            }
        }

        
        public List<string> GetWordChilds(string word)
        {
            List<string> childWords = new List<string>();

            baseLetter.GetChildWords(word, ref childWords);

            return childWords;
        }

        private IEnumerable<string> GetWordFromFile()
        {
            using (XmlReader reader = XmlReader.Create(fileName))
            {
                string word = null;
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "Word":
                                word = reader.ReadString();
                                yield return word;
                                break;
                        }                        
                    }
                }
            }
        }
    }
}
