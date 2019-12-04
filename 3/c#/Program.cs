using System;
using System.Drawing;
using System.Linq;
using System.IO;

namespace csharp
{
    class Program
    {
        static readonly Point p = new Point(0, 0);

        static void Main(string[] args)
        {
            string[] r1,r2; 

            using (var sr = new StreamReader("input.txt"))
            {
                r1 = sr.ReadLine().Split(',');
                r2 = sr.ReadLine().Split(',');
            }

            var snake1 = new Snake(p, r1);
            var snake2 = new Snake(p, r2);

            snake1.Slither();
            snake2.Slither();

            var intersections = snake1.CommonWith(snake2);
            var star1 = intersections.Min(x => x.Manhattan());
            Console.WriteLine(star1);
            
            var star2 = snake1.FewestIntersectSteps(snake2);
            Console.WriteLine(star2);
        }
    }
}
