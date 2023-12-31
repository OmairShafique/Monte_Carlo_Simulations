using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MontDep;

namespace Testing_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<MontDep.Shapes> shapes = new List<MontDep.Shapes>();
            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                int n_of_sides = random.Next(1, 9);
                
                double[] sides = new double[n_of_sides];
                
                for (int j = 0; j < n_of_sides; j++)
                {
                    sides[j] = random.Next(1, 100);
                }
                double[] origin = new double[2];
                origin[0] = random.Next(1, 100);
                origin[1] = random.Next(1, 100);
                double[] angles = new double[n_of_sides];
                
                for (int j = 0; j < n_of_sides; j++)
                {
                    angles[j] = random.Next(0,180);
                }
                
                shapes.Add(new MontDep.Shapes(n_of_sides, origin, sides, angles));
            }

            foreach (MontDep.Shapes shape in shapes)
            {
                Console.WriteLine("Number of sides: {0}", shape.number_of_sides);
                Console.WriteLine("Origin: ({0},{1})", shape.coord_for_origin[0], shape.coord_for_origin[1]);
                Console.WriteLine("Length of sides: {0}", string.Join(", ", shape.length_of_sides));
                Console.WriteLine("Angles: {0}", string.Join(", ", shape.Orientation_angles));
            }

            Console.ReadLine();
        }
    }
}
