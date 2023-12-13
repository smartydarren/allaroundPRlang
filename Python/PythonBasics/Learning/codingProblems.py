def solution(N):
    enable_print = N % 10
    while N > 0:
        if enable_print == 0 and N % 10 != 0:
            enable_print = 1
        if enable_print == 1 or N==1:
            print(N % 10, end="")
        N = N // 10
#solution(112)

def myTables(t):
    tbl = 1
    while tbl < 11:
        val = t * tbl
        print(f'{t} X {tbl} = {val}')
        tbl = tbl+1

# fibonnaci series
def fibonnaci():
    num = int(input("Enter a Number : "))  
    num1=int(0)
    num2=int(1)

    sum=0
    for n in range(int(num)):   
        print(f'{sum} \n ---Next Number---<_|')
        num1=num2
        num2=sum
        sum=num1 + num2