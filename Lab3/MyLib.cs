using System;
using System.Text.RegularExpressions;

namespace Lab3dotnet
{
        
    public class Employee
    {
        public string name;
        public string surname;
        public string patronymic;
        public string birthday;

        public Employee(string name, string surname, string patronymic, string birthday)
        {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.birthday = birthday;
        }

        public void Print()
        {
            Console.WriteLine($"Прізвище: {surname}   Ім'я: {name}   По батькові: {patronymic}   Дата народження:{birthday}");
        }
    }
}