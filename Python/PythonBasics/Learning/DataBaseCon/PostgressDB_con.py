"""
Install the latest version of Python
I use vscode as my editor
ctr + Shift + P to select the interpreter as python
Install Postgress version 12 on your Laptop
pip install psycopg2
"""

import psycopg2
import sys, os

con = ""

try:

    con = psycopg2.connect(host='localhost', database='telusko', user='darrenquadros',
        password='relo@2020')

    cur = con.cursor()
    cur.execute('SELECT version()')
    version = cur.fetchone()[0]
    print(version)
   
    cur.execute('SELECT * FROM auth_user;')
    result = cur.fetchone()
    for i in result:
        print(i)

    #cur.execute('truncate table pers RESTART IDENTITY;')
    #cur.close()
    #con.close()

    for i in range(999):
        cur.execute("call MyInsert('Smooth Operator',36,LOCALTIMESTAMP);")   #inserting via stored procedure
        #cur.execute('select pg_sleep(60)')
        con.commit()
        print(i)
    cur.close()
    #con.close()

except psycopg2.DatabaseError as e:

    print(f'Error {e}')
    sys.exit(1)

finally:

    if con:
        con.close()

from django.db import connection
cursor = connection.cursor()
cursor.execute("SELECT version();")
result = cursor.fetchone()[0]
print(result)
