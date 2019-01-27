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
            if (wspolczynniki.Length != 0)
            {
                bool liczZera = true;
                long ileZer = 0;
                for (int i =0; i < wspolczynniki.Length; i++)
                {
                    if (wspolczynniki[i] == 0 && liczZera == true)
                        ileZer++; 
                    else if (wspolczynniki[i] != 0)
                        liczZera = false;
                }
                //var aLength = wspolczynniki.Length == ileZer ? 1 : wspolczynniki.Length - ileZer;
                a = new int[wspolczynniki.Length - ileZer]; //nie wolno a=wspolczynniki, bo nie będzie niezmienniczości
                if (wspolczynniki.Length == ileZer)
                {
                    a = new int[1] { 0 };
                }
                else
                {
                    a = new int[wspolczynniki.Length - ileZer];
                    Array.Copy(wspolczynniki, ileZer, a, 0, wspolczynniki.Length - ileZer); //a nie może być pusta
                }
                Array.Reverse(a);
                //a = a.Where(x => x != 0).ToArray();
                //(Array sourceArray, long sourceIndex, Array destinationArray, long destinationIndex, long length);
            }
            else
                throw new ArgumentException("wielomian nie może być pusty");
        }
    }
}

