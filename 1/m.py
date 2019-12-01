from numpy import floor, sum

def calc_fuel(mass):
    return floor(mass / 3) - 2

def total_fuel(fuel):
    fl = calc_fuel(fuel)
    return fl + total_fuel(fl) if fl > 0 else 0

with open("modules.txt") as f:
    modules = [int(x) for x in f.readlines()]

star1 = sum(calc_fuel(x) for x in modules)
star2 = sum(total_fuel(x) for x in modules)