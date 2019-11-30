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
                words.Add(s);
            }
            baseLetter = new BaseLetterSet();
        }

        private void AddWord(string word)
        {
            Letter l = null;
            foreach(char c in word)
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

        /*private IEnumerable<string> GetNext()
        {
            foreach (string s in words)
                yield return s;
        }*/

        public List<string> GetWordChilds(string word)
        {
            List<string> childWords = new List<string>();

            foreach()

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
