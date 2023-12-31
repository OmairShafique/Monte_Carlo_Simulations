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

        public static void Engine()
        {
            try
            {
                #region Creating the Shapes

                double[] Origin_Boundries = new double[4];
                //Origin_Boundries[0] = 

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
                        angles[j] = random.Next(0, 180);
                    }

                    // generate the last angle
                    angles[n_of_sides - 1] = 360 - angles.Sum();

                    // add the shape to the list of shapes
                    shapes.Add(new MontDep.Shapes(i, n_of_sides, origin, sides, angles));
                }
                #endregion

                #region Posting to the Canvas

                

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
