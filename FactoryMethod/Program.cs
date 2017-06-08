using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// Ogolny produkt
    /// </summary>
    public abstract class Samochod
    {
        public String about;

        public abstract Samochod wyprodukujSamochod();

        protected void dodajSilnikISkrzynie()
        {
            Console.WriteLine("Dodaje silnik i skrzynie...");
        }
    }

    /// <summary>
    /// Produkt sprecyzowany 1
    /// </summary>
    public class Osobowy : Samochod
    {
        public Osobowy()
        {
            about = "Osobowy";
        }

        public void dodajOsobowaKaroserie()
        {
            Console.WriteLine("Dodaje osobowa karoserie...");
        }

        public void dodajKlimatyzacje()
        {
            Console.WriteLine("Dodaje klimatyzacje...");
        }

        public override Samochod wyprodukujSamochod()
        {
            Console.WriteLine(about);
            dodajSilnikISkrzynie();
            dodajKlimatyzacje();
            dodajOsobowaKaroserie();
            return this;
        }
    }

    /// <summary>
    /// Produkt sprecyzowany 2
    /// </summary>
    public class Terenowy : Samochod
    {
        public Terenowy()
        {
            about = "Terenowy";
        }

        public void dodajTerenowaKaroserie()
        {
            Console.WriteLine("Dodaje terenowa karoserie...");
        }

        public void dodajTerenoweKolaIZawieszenie()
        {
            Console.WriteLine("Dodaje terenowe kola i zawieszenie...");
        }

        public void dodajKlatkeBezpieczenstwa()
        {
            Console.WriteLine("Dodaje klatke bezpieczenstwa...");
        }

        public override Samochod wyprodukujSamochod()
        {
            Console.WriteLine(about);
            dodajSilnikISkrzynie();
            dodajKlatkeBezpieczenstwa();
            dodajTerenowaKaroserie();
            dodajTerenoweKolaIZawieszenie();
            return this;
        }
    }

    /// <summary>
    /// Produkt sprecyzowany 3
    /// </summary>
    public class Sportowy : Samochod
    {
        public Sportowy()
        {
            about = "Sportowy";
        }

        public void dodajSportowaKaroserie()
        {
            Console.WriteLine("Dodaje sportowa karoserie...");
        }

        public void dodajTurbo()
        {
            Console.WriteLine("Dodaje turbo...");
        }

        public override Samochod wyprodukujSamochod()
        {
            Console.WriteLine(about);
            dodajSilnikISkrzynie();
            dodajSportowaKaroserie();
            dodajTurbo();
            return this;
        }
    }

    /// <summary>
    /// Producent tworzący obiekty na podstawie parametru about
    /// </summary>
    public class ProducentSamochodow
    {
        public Samochod produkcjaSamochodu(String about)
        {
            Samochod car = null;

            /* teraz decyduje o tym, jakie auto wyprodukujemy */
            if (about.Equals("Osobowy"))
            {
                car = new Osobowy();
            }
            else if (about.Equals("Terenowy"))
            {
                car = new Terenowy();
            }
            else if (about.Equals("Sportowy"))
            {
                car = new Sportowy();
            }
            return car.wyprodukujSamochod();
        }
    }

    /// <summary>
    /// Klasa zawierająca funkcje Main
    /// </summary>
    public class FactoryMethod
    {
        public static void Main(string[] args)
        {
            ProducentSamochodow producent = new ProducentSamochodow();
            Samochod[] tab = new Samochod[3];

            tab[0] = producent.produkcjaSamochodu("Osobowy");
            Console.WriteLine("--------------------------------------------------------------");
            tab[1] = producent.produkcjaSamochodu("Terenowy");
            Console.WriteLine("--------------------------------------------------------------");
            tab[2] = producent.produkcjaSamochodu("Sportowy");
            Console.ReadLine();
        }
    }
}
