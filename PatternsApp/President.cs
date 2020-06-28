using System;
using System.Collections.Generic;
using System.Text;

namespace PatternsApp
{
    class President
    {
        private static President instance;
        public string Name { get; private set; }

        protected President(string name)
        {
            Name = name;
        }

        public static President GetInstance(string name)
        {
            if (instance == null)
                instance = new President(name);
            return instance;
        }
    }

    class Country
    {
        public President President { get; set; }

        public void Elect(string name)
        {
            President = President.GetInstance(name);
        }
    }
}
