from numpy import floor, sum

def calc_fuel(mass):
    return floor(mass / 3) - 2

with open("modules.txt") as f:
    modules = [int(x) for x in f.readlines()]
    
all_fuels = [calc_fuel(x) for x in modules]
# fuelsum = sum(all_fuels)

total = 0
for m in modules:
    t = calc_fuel(m)
    total += t
    while(calc_fuel(t) > 0):
           t = calc_fuel(t)
           total += t    

print(total)