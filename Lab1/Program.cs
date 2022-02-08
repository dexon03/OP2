using System.IO;
using System;
using System.Linq;

namespace Lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введіть назву першого файла:");
            string fileName1 = Console.ReadLine();
            Console.Write("Введіть текст для першого файла:");
            string userText1 = InputText();
            CreateAndWriteFile(fileName1,userText1);
            Console.Write("\nВведіть назву другого файла:");
            string fileName2 = Console.ReadLine();
            Console.Write("Введіть текст для другого файла:");
            string UserText2 = InputText();
            CreateAndWriteFile(fileName2,UserText2);
            string resultPath;
            CreateUnitFile(fileName1,fileName2,out resultPath);
            Console.WriteLine("\nТекст з третього файла: ");
            string text = ReadText(resultPath);
            Console.WriteLine(text);
            int countOfRow = CountOfRow(resultPath);
            Console.Write($"\nКількість рядків в третьому файлі:{countOfRow}");


        }

        public static string InputText()
        {
            string text = null;
            while (Console.ReadKey().Key != ConsoleKey.Delete)
            {
                text += (text==null?"":"\n") + Console.ReadLine();
                
            }

            return text;
        }
        
        public static void CreateAndWriteFile(string name, string text)
        {
            string path = @$"D:\OP2 Lab\Lab1\{name}.txt";
            using (StreamWriter file = new StreamWriter(path,true))
            {
                file.Write(text);
            }
        }

        public static void CreateUnitFile(string file1,string file2,out string resultPath)
        {
            string pathOfFirstFile = @$"D:\OP2 Lab\Lab1\{file1}.txt";
            string pathOfSeconfFile = @$"D:\OP2 Lab\Lab1\{file2}.txt";
            string textFromFirstFile = ReadText(pathOfFirstFile);
            string textFromSecondFile = ReadText(pathOfSeconfFile);
            string unitText = textFromFirstFile + "\n" + textFromSecondFile;
            resultPath = @"D:\OP2 Lab\Lab1\result.txt";
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