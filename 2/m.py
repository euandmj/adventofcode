from opcode import Opcode
from copy import deepcopy

def star1(lines):
    opcoder = Opcode(lines)
    print(opcoder.process())

def star2(lines):
    for noun in range(100):
        for verb in range(100):
            l = deepcopy(lines)
            l[1] = noun
            l[2] = verb

            opcoder = Opcode(l)
            
            try:
                ans = opcoder.process()
            except IndexError:
                continue
            else:
                if ans == 19690720:
                    break
        else:
            continue
        break 

    print(f"noun = {noun}\nverb = {verb}")
    print(100 * noun + verb)


with open("intcode.txt") as f:
    lines = [int(x) for x in f.readline().split(',')]

star1(deepcopy(lines))
star2(deepcopy(lines))