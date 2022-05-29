using System;
using System.Linq;

namespace Lab5
{
    public abstract class TDate
    {
        protected int day;
        protected int month;
        protected int year;

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

        public int CompareTo(string date)
        {
            string[] numbers;
            int day1 = 0;
            int month1 = 0;
            int year1 = 0;
            if (date.Contains('.'))
            {
                numbers = date.Split('.');
                day1 = int.Parse(numbers[0]);
                month1 = int.Parse(numbers[1]);
                year1 = int.Parse(numbers[2]);

            }else if (date.Contains('-'))
            {
                numbers = date.Split('-');
                day1 = int.Parse(numbers[1]);
                month1 = int.Parse(numbers[0]);
                year1 = int.Parse(numbers[2]);
            }

            if (this.year < year1 ||
                this.year == year1 && (this.month < month1 || this.month == month1 && this.day < day1)) return -1;
            if (this.year == year1 && this.month == month1 && this.day == day1) return 0;
            return 1;
        }

        public void AddYears(int count)
        {
            if (count < 0)
            {
                throw new Exception("unvalid value");
            }
            this.year += count;
        }

        public void AddMonth(int count)
        {
            if (count < 0)
            {
                throw new Exception("unvalid value");
            }
            int years = count / 12;
            int remainder = count % 12;
            this.year += years;
            this.month += remainder;
            if (this.month > 12)
            {
                this.year++;
                this.month -= 12;
            }
        }

        public void AddDays(int count)
        {
            if (count < 0)
            {
                throw new Exception("unvalid value");
            }
            int years = count / 365;
            int month = (count % 365) / 30;
            int days = (count % 365) % 30;
            this.year += years;
            this.month += month;
            if (this.month > 12)
            {
                this.year++;
                this.month -= 12;
            }

            this.day += days;
            if (this.day > 30)
            {
                if (this.month < 12)
                {
                    this.month++;
                }
                else
                {
                    this.year++;
                }

                this.day -= 30;
            }
        }

        public void SubstractYears(int count)
        {
            if (count < 0)
            {
                throw new Exception("unvalid value");
            }

            this.year -= count;
        }

        public void SubstractMonth(int count)
        {
            if (count < 0)
            {
                throw new Exception("unvalid value");
            }

            int years = count / 12;
            int month = count % 12;
            this.year -= years;
            this.month -= month;
            if (month < 0)
            {
                this.year--;
                this.month += 12;
            }
        }

        public void SubstractDays(int count)
        {
            if (count < 0)
            {
                throw new Exception("unvalid value");
            }
            int years = count / 365;
            int month = (count % 365) / 30;
            int days = (count % 365) % 30;
            this.year -= years;
            this.month -= month;
            if (this.month < 0)
            {
                this.year--;
                this.month += 12;
            }

            this.day -= days;
            if (this.day < 30)
            {
                if (this.month == 1)
                {
                    this.month = 12;
                    this.year--;
                }

                this.day += 30;
            }
            
        }

        
    }

    public class TDate1 : TDate
    {
        public TDate1(string date)
        {
            string[] numbers = date.Split('.');
            this.day = int.Parse(numbers[0]);
            this.month = int.Parse(numbers[1]);
            this.year = int.Parse(numbers[2]);
        }

        public override string ToString()
        {
            return $"{this.day}.{this.month}.{this.year}";
        }
    }

    public class TDate2 : TDate
    {
        public TDate2(string date)
        {
            string[] numbers = date.Split('-');
            this.day = int.Parse(numbers[1]);
            this.month = int.Parse(numbers[0]);
            this.year = int.Parse(numbers[2]);
        }
        public override string ToString()
        {
            return $"{this.month}-{this.day}-{this.year}";
        }
    }
    
}