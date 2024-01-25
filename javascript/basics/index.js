/*
console.log("I Love Bhendi!");
console.log("I Love Pizza!")
//window.alert("I love Beer");

let age; let firstName = "Darren "; age = 39;
console.log(firstName, age);
document.getElementById("p1").innerHTML = "Changed P1 via Java Script";

let num1 = 75, num2 = 5;
let result = num1 * num2;
console.log("Result is : ", result)
document.getElementById("p2").innerHTML = "Changed P2 via Java Script + result = " + result;

//let username = window.prompt("Whats your username ?");
//console.log('username is : ', username);

document.getElementById("myButton").onclick = function() {
    let username = document.getElementById("myText").value;    
    console.log(username);    
}
let x = 2.75;
console.log(Math.round(x));

method chaining
let username = "darren";
let letter = username.charAt(0).toUpperCase();
console.log(letter);

//If Statements
let age=18;
if(age > 18){
    console.log("You are an adult")
}else{
    console.log("You are a child")
}
     };

//checked property(radio or checkbox)
let isChecked = false;
document.getElementById("myCheckButton").onclick = function() {
     isChecked = document.getElementById("myCheckBox").checked
     if(isChecked == true){
        console.log("Box is checked");
     }else{
        console.log("Unchecked");
     }
}

//while loop
let userName;

//dowhile loop
do{
    userName = window.prompt("Please enter you user name!") //Ok returns empty string
}while(userName == "")
console.log("Hello " , userName);
for(let counter = 0; counter <10; counter +=1){
    if(counter == 5){
        continue; // this will skip 5
    }
    console.log(counter);
}

let rows = 3; columns = 7
for (let i = 1; i<=rows; i+=1){
    for(let j=1;j<=columns;j+=1){
        document.getElementById("nestedloop").innerHTML += j ;
    }
    document.getElementById("nestedloop").innerHTML += "</br>";

    //function
function happyBirthday(name){
    console.log("Happy Birthday, " + name)
    return "returning Thankyou!";
}

let rMessage = happyBirthday("darren");
console.log(rMessage, confirm);
console.log(j);
window.name = "JS"
console.log(window.name);

//Template Literal
let prop1 = "darren";
console.log(`Hello ${prop1}`);

//setting Currency
let money = 750000;
console.log(money.toLocaleString("en-IN",{style: "currency", currency:"INR"}));
console.log(money);
//Arrays
let fruits = ["apple","orange","banana"];
fruits = fruits.reverse();
for(let f in fruits){
    console.log(fruits[f]);
}

//2D Arrays - multidimensional
let fruits =        ["apple","orange","banana"];
let vegetables =    ["cauliflower","lemon","onion","tomatoe"];
let meats =         ["eggs","chicken","fish"];
// it forms a row and column data structure
let groceryList = [fruits,vegetables,meats]
groceryList[0][0] = "Bhendi";
console.log(groceryList[2].lastIndexOf("onion"));

for(let list of groceryList){
    for(let food of list){
        console.log(food);
    }
   // console.log(list)
}

//spread operator
let a = [1,2,3]
console.log(a);
console.log(...a)


//rest parameter
let a=2;
let b=5;
let h=9;

let s = sum345(a,b,h);
console.log(s);

function sum345(...numbers){
    let total = 0
    for(let n of numbers){
        total += n;
    }
    return total;
}

//String interpolation
let a = 1; b = 2;
let c = a+b;
console.log(`The Number is  : ${c}`);

//callback
callSumAndFunc(2,3,someFunc);

function callSumAndFunc(x,y,passAfunc){
    let result = x + y;   
    passAfunc(result);
}

function someFunc(output){
console.log(output);

//array.foreach
let students  = ["darren","aislinn","denver","adelyn"]
students.forEach(capitalize);
students.forEach(cPrint);

function capitalize(e,indx,array){
    console.log(array);
    let a =e.toUpperCase();
    array[0] = e[0].toUpperCase();
    console.log(a);
    console.log(array);
    return a;
}

function cPrint(e){    
    console.log(e);
}

console.log(typeof(ff));

//pass by value and ref
const a = "darren";
const o = {
    name : "aislinn"
};

let ff = function passByValue(x){
    x = "changed";
    return x;
}

function passByRef(obj){
    obj.name = "changed";
    return obj.name;
}

console.log(a);
console.log(ff(a));
console.log(a);

console.log(o.name);
console.log(passByRef(o));
console.log(o.name);

//array.map function
let numbers = [1,2,3,4,5,6]
let squares = numbers.map(doSquare);
squares.forEach(printToConsole);

function doSquare(element){
    return element * 2;
}

function printToConsole(element){
    console.log(element);
}



//array.filter
let ages = [18,19,20,25,30, 16, 17, 9, 7]
let adults = ages.filter(checkAge);
adults.forEach(printToConsole);

function checkAge(element){
    return element >= 18
}

function printToConsole(element){
    console.log(element);
}

let ages = [5,10,20,25,30, 16, 17, 9, 7, 88]
//const pt = ages.map((element,i,a) => console.log(element * 2, i, a))

document.getElementById("login").onclick = function(){
    return alert("Hello Darren")
} 

function log(value){
    console.log(value)
}

function sum2numbers(n1,n2,printFunc){
    let sum = n1 + n2
    printFunc(sum);
}

function doubletheNumbers(element,i,a){
    a = a[i] * element;
    console.log(a)
}
    
//log("Hello")
//sum2numbers(2,2,(v)=> console.log(v));
//ages.map(doubletheNumbers);

//object
const car = {
    model:"mustang",
    year:2021,
    color:"red",

    drive : function(){
        console.log(`you drive the car : ${this.model}`)
        console.log(`you drive the car : ${car.model}`)
    } 
}

//car.drive();

//clases
class student{

    constructor(name, age, gpa){
        this.name = name
        this.age = age
        this.gpa = gpa        
        }

        study(){
          console.log(`${this.name} is studying`)
    }
}

const darren = new student("darren", 39, 6.5)
const aislinn = new student("aislinn", 39, 7.5)
//darren.study()

//passing an object as an argumen
function changeGpa(student, gpa){
    oldGpa = student.gpa
    student.gpa = gpa
    console.log(`Old gpa of ${student.name} is ${oldGpa}, new gpa is ${student.gpa}`)
}

function changeGpaOnly(student){
    oldGpa = student.gpa
    student.gpa = gpa
    console.log(`Old gpa is ${oldGpa}, new gpa is ${student.gpa}`)
}

//changeGpa(darren,7.7)
const students = [darren,aislinn]

//students.forEach(changeGpa);

//array of objects
function updateGpa(students1){
    for(const s of students1){
        gpa = 11.11
        changeGpa(s,gpa);
    }
};

updateGpa(students);

//error handling
try {
    console.lag()
} catch (error) {
    console.log(error);
} finally{
    console.log("Finally Block")
}


let date = new Date();
//dateLocal = date.toLocaleDateString();
//date = date.getTime();
//getHours = date.getHours();
document.getElementById("mylable").innerHTML = date;

(() => { 
    console.log("GeeksforGeeks"); 
  })();

//asynchronous eg
console.log("Start at Step 1");
setTimeout(() => {console.log("Async step 2 completing after 5 secs")},5000);
console.log("Finish at Step 3");
console.time("Timer")
   setTimeout(() => {
    console.timeEnd("Timer")
    }, 5000);

//Promise
const promise = new Promise((resolve,reject) => {
    let fileload = true;

    if (fileload){
        resolve("File loaded successfully")
    }else{
        reject("File upload rejected")
    }
});

promise.then((retVal) => {
    console.log(retVal);
}).catch((retvalF) => {
    console.log(retvalF);
});

//2nd example
const wait = (tim) => {return new Promise((resol) => {
    setTimeout(resol,tim)
})};

wait(3000).then(() => {console.log("Thanks for waiting!!")})


function changeBgColor(){
    const clr = ["skyblue","red"]

        setTimeout(() => {
            for(i=0;i<clr.length;i++){
                document.body.style.backgroundColor = clr[i];
                console.log(`Color is : ${clr[i]}`)
            }
        },5000)
    };

    

changeBgColor();
*/

//using axios library

// class crcrd{
//     cc = null;
//     constructor(ccd){
//         this.cc = ccd;
//     }
    
// }

// async function getRandomUser() {
//     try {
//       const data = await axios.get("https://random-data-api.com/api/users/random_user");
//       //console.log(data.data)
//       return data;
//     } catch(err) {
//       console.log("error: ", err);
//     }
//   }

//   const printAddress = async () => {
//      const a = await getRandomUser();
//      const creditcard = new crcrd(a.data.credit_card.cc_number);
//      console.log(creditcard.cc);
//    };

// printAddress();

function findElement( arr, n, key)
{
    let i;
    for (i = 0; i < n; i++)
        if (arr[i] == key)
            return i;
 
    return -1;
}
 
      
    // Driver program
   
    class student{

        constructor(name, age, gpa){
            this.name = name
            this.age = age
            this.gpa = gpa        
            }
    
            study(){
              console.log(`${this.name} is studying`)
        }
    }

    let arr = [12, 34, 10, 6, 40];
    const aaa = new student("Darren",21,7);
    let arr1 = new Array<student>(2);
    let arr2 = new Array();
    arr1[0] = aaa;

    console.log(arr1);
    

    // let n = arr.length;
 
    // // Using a last element as search element
    // let key = 12;
    // let position = findElement(arr, n, key);
 
    // if (position == - 1)
    //     document.write("Element not found");
    // else
    //     document.write("Element Found at Position: "
    //          + (position + 1));