import keyboard

def CreateAndFillFile(fileName):
    with open(fileName + ".txt",'at',newline='\n') as file:
        print('Введіть текст для файлу(щоб завершити,натисніть ctrl + space + enter):')
        text = ''
        while not  keyboard.is_pressed('ctrl + space'):
            text += ('' if text=='' else '\n') + input()
        file.write(text)


def CreateUnitFile(fileName1, fileName2):
    file = open(fileName1 + '.txt','rt')
    textFile1 = file.read()
    file.close()
    file = open(fileName2 + '.txt','rt')
    textFile2 = file.read()
    file.close()
    finaleText = textFile1 + '\n' + textFile2
    with open('result.txt','wt',newline='\n') as file:
        file.write(finaleText)


def CountOfRow(fileName):
    with open(fileName + '.txt','rt') as file:
        text = file.read()
        if not text:
            count = 0
        else:
            count = 1
            for symb in text:
                if symb == '\n':
                    count+=1
    return count

def ReadText(fileName):
    file = open(fileName + '.txt','rt')
    result = file.read()
    file.close()
    return result
        


fileName1 = input("Введіть назву першого файла:")
CreateAndFillFile(fileName1)
fileName2 = input("Введіть назву другого файла:")
CreateAndFillFile(fileName2)
CreateUnitFile(fileName1,fileName2)
print('Текст в вихідному файлі:')
unitText = ReadText('result')
print(unitText)
countOfRow = CountOfRow('result')
print('Кількість рядків у вихідному файлі:',str(countOfRow))




