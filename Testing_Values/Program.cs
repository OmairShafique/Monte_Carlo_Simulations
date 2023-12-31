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

            // generate a list of shapes
            List<MontDep.Shapes> shapes = new List<MontDep.Shapes>();

            // generate a random number generator
            Random random = new Random();

            // generate 20 random shapes
            for (int i = 0; i < 20; i++)
            {
                // generate a random number of sides
                int n_of_sides = random.Next(3, 9);
                
                // generate a random number of sides
                double[] sides = new double[n_of_sides];
                
                // generate random lengths for the sides
                for (int j = 0; j < n_of_sides; j++)
                {
                    sides[j] = random.Next(1, 100);
                }

                // generate a random origin
                double[] origin = new double[2];

                // generate random coordinates for the origin
                origin[0] = random.Next(1, 100);
                origin[1] = random.Next(1, 100);

                // generate random angles for the shape
                double[] angles = new double[n_of_sides];

                // generate random angles for the shape
                for (int j = 0; j < n_of_sides - 1; j++)
                {
                    angles[j] = random.Next(0,180);
                }

                // generate the last angle
                angles[n_of_sides - 1] = 360 - angles.Sum();
                
                // add the shape to the list of shapes
                shapes.Add(new MontDep.Shapes(i, n_of_sides, origin, sides, angles));
            }

            // print out the shapes
            foreach (MontDep.Shapes shape in shapes)
            {
                Console.WriteLine("\nShape Number: {0}",shape.SN);
                Console.WriteLine("Number of sides: {0}", shape.number_of_sides);
                Console.WriteLine("Origin: ({0},{1})", shape.coord_for_origin[0], shape.coord_for_origin[1]);
                Console.WriteLine("Length of sides: {0}", string.Join(", ", shape.length_of_sides));
                Console.WriteLine("Angles: {0}", string.Join(", ", shape.Orientation_angles));
                
                //print the coordinates for each corner for each object in the list
                Console.WriteLine("Coordinates for each corner: ");
                foreach (double[] coord in shape.Coordinates_for_each_corner)
                {
                    Console.WriteLine("({0},{1})", coord[0], coord[1]);
                }

                Console.WriteLine("-------------------------\n");
            }

            
            Console.ReadLine();
        }
    }
}
