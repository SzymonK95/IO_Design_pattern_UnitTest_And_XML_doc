using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Decorator;
using Builder;
using FactoryMethod;
using Strategy;
using Lazy;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// TestMethod_Builder testuje poprwaność nazwy obiekt Mustang_3_0_GT_Czarny
        /// </summary>
        [TestMethod]
        public void TestMethod_Builder()
        {
            Builder.Program.Director szef = new Builder.Program.Director();
            Builder.Program.Builder builder = new Builder.Program.Mustang_3_0_GT_Czarny();
            
            szef.setBuilder(builder);
            szef.Produkuj();
            Builder.Program.Samochod samochod = szef.getSamochod();

            Assert.AreNotEqual(samochod.nazwa, "Mustang GT");
            Assert.AreEqual(samochod.nazwa, "Ford Mustang GT");
        }

        /// <summary>
        /// TestMethod_Decorator testuje poprawnosc ceny Mercedesa bez i z dodatkami
        /// </summary>
        [TestMethod]
        public void TestMethod_Decorator()
        {
            Decorator.Samochod s1 = new Mercedes();
            Assert.AreEqual(s1.cena(), 500000);

            s1 = new Klimatyzacja(s1);
            s1 = new OponyZimowe(s1);

            Assert.IsTrue(s1.cena() > 500000);
        }

        /// <summary>
        /// TestMethod_FactoryMethod testuje poprawnosc opisu stworzonego obiektu
        /// </summary>
        [TestMethod]
        public void TestMethod_FactoryMethod()
        {
            ProducentSamochodow producent = new ProducentSamochodow();
            FactoryMethod.Samochod s = producent.produkcjaSamochodu("Osobowy");

            Assert.AreEqual(s.about, "Osobowy");
            Assert.AreNotEqual(s.about, "Terenowy");
            Assert.AreNotEqual(s.about, "Sportowy");
        }

        /// <summary>
        /// TestMethod_Strategy testuje poprawnosc wywolywania roznych algorytmow dla roznych kontekstow
        /// </summary>
        [TestMethod]
        public void TestMethod_Strategy()
        {
            Pracownik pracownik1 = new Pracownik("LAKIERNIK");
            pracownik1.methods();

            Pracownik pracownik2 = new Pracownik("TESTER");
            pracownik2.methods();

            Assert.IsFalse(pracownik1 == pracownik2);
        }

        /// <summary>
        /// TestMethod_Lazy testuje czy wygenerowane vartosci w sumnie sa wieksze niz dana wartosc 
        /// </summary>
        [TestMethod]
        public void TestMethod_Lazy()
        {
            List<CustomLazyClass> list = new List<CustomLazyClass>();
            for (int i = 0; i < 100; i++)
                list.Add(new CustomLazyClass());

            var sum = 0;
            foreach (CustomLazyClass c in list)
                sum += c.Value;

            Assert.IsTrue(sum > 10000);
            
        }
    }
}
