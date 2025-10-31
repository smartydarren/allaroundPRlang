let count = 0;
Number(count);
let randomNumber;

randomNumber = Math.floor(Math.random() * 6);

document.getElementById("decreaseBtn").onclick = function(){
    count -=1;
    document.getElementById("countLabel").innerHTML = count;
    randomNumber = Math.floor(Math.random() * 6);
    console.log(randomNumber);
}

document.getElementById("increaseBtn").onclick = function(){
    count +=1;
    document.getElementById("countLabel").innerHTML = count;
    randomNumber = Math.floor(Math.random() * 6);
    console.log(randomNumber);
}

document.getElementById("resetBtn").onclick = function(){
    count =0;
    document.getElementById("countLabel").innerHTML = count;
}

//console.log(randomNumber);


