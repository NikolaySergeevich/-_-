from random import *
import json

films=[]


def save():
    with open("D:/Учёба в GB/Буткемп. Программирование/уроки/Локальный бот/films.json","w",encoding="utf-8") as fh:
        fh.write(json.dumps(films,ensure_ascii=False))
    print("Наша фильмотека была успешна сохранена в файле films.json")

def load():
    with open("D:/Учёба в GB/Буткемп. Программирование/уроки/Локальный бот/films.json","r",encoding="utf-8") as fh:
        films=json.load(fh)
    print("Фильмотека была успешна загружена")   

try:
    with open("films.json","r",encoding="utf-8") as fh:
        films=json.load(fh)
    print("Ваша фильмотека загружена")   
except:
    films.append("Матрица")
    films.append("Терминатор")
    films.append("Властелин колец")
    films.append("Техасская резня бензопилой")
    films.append("Санта барбора") 


while True:
    command=input("введите команду: ")
    if command=="/start":
        print("Бот-фильмотека начал свою работу")
    elif command=="/stop":
        save()
        print("Бот закончил свою работу")
        break
    elif command=="/all":
        print("Вот текущий список фильмов")
        print(films)
    elif command =="/add":
        f=input("Введите название фильма, который нужно добавить в фильмотеку")
        films.append(f)
        print("Фильм был успешно добавлен в коллекцию")
    elif command=="/help":
        print("Здесь какой-то манул")
    elif command=="/delete":
        f=input("Введите название фильма, который нужно удалить")
        '''
        if f in films:
            films.remove(f)
            print("Фильм Был успешно удалён")
        else:
            print("Такого фильма нет в вашей коллекции")
        '''
        try:
            films.remove(f)
            print("Фильм Был успешно удалён")
        except:
            print("Такого фильма нет в вашей коллекции")
    elif command=="/random":
       # rnd=randint(0,len(films)-1)
       # print("РЎР»РµРїРѕР№ Р¶СЂРµР±РёР№ РїРѕРєР°Р·Р°Р» РІР°Рј С„РёР»СЊРј -" + films[rnd])
       print("Слепой жребий выбрал вам фильм для просмотра" + choice(films) )
    elif command =="/save":
        save()
    elif command=="/load":
        with open("films.json","r",encoding="utf-8") as fh:
            films=json.load(fh)
        print("Коллекция была успешна загружена")   
    else:
        print("Такой команды нет, обратитесь к /help")