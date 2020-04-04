using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityClass
{
    public class Journel
    {
        private readonly List<string> entries = new List<string>();
        private static int count;

        public int AddEntry(string text)
        {
            text = string.Format(++count + ":" + text);
            entries.Add(text);
            //entries.Add($"{++count} :{text}");
            return count;
        }
        
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public string name;
        public int age;

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        // Now this class is resposible for two functionality 
        // one is to add and delete the entry and 
        ///other resposibilty to save so as per the solid pricile this is the voilation so we can break 
        ///this class into two class so that every class is resposible for one principle.
        
        //public void saveFile(Journel j,string filename, bool overwrite)
        //{
        //    if (overwrite || ! File.Exists(filename))
        //    {
        //        File.WriteAllText(filename, j.ToString());
        //    }
        //}
        //public override string tostring()
        //{
        //    return string.join(environment.newline, name);
        //}
    }

    class SaveJournalInfomation
    {
        public void saveFile(Journel j, string filename, bool overwrite)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }
    class SingleResponsibility
    {
       
        static void Main(string[] args)
        {
            Journel j1 = new Journel();
            //j1.name = "Vivek";
            //j1.age=50
            j1.AddEntry("I am happy Today");
            j1.AddEntry("Let's Play Game");
            Console.WriteLine(j1.ToString());
            SaveJournalInfomation s1 = new SaveJournalInfomation();
            string filename = @"c:\Temp\journal.txt";
            s1.saveFile(j1, filename, true);
            Process.Start(filename);
            Console.ReadLine();
        }
    }
}
