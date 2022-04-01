using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using static Lab2dotnet.functions;

namespace Lab2dotnet
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<string[]> listOfCLients = InputText();
            string path = "file1.dat";
            CreateAndWriteFile(path,listOfCLients);
            string textFromFirstFile = ReadFile(path);
            Console.WriteLine("\nТекст з першого файлу:");
            Console.WriteLine(textFromFirstFile);
            List<string[]> resultList = FindSpecialClients(listOfCLients);
            string path2 = "resultFile.dat";
            CreateAndWriteFile(path2,resultList);
            Console.WriteLine("\nТекст з другого файлу:");
            string textFromResultFile = ReadFile(path2);
            Console.WriteLine(textFromResultFile);

        }
    }
}