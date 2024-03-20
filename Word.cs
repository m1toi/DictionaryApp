using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp
{
    internal class Word
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }

        public string GetImagePathOrWordDescription()
        {
            Random rand = new Random();
            if (rand.Next(2) == 0)
            {
                return ImagePath;
            }
            else
            {
                return Description;
            }
        }

    }
}
