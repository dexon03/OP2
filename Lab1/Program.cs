using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Name File1:");
            string fileName1 = Console.ReadLine();
            Console.WriteLine("Text File1:");
            string userText1 = InputText();
            CreateAndWriteFile(fileName1,userText1);
            Console.Write("\nName File2:");
            string fileName2 = Console.ReadLine();
            Console.WriteLine("Text File2:");
            string UserText2 = InputText();
            CreateAndWriteFile(fileName2,UserText2);
            string resultPath;
            CreateUnitFile(fileName1,fileName2,out resultPath);
            Console.WriteLine("\nUnit Text: ");
            string text = ReadText(resultPath);
            Console.WriteLine(text);
            int countOfRow = CountOfRow(resultPath);
            Console.WriteLine($"Count of raw in result file: {countOfRow}");



        }

        public static string InputText()
        {
            List<string> str = new List<string>();
            do
            {
                var a = Console.ReadKey();
                if (a.Key == ConsoleKey.Delete)
                {
                    break;
                }
                str.Add(a.KeyChar + Console.ReadLine());

            } while (true);
            return string.Join("\n",str);
            
        }
        
        public static void CreateAndWriteFile(string name, string text)
        {
            string path = $"{name}.txt";
            using (StreamWriter file = new StreamWriter(path,true))
            {
                file.Write(text);
            }
        }

        public static void CreateUnitFile(string file1,string file2,out string resultPath)
        {
            string pathOfFirstFile = $"{file1}.txt";
            string pathOfSeconfFile = $"{file2}.txt";
            string textFromFirstFile = ReadText(pathOfFirstFile);
            string textFromSecondFile = ReadText(pathOfSeconfFile);
            string unitText = textFromFirstFile + "\n" + textFromSecondFile;
            resultPath = "result.txt";
            using (StreamWriter file = new StreamWriter(resultPath,true))
            {
                file.Write(unitText);
            }
        }
        
        public static string ReadText(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                string line = null;
                while (!file.EndOfStream)
                {
                    line +=(line==null?"":"\n")+file.ReadLine();
                }
                return line;
            }
        }
        
        public static int CountOfRow(string path)
        {
            int count;
            string text = ReadText(path);
            if (string.IsNullOrEmpty(text)) count = 0;
            else
            {
                count = 1;
                foreach (var VARIABLE in text)
                {
                    if (VARIABLE == '\n') count++;
                }
            }

            return count;
        }
    }
}
