using System;

namespace Lab_12
{
    public class Complex
    {
        public double Re { get; set; }
        public double Im { get; set; }

        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }
        public Complex()
        {
            Re = 0;
            Im = 0;
        }
        public static bool operator ==(Complex c1, Complex c2)
        {
            if (c1.Re == c2.Re && c1.Im == c2.Im)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Complex c1, Complex c2)
        {
            if (c1.Re == c2.Re && c1.Im == c2.Im)
            {
                return false;
            }
            return true;
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Re + c2.Re, c1.Im + c2.Im);
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.Re - c2.Re, c1.Im - c2.Im);
        }
        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.Re * c2.Re - c1.Im * c2.Im, c1.Re * c2.Im + c1.Im * c2.Re);
        }
        public override string ToString()
        {
            if (Re == 0)
            {
                return $"{Im}i";
            }
            if (Im == 0)
            {
                return $"{Re}";
            }
            if (Im > 0)
            {
                return $"{Re} + {Im}i";
            }
            return $"{Re}  {Im}i";
        }
        public override bool Equals(object obj)
        {
            if (obj is Complex c)
            {
                return c == this;
            }
            return base.Equals(obj);
        }
    }
}