def operators():
    num1, num2 = int(5), int(10)

    add = num1 + num2
    sub = num2 - num1
    mul = num1 * num2
    div = 7 / 5
    div1 = 7 / 5 #top portion
    mod = 250 % 7 #remainder
    expo = 3 ** 3
    floordiv = 7 / 5

    print(f'add={add} sub={sub} mul={mul} div={div} div={div1} mod={mod} expo={expo} floordiv={floordiv}');

# recursion
def recursionSimple(x):
    if x >= 5:
        return
    else:
        print(f'x is : {x}')
        recursionSimple(x+1);
#lessons.recursionSimple(7);

def recursionFactorial(x):    
    if x == 1:
        return 1 #the crux is here, it all starts with returning 1 as these are stacks{LIFO} returing back to the previous stack.
    else:
        return x * recursionFactorial(x-1)              
#lessons.recursionSimple(7);
#https://www.freecodecamp.org/news/how-recursion-works-explained-with-flowcharts-and-a-video-de61f40cb7f9/

# factorial [multiplying backwords from the number provided till 1]
def factorialSimple(n):
    factorial = 1

    for i in range(1, n+1):
        factorial = factorial * i
        print(factorial)
#lessons.factorialSimple(3);
