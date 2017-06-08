using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// Podstawowy obiekt, nieudekorowany
    /// </summary>
    public abstract class Samochod
    {
        protected string samochod = "Samochod podstawowy";

        virtual public String about()
        {
            return samochod;
        }

        public abstract double cena();
    }
    
    /// <summary>
    /// Dekorator dla obiektu Samochod
    /// </summary>
    public abstract class Dekorator : Samochod
    {
        public abstract override String about();
    }

    
    /// <summary>
    /// Klasa dziedziczaca z Samochod
    /// </summary>
    public class Mercedes : Samochod
    {

        public Mercedes()
        {
            samochod = "Mercedes";
        }

        public override double cena()
        {
            return 500000;
        }
    }

    /// <summary>
    /// Klasa dziedziczaca z Samochod
    /// </summary>
    public class Ford : Samochod
    {

        public Ford()
        {
            samochod = "Ford";
        }

        public override double cena()
        {
            return 100000;
        }
    }

    /// <summary>
    /// Klasa dziedziczaca z Dekorator
    /// </summary>
    public class Klimatyzacja : Dekorator
    {
        Samochod car;

        public Klimatyzacja(Samochod samochod)
        {
            car = samochod;
        }

        public override String about()
        {
            return car.about() + " + klimatyzacja";
        }

        public override double cena()
        {
            if (car is Mercedes)
            {
                return car.cena() + 60000;
            }
            else if (car is Ford)
            {
                return car.cena() + 20000;
            }
            return 0;
        }
    }

    /// <summary>
    /// Klasa dziedziczaca z Dekorator
    /// </summary>
    public class OponyZimowe : Dekorator
    {
        Samochod car;

        public OponyZimowe(Samochod samochod)
        {
            car = samochod;
        }

        public override String about()
        {
            return car.about() + " + opony zimowe";
        }

        public override double cena()
        {
            return car.cena() + 8000;
        }
    }

    /// <summary>
    /// Klasa zawierająca funkcje Main
    /// </summary>
    public class Decorator
    {
        public static void Main(String[] args)
        {
            Samochod s1 = new Mercedes();
            Samochod s2 = new Ford();

            Console.WriteLine("\nBez wyposazenia");
            Console.WriteLine(s1.about() + " " + s1.cena());
            Console.WriteLine(s2.about() + " " + s2.cena());

            //dodajemy po klimie

            s1 = new Klimatyzacja(s1);
            s2 = new Klimatyzacja(s2);
            Console.WriteLine("\nZ Klima");
            Console.WriteLine(s1.about() + " " + s1.cena());
            Console.WriteLine(s2.about() + " " + s2.cena());

            // i opony

            s1 = new OponyZimowe(s1);
            s2 = new OponyZimowe(s2);
            Console.WriteLine("\nZ oponami");
            Console.WriteLine(s1.about() + " " + s1.cena());
            Console.WriteLine(s2.about() + " " + s2.cena());

            //odrazu tworzymy wyposazony samochod
            Console.WriteLine("\nPelne wyposazenie");
            Samochod s3 = new OponyZimowe(new Klimatyzacja(new Mercedes()));
            Console.WriteLine(s3.about() + " " + s3.cena());
            Console.ReadLine();

        }
    }
}
