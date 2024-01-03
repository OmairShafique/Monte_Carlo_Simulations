using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MontDep;

namespace Monte_Carlo_Simulations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // generate a list of shapes
        public static List<MontDep.Shapes> shapes = new List<MontDep.Shapes>();
        // generate a random number generator
        public static Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();

            Engine();
        }

        public void Engine()
        {
            try
            {
                #region Creating the Shapes

                int[] Origin_Boundries = new int[4];
                Origin_Boundries[0] = 0;
                Origin_Boundries[1] = 0;
                Origin_Boundries[2] = 500;// (int)Main_Canvas.Width;
                Origin_Boundries[3] = 500;// (int)Main_Canvas.Height;


                // generate 20 random shapes
                for (int i = 0; i < 50; i++)
                {
                    // generate a random number of sides
                    int n_of_sides = random.Next(3, 5);

                    // generate a random number of sides
                    double[] sides = new double[n_of_sides];

                    // generate random lengths for the sides
                    for (int j = 0; j < n_of_sides; j++)
                    {
                        sides[j] = random.Next(1, 30);
                    }

                    // generate a random origin
                    double[] origin = new double[2];

                    // generate random coordinates for the origin
                    origin[0] = random.Next(Origin_Boundries[0], Origin_Boundries[2]);
                    origin[1] = random.Next(Origin_Boundries[1], Origin_Boundries[3]);

                    // generate random angles for the shape
                    double[] angles = new double[n_of_sides];

                    // generate random angles for the shape
                    for (int j = 0; j < n_of_sides - 1; j++)
                    {
                        angles[j] = random.Next(0, 180);
                    }

                    // generate the last angle
                    angles[n_of_sides - 1] = 360 - angles.Sum();

                    // add the shape to the list of shapes
                    shapes.Add(new MontDep.Shapes(i, n_of_sides, origin, sides, angles));
                }
                #endregion

                #region Writing to the Output

                foreach (MontDep.Shapes shape in shapes)
                {
                    Output.Text = Output.Text + "\nShape Number: "+ shape.SN;
                    Output.Text = Output.Text + "\nNumber of sides: " + shape.number_of_sides;
                    Output.Text = Output.Text + "\nOrigin: (" +  shape.coord_for_origin[0] + " , " + shape.coord_for_origin[1] + ")";
                    Output.Text = Output.Text + "\nLength of sides: " + string.Join(", ", shape.length_of_sides);
                    Output.Text = Output.Text + "\nAngles: " + string.Join(", ", shape.Orientation_angles);

                    //print the coordinates for each corner for each object in the list
                    Output.Text = Output.Text + "\nCoordinates for each corner: ";
                    foreach (double[] coord in shape.Coordinates_for_each_corner)
                    {
                        Output.Text = Output.Text + "\n(" + coord[0] + " , " + coord[1] + ")";
                    }

                    Output.Text = Output.Text + "\n-------------------------\n";
                }

                #endregion

                #region Posting to the Canvas

                foreach (MontDep.Shapes shape in shapes)
                {
                    Polyline aggregate = new Polyline();

                    List<Point> points = new List<Point>();

                    points.Add(new Point(shape.coord_for_origin[0], shape.coord_for_origin[1]));

                    for (int i = 0; i < shape.number_of_sides - 1; i++)
                    {
                        points.Add(new Point(shape.Coordinates_for_each_corner[i][0], shape.Coordinates_for_each_corner[i][1]));
                    }

                    points.Add(new Point(shape.coord_for_origin[0], shape.coord_for_origin[1]));

                    aggregate.Points = new PointCollection(points);

                    aggregate.Stroke = Brushes.Black;

                    aggregate.StrokeThickness = 2;

                    Main_Canvas.Children.Add(aggregate);
                }


                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
