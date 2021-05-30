using System;
using System.IO;
using System.Collections.Generic;

namespace Trigonometry
{
    public class Triangle
    {
        public double SideA
        { get; private set; }
        public double SideB
        { get; private set; }
        public double SideC
        { get; private set; }
        public double AngA
        { get; private set; }
        public double AngB
        { get; private set; }
        public double AngC
        { get; private set; }
        public Triangle(string a = "-1", string b = "-1", string c = "-1", string angA = "-1", string angB = "-1", string angC = "-1")
        {
            this.SideA = Convert.ToDouble(a);
            this.SideB = Convert.ToDouble(b);
            this.SideC = Convert.ToDouble(c);
            this.AngA = Convert.ToDouble(angA);
            this.AngB = Convert.ToDouble(angB);
            this.AngC = Convert.ToDouble(angC);
        }

        public Triangle(double a = -1, double b = -1, double c = -1, double angA = -1, double angB = -1, double angC = -1)
        {
            this.SideA = a;
            this.SideB = b;
            this.SideC = c;
            this.AngA = angA;
            this.AngB = angB;
            this.AngC = angC;
        }

        public static double LawOfCosineAngle(double a, double b, double c)
        {
            double angC = (((a * a) + (b * b)) - c * c) / (2 * a * b);
            // c^2 = (a^2 + b^2) - 2abCos(c)
            // 2abCos(C) = (a^2 + b^2) - c^2)
            // Cos(C) = ((a^2 + b^2) - C^2) / 2ab
            double rad = 180 / Math.PI;
            return (Math.Acos(angC)*rad);
        }
        public static double LawofCosingSide(double a, double b, double c)
        {
            double rad = 180 / Math.PI;
            double sideC = Math.Sqrt((a * a + b * b) - (2 * a * b * (Math.Cos(c/rad))));

            return sideC;
        }

        public static double LawOfSineAngle(double sideA, double angleA, double sideC)
        {
            double rad = 180 / Math.PI;
            double s = sideA / Math.Sin(angleA / rad);
            //Console.WriteLine(s);
            double sinC = sideC / s;
            //Console.WriteLine(sinC);
            //Console.WriteLine(Math.Asin(sinC));
            //Console.WriteLine(Math.Abs(Math.Asin(sinC)*rad));
            double outp = Math.Asin(sinC) * rad;
            return Math.Abs(outp);

        }

    }
}
