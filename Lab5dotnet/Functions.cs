using System;
using System.Collections.Generic;

namespace Lab5
{
    public class Functions
    {
        public static bool isValid1(string date)
        {
            string[] arr = date.Split('.');
            foreach (var VARIABLE in arr)
            {
                if (!int.TryParse(VARIABLE, out int number)) return false;
            }
            int day = Int32.Parse(arr[0]);
            int month = Int32.Parse(arr[1]);
            int year = Int32.Parse(arr[2]);
            if ((day < 1 || day > 31) || (month < 1 || month > 12)) return false;
            return true;
        }
        public static bool isValid2(string date)
        {
            string[] arr = date.Split('-');
            foreach (var VARIABLE in arr)
            {
                if (!int.TryParse(VARIABLE, out int number)) return false;
            }
            int day = Int32.Parse(arr[1]);
            int month = Int32.Parse(arr[0]);
            int year = Int32.Parse(arr[2]);
            if (day < 1 || day > 31 || month < 1 || month > 12) return false;
            return true;
        }
        public static string OldestDate(List<TDate1> list1, List<TDate2> list2)
        {
            string result = list1[0].ToString();
            for (int i = 1; i < list1.Count; i++)
            {
                if (list1[i].CompareTo(result) < 0) result = list1[i].ToString();
            }

            for (int i = 0; i < list2.Count; i++)
            {
                if (list2[i].CompareTo(result) < 0) result = list2[i].ToString();
            }

            return result;
        }
        public static List<string> ListDatesBetween(List<TDate1> list1, List<TDate2> list2, string date1, string date2)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].CompareTo(date1) >= 0 && list1[i].CompareTo(date2) <= 0)
                {
                    result.Add(list1[i].ToString());
                }
            }
            for (int i = 0; i < list2.Count; i++)
            {
                if (list2[i].CompareTo(date1) >= 0 && list2[i].CompareTo(date2) <= 0)
                {
                    result.Add(list2[i].ToString());
                }
            }
            

            return result;
        }
        public static void Input1(List<TDate1> list,int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("Введіть дату для першого об'єкта в форматі 'ЧЧ.ММ.РРРР': ");
                string date;
                do
                {
                    date = Console.ReadLine();
                    if (isValid1(date))
                    {
                        break;
                    }

                    Console.Write("Ви ввели дату в неправильному форматі, спробуйте ще раз: ");
                } while (true);
                list.Add(new TDate1(date));
            }
        }
        public static void Input2(List<TDate2> list,int m)
        {
            for (int i = 0; i < m; i++)
            {
                Console.Write("Введіть дату для другого об'єкта в форматі 'ММ-ЧЧ-РРРР': ");
                string date;
                do
                {
                    date = Console.ReadLine();
                    if (isValid2(date))
                    {
                        break;
                    }

                    Console.Write("Ви ввели дату в неправильному форматі, спробуйте ще раз: ");
                } while (true);
                list.Add(new TDate2(date));
            }
        }
    }
}