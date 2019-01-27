using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMath
{
    public class Wielomian
    {
        private int[] a;
        public int Stopien => a.Length - 1; //to tylko get

        public Wielomian()
        {
            a = new int[1] { 0 };
        }
        
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Stopien; i++)
            {
                s += a[i] + "x^" + i + " + ";
            }
            return s + a[Stopien] + "x^" + Stopien;
        }
        
        public Wielomian(params int[] wspolczynniki)
        {
            a = new int[wspolczynniki.Length]; //niewolno a=wspol... bo nie będzie niezmienniczości
            Array.Copy(wspolczynniki, a, wspolczynniki.Length); //a  nie może być pusta
            Array.Reverse(a);
            //a = a.Where(x => x != 0).ToArray();
        }
    }
}