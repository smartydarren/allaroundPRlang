# At the very basics
undefined - when the variable is not assigned any value {let userName; console.log("Hello " , userName);}
NaN - not a number
HTML events are "things" that happen to HTML elements.
DOM - Document object model (API), an api for changing the content of a page.

# variables 
	- Its an item of data that has a name and a value.
	Strings - these are objects as they have some internal properties and methods which we can use. [a property is just a peice of information it tells you something about the object, a method on the other take input, do computation and then output the answer]

# 

# operators
- binary operators always take 2 operands like num1=5 + num2=6
- unary operators take one operand like num1++ or ++num1, ++ increments the variable
	e.g var total = num1++ //total will be 5 but num1 will be 6 [if you add ++ after the variable it will evaluate the expression and will add total to num1 and then increment the variables]
		total = ++num1 //total will be 6 [if you want to do the increment before the evaluation then add ++ before the variable]

= assignment operator
== comparision operator (this disregards the datatype)
=== strict equality operator (compares the value and datatype e.g x = "3.14" we cannot use string with arithmetic operations)

Gives us the ability to check more thatn 1 condition concurrently
&& AND (Both must be true)
|| OR (Either one must be true)

! NOT logical operator, typically used to reverse a conditions boolean value, If True -> false, If false -> true.

Arithmetic operators + - / x %

# flow control statements:
 	if/else statement

# Loops

While Loop - repeats same while something is true, potentially infinite.

do while Loop - its a variation of the while loop, you do something then check

for loop - A finite amount of time

Breaks - breaks out of a loop entirely, Continue - continues will skip only that iteration. eg 13 continue will skip the number 13 in a for loop.

nested loop - a loop inside another loop

Addition assignment (+=) which is either numeric addition or string concatenation

# Functions
function - they are very useful if there is code that you want to reuse
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

Callbacks - a function passed as an argument to another function. basically as a real life e.g (To leave your parking spot, you need to reverse the car, but you can only do so once you’ve shifted into the reverse gear. In this scenario, you backing out of the parking spot is the function and the process of shifting into reverse is the callback. Without shifting into reverse, you cannot back out of your spot.)

array.map()  -	Executes a call back function 
			one for each array element
			AND creates a new array

array.filter() - 	Creates a new array with all elements
			that pass the test provided by a function.

predicate function - is a function that returns a Boolean value.

arrow/anonymouns/lambda function : concise way of writing JavaScript functions in shorter way starting with ES6.

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

 # Error Handling
	object with a description of something went wrong, cant open file/loose connection/user types input error etc
	Try > Throw > catch > finally

# Synchronous vs Asynchronous code
sync - In an ordered sequence, step by step linear instructions (startnow, finish now)
async - Out of sequence, e.g - Access a database, Fetch a file tasks that take time (startnow, finish sometime later)

# Promise
Object that encapsulates the result of an asynchronous operation
lets asynchronous methods return values like Synchronous methods
	"I promise to return something in the future"
the STATE is 'pending' then: 'fulfilled' or 'rejected'
	the result is what it can be returned
	2 parts producing and consuming

# ES6 module
The idea behind a module is, its a file of reusable code which can be imported

# Events
Event is something that a user or a browser does
addevent method - Link an event and a function to an HTML element
