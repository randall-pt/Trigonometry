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


            List<TestResult> testResult = new List<TestResult>();

            testResult.AddRange(LawOfCosineAngle_test(tris));
            testResult.AddRange(LawofCosineSide_test(tris));
            testResult.AddRange(LawOfSineAngle_test(tris));
            double n = Triangle.LawOfSineAngle(6, 60, 6);

            PrintResults(testResult);
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

        public static List<TestResult> LawOfCosineAngle_test(List<Triangle> input)
        {
            List<TestResult> trs = new List<TestResult>();
            foreach (Triangle t in input)
            {
                double a = Triangle.LawOfCosineAngle(t.SideB, t.SideC, t.SideA);
                double b = Triangle.LawOfCosineAngle(t.SideA, t.SideC, t.SideB);
                double c = Triangle.LawOfCosineAngle(t.SideA, t.SideB, t.SideC);
                trs.Add(new TestResult(t, new Triangle(t.SideA, t.SideB, t.SideC, a, b, c), "Law of Cosine - Angle -"));
            }
            return trs;
        }
        public static List<TestResult> LawofCosineSide_test(List<Triangle> input)
        {
            List<TestResult> trs = new List<TestResult>();
            foreach(Triangle t in input)
            {
                double sideA = Triangle.LawofCosingSide(t.SideB, t.SideC, t.AngA);
                double sideB = Triangle.LawofCosingSide(t.SideA, t.SideC, t.AngB);
                double sideC = Triangle.LawofCosingSide(t.SideA, t.SideB, t.AngC);

                trs.Add(new TestResult(t, new Triangle(sideA, sideB, sideC, t.AngA, t.AngB, t.AngC), "Law of Cosine - Side -"));
            }
            return trs;
        }

        public static void PrintResults(List<TestResult> trs)
        { 
            double rad = 180 / Math.PI;
            int triSet = 0;
            foreach(TestResult tr in trs)
            {
                /*
                Console.WriteLine($"Test type -> {tr.TestType}");
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
                */
                
                if (!tr.Matched)
                {
                    Console.WriteLine($"Test type -> {tr.TestType}");
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
                    Console.WriteLine("-----------------------------------");

                }
            }
        }
        
        public static List<TestResult> LawOfSineAngle_test(List<Triangle> input)
        {
            List<TestResult> trs = new List<TestResult>();

            foreach(Triangle t in input)
            {
                
                double angA1 = Triangle.LawOfSineAngle(t.SideB, t.AngB, t.SideA);
                double angA2 = Triangle.LawOfSineAngle(t.SideC, t.AngC, t.SideA);
                double angB1 = Triangle.LawOfSineAngle(t.SideA, t.AngA, t.SideB);
                double angB2 = Triangle.LawOfSineAngle(t.SideC, t.AngC, t.SideB);
                double angC1 = Triangle.LawOfSineAngle(t.SideA, t.AngA, t.SideC);
                double angC2 = Triangle.LawOfSineAngle(t.SideB, t.AngB, t.SideC); 
                /*
                double angA1 = Math.Round(Triangle.LawOfSineAngle(t.SideB, t.AngB, t.SideA), 10);
                double angA2 = Math.Round(Triangle.LawOfSineAngle(t.SideC, t.AngC, t.SideA), 10);
                double angB1 = Math.Round(Triangle.LawOfSineAngle(t.SideA, t.AngA, t.SideB), 10);
                double angB2 = Math.Round(Triangle.LawOfSineAngle(t.SideC, t.AngC, t.SideB), 10);
                double angC1 = Math.Round(Triangle.LawOfSineAngle(t.SideA, t.AngA, t.SideC), 10);
                double angC2 = Math.Round(Triangle.LawOfSineAngle(t.SideB, t.AngB, t.SideC), 10);
                */
                bool equal = (angA1 == angA2 && angB1 == angB2 && angC1 == angC2);
                Console.WriteLine(equal);
                trs.Add(new TestResult(t, new Triangle(t.SideA, t.SideB, t.SideC, angA1, angB1, angC1), "Law of Sine - Angle - "));
                if (equal)
                {
                    Console.WriteLine("good");
                }
                else
                {
                    Console.WriteLine($"Angle A --> 1-{angA1} --> 2-{angA2}\nAngle B --> 1-{angB1} --> 2-{angB2}\nAngle C --> 1-{angC1} --> 2-{angC2}");
                    Console.WriteLine($"" +
                        $"Angle A --> 1-{Math.Round(angA1,10)} --> 2-{Math.Round(angA2,10)}" +
                        $"\nAngle B --> 1-{Math.Round(angB1,10)} --> 2-{Math.Round(angB2,10)}" +
                        $"\nAngle C --> 1-{Math.Round(angC1,10)} --> 2-{Math.Round(angC2,10)}");
                }
            }
            return trs;

        }
        
    }
    class TestResult
    {
        public string TestType
        { get; private set; }
        public Triangle Input
        { get; private set; }
        public Triangle Output
        { get; private set; }
        public bool Matched
        { get; private set; }
        public string MatchedList
        { get; private set; }
        public TestResult(Triangle inp, Triangle outp, string testType)
        {
            this.TestType = testType;
            this.Input = inp;
            this.Output = outp;
            this.Matched = MatchedSet(inp, outp);
        }

        private bool MatchedSet(Triangle inp, Triangle outp)
        {
            double sa = outp.SideA;
            double sb = outp.SideB;
            double sc = outp.SideC;
            double aa = outp.AngA;
            double ab = outp.AngB;
            double ac = outp.AngC;
            bool[] match = new bool[6];
            match[0] = (sa >= inp.SideA - 0.01 && sa <= inp.SideA + 0.01 );
            match[1] = (sb >= inp.SideB - 0.01 && sb <= inp.SideB + 0.01);
            match[2] = (sc >= inp.SideC - 0.01 && sc <= inp.SideC + 0.01);
            match[3] = (aa >= inp.AngA - 0.01 && aa <= inp.AngA + 0.01);
            match[4] = (ab >= inp.AngB - 0.01 && ab <= inp.AngB + 0.01);
            match[5] = (ac >= inp.AngC - 0.01 && ac <= inp.AngC + 0.01);

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
