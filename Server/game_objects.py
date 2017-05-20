import random
import azim

treasure_array = []
start_lat = 56.79
stop_lat = 56.92
start_long =60.58
stop_long =60.62
#lat=start_lat
#long=start_long
#count=0

#def Random_Treasure():
#    count = 0
#    while count < 1500:
#        lat= round(random.uniform(start_lat,stop_lat),6)
#        long= round(random.uniform(start_long,stop_long),6)
#        treasure_array.append(str(lat) + " " +str(long))
#        count += 1
#    return treasure_array


#treasure = Random_Treasure()

#f= open ("treasure.txt", "w")

#for i in range(1490):
#    f.write(treasure[i]+"\n")
#f.close()



def Min_dist_treasure(data):
    f = open("treasure.txt")
    data = data.split()
    min = 999999999
    minimum_distation=0
    for line in f:
        array=line.split()
        distAngles = azim.azimut(float(data[3]),float(data[2]),float(array[0]),float(array[1]))
        distAngle = azim.azimut(float(data[3]),float(data[2]),float(array[0]),float(array[1])).split()
        dist=int(distAngle[0])
        if dist < min:
            min=dist
            minimum_distation = distAngles
    return minimum_distation

#56.779869, 60.698939
#56.924577, 60.599491
#56.851522, 60.597894

#data = "Venik coord 56.851522 60.597894"
#print("min_dist" + str(Min_dist_treasure(data)))
