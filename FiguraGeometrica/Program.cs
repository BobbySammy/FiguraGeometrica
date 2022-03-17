
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
            FiguraGeometrica t = new Triangolo(3, 4, 5, 5);
            FiguraGeometrica t2 = new Triangolo(7, 4, 5, 8);
            FiguraGeometrica q = new Quadrato(10);
            FiguraGeometrica q2 = new Quadrato(2);
            //FiguraGeometrica qEx2 = new Quadrato(0);
            Quadrato qCast = null;
            FiguraGeometrica qEx = null;
            try
            {
                qCast = r.toQuadrato(t);
                qEx = new Quadrato(-8);
            }
            catch (Exception ex)
            {
                if (ex is InvalidCastException)
                {
                    Console.WriteLine("Casting non corretto! Restituisco un oggetto null");
                    qCast = null;
                }
                if (ex is ParametroErrato)
                {
                    Console.WriteLine("Lato negativo! Creo un quadrato di lato 1");
                    qEx = new Quadrato(1);
                }
            }
            Console.WriteLine(qCast);
            Console.WriteLine(qEx);
            
            //FiguraGeometrica r1 = new Rettangolo(7, 3);
            //FiguraGeometrica r2 = new Rettangolo(7, 5);
            //FiguraGeometrica r3 = new Rettangolo(7, 9);
            //Quadrato qCast = r.toQuadrato(q);
            r.Add(t);
            r.Add(t2);
            r.Add(q2);
            r.Add(q);
            //r.Add(r1);
            //r.Add(r2);
            //r.Add(r3);
            Console.WriteLine("----------------------");
            Console.WriteLine(t);
            Console.WriteLine("----------------------");
            Console.WriteLine(q);
            Console.WriteLine("----------------------");
            Console.WriteLine(r);
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
            Console.WriteLine("Figure di area massima della Raccolta: ");
            Console.WriteLine(r.maxAreaFigure());
            Console.WriteLine("----------------------");
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

    public class Quadrato: Rettangolo
    {
        public Quadrato(double lato) : base(lato, lato) 
        {
            if (lato < 1)
            {
                throw new ParametroErrato("Lato del quadrato non valido!", lato);
            }
        }
        public override Quadrato Clone()
        {
            return new Quadrato(base.bas);
        }
        public override bool Equals(object obj)
        {
            try
            {
                Quadrato q = (Quadrato)obj;
                return true ? base.bas == q.bas : false;
            }
            catch (InvalidCastException ex)
            {
                return false;
            }
        }
        public override string ToString()
        {
            return "Figura: Quadrato \n Lato: " + base.alt + "\n Area: " + base.area() + "\n Perimetro: " + base.perimetro();
        }
    }

    public class Rombo : Quadrato
    {
        double diagMag, diagMin;
        public Rombo(double lato, double diagMag, double diagMin) : base(lato) 
        {
            this.diagMag = diagMag;
            this.diagMin = diagMin;
        }
        public override double area()
        {
            return (diagMag*diagMin)/2;
        }
        public override Rombo Clone()
        {
            return new Rombo(base.bas, this.diagMag, this.diagMin);
        }
        public override bool Equals(object obj)
        {
            try { 
                Rombo q = (Rombo)obj;
                return true ? base.bas == q.bas : false;
            }
            catch(InvalidCastException ex)
            {
                return false;
            }
        }
        public override string ToString()
        {
            return "Figura: Rombo \n Lato: " + this.alt + "\n Area: " + this.area() + "\n Perimetro: " + this.perimetro();
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
        protected double bas, alt;
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
                s += i + "\n";
            }
            return s;
        }

        public Quadrato maxAreaQuadrato()
        {
            Quadrato q = (Quadrato)l.Find(x => x is Quadrato);
            foreach (FiguraGeometrica i in this.l)
            {
                if (i is Quadrato)
                {
                    q = (i.CompareTo(q) > 0) ? (Quadrato)i : q;
                }
            }
            return q;
        }

        public Raccolta maxAreaFigure()
        {
            Raccolta ris = new Raccolta();
            FiguraGeometrica tmpMax;
            //Predicate<FiguraGeometrica> p = eTriangolo;
            foreach (FiguraGeometrica f in this.l)
            {
                //Console.WriteLine(ris.Find(eTriangolo));
                if (ris.l.Find(x => x.GetType() == f.GetType()) == null)
                {
                    tmpMax = f;
                    foreach (FiguraGeometrica i in this.l)
                    {
                        if (f.GetType() == i.GetType())
                        {
                            tmpMax = (i.CompareTo(tmpMax) > 0) ? i : tmpMax;
                        }
                    }
                    ris.Add(tmpMax);
                }
            }
            return ris;
        }

        //i predicati lavorano solo su funzioni che hanno come parametro un oggetto
        //dello stesso tipo definito nel predicato.
        //La funzione deve essere dichiarata private static bool
        /*private static bool eTriangolo(FiguraGeometrica f)
        {
            return f is Triangolo;
        }*/
        public Quadrato toQuadrato(FiguraGeometrica f)
        {

            //Quadrato q = (Quadrato)f;


            //sollevo l'eccezione
            Quadrato q;
            if (!(f is Quadrato))
                throw new InvalidCastException();
            else
                q = (Quadrato)f;
            return q;


            //gestisco l'eccezione nel metodo
            //Quadrato q;
            //try
            //{
            //    q = (Quadrato)f;
            //}catch(InvalidCastException ex)
            //{
            //    Console.WriteLine(ex);
            //    return null;
            //}
            //return q;


        }
    }
}
