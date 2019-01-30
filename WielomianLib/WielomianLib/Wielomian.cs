using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMath
{

    public sealed class Wielomian// : IEquatable<Wielomian>// : IEnumerable<Wielomian> //IE NIE SKOŃCZONE, nie działa poprawnie
    {
        private readonly int[] a;//{ get; set; } immutability: nie może być setterów, Provide parameters via constructor., readonly 
        public int Stopien => a.Length - 1; //to tylko get
        //public int Stopien { get { return a.Length - 1; } set { Stopien = value; } }//TYLKO TO UNIT TESTÓW

        public Wielomian()
        {
            a = new int[1] { 0 };
        }

        // jawna Wielomian na int
        private int val;
        public static implicit operator int(Wielomian d)
        {

            if(d.Stopien == 0)
                return d.val;
            else
                throw new InvalidCastException("wielomian nie jest stopnia zerowego");
        }

        // jawna int na Wielomian
        public static implicit operator Wielomian(int d)
        {
            return new Wielomian(d);
        }

        //niejawna z Wielomian na int[]
        public static explicit operator int[](Wielomian r) // NIE SKOŃCZONE
        {
            //r = Int32.Parse("r");
            //int[] array = c.Split(',').Select(str => int.Parse(str)).ToArray(); //string na int[]
            // lub int[] array = arr.Split(',').Select(int.Parse).ToArray(); //string na int[]

            int[] b = new int[] { r };
            return b;
        }
        public override string ToString()
        {
            //Console.WriteLine(string.Join(" | ", a));
            string s = "";
            for (int i = Stopien; i > 0; i--) //  int i = Stopien; i > 0; i-- || int i = 0; i < Stopien; i++
            {
                s += a[i] + "x^" + i + " + ";
            }
            return s + a[0];// + "x^0";
            /*
            s = s + a[Stopien] + "x^" + Stopien;
            string[] words;
            words = s.Split(';').ToArray<string>();
            Array.Reverse(words);
            return string.Join(" ", words);*/
        }/*
        public static Wielomian Parse(string c) //NIE SKOŃCZONE
        {
            Type type = Type.GetType(inputString); //target type
            object o = Activator.CreateInstance(type); // an instance of target type
            YourType your = (YourType)o;
            int[] tab = c.Split(',').Select(int.Parse).ToArray(); //string na int[]
            if (c == null)
            throw new InvalidCastException("Długość tablicy wielomianu ma nulla");
            //Wielomian s = new Wielomian();
        }*/


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
            }
            else
                throw new ArgumentException("wielomian nie może być pusty");
        }/*
        private readonly int[] b;//{ get; set; } immutability: nie może być setterów, Provide parameters via constructor., readonly 

        public bool Equals(Wielomian other)
        {
            return false;
        }
        public override bool Equals(object other)
        {
            Wielomian w = other as Wielomian;

            return !ReferenceEquals(null, w)
                && Equals(a, w.a)
                && Equals(b, w.b);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, a) ? a.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, b) ? b.GetHashCode() : 0);
                return hash;
            }
        }
        public static bool operator ==(Wielomian numberA, Wielomian numberB)
        {
            if (Object.ReferenceEquals(numberA, numberB))
            {
                return true;
            }

            if (Object.ReferenceEquals(null, numberA))
            {
                return false;
            }

            return (numberA.Equals(numberB));
        }
        public static bool operator !=(Wielomian numberA, Wielomian numberB)
        {
            return !(numberA == numberB);
        }*/
        /*
        public IEnumerator<Wielomian> GetEnumerator()
        {
            //Wielomian a = new Wielomian(WielomianEnum.dane);
            throw new NotImplementedException("Cannot implicitly convert type WielomianEnum to Wielomian.\n An explicit conversion exists (are you missing a cast?) "); //new WielomianEnum(dane);
            //return new (WielomianEnum(WielomianEnum.dane);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); //return (IEnumerator)GetEnumerator();
        }
    }
    public class WielomianEnum : IEnumerator
    {
        public static Wielomian[] dane;
        int position = -1;

        public WielomianEnum(Wielomian[] list)
        {
            dane = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < dane.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Wielomian Current
        {
            get
            {
                try
                {
                    return dane[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }*/
    }

}

