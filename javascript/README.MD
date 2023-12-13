undefined - when the variable is not assigned any value {let userName; console.log("Hello " , userName);}
NaN - not a number

= assignment operator
== comparision operator (this disregards the datatype)
=== strict equality operator (compares the value and datatype e.g x = "3.14" we cannot use sting with arithmetic operations)

Gives us the ability to check more thatn 1 condition concurrently
&& AND (Both must be true)
|| OR (Either one must be true)

! NOT logical operator, typically used to reverse a conditions boolean value, If True -> false, If false -> true.

While Loop - repeats same while something is true, potentially infinite.

do while Loop - its a variation of the while loop, you do something then check

for loop - A finite amount of time

Breaks - breaks out of a loop entirely, Continue - continues will skip only that iteration. eg 13 continue will skip the number 13 in a for loop.

nested loop - a loop inside another loop

Addition assignment (+=) which is either numeric addition or string concatenation

function - you define code once and then use it many times
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

array.map()  -	 	Executes a call back function 
			one for each array element
			AND creates a new array

array.filter() - 	Creates a new array with all elements
			that pass the test provided by a function.

predicate function - is a function that returns a Boolean value.

array.



