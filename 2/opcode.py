class Opcode():
    def __init__(self, opcode):
        self.opcode = opcode
    
    def multiply(self, a, b):
        return self.opcode[a] * self.opcode[b]

    def add(self, a, b):
        return self.opcode[a] + self.opcode[b]

    def process(self):
        for i in range(0, len(self.opcode), 4):
            op = self.opcode[i]
            if op == 99: break
            a, b, loc = self.opcode[i+1:i+4]
            
            if op is 1:
                self.opcode[loc] = self.add(a,b)
            elif op is 2:
                self.opcode[loc] = self.multiply(a,b)
            
        return self.opcode[0]