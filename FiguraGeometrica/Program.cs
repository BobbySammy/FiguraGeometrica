
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
            Quadrato q2 = new Quadrato(2);
            Rettangolo f = new Rettangolo(7, 3);
            r.Add(t);
            r.Add(q2);
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
            Console.WriteLine("----------------------");
            Console.WriteLine("Quadrato di area massima della Raccolta: ");
            Console.WriteLine(r.maxAreaQuadrato());
            Console.WriteLine("----------------------");
            //testing git CLI
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
        double bas, l1, l2, alt;
        public Triangolo(double b, double c, double bas, double alt)
        {

            this.l1 = b;
            this.l2 = c;
            this.bas = bas;
            this.alt = alt;
        }
        public override double perimetro()
        {
            return bas + l1 + l2;
        }
        public override double area()
        {
            return (bas * alt) / 2;
        }

        public override Triangolo Clone()
        {
            return new Triangolo(l1, l2, bas, alt);
        }
        public override string ToString()
        {
            return "Figura: Triangolo \n Lati: " + bas + ", " + l1 + ", " + l2 + "\n Area: " + this.area() + "\n Perimetro: " + this.perimetro();
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

    public class Circonferenza : FiguraGeometrica
    {
        double raggio;

        public Circonferenza(double r)
        {
            this.raggio = r;
        }

        public override double area()
        {
            return Math.PI*(Math.Pow(raggio,2));
        }

        public override FiguraGeometrica Clone()
        {
            return new Circonferenza(this.raggio);
        }

        public override double perimetro()
        {
            return 2*Math.PI*raggio;
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
            FiguraGeometrica f = l.First();
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
            FiguraGeometrica f = l.First();
            foreach (FiguraGeometrica i in this.l)
            {
                if (i.perimetro() < f.perimetro())
                {
                    f = i;
                }
            }
            return f;
        }
        public override string ToString()
        {
            string s = "";
            foreach (FiguraGeometrica i in this.l)
            {
                s += i;
            }
            return s;
        }

        public Quadrato maxAreaQuadrato()
        {
            Quadrato q = (Quadrato)l.Find(q => q is Quadrato);
            foreach (FiguraGeometrica i in this.l)
            {
                if (i is Quadrato)
                {
                    q = (i.CompareTo(q)>1) ? (Quadrato)i : q;
                }
            }
            return q;
        }
    }
}
