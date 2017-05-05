from sql_base import*
from random import randint
from azim import*
from exception import*
lat2=56.837507
long2=60.603766

def coordHandler(data):
    def longCord(data):
        data=data.split()
        longt=float(data[1])
        print(data[1])
        return longt
    def latCord(data):
        data=data.split()
        lat=float(data[2])
        return lat
    set_Coord(data[0],longht, lat)
    if checkAim() == "false":
        return azimut(latCord(data), longCord(data), lat2 ,long2)
    else:
        

def set_Aim_Player():
    aim = set_Aim()
    aim = aim.split()
    return azimut(latCord(data), longCord(data), lat2 ,long2)


def checkAim():
    check= "false"
    dist = azimut(latCord(data), longCord(data), lat2 ,long2)
    dist= dist.split()
    if int(dist[0])<50:
        check= "true"
        print("рядом с целью")
    print("не рядом")    
    return check    

def registCheck(data):
    data=data.split()
    check=checking(data[0],data[1])
    return check

def regisTrat(data):
    data=data.split()
    check=str(False)
    if check == checking(data[1],data[2]):
        add_user(data[0],data[1],data[2])
        check=str(True)
    return check    

def checkString(data):
    data=data.split()
    data_len=len(data)
    a="ne rabotaet gps idiot"
    if findClientBug(data)== True:
        print("/n")
    else:
        if data[0]=="coord" and data[data_len-1]:
            string = data[data_len-2] + " " + data[1] + " " + data[2]
            a = coordHandler(string)
        
        elif data[0]=="coord":
            string = data[1] + " " + data[2]
            a = coordHandler(string)
        elif data[0] == "TreshFounded":
            a= checkAim()
        elif data[0]=="login" :
            string = data[1] + " " + data[2]
            a = registCheck(string)
        elif data[0] =="regist":
            string = data[1] + " " + data[2] + " " + data[3]
            a = regisTrat(string)
    return a


