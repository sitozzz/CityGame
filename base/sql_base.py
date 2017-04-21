# -*- coding: utf-8 -*-
import sqlite3
global row
#Подключение к базе
conn = sqlite3.connect('my.sqlite')
#Создание курсора
c = conn.cursor()
#Функция занесения пользователя в базу
def add_user(username,userlogin,userpass):
    conn = sqlite3.connect('my.sqlite')
    c = conn.cursor()
    c.execute("INSERT INTO users (name,login,password) VALUES ('%s','%s','%s')"%(username,userlogin,userpass))
    conn.commit()
    row = c.fetchone()
    c.execute('SELECT * FROM users')
    c.close()
    conn.close()
    return str(True)
#Вводим данные
#name = input("Введите Имя\n")
#login = input("Введите Логин\n")
#passwd = input("Введите Пароль\n")
#print('\n')
#Делаем запрос в базу
#print("Список пользователей:\n")
#add_user(name,login,passwd)
c.execute('SELECT * FROM users')
row = c.fetchone()


def checking(login,passwd):
    conn = sqlite3.connect('my.sqlite')
    c = conn.cursor()
    c.execute('SELECT * FROM users')
    row = c.fetchone()
    check=str(False)
    while row is not None:
        if login == ((str(row[2]))) or passwd == (str(row[3])):
            check=str(True)
        row = c.fetchone()
    c.close()
    conn.close()    
    return check    

#выводим список пользователей в цикле
while row is not None:
   print("id:"+str(row[0])+" Имя: "+row[1]+" | Логин: "+row[2] +" | Пароль: " +row[3])
   row = c.fetchone()
# закрываем соединение с базой

c.close()
conn.close()
