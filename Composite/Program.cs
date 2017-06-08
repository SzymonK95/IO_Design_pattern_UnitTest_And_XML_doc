using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Composite
{
    public class CustomString
    {
        private readonly IEnumerable<Char> _chars;
        public CustomString(IEnumerable<Char> chars)
        {
            _chars = chars;
        }

        public CustomString Append(CustomString customString)
        {
            var newChars = _chars.Concat(customString._chars);
            var newCustomString = new CustomString(newChars);
            return newCustomString;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < _chars.Count(); i++)
            {
                sb.Append(_chars.ElementAt(i));
            }
            return sb.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var firstCustomString = new CustomString("_FirstCustomString_");
            var secondCustomString = new CustomString("_SecondCustomString_");
            var thirdCustomString = firstCustomString.Append(secondCustomString);
            var forthCustomString = thirdCustomString.Append(secondCustomString);
            Console.WriteLine(thirdCustomString.ToString());
            Console.WriteLine(forthCustomString.ToString());
        }
    }
}