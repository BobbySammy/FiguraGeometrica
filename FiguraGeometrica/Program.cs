
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguraGeometriche
{
    class Program
    {
        static void Main(string[] args)
        {
            Raccolta r = new Raccolta();
            Triangolo t = new Triangolo(3, 4, 5, 5);
            Quadrato q = new Quadrato(10);
            Rettangolo f = new Rettangolo(7, 3);
            r.Add(t);
            r.Add(q);
            r.Add(f);

            Console.WriteLine(t);
            Console.WriteLine("----------------------");
            Console.WriteLine(q);
            Console.WriteLine("----------------------");
            Console.WriteLine(f);
            Console.WriteLine("----------------------");
            Console.WriteLine("Figura di area massima della Raccolta: ");
            Console.WriteLine(r.maxArea());
            Console.WriteLine("----------------------");
            Console.WriteLine("Figura di perimetro minimo della Raccolta: ");
            Console.WriteLine(r.minPerimeter());
            Console.ReadKey();

        }
    }

    public abstract class FiguraGeometrica : ICloneable, IComparable
    {
        public abstract double perimetro();
        public abstract double area();
        object ICloneable.Clone()
        {
            return (object)Clone();
        }
        public abstract FiguraGeometrica Clone();
        public int CompareTo(object obj)
        {
            FiguraGeometrica f = (FiguraGeometrica)obj;
            if (this.area() == f.area())
            {
                return 0;
            }
            if (this.area() < f.area())
            {
                return -1;
            }

            return 1;
        }
    }
    public class Quadrato : FiguraGeometrica
    {
        double a;
        public Quadrato(double a)
        {
            this.a = a;
        }
        public override double perimetro()
        {
            return a * 4;
        }
        public override double area()
        {
            return a * a;
        }
        public override Quadrato Clone()
        {
            return new Quadrato(a);
        }

        public override bool Equals(object obj)
        {
            Quadrato q = (Quadrato)obj;
            return true ? this.a == q.a : false;
        }
        public override string ToString()
        {
            return "Figura: Quadrato \n Lato: " + a + "\n Area: " + this.area() + "\n Perimetro: " + this.perimetro();
        }
    }
    public class Triangolo : FiguraGeometrica
    {
        double bas, b, c, alt;
        public Triangolo(double b, double c, double bas, double alt)
        {

            this.b = b;
            this.c = c;
            this.bas = bas;
            this.alt = alt;
        }
        public override double perimetro()
        {
            return bas + b + c;
        }
        public override double area()
        {
            return (bas * alt) / 2;
        }

        public override Triangolo Clone()
        {
            return new Triangolo(b, c, bas, alt);
        }
        public override string ToString()
        {
            return "Figura: Triangolo \n Lati: " + bas + ", " + b + ", " + c + "\n Area: " + this.area() + "\n Perimetro: " + this.perimetro();
        }
    }
    public class Rettangolo : FiguraGeometrica
    {
        double bas, alt;
        public Rettangolo(double bas, double alt)
        {
            this.bas = bas;
            this.alt = alt;
        }
        public override double perimetro()
        {
            return (bas + alt) * 2;
        }
        public override double area()
        {
            return bas * alt;
        }
        public override Rettangolo Clone()
        {
            return new Rettangolo(bas, alt);
        }
        public override string ToString()
        {
            return "Figura: Rettangolo \n Lati: " + bas + ", " + alt + "\n Area: " + this.area() + "\n Perimetro: " + this.perimetro();
        }
    }
    public class Raccolta
    {
        List<FiguraGeometrica> l;
        public Raccolta()
        {
            l = new List<FiguraGeometrica>();
        }
        public void Add(FiguraGeometrica f)
        {
            l.Add(f);
        }
        public FiguraGeometrica maxArea()
        {
            IEnumerator<FiguraGeometrica> en = l.GetEnumerator();
            en.MoveNext();
            FiguraGeometrica f = en.Current;
            foreach (FiguraGeometrica i in this.l)
            {
                if (i.CompareTo(f) > 0)
                {
                    f = i;
                }
            }
            return f;
        }

        public FiguraGeometrica minPerimeter()
        {
            IEnumerator<FiguraGeometrica> en = l.GetEnumerator();
            en.MoveNext();
            FiguraGeometrica f = en.Current;
            foreach (FiguraGeometrica i in this.l)
            {
                if (i.perimetro() < f.perimetro())
                {
                    f = i;
                }
            }
            return f;
        }
    }
}
