import time

def tictoc(func):
    def wrapper(*args, **kwargs):
        t1 = time.time()
        func(*args)
        t2 = time.time() - t1
        print(f'It took {round(t2)} seconds for function : {func.__name__} to run')
    return wrapper

@tictoc
def printFirstName(fname):
    print("sleeping for ..... secs")
    time.sleep(10)
    print(fname)

@tictoc
def printLastName(lname):
    print("sleeping for ..... secs")
    time.sleep(5)
    print(lname)    