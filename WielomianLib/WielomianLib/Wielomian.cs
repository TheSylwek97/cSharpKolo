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
            //Console.WriteLine(string.Join(" | ", a));
            string s = "";
            for (int i = Stopien; i > 0; i--) //  int i = Stopien; i > 0; i-- || int i = 0; i < Stopien; i++
            {
                s += a[i] + "x^" + i + " + ";
            }
            //s = s + a[Stopien] + "x^" + Stopien;
            return s + a[0];// + "x^0";
            /*
            string[] words;
            words = s.Split(';').ToArray<string>();
            Array.Reverse(words);
            return string.Join(" ", words);*/
        }
        
        public Wielomian(params int[] wspolczynniki)
        {
            a = new int[wspolczynniki.Length]; //nie wolno a=wwspolczynniki, bo nie będzie niezmienniczości

            if (a.Length != 0)
            {
                Array.Copy(wspolczynniki, a, wspolczynniki.Length); //a nie może być pusta
                Array.Reverse(a);
                //a = a.Where(x => x != 0).ToArray();
            }
            else
                throw new ArgumentException("wielomian nie może być pusty");
        }
    }
}

