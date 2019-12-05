min, max = 138307, 654504
matches = 0

def match_A(x):
    '''6 digit number'''
    return x < 1000000

def match_B(x):
    '''Two adjacent digits are the same'''
    y = str(x)
    for i, c in enumerate(y[:-1]):
        if y[i+1] == c:
            return True
    
    return False

def match_C(x):
    '''Going from left to right, the digits never decrease'''
    y = str(x)
    for i, c in enumerate(y[:-1]):
        if int(c) > int(y[i+1]):
            return False
    
    return True

def match_D(x):
    '''Part 2 only pairs allowed'''
    # find all groups of matching chars
    # if there are none 2 len groups ret false
    y = str(x)    
    i = 0

    while(i < len(y) - 1):
        worker = ""
        for j, c in enumerate(y[i:]):
            if c != y[i]: break
            worker += c
        if len(worker) == 2: return True
        i+=j
    return False


for i in range(min,max,1):
    if match_A(i) and match_B(i) and match_C(i):
        matches+=1

print(matches)
matches = 0

for i in range(min,max,1):
    if match_A(i) and match_B(i) and match_C(i) and match_D(i):
        matches+=1

print(matches)