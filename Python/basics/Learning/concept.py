# High Level Language, computers understand only binary language.
# A comipler is used to compile the Python code to binary language, it will give you a byte code
# Python is first compiled to byte code so that it can run on any platform(different CPU Architectures)
# PVM(python virtual machine) Then this interpreter reads the files and runs the app
# CPython - the implementation is done using c language, similarly ironpython - the implementation is done using .net


# Importing a math function module
import os
import math
print(math.floor(3.78))


# Logical conditions
# and or not, comparision operators > < =! = etc ==

# For Loops  (we use "for loops" to iterate over a collection of items eg a string)

# -----------------DataTypes--------------------------------#
# list
list = ['John', 'Darren', 'Ashley']
print(list[0:])
list[0] = 'Jon'
print(list)

# Tuple(unlike list we cannot modify them, they are unmutable)
number = (1, 2, 3, 4, 5)
print(number[0:3])

# 2D List
darrens_matrix = [
    [1, 2, 3],
    [7, 8, 9],
    ['darren', 'ashley', 'tom']
]

for rows in darrens_matrix:
    for items in rows:
        print(items)

# Dictionaries(we use it to store information that come in key value pair)
# each key value pair should be unique - just like in real world the dictionary, each word is only once with defnition
customer = {
    "name": "Darren Quadros",
    "age": "36",
    "email": ""
}
print(customer["name"])
print(customer.get("age"))
print(customer["email"])
print(customer.get("birthdate", "11-JAN-1984"))
print(customer.get("emaiil", "sss@gmail.com"))

# -----------------Function--------------------------------#
# Its a container for a few lines of codes that perform a specific task)
# Parameters() if a function accepts parameters then we are obligated to pass one
# Parameters are the holes or place holder which we define in our functions for receiving information
# Arguments are actual peices of information that we supply to these functions


def operators():
    num1, num2 = int(5), int(10)

    add = num1 + num2
    sub = num2 - num1
    mul = num1 * num2
    div = 7 / 5
    div1 = 7 / 5  # top portion
    mod = 250 % 7  # remainder
    expo = 3 ** 3
    floordiv = 7 / 5

    print(f'add={add} sub={sub} mul={mul} div={div} div={div1} mod={mod} expo={expo} floordiv={floordiv}')


def simplesum(a, b):
    return a + b


def simpleSumNoReturn(a, b):
    c = a + b
    print(c)

# recursion


def recursionSimple(x):
    if x >= 5:
        return
    else:
        print(f'x is : {x}')
        recursionSimple(x+1)
# lessons.recursionSimple(7);


def recursionFactorial(x):
    if x == 1:
        # the crux is here, it all starts with returning 1 as these are stacks{LIFO} returing back to the previous stack.
        return 1
    else:
        return x * recursionFactorial(x-1)
# lessons.recursionSimple(7);
# https://www.freecodecamp.org/news/how-recursion-works-explained-with-flowcharts-and-a-video-de61f40cb7f9/

# factorial [multiplying backwords from the number provided till 1]


def factorialSimple(n):
    factorial = 1

    for i in range(1, n+1):
        factorial = factorial * i
        print(factorial)
# lessons.factorialSimple(3);


# -----------------Classes--------------------------------#
# Classes(We already have data types like use strings, numbers, dictionaries,
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


# File Handling -

a = os.path.dirname('D:/Darren - Information Technology/WriterRelocations/1 PROJECTS/OneDrive - Writer Business Services Private Limited/DevOps/LEARNING/Python/DjangoLearnProjects/pythontutorials/basics/')
b = 'myfile.txt'
c = os.path.join(a, b)


def my_function():
    """
    This function prints a documentation message.

    Im documenting my function
    
    """
    print("This is my function")
    
print(my_function.__doc__)


'''
DJango to built Popular Web Applications
Framework - Its essentially a library of reusable modules, these provide functionality for common tasks
e.g HTTP requests,URLS, sessions etc
It also defines the structure for applications, it tells what folders and files we should use for our projects

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

 MVC FRAMEWORK
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


'''
