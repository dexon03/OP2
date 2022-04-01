import math
import keyboard
import re
import datetime
import pickle

def InputText():
    listOfClients = []
    print('Введіть список клієнтів, якщо хочете закінчити ввід, натисніть ctrl+space+enter після введеня часу закінчення обслуговування.')
    while not keyboard.is_pressed('ctrl+space'):
        person = []
        person.append(input('Введіть прізвище:')) 
        while True:
            time_start = input('Введіть час приходу в форматі (HH:mm):')
            while not isValid(time_start):
                time_start = input('Ви ввели час в неправильному форматі, або недопустимі значення. Будь ласка введіть коректний час:')
            time_end = input('Введіть час закінчення обслуговування в форматі (HH:mm):')
            while not (isValid(time_end) and isAdmissible(time_start,time_end)):
                time_end = input('Ви ввели час в неправильному форматі, або недопустимі значення. Будь ласка введіть коректний час:')
            if not isCrossing(listOfClients,time_start,time_end):
                break
            print('Час прийому який ви ввели неможливий, оскільки пересікаєтся з вже існуючими клієнтами, спробуйте ще раз')
        person.append(time_start)
        person.append(time_end)
        listOfClients.append(person)
    return listOfClients


def isValid(time):
    match = re.match(r'\b((09|1[0-7]):([0-5][0-9]\b))|18:00\b',time)
    if match:
        return True
    return False

def isAdmissible(time1,time2):
    time_start = datetime.datetime.strptime(time1,"%H:%M")
    time_end = datetime.datetime.strptime(time2,"%H:%M")
    if time_end>time_start:
        return True
    return False

def isCrossing(listOfClients,time1,time2):
    if len(listOfClients) != 0:
        time_start1 = datetime.datetime.strptime(time1,"%H:%M")
        time_end1 = datetime.datetime.strptime(time2,"%H:%M")
        for i in range (len(listOfClients)):
            time_start2 = datetime.datetime.strptime(listOfClients[i][1],"%H:%M")
            time_end2 = datetime.datetime.strptime(listOfClients[i][2],"%H:%M")
            if time_start1 > time_start2 and time_start1<time_end2 or time_end1 > time_start2 and time_end1 < time_end2:
                return True
    return False

def CreateFile(fileName,listOfClients):
    with open(fileName + '.dat','wb') as file:
        text = ''
        for i in range(len(listOfClients)):
            line = 'Прізвище: ' + listOfClients[i][0] + '\tЧас приходу: ' + listOfClients[i][1] + '\tЧас закінчення: ' + listOfClients[i][2]
            text+= ('' if text=='' else '\n') + line
        pickle.dump(text,file)

def ReadFile(fileName):
    with open(fileName + '.dat','rb') as file:
        result = pickle.load(file)
        return result
def FindSpecialClients(listOfClients):
    resultList = []
    for i in range(len(listOfClients)):
        time_start = listOfClients[i][1].split(':')
        time_end = listOfClients[i][2].split(':')
        if isSpecial(time_start,time_end):
            resultList.append(listOfClients[i])           
    return resultList

def isSpecial(time_start,time_end):
    hours_start = int(time_start[0])
    hours_end = int(time_end[0])
    minutes_start = int(time_start[1])
    minutes_end = int(time_end[1])

    if hours_end - hours_start == 1:
        if minutes_start>30 and minutes_end<30 and 60-minutes_start+minutes_end < 30:
            return False
    if hours_start == hours_end and minutes_end - minutes_start < 30:
        return False

    return True



        



