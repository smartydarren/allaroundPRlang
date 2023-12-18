undefined - when the variable is not assigned any value {let userName; console.log("Hello " , userName);}
NaN - not a number

# operators
= assignment operator
== comparision operator (this disregards the datatype)
=== strict equality operator (compares the value and datatype e.g x = "3.14" we cannot use string with arithmetic operations)

Gives us the ability to check more thatn 1 condition concurrently
&& AND (Both must be true)
|| OR (Either one must be true)

! NOT logical operator, typically used to reverse a conditions boolean value, If True -> false, If false -> true.

Arithmetic operators + - / x %

# Loops

While Loop - repeats same while something is true, potentially infinite.

do while Loop - its a variation of the while loop, you do something then check

for loop - A finite amount of time

Breaks - breaks out of a loop entirely, Continue - continues will skip only that iteration. eg 13 continue will skip the number 13 in a for loop.

nested loop - a loop inside another loop

Addition assignment (+=) which is either numeric addition or string concatenation

# Functions
function - you define code once and then use it many times
	Parameters - is what you define in the brackets of the function which accepts arguments
	Arguments - is what you pass to the function while calling it
return - return a value back to the place where you invoked a function

ternary operator - shortcut for if else statement

let & var scope - let is only limited to block scope{} e.g if let i is in a {} then you can access it from within the {}, var is limited to a function(){} eg var i in a function(), then we cannot access is outside of a ()

Global Variables - let can be accessible to the entire script file, var declared globally can mess with your browers windows properties.

Template literals just like string interpolation - (`Hello ${username}`)

Arrays - a variable which can store multiple values

...spread operator = eg unpack anything and spread it like individual items. e.g let a = [1,2,3]
...console.log(...a)

...rest parameter - indefinite number of parameters (packs arguments into an array) - magic function which can take end number of arguments e.g to sum a list of variables.

Callbacks - a function passed as an argument to another function.

array.map()  -	Executes a call back function 
			one for each array element
			AND creates a new array

array.filter() - 	Creates a new array with all elements
			that pass the test provided by a function.

predicate function - is a function that returns a Boolean value.


# Objects classes etc
 # object - A group of properties and methods [use . to access properties/methods]
	Properties - what an object has
	Methods - what an object can do

	this keyword = its a reference to a particular object
					the object depends on the immedeate context

 # classes - its a blueprint for creating objects
			define what properties and methods they have and use a constructor for unique properties
			reuse this class to create multiple objects rather than creating objects with unique stuff everything.

	static - belongs to a class and not to the object
 # Inheritance - a child class can inherit all the methods and propertiesfrom another class
 super keyword refers to the parent class, its commonly used to invoke the constructor of the parent class