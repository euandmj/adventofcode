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
        public Dictionary<Point, int> Visited;

        public Snake(Point origin, string[] route)
        {
            Instructions = new List<Instruction>(route.Count());
            Visited = new Dictionary<Point, int>();
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
            int steps = 0;
            Instructions.ForEach(x => {
                for(int i = 0; i < x.Value; ++i){
                    currentPoint = currentPoint.Add(x.normalisedDelta);
                    Visited.TryAdd(currentPoint, ++steps);
                }
            });
        }

        public List<Point> CommonWith(Snake other)
        {
            return Visited.Keys.Intersect(other.Visited.Keys).ToList();
        }

        private int FindShortestPathSum(IEnumerable<KeyValuePair<Point, int>> a, IEnumerable<KeyValuePair<Point, int>> b)
        {
            int min = int.MaxValue;

            
            foreach(var wire1 in a)
            {
                var wire2 = b.First(x => x.Key == wire1.Key);

                if(wire1.Key != wire2.Key)
                    throw new Exception($"mismatch keys");

                int localmin = wire1.Value + wire2.Value;

                if(localmin < min)
                {
                    min = localmin;
                }
            }            

            return min;
        }

        public int FewestIntersectSteps(Snake other)
        {
            var sharedKeys = CommonWith(other);

            var shared1 =  this.Visited.Where(x => sharedKeys.Contains(x.Key));
            var shared2 = other.Visited.Where(x => sharedKeys.Contains(x.Key));
            

            return FindShortestPathSum(shared1, shared2);
        }
    }

    public static class PointExtension
    {
        public static Point Add(this Point a, Point b){
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public static double Manhattan(this Point a){
            return Math.Abs(a.X) + Math.Abs(a.Y);
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