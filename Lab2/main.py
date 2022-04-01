from functions import *
import functions

listOFClients = InputText()

fileName1 = 'file1'

CreateFile(fileName1,listOFClients)

textFromFile = ReadFile(fileName1)

print('Текст з першого файлу: ')

print(textFromFile)

resultList = FindSpecialClients(listOFClients)

if len(resultList) != 0:
    fileName2 = 'file2'
    CreateFile(fileName2,resultList)
    print('Текст з другого файлу:')
    textFromResultFile = ReadFile(fileName2)
    print(textFromResultFile)
else:
    print('Немає клієнтів з тривалістю прийому понад 30 хвилин')

