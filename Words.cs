using System;
using System.Collections.Generic;

namespace tusur_informatika_kursovaya
{
    abstract class Words
    {
        protected int count;
        protected List<String> words = new List<String>();

        public Words()
        {

        }

        public bool Exists(String _word)
        {
            if (words.IndexOf(_word) == -1)
            {
                return false;
            }
            else return true;
        }
        public List <String> GetAllWords()
        {
            return new List<String>(words);
        }
    }
}
