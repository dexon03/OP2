using System;
using System.Runtime.Remoting.Messaging;

namespace ConsoleApplication1
{
    public class Data
    {
        private int day;
        private int month;
        private int year;
        public static int YearNow = 2022;
        public Data(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;

        }
        public Data(int day, int month)
        {
            this.day = day;
            this.month = month;
            year = YearNow;

        }

        public int Day
        {
            set => day = value;
            get => day;
        }

        public int Month
        {
            set => month = value;
            get => month;
        }

        public int Year
        {
            set => year = value;
            get => year;
        }

        public static Data operator ++(Data obj)
        {
            if (obj.month == 12)
            {
                obj.year++;
                obj.month = 1;
                return obj;
            }
            obj.month++;
            return obj;
        }

        public static Data operator --(Data obj)
        {
            if (obj.month == 12 && obj.day == 31)
            {
                obj.year++;
                obj.month = 1;
                return obj;
            }
            if (obj.month == 2 && obj.day == 28)
            {
                obj.month++;
                obj.day = 1;
                return obj;
            }
            if (obj.month <= 7 && (obj.day == 31 && obj.month % 2 != 0 || obj.day == 30 && obj.month % 2 == 0))
            {
                obj.month++;
                obj.day = 1;
                return obj;
            }
            if (obj.month > 7 && (obj.day == 30 && obj.month % 2 != 0 || obj.day == 31 && obj.month % 2 == 0))
            {
                obj.month++;
                obj.day = 1;
                return obj;
            }
            obj.day++;
            return obj;
        }

        public static bool operator >(Data obj1, Data obj2)
        {
            if (obj1.year < obj2.year)
            {
                return false;
            }

            if (obj1.year == obj2.year && (obj1.month < obj2.month || obj1.month == obj2.month && obj1.day < obj1.day))
            {
                return false;
            }

            return true;
        }

        public static bool operator <(Data obj1, Data obj2)
        {
            if (obj1.year < obj2.year)
            {
                return true;
            }

            if (obj1.year == obj2.year && (obj1.month < obj2.month || obj1.month == obj2.month && obj1.day < obj1.day))
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(Data obj1, Data obj2)
        {
            if (obj1.day == obj2.day && obj1.year == obj2.year && obj1.month == obj2.month) return true;
            return false;
        }

        public static bool operator !=(Data obj1, Data obj2)
        {
            return !(obj1 == obj2);
        }

        public static int RemainedUntilEndOfTheYear(Data obj)
        {
            Data EndOfTheYearDate = new Data(31, 12, obj.year);
            if (obj == EndOfTheYearDate) return 0;
            int monthInDays = 0;
            if (obj.month <= 7)
            {
                for (int i = obj.month; i <= 7; i++)
                {
                    if (i % 2 != 0)
                    {
                        monthInDays += 31;
                    }else if (i % 2 == 0 && i != 2)
                    {
                        monthInDays += 30;
                    }
                    if (i == 2) monthInDays += 28;
                }

                for (int i = 8; i < 12; i++)
                {
                    if (i % 2 != 0)
                    {
                        monthInDays += 30;
                    }else if (i % 2 == 0)
                    {
                        monthInDays += 31;
                    }
                }
                
            }
            else
            {
                for (int i = obj.month; i < 12; i++)
                {
                    if (i % 2 != 0)
                    {
                        monthInDays += 30;
                    }else if (i % 2 == 0)
                    {
                        monthInDays += 31;
                    }
                }
            }


            int result = 31 - obj.day + monthInDays;
            return result;
        }

        public void Print()
        {
            Console.WriteLine($"Day:{day} Month:{month} Year:{year}");
        }
        
        public static Data Parse(string date)
        {
            string[] list = date.Split(new[] {'.'});
            int day = Int32.Parse(list[0]);
            int month = Int32.Parse(list[1]);
            if (list.Length == 2)
            {
                return new Data(day,month);
            }
            int year = Int32.Parse(list[2]);
            return new Data(day,month,year);
        }
    }
}