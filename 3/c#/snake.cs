using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace csharp
{    
    class Snake
    {
        private Point currentPoint;

        public readonly List<Instruction> Instructions;
        public HashSet<Point> Visited;

        public Snake(Point origin, string[] route)
        {
            Instructions = new List<Instruction>(route.Count());
            Visited = new HashSet<Point>();
            currentPoint = origin;

            BuildInstructionSet(route);
        }

        private void BuildInstructionSet(string[] instructions)
        {
            foreach(var s in instructions)
            {
                Instructions.Add(new Instruction(){
                    Operator = s[0],
                    Value = int.Parse(s.Substring(1))
                });
            }
        }

        public void Slither()
        {
            Instructions.ForEach(x => {
                for(int i = 0; i < x.Value; ++i){
                    currentPoint = currentPoint.Add(x.normalisedDelta);
                    Visited.Add(currentPoint);
                }
            });
        }

        public List<Point> CommonWith(Snake other)
        {
            return Visited.Intersect(other.Visited).ToList();
        }
    }

    public static class PointExtension
    {
        public static Point Add(this Point a, Point b){
            return new Point(a.X + b.X, a.Y + b.Y);
        }
    }

    struct Instruction
    {
        public char Operator;
        public int Value;

        public Point normalisedDelta
        {
            get
            {
                switch(Operator)
                {
                    case 'U':
                        return new Point(0, -1);
                    case 'D':
                        return new Point(0, 1);
                    case 'L':
                        return new Point(-1, 0);
                    case 'R':
                        return new Point(1, 0);
                    default:
                        throw new FormatException($"{nameof(Instruction)} invalid operator: {Operator}");
                }
            }
        }
    }
}