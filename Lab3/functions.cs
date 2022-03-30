using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab3dotnet
{
    public static class functions
    {
        public static void Input(int count,List<Employee> list)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Робітник {i+1}:");
                Console.Write("Введіть ім'я:");
                string name = Console.ReadLine();
                Console.Write("Введіть прізвище:");
                string surname = Console.ReadLine();
                Console.Write("По батькові:");
                string patronymic = Console.ReadLine();
                string date;
                Console.Write("Введіть дату народження у форматі 'ММ-ДД-РРРР':");
                do
                {
                    date = Console.ReadLine();
                    if (ValidDate(date))
                    {
                        break;
                    }

                    Console.Write("Ви ввели дату в неправильному форматі, або недопустимі значення віку, будь ласка введіть у форматі 'ММ-ДД-РРРР':");

                } while (true);

                list.Add(new Employee(name, surname, patronymic, date));
                Console.WriteLine();
            }
        }

        public static void Output(List<Employee> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"Робітник:{i+1}:");
                list[i].Print();
                Console.WriteLine();
            }
        }

        public static bool ValidDate(string date)
        {
            Regex regex = new Regex(@"\d{2}-\d{2}-\d{4}");
            if (regex.IsMatch(date))
            {
                string[] number = date.Split(new char[] {'-'});
                if (Int32.Parse(number[0]) <= 12 && Int32.Parse(number[0]) > 0 && Int32.Parse(number[1]) <= 31 &&
                    Int32.Parse(number[1]) > 0 && Int32.Parse(number[2]) <= 2004 && Int32.Parse(number[2]) >= 1962)
                {
                    return true;
                }
            }
            return false;
        }

        public static int OldestWorker(List<Employee> workers)
        {
            int positionOfOldest = 0;
            for (int i = 1; i < workers.Count; i++)
            {
                string[] birthday1 = workers[positionOfOldest].birthday.Split(new[] {'-'});
                string[] birthday2 = workers[i].birthday.Split(new[] {'-'});
                DateTime data1 = new DateTime(Int32.Parse(birthday1[2]), Int32.Parse(birthday1[0]), Int32.Parse(birthday1[1]));
                DateTime data2 = new DateTime(Int32.Parse(birthday2[2]), Int32.Parse(birthday2[0]), Int32.Parse(birthday2[1]));
                if (data2 < data1)
                {
                    positionOfOldest = i;
                }
            }

            return positionOfOldest;
        }
    }
}