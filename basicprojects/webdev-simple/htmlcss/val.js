var num1 = 5
// var total = num1++
// console.log(`num1 is ${num1} & total is ${total}`);
// var total = num1++;
// console.log(`num1 is ${num1} & total is ${total}`);

for(i=1;i<6;i++){
    var total = num1++
    console.log(`num1 is ${num1} & total is ${total}`);
}

document.getElementById("homeurl").onclick = function(){
    alert("Home url clicked");
};

let value = 1;

function doSomething(cbfunc,va){
    let ans = cbfunc();
    value = ans + va;
}

doSomething(() => {
    value = 2 * 2;
    return value;
},5);

console.log(value)

