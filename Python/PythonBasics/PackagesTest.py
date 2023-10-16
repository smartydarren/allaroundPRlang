from Learning import func as t1
from Learning import decoratorsEG

#decoratorsEG.printFirstName('darren')
#decoratorsEG.printLastName('quadros')

import json

x = {
  "name": "John",
  "age": 30,
  "married": True,
  "divorced": False,
  "children": ("Ann","Billy"),
  "pets": None,
  "cars": [
    {"model": "BMW 230", "mpg": 27.5},
    {"model": "Ford Edge", "mpg": 24.1}
  ]
}

def printX():
    print(x)

y="Hello Darren hi"

print(x.get("children"))
print(x.get("children"))


def solution(N):
    enable_print = 0 if N % 10 == 0 else 1 #1
    while N > 0:
        if enable_print == 0 and N % 10 != 0: #2
            enable_print = 1
        if enable_print == 1:
            print(N % 10, end="") 
        N = N // 10 #3


solution(123)
