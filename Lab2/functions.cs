using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab2dotnet
{
    public static class functions
    {
        public static List<string[]> InputText()
        {
            List<string[]> list = new List<string[]>();
            Console.WriteLine("Якшо хочете закінчити ввід - натисність delete, інакше любу іншу клавішу.");
            do
            {
                Console.Write("Введіть прізвище:");
                var a = Console.ReadKey();
                if (a.Key == ConsoleKey.Delete) break;
                
                string[] person = new string[3];
                
                person[0] = a.KeyChar + Console.ReadLine();
                do
                {
                    Console.Write("Введіть час приходу в форматі (HH:mm):");
                    do
                    {
                        person[1] = Console.ReadLine();
                        if (ValidTime(person[1])) break;
                        

                        Console.Write("Ви ввели час в неправильному форматі, або недопустипі значення. Будь ласка введіть коректний час:");
                    } while (true);
                
                    Console.Write("Введіть час закінчення обслуговування в форматі (HH:mm):");
                    do
                    {
                        person[2] = Console.ReadLine();
                        if (ValidTime(person[2]) && isAdmissible(person[1],person[2])) break;

                        Console.Write("Ви ввели час в неправильному форматі, або недопустипі значення. Будь ласка введіть коректний час:");
                    } while (true);

                    if (!isCrossing(list, person[1], person[2])) break;
                    

                    Console.WriteLine("Час прийому який ви ввели неможливий, оскільки пересікаєтся з вже існуючими клієнтами, спробуйте ще раз.");
                } while (true);
                

                list.Add(person);
            } while (true);

            return list;
        }

        public static bool isAdmissible(string time1, string time2)
        {
            DateTime time_start = DateTime.Parse(time1);
            DateTime time_end = DateTime.Parse(time2);
            if (time_end < time_start) return false;
            return true;
        }

        public static bool ValidTime(string time)
        {
            Regex regex = new Regex(@"\b((09|1[0-7]):([0-5][0-9]\b))|18:00\b");
            if (regex.IsMatch(time))
            {
                return true;
            }
            return false;
        }

        public static bool isCrossing(List<string[]> list, string time_start, string time_end)
        {
            if (list.Count != 0)
            {
                DateTime date_start1 = DateTime.Parse(time_start);
                DateTime date_end1 = DateTime.Parse(time_end);
                for (int i = 0; i < list.Count; i++)
                {
                    DateTime date_start2 = DateTime.Parse(list[i][1]);
                    DateTime date_end2 = DateTime.Parse(list[i][2]);
                    if (date_start1 > date_start2 && date_start1 < date_end2 ||
                        date_end1 > date_start2 && date_end1 < date_end2)
                    {
                        return true;
                    }
                }
            }
            

            return false;
        }

        public static void CreateAndWriteFile(string path,List<string[]> list)
        {
            
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                string line = null;
                for (int i = 0; i < list.Count; i++)
                {
                    line += (line==null?"":"\n")+  $"Прізвище:{list[i][0]}\t Час приходу: {list[i][1]}\t Час закінчення:{list[i][2]}";
                    
                }
                writer.Write(line);
            }

        }

        public static string ReadFile(string path)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path,FileMode.Open)))
            {
                string text = reader.ReadString();
                return text;
            }
        }

        public static List<string[]> FindSpecialClients(List<string[]> list)
        {
            List<string[]> resultList = new List<string[]>();
            for (int i = 0; i < list.Count; i++)
            {
                string[] time_start = list[i][1].Split(new[] {':'});
                string[] time_end = list[i][2].Split(new[] {':'});
                if (isSpecial(time_start, time_end))
                {
                    resultList.Add(list[i]);
                }
            }

            return resultList;
        }

        public static bool isSpecial(string[] time_start, string[] time_end)
        {
            int hours_start = Int32.Parse(time_start[0]);
            int hours_end = Int32.Parse(time_end[0]);
            int minutes_start = Int32.Parse(time_start[1]);
            int minutes_end = Int32.Parse(time_end[1]);
            if (hours_end - hours_start == 1)
            {
                if (minutes_start>30 && minutes_end < 30 && 60-minutes_start+minutes_end < 30)
                {
                    return false;
                }
            }

            int delta = minutes_end - minutes_start;
            if (hours_start == hours_end &&  delta < 30)
            {
                return false;
            }

            return true;
        }
    }
}
