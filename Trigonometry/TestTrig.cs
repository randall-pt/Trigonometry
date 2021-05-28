using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigonometry;

namespace Trigonometry
{
    class TestTrig
    {
        public static void Main(string[] args)
        {
            string fname = @"Assets\triangle_test_input.csv";
            fname = @"C:\Users\pault\source\repos\Trigonometry\Trigonometry\Assets\triangle_test_input.csv";
            Console.WriteLine("I am doing stuff thank you!");
            List<Triangle> tris = GetTestData(fname);
            foreach (Triangle t in tris)
            {
                Console.WriteLine($"{t.SideA}, {t.SideB}, {t.SideC}, {t.AngA}, {t.AngB}, {t.AngC}");
            }
        }

        private static List<Triangle> GetTestData(string fname)
        {
            List<Triangle> lst = new List<Triangle>();

            StreamReader sr = new StreamReader(fname);


            while (!sr.EndOfStream)
            {
                string rline = sr.ReadLine();
                string[] lineData = new string[6];
                string singleValue = "";
                int i = 0;

                // Seperates the data out from the readLine of the csv file
                for(int j = 0; j < rline.Length; j++)
                {

                    if (rline[j] == ',')
                    {
                        lineData[i] = singleValue;
                        singleValue = "";
                        i++;
                    }
                    else
                    {
                        singleValue += rline[j];
                        // if the pointer is at the end of the line will add the value to the line Data array
                        if (j == rline.Length - 1)
                        {
                            lineData[i] = singleValue;
                        }
                    }


                }
                // catches any erronous inputs into the csv file, and prints a warning
                try
                {
                    lst.Add(new Triangle(lineData[0], lineData[1], lineData[2], lineData[3], lineData[4], lineData[5]));
                }
                catch
                {
                    Console.WriteLine($"The following input was not valid:\n {lineData[0]}, {lineData[1]}, {lineData[2]}, {lineData[3]}, {lineData[4]}, {lineData[5]}\n---------------------");
                }
            }

            return lst;
        }
    }
}
