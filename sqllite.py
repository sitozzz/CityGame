# -*- coding: utf-8 -*-
import sqlite3
global row
import sys
from random import*
#Подключение к базе
#conn = sqlite3.connect('my.sqlite')
#Создание курсора
#c = conn.cursor()
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
#c.execute('SELECT * FROM users')
#row = c.fetchone()


"""
with conn:
    c = conn.cursor()    
    c.execute("UPDATE users SET password=? WHERE name=?", (upassword, uname))        
    conn.commit()
    print ("Number of rows updated: %d" % c.rowcount)
    row = c.fetchone()
    c.execute('SELECT * FROM users')
    c.close()
    """
#def setCoord(userlogin):
 #   conn = sqlite3.connect('my.sqlite')
  #  c = conn.cursor()
   # c.execute('INSERT INTO users

#def getCoord():
 #   conn = sqlite3.connect('my.sqlite')
  #  c = conn.cursor()
   # c.execute("SELECT * FROM users WHERE name = 'Veniamin' ")
userlogin= "Venik"
long = "10"
lat = "23"
def set_Coord(userlogin, long, lat):
    conn = sqlite3.connect('my.sqlite')
    usercoord = str(long) + " " + str(lat)
    c = conn.cursor()
    row = c.fetchone()
    with conn:    
        c.execute('SELECT * FROM users')
        c.execute("UPDATE users SET coordinates=? WHERE login=?", (usercoord, userlogin))
        conn.commit()
        print ("Number of rows updated: %d" % c.rowcount)
    c.close()
    conn.close()
        


def checking(login,passwd):
    conn = sqlite3.connect('my.sqlite')
    c = conn.cursor()
    c.execute('SELECT * FROM users')
    row = c.fetchone()
    check=str(False)
    while row is not None:
        if login == ((str(row[2]))) and passwd == (str(row[3])):
            check=str(True)
        row = c.fetchone()
    c.close()
    conn.close()    
    return check

def counter_Row():
    conn = sqlite3.connect('my.sqlite')
    c = conn.cursor()
    c.execute('SELECT * FROM users')
    row = c.fetchone()
    check=str(False)
    counter=0
    while row is not None:
        counter+=1
        row = c.fetchone()
    c.close()
    conn.close()    
    return counter

print("vot ",counter_Row())

      
def set_hunter(k):
    conn= sqlite3.connect('my.sqlite')
    cur = conn.cursor()
    cur.execute('SELECT * FROM users')
    row1 = cur.fetchone()
    count = 0
    check=False
    print("здесб")
    while row1 is not None:
        if k==count:
            if ((row1[5]== None) or (row1[5]== "")) :
                aim= row1[2]
                row1=cur.fetchone()
                check=aim
            else:
                check=False
        count+=1    
        row1=cur.fetchone()
    return check
       
    
def set_Aim(login):
    conn = sqlite3.connect('my.sqlite')
    c = conn.cursor()
    c.execute('SELECT * FROM users')
    row = c.fetchone()
    k=randint(1,counter_Row())
    k=5
    while row is not None:
        if login == (str(row[2])) and (row[6]==None or row[6]==""):
            print(row[2])
            aim=set_hunter(k)
            print(aim)
            if aim!= False:
                c.execute("UPDATE users SET aim=? WHERE login=?", (aim, login))
                c.execute("UPDATE users SET hunter=? WHERE login=?", (login, aim))
                conn.commit()
        row=c.fetchone()        
    c.close()
    conn.close()            

set_Aim("Venik")
                            
        

uslogin = "Venik"
def check_Object(uslogin):
    conn = sqlite3.connect('my.sqlite')
    c = conn.cursor()
    row = c.fetchone()
    with conn:    
        c.execute('SELECT * FROM users')
        c.execute("UPDATE users SET TObject=? WHERE login=?", (1, uslogin))
        conn.commit()
        print ("Number of rows updated: %d" % c.rowcount)
    c.close()
    conn.close()
check_Object(uslogin)

#выводим список пользователей в цикле
#while row is not None:
#   print("id:"+str(row[0])+" Имя: "+row[1]+" | Логин: "+row[2] +" | Пароль: " +row[3])
#   row = c.fetchone()
#закрываем соединение с базой

#c.close()
#conn.close()
