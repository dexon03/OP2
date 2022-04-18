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
            obj.month++;
            return obj;
        }

        public static Data operator --(Data obj)
        {
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
    }
}