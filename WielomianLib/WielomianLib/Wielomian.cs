using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMath
{

    public sealed class Wielomian : IEnumerable<Wielomian>, IEnumerator<Wielomian>, IEquatable<Wielomian> //IEquatable NIE SKOŃCZONE (nie działa poprawnie)
    {
        private readonly int[] a;//{ get; set; } immutability: nie może być setterów, Provide parameters via constructor., readonly 
        public int Stopien => a.Length - 1; //to tylko get

        //public int Stopien { get { return a.Length - 1; } set { Stopien = value; } }//TYLKO DLA UNIT TESTÓW
        //konstruktor domyślny
        public Wielomian()
        {
            a = new int[1] { 0 };
        }

        // konwersja jawna Wielomian na int
        private int val;
        public static implicit operator int(Wielomian d)
        {

            if (d.Stopien == 0)
                return d.val;
            else
                throw new InvalidCastException("wielomian nie jest stopnia zerowego");
        }

        // konwersja jawna int na Wielomian
        public static implicit operator Wielomian(int d)
        {
            return new Wielomian(d);
        }

        //konwersja niejawna z Wielomian na int[]
        public static explicit operator int[] (Wielomian r) // NIE SKOŃCZONE
        {
            Object number = r as Object;
            r = Int32.Parse("r");
            //int[] array = c.Split(',').Select(str => int.Parse(str)).ToArray(); //string na int[]
            //lub int[] array = arr.Split(',').Select(int.Parse).ToArray(); //string na int[]
            int[] a = number as int[];
            int[] b = new int[] { r };
            return a;
        }
        //metoda tworząca reprezentacje do strina klasy wielomian
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
        //foreach IEnumerator + IEnumerable
        IEnumerator<Wielomian> IEnumerable<Wielomian>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //foreach IEnumerator + IEnumerable
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        //foreach IEnumerator + IEnumerable
        Wielomian IEnumerator<Wielomian>.Current => throw new NotImplementedException();

        //foreach IEnumerator + IEnumerable
        private int position = -1;
        object IEnumerator.Current
        {

            get
            {
                try
                {
                    return (Wielomian)a[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        //foreach IEnumerator + IEnumerable
        bool disposed = false;
        void IDisposable.Dispose()
        {
            // Dispose of unmanaged resources.
            disposed = true;
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        //foreach IEnumerator + IEnumerable
        bool IEnumerator.MoveNext()
        {
            position++;
            return (position < a.Length);

        }

        //foreach IEnumerator + IEnumerable
        void IEnumerator.Reset()
        {
            position = 0;
        }

        //konstruktor 
        public Wielomian(params int[] wspolczynniki)
        {
            if (wspolczynniki.Length != 0)
            {
                bool liczZera = true;
                long ileZer = 0;
                for (int i = 0; i < wspolczynniki.Length; i++)
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
        }


        //IEquatable Równość, nierówność
        /*static */bool IEquatable<Wielomian>.Equals(Wielomian w)
        {
            return !ReferenceEquals(null, w)
                          && Equals(a, w.a);

        }
        //IEquatable Równość, nierówność
        /*public override bool Equals(object value)
        {
            Wielomian w = value as Wielomian;

            return !ReferenceEquals(null, w)
                && Equals(a, w.a);
        }*/
        //IEquatable Równość, nierówność
        public override int GetHashCode()
        {
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!ReferenceEquals(null, a) ? a.GetHashCode() : 0);
                return hash;
            }
        }
        //IEquatable Równość, nierówność
        public static bool operator ==(Wielomian numberA, Wielomian numberB)
        {
            if (ReferenceEquals(numberA, numberB))
            {
                return true;
            }

            if (ReferenceEquals(null, numberA))
            {
                return false;
            }

            return numberA.Equals(numberB);
        }
        //IEquatable Równość, nierówność
        public static bool operator !=(Wielomian numberA, Wielomian numberB)
        {
            return !(numberA == numberB);
        }


        public static Wielomian Plus(Wielomian a, Wielomian b)
        {
            
            return a;
        }
    }
   

}

