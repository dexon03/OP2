using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace Lab2dotnet
{
    public static class Functions
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
                        if (ValidTime(person[2]) && IsAdmissible(person[1],person[2])) break;

                        Console.Write("Ви ввели час в неправильному форматі, або недопустипі значення. Будь ласка введіть коректний час:");
                    } while (true);

                    if (!IsCrossing(list, person[1], person[2])) break;
                    

                    Console.WriteLine("Час прийому який ви ввели неможливий, оскільки пересікаєтся з вже існуючими клієнтами, спробуйте ще раз.");
                } while (true);
                

                list.Add(person);
            } while (true);

            return list;
        }

        public static bool IsAdmissible(string time1, string time2)
        {
            DateTime timeStart = DateTime.Parse(time1);
            DateTime timeEnd = DateTime.Parse(time2);
            if (timeEnd < timeStart) return false;
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

        public static bool IsCrossing(List<string[]> list, string timeStart, string timeEnd)
        {
            if (list.Count != 0)
            {
                DateTime dateStart1 = DateTime.Parse(timeStart);
                DateTime dateEnd1 = DateTime.Parse(timeEnd);
                for (int i = 0; i < list.Count; i++)
                {
                    DateTime dateStart2 = DateTime.Parse(list[i][1]);
                    DateTime dateEnd2 = DateTime.Parse(list[i][2]);
                    if (dateStart1 > dateStart2 && dateStart1 < dateEnd2 ||
                        dateEnd1 > dateStart2 && dateEnd1 < dateEnd2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void CreateAndWriteFile(string path,List<string[]> list)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream writer = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(writer,list);
            }

        }

        public static string ReadFile(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream writer = new FileStream(path, FileMode.OpenOrCreate))
            {
                List<string[]> list = (List<string[]>) formatter.Deserialize(writer);
                string text = null;
                for (int i = 0; i < list.Count; i++)
                {
                    text += (text==null?"":"\n")+  $"Прізвище:{list[i][0]}\t Час приходу: {list[i][1]}\t Час закінчення:{list[i][2]}";
                    
                }
                return text;
            }
        }

        public static List<string[]> FindSpecialClients(List<string[]> list)
        {
            List<string[]> resultList = new List<string[]>();
            for (int i = 0; i < list.Count; i++)
            {
                string[] timeStart = list[i][1].Split(new[] {':'});
                string[] timeEnd = list[i][2].Split(new[] {':'});
                if (IsSpecial(timeStart, timeEnd))
                {
                    resultList.Add(list[i]);
                }
            }

            return resultList;
        }

        public static bool IsSpecial(string[] timeStart, string[] timeEnd)
        {
            int hoursStart = Int32.Parse(timeStart[0]);
            int hoursEnd = Int32.Parse(timeEnd[0]);
            int minutesStart = Int32.Parse(timeStart[1]);
            int minutesEnd = Int32.Parse(timeEnd[1]);
            if (hoursEnd - hoursStart == 1)
            {
                if (minutesStart>30 && minutesEnd < 30 && 60-minutesStart+minutesEnd < 30)
                {
                    return false;
                }
            }

            int delta = minutesEnd - minutesStart;
            if (hoursStart == hoursEnd &&  delta < 30)
            {
                return false;
            }

            return true;
        }
    }
}