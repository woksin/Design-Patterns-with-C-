using System;
using System.Collections.Generic;
using System.IO;

namespace Single_Responsibility_Principle
{
     public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text) 
        {
            entries.Add($"{++count}: {text}");
            return count; // memento
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        /*
            Classes should have a single responsibility.
            Don't do too much.

            The whole class is responsible for one thing, and has
            only one reason to change.
         */

        /*
        public void Save(string filename) 
        {
            File.WriteAllText(filename, ToString());
        }

        public static Journal Load(string filename) 
        {
            return new Journal();
        }

    
        public void Load(Uri uri)
        {
            //...
        }
        */
    }

    public class Persistance
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false) 
        {
            if (overwrite || File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }   
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("Hello");
            j.AddEntry("World");
        }
    }
}
