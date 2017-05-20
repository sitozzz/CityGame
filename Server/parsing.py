from sql_base1 import*
from random import randint
from azim import*
from exception import*
from game_objects import*


def coordHandler(data):
    kata=data.split()
    def longCord(data):
        data=data.split()
        longt=float(data[0])
        return longt
    def latCord(data):
        data=data.split()
        lat=float(data[1])
        return lat
    #set_Coord(kata[2],longCord(data), latCord(data))
    if checkAim(data) == "0":
        return Min_dist_treasure(data)
        print(azimut(latCord(data), longCord(data), lat2 ,long2))
    else:
        return Min_dist_treasure(data)
        

def set_Aim_Player(data):
    aim = set_Aim()
    aim = aim.split()
    # расстояние до цели
    return azimut(latCord(data), longCord(data), float(aim[0]) ,float(aim[1]))


def checkAim(data):
    check = "0"
    print(lat)
    dist = Min_dist_treasure(data)
    dist= dist.split()
    if int(dist[0])<50:
        check = "1"       
    print(check)
    return check    

def registCheck(data):
    data=data.split()
    check=checking(data[0],data[1])
    print(check)
    return check

def regisTrat(data):
    data=data.split()
    check=str(False)
    if check == checking(data[1],data[2]):
        add_user(data[0],data[1],data[2])
        check=str(True)
    return check

    
def checkString(data):
    alldata=data
    data=data.split()
    data_len=len(data)
    a= "hui"

    if findClientBug(data)== True:
        print(" ")
    else:

        #Сверка с координатами клада, нахождение минимального и отправка клиенту
        if data[1]=="coord":
            set_Coord(data[0],data[2],data[3])
            string = data[0] + " " + data[1]+ " " +data[2] + " " + data[3]
            if checkAim(alldata)=="1":
                a="1"
            else:    
                a = coordHandler(string) + " " +"Ближайший_К_Вам_Объект "

        elif data[1] =="FindAim":
            set_Coord(data[0],data[2],data[3])
            set_Aim(data[0])
            aim_coord=(get_AimCoord((get_AimName(data[0])),4)).split()
            a = azimut (float(data[2]),float(data[3]),float(aim_coord[0]),float(aim_coord[1]))+ " " + get_AimName(data[0]) + " "
        elif data[0] == "TreshFounded":
            a= checkAim()


        #регистрация и авторизация
        elif data[0]=="login" :
            string = data[1] + " " + data[2]
            a = registCheck(string) + " " + get_AimCoord(data[1],7)
        elif data[0] =="regist":
            string = data[1] + " " + data[2] + " " + data[3]
            a = regisTrat(string)


    print("a ="+ a)        
    return a


# Координаты цели получены, получить координаты охотника, сравнить и отправить...
