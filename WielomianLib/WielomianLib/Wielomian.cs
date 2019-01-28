using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMath
{

    public class Wielomian //: /*IEquatable<Wielomian>,*/ IEnumerator<Wielomian>
    {
        private int[] a;//{ get; set; }
        
        public int Stopien => a.Length - 1; //to tylko get
        //public int Stopien { get { return a.Length - 1; } set {Stopien = value; } }


        public Wielomian()
        {
            a = new int[1] { 0 };
        }

        public int val;
        // jawna Wielomian na int
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
        public static explicit operator int[](Wielomian r)
        {
            //r = Int32.Parse("r");
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
            //s = s + a[Stopien] + "x^" + Stopien;
            return s + a[0];// + "x^0";
            /*
            string[] words;
            words = s.Split(';').ToArray<string>();
            Array.Reverse(words);
            return string.Join(" ", words);*/
        }
        public static Wielomian Parse(string c)
        {/*
            Type type = Type.GetType(inputString); //target type
            object o = Activator.CreateInstance(type); // an instance of target type
            YourType your = (YourType)o;*/
            Type type = Type.GetType(c); //target type
            object o = Activator.CreateInstance(type); // an instance of target type
            Wielomian w = (Wielomian)o;

            string[] words;
            words = c.Split('^').ToArray<string>();

            if (words.Length > 0)
                return w;
            else
                throw new InvalidCastException("Długość tablicy wielomianu wynosi 0");
            //Wielomian s = new Wielomian();
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
                
            }
            else
                throw new ArgumentException("wielomian nie może być pusty");
        }/*
        public bool MoveNext()//back
        {
            Stopien--;
            return (Stopien < a.Length);
        }
        public void Reset()
        {
            Stopien = a.Length - 1;
        }
        object IEnumerator<Wielomian>.Current
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
                    return a[Stopien];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }/*
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

            if (!(obj is Wielomian wielomianObj))
                return false;
            else
                return Equals(wielomianObj);
        }

        public override int GetHashCode()
        {
            return this.Stopien.GetHashCode();
        }
        */

    }
}

