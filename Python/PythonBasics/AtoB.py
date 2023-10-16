import requests
import json
import pyodbc
import time

class APIS:
    def __init__(self,name):
        self.name = name

def copytoDB(listOfApi) :
    driver = 'Driver={SQL Server};'
    server = 'Server=localhost,1433;'
    database = 'Database=test;' 
    username = 'test;'
    password = 'test@2023;'
    tsc = 'TrustServerCertificate=false;'

    cnxn = pyodbc.connect(driver+server+database+username+password+tsc)
    print(cnxn)

    # listofapia = []
    # for apik in data['entries']:
    #     listofapia.append(APIS(name=apik['API']))
    #     cursor = cnxn.cursor()        
    #     for i in listofapia:
    #         cursor.execute(f"insert into dbo.apis (name) values({i.name})")   #inserting via stored procedure
    #     cursor.close()
    # cnxn.commit()
    # cnxn.close()

    return "inserted successfully"

response = requests.get('https://api.publicapis.org/entries')
data = json.loads(response.text)

#result = copytoDB(data)
#print(result)
i = 1
while i < 3:
    print(data)
    print('\n----------------------------------------------')
    time.sleep(5)
    i += 1




