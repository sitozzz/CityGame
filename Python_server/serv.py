import socket
from azim import*
from parsing import*

serv_sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM, proto=0)
print(type(serv_sock))
serv_sock.bind((socket.gethostname(),14880))
serv_sock.listen(10)
print(socket.gethostname())
             

while True:
        client_sock, client_addr = serv_sock.accept()
        print('Connected by',client_addr)
        while True:
                data= client_sock.recv(1024)
                data=data.decode('ascii')
                print("Recieved", data)
                if data ==(""):
                        print("hi")
                       # client_sock.sendall("GI".encode())
                else:
                        print(data)
                        client_sock.sendall(checkString(data).encode())
                if not data:
                        break
		
