using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMath
{

    public class Wielomian : IEquatable<Wielomian>
    {
        private int[] a;
        public int Stopien => a.Length - 1; //to tylko get

        public Wielomian()
        {
            a = new int[1] { 0 };
        }
        //int na wielomian
        
        public static implicit operator Wielomian(int x)
        {
            return x;
        }
        /*
        public static implicit operator Wielomian(int z)
        {
            return z.value;
        }*/
        //reszta kodu  

        //pole prywatne 
        private int value;
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
                //a = a.Where(x => x != 0).ToArray(); usuwanie 0 z tablicy.
/*
                if (Regex.IsMatch(ssn, @"\d{9}"))
                    uniqueSsn = $"{ssn.Substring(0, 3)}-{ssn.Substring(3, 2)}-{ssn.Substring(5, 4)}";
                else if (Regex.IsMatch(ssn, @"\d{3}-\d{2}-\d{4}"))
                    uniqueSsn = ssn;
                else
                    throw new FormatException("The social security number has an invalid format.");

                this.LastName = lastName;*/
            }
            else
                throw new ArgumentException("wielomian nie może być pusty");
        }
        

        public bool Equals(Wielomian other)
        {
            if (other == null)
                return false;

            if (this.a == other.a)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Wielomian wielomianObj = obj as Wielomian;
            if (wielomianObj == null)
                return false;
            else
                return Equals(wielomianObj);
        }

        public override int GetHashCode()
        {
            return this.Stopien.GetHashCode();
        }
        

    }
}

