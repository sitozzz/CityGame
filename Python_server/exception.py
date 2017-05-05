def findClientBug(data):
    lenght=len(data)
    answer=False
    if data[0]=="coord" and lenght==1:
        answer=True
    elif (data[0] =="login" or "regist") and (lenght ==1 or lenght ==2):
        answer=True
    elif (data[0]=="regist") and (lenght ==1 or lenght==2 or lenght==3):
        answer=True
    return answer
    
