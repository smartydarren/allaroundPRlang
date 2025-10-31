"""
Install the latest version of Python
I use vscode as my editor
ctr + Shift + P to select the interpreter as python
Install pyodbc(pip install pyodbc) on your Laptop (pip show pyodbc)
Install django-mssql-backend (pip install django-mssql-backend)
"""
#%%
import pyodbc
import sys, os

driver = 'Driver={SQL Server};'
server = 'Server=RELOUATDB2K12\TESTENV01;'
database = 'Database=telusko;' 
username = 'telusko;' 
password = 'relo@2020;'
tsc = 'Trusted_Connection=yes;'

cnxn = pyodbc.connect(driver+server+database+username+password+tsc)

cursor = cnxn.cursor()
 
for i in range(5000):
    cursor.execute("declare @tmpdate datetime = getdate() execute dbo.myinsert 'Denver',36,@tmpdate")   #inserting via stored procedure
    #cur.execute('select pg_sleep(60)')
    cursor.commit()
    print(i)

result = cursor.execute('SELECT top 10 * from pers order by ID desc')
for i in result:
   print(i.id,i.name,i.age,i.inserted_dt)
cnxn.close()





   

   