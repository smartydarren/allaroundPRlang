print("Hello World welcome Darren to Python Programming")
print(10*20)
print('0----')
print(' ||||')
print('*' * 10)

name = 'John'
age = 20
is_new = True
print('John is a new patient and is age is ' + str(age))


name = input('What is your Name? ')
color = input('What is your favourite color? ')
print(name + ' Likes ' + color)


weight_pounds = float(input('Enter weight in pounds '))
weight_conv_kgs = 0.45
print('Your weight in Kgs is : '+ str(weight_pounds * weight_conv_kgs))


#Multiline
print(''' 
Hi john

This is Darren


''')


name = 'Darren'
print(name[1:-1])


#formatted String
first = 'Darren'
last = 'Quadros'

message = f'{first} [{last}] is a coder'
print (message)


# Importing a math function module
import math
print(math.floor(3.78))


home_cost = 5000000
good_credit = True
if good_credit:
    downpayment = (home_cost * 0.1)
    downpayment = (home_cost * 0.5)
else:
    downpayment = (home_cost * 0.2)

print(f"Hello Buyer you down payment would be: INR {downpayment} ")

#Logical conditions
#and or not, comparision operators ><=!= etc ==

#eg test
name = input('What is your Name? ')
if len(name) < 3:
    print("name too short")
elif len(name) > 50:
    print("name is too big")
else:
    print("Name is ok")

##Exercise weight converter
weight = float(input("Please Enter your weight: "))
unit = input("[L]bs or [K]g: ")

if unit.upper() == "L":
    print(f"You weight is {round(weight * 0.45,2)}Kilos")
elif unit.upper() == "K":
    print(f"You weight is {round(weight * 2.20,2)}pounds")
else:
    print("Incorrect unit")

    
##Exercise while loop secret number (we use while loops to execute a block of code multiple times)
secret_number = 11
guess_count = 1
guess_limit = 3

while guess_count <= guess_limit:
    if guess_count < 3:
        guess = int(input(f'Chance no {guess_count} :  '))
        guess_count += 1
    else:
        guess = int(input(f'Last Chance {guess_count} :  '))
        guess_count = guess_count+1
    if guess == secret_number:
        print("you Won!")
        break
else:
    print("You lost all 3 chances missed") 
    

##Exercise car game
started = False

while True:
    print("""
start -- to start the car
stop -- to stop the car
quit -- to quit the program     
        """)        
    command=input("> ").lower()
    if command == "start":
        if started:
            print("The Car has already started...start driving you Idiot")
        else:
            print("The Car Has Started...")
            started = True
    elif command == "stop":
        if not started:
            print("The Car is already stopped...Either Start driving it first or Quit you Idiot")
        else:
            print("The Car Has been Stopped...")
            started = False
    elif command == "quit":
        if started:
            print("You can't quit before Stopping the car...Idiot")
        else:
            break


   # For Loops  (we use "for loops" to iterate over a collection of items eg a string)
for item in "Darren":
    print(item)

for item in ["Marsh","John","Ashley"]:
    print(item)

for item in range(10):
    print(item)

for item in range(5,10,3):
    print(item)

prices = [10,20,30]
total = 0
for price in prices:
    total = total + price
print(f"Total is : {total}")

#for loop example with retur statement on outer side
i = -1
def search(list,n): 
    for item in list:
        globals()['i'] = i + 1
        if item == n:
            return True
    return False
                     
            
list = [45,67,89,35,77,78]
n = 89

if search(list,n):
    print(f'found at : {i}')
else:
    print('nope')


# Nested Loops ( ) 
for x in range(4):
    for y in range(3):
        print(f"({x},{y})")

#printing F
numbers = [5,2,5,2,2]
pnt = ""
for f in numbers:
    for g in "x":
        pnt = (f * g)
        print(pnt)

numbers = [5,2,5,2,2]
for count_nos in numbers:
    output =''
    for rng in range(count_nos):
        output += 'x'
    print(output)

#printing L
numbers = [1,1,1,1,10]
for count_nos in numbers:
    output =''
    for rng in range(count_nos):
        output += '|'
    print(output)   

#Bubble sorting every 2 nos
def sort(nums):
    for item in range(len(nums)-1,0,-1):
        print(f'index no : {item} holds {nums[item]} Total Count of Nums : {len(nums)}')
        #print(nums[item])
        for j in range(item):
            #print(nums)
            #print(f'J will iterate : {item} times, iteration no {j} which holds {nums[j]}')
            if nums[j] > nums[j+1]:
                temp = nums[j]
                nums[j] = nums[j+1]
                nums[j+1] = temp
            print(nums)
        
#select sort
def sort(nums):
    for item in range(len(nums)):
        minpos = item
        print(item,nums)
        for j in range(item,len(nums)):
            if nums[j] < nums[minpos]:
                minpos = j
        #swapping in the outer Loop                    
        temp = nums[item]
        nums[item] = nums[minpos]
        nums[minpos] = temp
    return nums



list = [45,97,67,109,35,2]
sort(list)
print(list)     



list = [45,97,67,109,35,77]
sort(list)
#print(list)

##Lists
list = ['John','Darren','Ashley']
print(list[0:])
list[0] = 'Jon'
print(list)

list = [1,2,3]
max_number = max(list)
print(max_number)

number_list = [78,99,124,67,35,354]
max_number = number_list[0]
for number in number_list:
    if number > max_number:
        max_number = number
print(max_number)

#2D List
darrens_matrix = [
    [1,2,3],
    [7,8,9],
    ['darren','ashley','tom']
]

for rows in darrens_matrix:
    for items in rows:
        print(items)

##list methods remove duplicates exercise
mylist = [1,1,2,3,4]
unique = []
for iterate in mylist:
    if iterate not in unique:
        unique.append(iterate)
print(unique)

##Tuple(unlike list we cannot modify them, they are unmutable)
number = (1,2,3,4,5)
print(number[0:3])

##Unpacking
number = (1,2,3,4,5)
a,b,c,d,e = number
print(a,b,c,d,e)

#Dictionaries(we use it to store information that come in key value pair)
# each key value pair should be unique - just like in real world the dictionary, each word is only once with defnition
customer = {
    "name": "Darren Quadros",
    "age": "36",
    "email": ""
}
print(customer["name"])
print(customer.get("age"))
print(customer["email"])
print(customer.get("birthdate" , "11-JAN-1984"))
print(customer.get("emaiil" , "sss@gmail.com"))

## exercise converting numbers to words
numberdictonary = {
    0: "Zero",
    1: "One",
    2: "Two",
    3: "Three",
    4: "Four",
    5: "Five",
    6: "Six",
    7: "Seven",
    8: "Eight",
    9: "Nine",
}

phone = input("Phone: ")
int(phone)
output = ""
for ch in phone:
    a = numberdictonary.get(int(ch),"No Match")
    output = output + (f"{a} ")
print(output) 

##Emoji converter exercise(pip3 install -U emojis )
import emojis
message = input('> ')
words = message.split(' ')
myemojis = {

    ":)":emojis.encode(':smile:'),
    "::)":emojis.encode(':disappointed:')
}

output='''

'''
for word in words:
    output += myemojis.get(word,word) + ' '
print(output)

#Functions(its a container for a few lines of codes that perform a specific task)
def greet_users():
    print('Hi There')
    print('Welcome Aboard !')


print('start')
greet_users()
print('Finish')

#Parameters() if a function accepts parameters then we are obligated to pass one
#parameters are the holes or place holder which we define in our functions for receiving information
#arguments are actual peices of information that we supply to these functions
def greet_usersss(name):
    print(f'Hi {name}')
    print('Welcome Aboard !')


print('start')
greet_usersss('Darren')
greet_usersss('Aislinn')
print('Finish')


def greet_userss(first_name,last_name):
    print(f'Hi {first_name},{last_name}')
    print('Welcome Aboard !')


print('start')
greet_userss('Darren','Quadros')
greet_userss('Aislinn','Quadros')
print('Finish')


#Keyword arguments(the order of the parameter matrers)
def greet_users(first_name,last_name):
    print(f'Hi {first_name},{last_name}')
    print('Welcome Aboard !')


print('start')
greet_users(last_name='Quadros',first_name='Darren')
greet_users('Quadros','Aislinn')
print('Finish')

#Return statements(its is particularly useful for returning a result while calculates)
#by default all functions return none
def square(number):
    return number * number
    

result = square(5)
print(result)

#or

print(square(7))


#Creating a reusable function
#the function should not worry about receiving an input and printing, because one program may call from the terminal while the other from a GUI
def emoji_converter(message):
    import emojis
    words = message.split(' ')
    myemojis = {

    ":)":emojis.encode(':smile:'),
    "::)":emojis.encode(':disappointed:')
    }
    output = ""
    for word in words:
        output += myemojis.get(word,word) + ' '
    return output

message = input('> ')   
result = emoji_converter(message)
print(result)

#Runtime Error , if a user gives you 6/0, 0 is will result in a runtime error, the mistake is done by the user.
#In my mind i know the user will use proper value, as a developer we need to handle this
#Exceptions(How to handle errors)

try:    
    age = int(input('Age :'))
    income = 20000
    risk = round(income / age,2)
    print(age)
    print(risk)
except ZeroDivisionError as e:
    print('Age cannot be 0 !',e)
except Exception as e:
    print('Invalid Age!',e)
finally:
    print('Resource Closed')

#Classes(We already have data types like use strings, numbers, dictionaries, 
# but what if need a real world type(Phones,shopping cart etc)
# essentially what we are trying to says is,  hey here's another datatype 
# eg Im modelling a Student of a college(real world object), there is no student data type and 
# I cant really represent
# a student using a string or number data type, so what I can actually do is create a class,
# (so basically) im creating a student data type
class PointClass:
    def draw(self):
        print("Draw")
    def move(self):
        print("Move")


#Object no 1
point1 = PointClass()
point1.draw()
point1.move()
point1.xaxis = 10
point1.yaxis = 20
print(f'X axis = {point1.xaxis}, Y axis = {point1.yaxis}')

#Object no 2
point2 = PointClass()
point2.xaxis = 30
print(point2.xaxis)

#attributes(These are columns of a database e.g human class has name, age, gender)

#Constructurs(A constructor is a function which is called at the time of creating the object, its resposible to assign a memory location, size etc)
class Person:
    def __init__(self,name):
        self.name = name #self references the current object,So we are setting the name attribute
                         # of the current object to the name argument passed to this method

    def talk(self):
        print(f"Hi, I am {self.name} ")

#Instance 1
DarrenPerson = Person("Darren Quadros")
DarrenPerson.talk()
#Instance 2
AshleyPerson = Person("Ashley Riberio")
print(AshleyPerson.name)
AshleyPerson.talk()


#Inheritance(Its a mechanism of reusing code from parent)
class Mamal:
    def walk(self):
        print("Walk")


class Dog(Mamal):
    def bark(self):
        print("Bark")


class Cat(Mamal):
    def mew(self):
        print("Mew")


dog1 = Dog()
dog1.walk()
dog1.bark()

cat1 = Cat()
cat1.walk()
cat1.mew()

class Person: #this is a class(blueprint/design)

    company = 'Writer Relocations' #class/static variable (Class namespace)

    def __init__(self,name,age,m1,m2):  #this is actually a constructor, and is responsible to assign the obejct a memory,the size etx
        self.name = name          #instance variable/attributes/properties (Instance namespace)
        self.age = age
        self.m1 = m1
        self.m2 = m2
        self.m3 = 'Hello'
        self.lap = self.laptop()

    def getdetails(self):          #function
        print(self.name,self.age,self.company)

    def avgmarks(self):
        return (self.m1+self.m2)/2

    def get_m1(self):           #Traditional Get method (Accessors and Mutators)
        return self.m1

    def set_m1(self,newvalue):  #Traditional Set method or instance method, it has got to do with Insance variables
        self.m1 = newvalue

    @classmethod                #Class method, it has got to do only with Class variables
    def info(cls):
        return cls.company

    @staticmethod                #Static method, it has nothing to do with the instance or class variable
    def getschoolclass():
        return type(Person)

    def compare(self,anotherobject):
        if self.age == anotherobject.age:
            return True
        else:
            return False

    class laptop:               #Inner class - as the person will only use the laptop
        
        def __init__(self):
            self.brand = 'HP'
            self.proc = 'i5'


pers1 = Person('darren',35,45,50) #object/instance of a class
Person.getdetails(pers1)
#either
pers1.getdetails()
print(type(pers1)) # find out the type
print(id(pers1)) #location of heap memory
print(f'Average marks : {pers1.avgmarks()}')
print(f'Get Method Constructor : {pers1.get_m1()}')
pers1.set_m1(99)
print(f'Set Method Constructor : {pers1.m1} ')
print(f'Class Method : {pers1.info()} ')
print(f'Class Method : {pers1.getschoolclass()} ')
print(pers1.m3)
print(pers1.lap.brand,pers1.lap.proc)
pers2 = Person('ashley',37,34,45)
if pers1.compare(pers2):
    print('They are same')
else:
    print('!!!Mismatch')

#operator overloading

class Student:

    def __init__(self,m1,m2):
        self.m1 = m1
        self.m2 = m2

    def __add__(self,other):    # Operator overload, in this case taking the inbuilt built operator and changing the built in add function
        v1 = self.m1 + other.m1
        v2 = self.m2 + other.m2
        v3 = Student(v1,v2)
        return v3

s1 = Student(1,2)
s2 = Student(3,5)
s3 = s1 + s2  #using the default operator overloading concepts.
print(s3.m1,s3.m2)

#method overloading - in a class 2 methods with same name but different arguments
#method overriding - in a class with inheritance concept , same method with similar arguments 

#Multithreadhing - They are using different cores of the CPUS
from threading import *
from time import sleep

class Hello(Thread):
    def run(self):
        i = "Hello"
        for i in range(9000000000):
            print(f"Hello {i}")
            #sleep(1)


class Hi(Thread):
    def run(self):
        for i in range(900000000):
            print("Hi")
            #sleep(1)


o1 = Hello()
o2 = Hi()

o1.start()
o2.start()


#High Level Language, computers understand only binary language.
# A comipler is used to compile the Python code to binary language, it will give you a byte code
# Python is first compiled to byte code so that it can run on any platform(different CPU Architectures)
# PVM(python virtual machine) Then this interpreter reads the files and runs the app
# CPython - the implementation is done using c language, similarly ironpython - the implementation is done using .net

#File Handling - 
import os

a = os.path.dirname('D:/Darren - Information Technology/WriterRelocations/1 PROJECTS/OneDrive - Writer Business Services Private Limited/DevOps/LEARNING/Python/DjangoLearnProjects/pythontutorials/basics/')
b = 'myfile.txt'
c = os.path.join(a,b)



filel = open(c,'a')
for i in range(10):
    filel.write('Hey %d\r\n'%(i+1))




#Modules(Another file with some python code, just like a section in a supermarket, its better structured)
import converter
from converter import kgs_to_lbs
lbs=converter.kgs_to_lbs(50)
print(round(lbs,2))

#
from utils import find_max
maximum_number=find_max([5,78,89,4500,105,567,891])
print(maximum_number)

#reading and writing to files
employee_file = open("D:/Bill_Appoved.txt","r")
print(employee_file.readable())

for lines in employee_file:
    print(lines)


#Packages(Its another way to organise our code, a real project can have 100-1000's of modules, a package is a container for multiple modules)
#e.g in a supermarker the section line (Men,Women,Kinds) - Modules are(Men-shoes,Tshirts,Jackets)
from ecommerce import shipping

shipping.shipping_cost()
shipping.shipping_cost()
shipping.shipping_cost()
shipping.shipping_cost()
shipping.shipping_cost()

#Random values(in google search for python 3 modules)
import random


class Dice:
    def roll(self):
        first=random.randint(1,6)
        second=random.randint(1,6)
        return (f'{first},{second},= {first+second}')


playgame = Dice()
numbers = playgame.roll()
print(numbers)

#Files and Directories(Absoulute and Relative Path on the computer or Program)
import glob
from pathlib import Path
import os

#relative path
path1 = Path("ecommerce")
exists=path1.exists()
print(exists)

pathlist = Path('D:\Darren - Information Technology\WriterRelocations').glob('**/*.*')
for path in pathlist:
     # because path is object not string
     path_in_str = str(path)
     print(path_in_str)

#Pypi(python package index) and Pip-Python manager(thousands of packages/modules availabel to install) - https://pypi.org/
pip install openpyxl

#Working with excel worksheets
import utils
utils.process_workbook('transactions.xlsx')

##Machine Learning (Anaconda and Jupyter)
#Install Anaconda and start Jupyter notebook
#Go to kaggle and download a dataset
import pandas as pd
df = pd.read_csv('vgsales.csv')
df.shape
df.describe()
df.values
#press tab in Jupyter for list of associated functions e.g df.<PRESS TAB>

""" AI(Artificial Intelligence) Project Music streaming ideas to new user
Step 1 : Get your data
"""

import pandas as pd
music_data = pd.read_csv('music.csv')
music_data

"""Step 2 : Preparing the Data(cleaning, removing duplicates, no nulls etc and split into 2 sets)
choose the columns as input and the remaining column as output
Splitting the data as input and output
"""

import pandas as pd
music_data = pd.read_csv('music.csv')
X = music_data.drop(columns=['genre']) #Input data set
y = music_data['genre'] #output data set
y


#Step 3: Create a model using a Machine Learning Algorithm(Decision Tree)
import pandas as pd
from sklearn.tree import DecisionTreeClassifier
music_data = pd.read_csv('music.csv')
X = music_data.drop(columns=['genre']) #Input data set
y = music_data['genre'] #output data set
model = DecisionTreeClassifier()
model.fit(X,y)
music_data
prediction = model.predict([[21,1],[22,0]])
prediction


"""Step 4: Measure accuracy of the Model
split the data set in to 2 sets (one from training and the other for testing)
General rule of Thumb is to pass 70-80% of the data from training and then remaining for testing
"""

import pandas as pd
from sklearn.tree import DecisionTreeClassifier
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score
music_data = pd.read_csv('music.csv')
X = music_data.drop(columns=['genre']) #Input data set
y = music_data['genre'] #output data set
X_train, X_test, y_train, y_test = train_test_split(X , y , test_size = 0.2) #returns a Tuple
model = DecisionTreeClassifier()
model.fit(X_train,y_train)
prediction = model.predict(X_test)
score = accuracy_score(y_test, prediction)
score

#Persisting Model
#Everytime calculating a Model is time consuimng, so we build the Model, Train it and save it to a file at intervals

import pandas as pd
from sklearn.tree import DecisionTreeClassifier
from sklearn.externals import joblib

music_data = pd.read_csv('music.csv')
X = music_data.drop(columns=['genre']) #Input data set
y = music_data['genre'] #output data set
model = DecisionTreeClassifier()
model.fit(X,y)
joblib.dump(model,'music-recommender.joblib')

#To Import the trained Model
import pandas as pd
from sklearn.tree import DecisionTreeClassifier
from sklearn.externals import joblib

model = joblib.load('music-recommender.joblib')
predictions = model.predict([[21,1]])
predictions


#DJango to built Popular Web Applications
"""Framework - Its essentially a library of reusable modules, these provide functionality for common tasks
e.g HTTP requests,URLS, sessions etc
It also defines the structure for applications, it tells what folders and files we should use for our projects
"""
#Install Django version 2.1
pip install django==2.1

#create a django project in the folder DjangoProject
django-admin startproject pyshop DjangoProject .

#Start the server
python manage.py startserver
python manage.py runserver

## to create a new app(essentialy its a package)
python manage.py startapp products

#view Functions(it get called by Django when the user navigates to a particular page)

#Model(it is a representation of a real world concept - e.g in an online shop - customer, shopping cart, review etc)

#Migrations(To create tables based on classes and its attributes in the databases directly)
python manage.py makemigrations
python manage.py migrate

#Admin
python manage.py createsuperuser

#Templates(html templates which can be defined in the projects)
##Bootstrap(Framework to build modern application)


#MVC FRAMEWORK
Busines Logic is written in - view.
Model - Gets data from the Database.
Template - is the html and jinga code for response back to the user.


M - model will work with Data
V - view will work with Logic
T - Templates will work with Layouts

ORM - Object Relational Mapper - its an important concept where if you do not want to
create table in the database, the framework will look at the classes and create
the tables based on it.

postgress password = relo@2020

Pillow - for image related libraries
psycop2 - for postgress connector


Python 3.8.1 (tags/v3.8.1:1b293b6, Dec 18 2019, 22:39:24) [MSC v.1916 32 bit (Intel)] on win32

Python 3.8.1 (tags/v3.8.1:1b293b6, Dec 18 2019, 22:39:24) [MSC v.1916 32 bit (Intel)] on win32

C:\Users\darren.quadros\AppData\Local\Programs\Python\Python38-32\Scripts\




import sys
print(sys.executable)

