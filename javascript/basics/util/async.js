let a = 5;
let b = 7;

let fff = fetch('/').then(()=>{
  console.log('Fetch' + fff)
})

let ttt = setTimeout(() => {
  console.log("Async function");
},40);

console.log(fff);
console.log(a);
console.log(b);
