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
            LawOfCosine_test(tris);
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
                            Console.WriteLine(singleValue);
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

        public static void LawOfCosine_test(List<Triangle> input)
        {
            List<TestResult> trs = new List<TestResult>();
            foreach(Triangle t in input)
            {
                double a = Triangle.LawOfCosine(t.SideB, t.SideC, t.SideA);
                double b = Triangle.LawOfCosine(t.SideA, t.SideC, t.SideB);
                double c = Triangle.LawOfCosine(t.SideA, t.SideB, t.SideC);
                Console.WriteLine($"{a} || {b} || {c}");
                trs.Add(new TestResult(t, new Triangle(t.SideA, t.SideB, t.SideC, a, b, c)));
            }
            double rad = 180 / Math.PI;
            int triSet = 0;
            foreach(TestResult tr in trs)
            {
                Console.WriteLine($"Triangle Set --- {triSet} ---");
                triSet++;
                if (tr.Matched)
                {
                    Console.WriteLine($"Test Input  -> {tr.Input.SideA} || { tr.Input.SideB} || { tr.Input.SideC} || { tr.Input.AngA} || { tr.Input.AngB} || { tr.Input.AngC}");
                    Console.WriteLine($"Test Output -> {tr.Output.SideA} || {tr.Output.SideB} || {tr.Output.SideC} || {tr.Output.AngA} || {tr.Output.AngB} || {tr.Output.AngC}");
                }
                else
                {
                    Console.WriteLine($"Test Failed. Output does not match expected results.");
                    Console.WriteLine($"Test Input  -> {tr.Input.SideA} || { tr.Input.SideB} || { tr.Input.SideC} || { tr.Input.AngA} || { tr.Input.AngB} || { tr.Input.AngC}");
                    Console.WriteLine($"Test Output -> {tr.Output.SideA} || {tr.Output.SideB} || {tr.Output.SideC} || {tr.Output.AngA} || {tr.Output.AngB} || {tr.Output.AngC}");
                    Console.WriteLine($"Matched Perameters -> {tr.MatchedList}");
                    Console.WriteLine($" -> OUT DIF SA -> {tr.Output.SideA >= tr.Input.SideA - 0.01 && tr.Output.SideA <= tr.Input.SideA + 0.01 }" +
                        $"|| OUT DIF SA -> {tr.Output.SideB >= tr.Input.SideB - 0.01 && tr.Output.SideB <= tr.Input.SideB + 0.01 }" +
                        $"|| OUT DIF SA -> {tr.Output.SideC >= tr.Input.SideC - 0.01 && tr.Output.SideC <= tr.Input.SideC + 0.01 }");
                    Console.WriteLine($" -> OUT DIF AA -> {tr.Output.AngA >= tr.Input.AngA - 0.01 && tr.Output.AngA <= tr.Input.AngA + 0.01 }" +
                        $"|| OUT DIF AB -> {tr.Output.AngB >= tr.Input.AngB - 0.01 && tr.Output.AngB <= tr.Input.AngB + 0.01 } " +
                        $"|| OUT DIF AC -> {tr.Output.AngC >= tr.Input.AngC - 0.01 && tr.Output.AngC <= tr.Input.AngC + 0.01 } ");
                    Console.WriteLine($" -> {tr.Matched}");
                    
                }
                Console.WriteLine("-----------------------------------");
            }
            
        }
    }
    class TestResult
    {
        public Triangle Input
        { get; private set; }
        public Triangle Output
        { get; private set; }
        public bool Matched
        { get; private set; }
        public string MatchedList
        { get; private set; }
        public TestResult(Triangle inp, Triangle outp)
        {
            this.Input = inp;
            this.Output = outp;
            this.Matched = MatchedSet(inp, outp);
        }

        private bool MatchedSet(Triangle inp, Triangle outp)
        {
            /*
            double sa = Math.Round(outp.SideA, 3);
            double sb = Math.Round(outp.SideB, 3);
            double sc = Math.Round(outp.SideC, 3);
            double aa = Math.Round(outp.AngA, 3);
            double ab = Math.Round(outp.AngB, 3);
            double ac = Math.Round(outp.AngC,3);
            */
            double sa = outp.SideA;
            double sb = outp.SideB;
            double sc = outp.SideC;
            double aa = outp.AngA;
            double ab = outp.AngB;
            double ac = outp.AngC;
            bool[] match = new bool[6];
            match[0] = (sa >= inp.SideA - 0.001 && sa <= inp.SideA + 0.001 );
            match[1] = (sb >= inp.SideB - 0.001 && sb <= inp.SideB + 0.001);
            match[2] = (sc >= inp.SideC - 0.001 && sc <= inp.SideC + 0.001);
            match[3] = (aa >= inp.AngA - 0.001 && aa <= inp.AngA + 0.001);
            match[4] = (ab >= inp.AngB - 0.001 && ab <= inp.AngB + 0.01);
            match[5] = (ac >= inp.AngC - 0.001 && ac <= inp.AngC + 0.001);

            string s = $"";

            foreach(bool a in match)
            {
                s += $" || {a}";

            }
            this.MatchedList = s;
            return (!match.Contains(false));
        }
    }
}
