using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy
{
    /// <summary>
    /// LazyClass posiada zmienna Value
    /// </summary>
    public class LazyClass
    {
        public int Value { get; set; }
        public LazyClass()
        {
            Value = 10;
        }
    }

    /// <summary>
    /// CustomLazyClass posiada zmienna _Value inicjalizowaną tuż przed uzyciem
    /// </summary>
    public class CustomLazyClass
    {
        private int _Value;
        public int Value
        {
            get
            {
                if (_Value == 0)
                {
                    _Value = new Random().Next(10, 1000);
                }

                return _Value;
            }
            set
            {
                _Value = value;
            }
        }
    }

    /// <summary>
    /// Klasa zawierająca funkcje Main
    /// </summary>
    public class Lazy
    {
        public static void Main(string[] args)
        {
            var lazyVar = new LazyClass();
            Console.WriteLine("value = " + lazyVar.Value);

            var customLazy = new CustomLazyClass();
            Console.WriteLine("valueC = " + customLazy.Value);
        }
    }
}
