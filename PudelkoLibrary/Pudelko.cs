using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;


namespace PudelkoLibrary
{

    public sealed class Pudelko
    {
        //zadanie 1,2

        private double a, b, c;
        private UnitOfMeasure unit { get; set; }

        public Pudelko(double a = 10, double b = 10, double c = 10, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if (a <= 0 || b <= 0 || c <= 0)

                throw new ArgumentOutOfRangeException("BŁĄD, podałeś wartość ujemną");

            switch (unit)
            {
                case UnitOfMeasure.milimeter:

                    a /= 1000;
                    b /= 1000;
                    c /= 1000;

                    break;
                case UnitOfMeasure.centimeter:

                    a /= 100;
                    b /= 100;
                    c /= 100;

                    break;
                case UnitOfMeasure.meter:

                    break;
                default:

                    throw new ArgumentOutOfRangeException("BŁĄD, nieprawidłowa jednostka");
            }

            if (a > 10 || b > 10 || c > 10)

                throw new ArgumentOutOfRangeException("BŁĄD, przekroczyłeś zakres liczb (max 10m)");

            this.a = a;
            this.b = b;
            this.c = c;
        }


        //zadanie 3
        public double A
        {
            get { return Math.Round(a, 3); }
        }

        public double B
        {
            get { return Math.Round(b, 3); }
        }

        public double C
        {
            get { return Math.Round(c, 3); }
        }

        //////zadanie 4

        //«liczba» «jednostka» × «liczba» «jednostka» × «liczba» «jednostka»

        public static System.Text.Encoding Unicode { get; }
        public string ToString(string format)
        {
            switch (format)
            {
                case "m":
                    return $"{a:F3} m × {b:F3} m × {c:F3} m";
                case "cm":
                    return $"{a * 100:F1} cm × {b * 100:F1} cm × {c * 100:F1} cm";
                case "mm":
                    return $"{a * 1000:F0} mm × {b * 1000:F0} mm × {c * 1000:F0} mm";
                default:
                    throw new FormatException($"Nieobsługiwany format: {format}");
            }
        }

               public override string ToString()
        {
            return ToString("m");
        }


        //zadanie 5
        public double Objetosc
        { get => Math.Round((this.A * this.B * this.C), 9); }

        //zadanie 6

        public double Pole 
        { get => Math.Round(2 * (this.A * this.B + this.A * this.C + this.B * this.C), 6); }

        //zadanie 7

        public override bool Equals(object obj)
        {
            if (obj is Pudelko)  return Equals((Pudelko)obj);

            return base.Equals(obj);
        }
        public bool Equals(Pudelko pudelko)
        {
            return (Pole == pudelko.Pole && Objetosc == pudelko.Objetosc);
        }

        public override int GetHashCode()
        {
            return A.GetHashCode() + B.GetHashCode() + C.GetHashCode() + unit.GetHashCode();
        }

        public static bool operator ==(Pudelko p1, Pudelko p2) => p1.Equals(p2);
        public static bool operator !=(Pudelko p1, Pudelko p2) => p1.Equals(p2);






    }
    }















