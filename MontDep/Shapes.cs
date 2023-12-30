using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontDep
{

    public class Shapes
    {
        #region Properties

        /// <summary>
        /// Total number of sides of the shape
        /// </summary>
        public int number_of_sides;

        /// <summary>
        /// Coordinates of the Origin Point
        /// </summary>
        public double[] coord_for_origin;

        /// <summary>
        /// length of the sides but in an array
        /// </summary>
        public double[] length_of_sides;

        /// <summary>
        /// not yet properly defined, meant to give areas for any particle shape
        /// </summary>
        public double Area
        {
            get
            {
                switch (this.number_of_sides)
                {
                    case 1:
                        double area_C = Math.PI * (this.length_of_sides[0]) * (this.length_of_sides[0]) / 4;
                        return area_C;

                    case 2:
                        return 0;

                    case 3:
                        double a = this.length_of_sides[0];
                        double b = this.length_of_sides[1];
                        double c = this.length_of_sides[2];

                        double s = (a + b + c) / 2;
                        double area_T = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                        return area_T;

                    case 4:
                        double l = this.length_of_sides[0];
                        double w = this.length_of_sides[1];

                        double area_Rec = l * w;
                        return area_Rec;

                    case 5:
                        return 0;
                    case 6:
                        return 0;
                    case 7:
                        return 0;
                    case 8:
                        return 0;
                    case 9:
                        return 0;
                    default:
                        return 0;
                        break;

                }
            }
        }

        /// <summary>
        /// Coordinates for each corner, needs to be updated
        /// </summary>
        public double[] Coordinates_for_each_corner { get; set; }

        /// <summary>
        /// Mathematical Domain of the shape, where other shapes may not be instantiated
        /// </summary>
        public double DOMAIN;
        #endregion


        #region Constructor

        /// <summary>
        /// Constructor for the Shape class
        /// </summary>
        /// <param name="Number_of_sides">Total number of sides of the shape</param>
        /// <param name="Coord_for_origin">Coordinates of the Origin Point</param>
        /// <param name="Length_of_sides">length of the sides but in an array</param>
        public Shapes(int Number_of_sides, double[] Coord_for_origin, double[] Length_of_sides)
        {
            number_of_sides = Number_of_sides;
            coord_for_origin = Coord_for_origin;
            length_of_sides = Length_of_sides;
        }

        #endregion

        #region Functions

        #endregion
    }

}
