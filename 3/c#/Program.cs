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

            var i = snake1.CommonWith(snake2);

            var smol = i.Min(x => manhattan(x));

            Console.WriteLine(smol);
        }
        
        static double manhattan(Point a)
        {
            return Math.Abs(a.X) + Math.Abs(a.Y);
        }
    }
}
