from basics.Learning.lessons import (
    simplesum,
    simpleSumNoReturn)

def test_func1():
    assert  simplesum(2,3) == 5
    assert  simplesum(2,3) == 5
    assert  simplesum(2,-1) == 1

#def test_func_noreturn():
   # assert  simpleSumNoReturn(2,5) == 7