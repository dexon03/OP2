from TDate import *


def is_valid1(date):
    arr = date.split('.')
    for symbol in arr:
        if not symbol.isdigit():
            return False
    day = int(arr[0])
    month = int(arr[1])
    year = int(arr[2])
    if day < 1 or day > 31 or month < 1 or month > 12:
        return False
    return True


def is_valid2(date):
    arr = date.split('-')
    for symbol in arr:
        if not symbol.isdigit():
            return False
    day = int(arr[1])
    month = int(arr[0])
    year = int(arr[2])
    if day < 1 or day > 31 or month < 1 or month > 12:
        return False
    return True


def oldest_date(list1, list2):
    result = list1[0].__str__()
    for i in range(len(list1)):
        if list1[i].compare_to(result) < 0:
            result = list1[i].__str__()
    for i in range(len(list2)):
        if list2[i].compare_to(result) < 0:
            result = list2[i].__str__()
    return result


def list_dates_between(list1, list2, date1, date2):
    result = []
    for ele in list1:
        if ele.compare_to(date1) >= 0 and ele.compare_to(date2) <= 0:
            result.append(ele.__str__())
    for ele in list2:
        if ele.compare_to(date1) >= 0 and ele.compare_to(date2) <= 0:
            result.append(ele.__str__())
    return result
def input1(list, n):
    for i in range(n):
        print("Введіть дату для першого об'єкта в форматі 'ЧЧ.ММ.РРРР': ")
        date = ''
        while(True):
            date = input()
            if is_valid1(date):
                break
            print("Ви ввели дату в неправильному форматі, спробуйте ще раз: ")
        list.append(TDate1(date))

def input2(list, n):
    for i in range(n):
        print("Введіть дату для другого об'єкта в форматі 'ММ-ЧЧ-РРРР': ")
        date = ''
        while(True):
            date = input()
            if is_valid2(date):
                break
            print("Ви ввели дату в неправильному форматі, спробуйте ще раз: ")
        list.append(TDate2(date))


