import duckdb
import requests
import time, os
import pandas as pd
import json

cur_time = time.time()
baseassetdir = os.path.dirname("./assets/")
filename = "/Sales_Product_Combined.csv"


''' 
# loop through the rows using iterrows()
for index, row in sales.iterrows():
    print(row['Order ID'], row['Product'])

salaries = {
    'Data Scientist': 10000,
    'Data Analyst': 20000,
    'Data Engineer': {
        'salary':5000
    },
}
sales = pd.read_csv(f"{baseassetdir}{filename}")
print(sales)

j = json.dumps(salaries)
print(j)

rr = pd.read_json(j)
print(rr)

'''
# con = duckdb.connect("D:\TestingData\dockervolumes\duckdb\mydb.duckdb")
# sales = pd.read_csv(f"{baseassetdir}{filename}")
# print(sales.head(10))
# print (f"time: {round((time.time() - cur_time),2)} secs")

# print("------------------------------------")

# duckdbtime = time.time()
# df = con.sql(f"select * from '{baseassetdir}{filename}'")
# #print(df)
# print (f"time: {round((time.time() - duckdbtime),2)} secs")
# print(con.sql(f"select count(*) from df"))

# con.execute(""" 
# create or replace table sales as
#             select * from df
# """)

# pd1 = con.sql("""
# select * from sales
# """).show()

# con.execute("""
# COPY sales TO 'output.json' (FORMAT JSON, ARRAY true);
# """)

class requestApi:

    base_url = "https://gorest.co.in/public/v2/"
    access_token = "221617f1e325c4ca1c21e3bb7ac01bfd42e26168925f77fd7d3a987999928c47"
    
    # sending a get request
    def getUsers(self,pageNo,per_Page):
        url = self.base_url + '/users'
        qParams={"page":pageNo,"per_page":per_Page}
        r = requests.get(url=url,params=qParams)
        j = r.json()
        df = pd.DataFrame(j)
        return df

# 
class duckDB:

    def __init__(self) -> None:        
        self.con = duckdb.connect("D:\TestingData\dockervolumes\duckdb\mydb.duckdb")
    
    def __createTable(self,tableName,df):
        my_dictionary = {}
        my_dictionary["test_df"] = df
        self.con.register("test_df_view", my_dictionary["test_df"])
        self.con.sql(f"""            
            create or replace table gorestapi.{tableName} as       
            select * from test_df_view;
        """)
        self.con.sql(f"""
            truncate table gorestapi.{tableName};           
        """)

    def insertRecords(self,schema,tableName,df):
        my_dictionary = {"dfDict":df}
        self.con.register("df", my_dictionary["dfDict"])
        self.con.sql(f"""
                     INSERT INTO {schema}.{tableName} 
                     SELECT * FROM df  
                     """)

    def selectTableRecords(self):
        self.con.sql(f""" 
            select * from gorestapi.users
                     order by id desc
                     LIMIT 10;
        """).show()

    # sales = pd.read_csv(f"{baseassetdir}{filename}")
    # print(sales.head(10))
    # print (f"time: {round((time.time() - cur_time),2)} secs")

#trying to see the cookies in my system for a site
def getCookies():
    s = requests.Session()
    r = s.get("https://www.google.com")
    print(json.dumps(dict(r.cookies),indent=8))

# sending a post request
def postUser():    
    url = base_url + "users/"
    d = mockUser()
    black_list_values = set(("family","id"))
    u = {k:v for k,v in d.items() if k not in black_list_values}
    headers = {'Authorization':'Bearer ' + access_token}
    res = requests.post(url=url,data=u,headers=headers)
    print(f"{res.status_code} \n --- \n {res.headers}, \n --- \n {res.json()}")


def mockUser():
    user = dict()
    user['name']="Darren"
    user['email']="smartydarren@gmail.com"
    user['gender']="male"
    user['status']="active"
    user['role']="FullStack"
    user['family']={"parents":{"father":"roque","mother":"luiza"},
                    "immFamily":{"wife":"A","daughter":"A","son":"D"}}
    return user

ob = requestApi()
rt = ob.getUsers(1,100)
print(rt)

#duckdb.sql("select * from rt").fetchall()

dkd = duckDB()
#dkd.insertRecords("gorestapi","users",rt)
#dkd.selectTableRecords()
dkd.con.sql("select timestamp()").show()