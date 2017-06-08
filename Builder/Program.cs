using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Program
    {
        /// <summary>
        /// Klasa samochod posiada metody z których korzysta builder
        /// </summary>
        public class Samochod
        {
            public String silnik { get; set; }
            public String karoseria { get; set; }
            public String kolor { get; set; }
            public String nazwa { get; set; }

            public void setSilnik(String silnik)
            {
                this.silnik = silnik;
            }

            public void setKaroseria(String karoseria)
            {
                this.karoseria = karoseria;
            }

            public void setKolor(String kolor)
            {
                this.kolor = kolor;
            }

            public void setNazwa(String nazwa)
            {
                this.nazwa = "Ford " + nazwa;
            }

            public void show()
            {
                if (nazwa != null) Console.WriteLine("Nazwa = " + nazwa);
                if (silnik != null) Console.WriteLine("Silnik = " + silnik);
                if (karoseria != null) Console.WriteLine("Karoseria = " + karoseria);
                if (kolor != null) Console.WriteLine("Kolor = " + kolor);
            }
        }

        /// <summary>
        /// Glowny interface
        /// </summary>

        public abstract class Builder
        {
            protected Samochod samochod;

            public void newSamochod()
            {
                samochod = new Samochod();
            }

            public Samochod getSamochod()
            {
                return samochod;
            }

            public abstract void buildSilnik();
            public abstract void buildKategoria();
            public abstract void buildKolor();
            public abstract void buildNazwa();
        }

        /// <summary>
        /// Mustang_3_0_GT_Czarny implementuje inteface Builder dzieki czemu precyzujemy wartości obiektu
        /// </summary>
        public class Mustang_3_0_GT_Czarny : Builder
        {
            public override void buildSilnik()
            {
                samochod.setSilnik("3.0 GT");
            }

            public override void buildKategoria()
            {
                samochod.setKaroseria("Sportowy/Coupe");
            }

            public override void buildKolor()
            {
                samochod.setKolor("Czarny");
            }

            public override void buildNazwa()
            {
                samochod.setNazwa("Mustang GT");
            }
        }

        /// <summary>
        /// Focus_2_0_Niebieski implementuje inteface Builder dzieki czemu precyzujemy wartości obiektu
        /// </summary>
        public class Focus_2_0_Niebieski : Builder
        {
            public override void buildSilnik()
            {
                samochod.setSilnik("2.0 Turbo");
            }

            public override void buildKategoria()
            {
                samochod.setKaroseria("Seadn");
            }

            public override void buildKolor()
            {
                samochod.setKolor("Niebieski");
            }

            public override void buildNazwa()
            {
                samochod.setNazwa("Focus Turbo");
            }
        }

        /// <summary>
        /// Klasa zlecająca builderom zbudowanie obiektu
        /// </summary>
        public class Director
        {
            private Builder builder;

            public void setBuilder(Builder builder)
            {
                this.builder = builder;
            }

            public Samochod getSamochod()
            {
                return builder.getSamochod();
            }

            public void Produkuj()
            {
                builder.newSamochod();
                builder.buildSilnik();
                builder.buildKategoria();
                builder.buildNazwa();
                builder.buildKolor();
            }
        }
        
        /// <summary>
        /// Funkcja Main wywoluje kolejno funkcje oraz wyświetla wyniki
        /// </summary>
        /// <param name="args">Standardowy zapis funkcji Main z parametrem args</param>
        public static void Main(string[] args)
        {
            Director szef = new Director();
            Builder builder = new Mustang_3_0_GT_Czarny();
            Builder builder2 = new Focus_2_0_Niebieski();

            Console.WriteLine("\nSamochod 1");
            szef.setBuilder(builder);
            szef.Produkuj();
            Samochod samochod1 = szef.getSamochod();


            szef.setBuilder(builder2);
            szef.Produkuj();
            Samochod samochod2 = szef.getSamochod();


            samochod1.show();
            Console.WriteLine("\n\nSamochod 2");
            samochod2.show();

            Console.ReadKey();
        }
    }
}