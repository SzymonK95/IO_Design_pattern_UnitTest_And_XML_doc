using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    /// <summary>
    /// Interface wymagający implementacji funkcji pracuj
    /// </summary>
    public interface Praca
    {
        void pracuj();
    }

    /// <summary>
    /// Interface wymagający implementacji funkcji dojazd
    /// </summary>
    public interface Dojazd
    {
        void dojazd();
    }

    /// <summary>
    /// Interface wymagający implementacji funkcji spedzajWolnyCzas
    /// </summary>
    public interface SpedzanieWolnegoCzasu
    {
        void spedzajWolnyCzas();
    }

    /// <summary>
    /// Klasa implementacji funkcje pracuj
    /// </summary>
    public class TestujeSamochodow : Praca
    {
        public void pracuj()
        {
            Console.WriteLine("Praca: testuje samochod");
        }
    }

    /// <summary>
    /// Klasa implementacji funkcje pracuj
    /// </summary>
    public class MalujeSamochod : Praca
    {
        public void pracuj()
        {
            Console.WriteLine("Praca: maluje samochod");
        }
    }

    /// <summary>
    /// Klasa implementacji funkcje pracuj
    /// </summary>
    public class MontujeSilnik : Praca
    {
        public void pracuj()
        {
            Console.WriteLine("Praca: montuje silnik");
        }
    }

    /// <summary>
    /// Klasa implementacji funkcje dojazd
    /// </summary>
    public class Samochod : Dojazd
    {
        public void dojazd()
        {
            Console.WriteLine("Dojazd: samochod");
        }
    }

    /// <summary>
    /// Klasa implementacji funkcje dojazd
    /// </summary>
    public class Rower : Dojazd
    {
        public void dojazd()
        {
            Console.WriteLine("Dojazd: rower");
        }
    }

    /// <summary>
    /// Klasa implementacji funkcje spedzajWolnyCzas
    /// </summary>
    public class Silownia : SpedzanieWolnegoCzasu
    {
        public void spedzajWolnyCzas()
        {
            Console.WriteLine("Wolny Czas: silownia");
        }
    }

    /// <summary>
    /// Klasa implementacji funkcje spedzajWolnyCzas
    /// </summary>
    public class LiteraturaPopularnoNaukowa : SpedzanieWolnegoCzasu
    {
        public void spedzajWolnyCzas()
        {
            Console.WriteLine("Wolny Czas: literatura popularno-naukowa");
        }
    }

    /// <summary>
    /// Klasa implementacji funkcje spedzajWolnyCzas
    /// </summary>
    public class GraKomputerowa : SpedzanieWolnegoCzasu
    {
        public void spedzajWolnyCzas()
        {
            Console.WriteLine("Wolny Czas: gra komputerowa");
        }
    }

    /// <summary>
    /// Klasa ustalająca kontekst
    /// </summary>
    public class Pracownik
    {
        private Praca praca = null;
        private Dojazd dojazd = null;
        private SpedzanieWolnegoCzasu spedzanieWolnegoCzasu = null;

        public Pracownik(String zawod)
        {
            if ((zawod.ToUpper()).Equals("TESTER"))
            {
                praca = new TestujeSamochodow();
                dojazd = new Samochod();
                spedzanieWolnegoCzasu = new Silownia();
            }
            else if ((zawod.ToUpper()).Equals("LAKIERNIK"))
            {
                praca = new MalujeSamochod();
                dojazd = new Samochod();
                spedzanieWolnegoCzasu = new LiteraturaPopularnoNaukowa();
            }
            else if ((zawod.ToUpper()).Equals("MONTER"))
            {
                praca = new MontujeSilnik();
                dojazd = new Rower();
                spedzanieWolnegoCzasu = new Silownia();
            }
        }

        public void methods() //wywolanie algorytmow
        {
            praca.pracuj();
            dojazd.dojazd();
            spedzanieWolnegoCzasu.spedzajWolnyCzas();
        }
    }

    /// <summary>
    /// Klasa posiadająca funkcje Main
    /// </summary>
    public class Strategy
    {
        public static void Main(string[] args)
        {
            int i = 0;
            while (i < 5)
            {
                Console.WriteLine("\nPodaj zawod:");
                try
                {
                    Pracownik pracownik = new Pracownik(Console.ReadLine());
                    pracownik.methods();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Nie ma takiego zawodu");
                }
                i++;
            }
            return;
        }

    }
}
