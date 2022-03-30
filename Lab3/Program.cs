using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static Lab3dotnet.functions;

namespace Lab3dotnet
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введіть кількість робітників:");
            int countOfEmployee = Convert.ToInt32(Console.ReadLine());
            
            List<Employee> workers = new List<Employee>();
            Input(countOfEmployee, workers);
            Output(workers);
            Console.WriteLine();
            int indexOfOldesWorker = OldestWorker(workers);
            Console.WriteLine("Найстарший робітник:");
            workers[indexOfOldesWorker].Print();
        }
    }
}