from TDate import *
from functions import *

n = int(input("Скільки об'єктів TDate1 бажаєте створити: "))
m = int(input("Скільки об'єктів TDate2 бажаєте створити: "))
list_of_Date1 = []
input1(list_of_Date1, n)

list_of_Date2 = []
input2(list_of_Date2, m)
oldest_Date = oldest_date(list_of_Date1, list_of_Date2)

print('Сама пізня дата: ' + oldest_Date + '\n')
print("Введіть проміжок дат в одному з двох форматів")
while(True):
    begin = input('Початок: ')
    if is_valid1(begin) or is_valid2(begin):
        break
    print('Ви ввели в неправильному форматі, спробуйте ще раз')
while(True):
    end = input('Кінець: ')
    if is_valid1(end) or is_valid2(end):
        break
    print('Ви ввели в неправильному форматі, спробуйте ще раз')

result_list = list_dates_between(list_of_Date1, list_of_Date2, begin, end)
print('Результат: ')
if len(result_list) == 0:
    print('Немає дат з цього проміжку')
else:
    for i in range(len(result_list)):
        print("Дата {0}: {1}".format(i+1,result_list[i]))










