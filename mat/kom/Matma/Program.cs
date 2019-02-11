using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        { 
            Mathm math = new Mathm();
            string ChoseFunction;
            Console.WriteLine("Wybież odpowienid skrót {K, KB, W, WB} \nOblicz, ile jest 3-elementowych podzbiorów zbioru 6-elementowego ---> KB" +
                              "\nOblicz, ile można utworzyć 4-elementowych multizbiorów(z powtórzeniami) ze zbioru A ={a,b,c} ---> K" +
                              "\n Wariacja Z Powtórzeniami ---> W" +
                              "\n Wariacja Bez Powtórzeń ---> WB");
            

            ChoseFunction = Console.ReadLine();
            switch (ChoseFunction)
            {
                case "K":
                    Console.WriteLine("Wynik --->" + math.KbZPow());
                    break;

                case "KB":
                    Console.WriteLine("Wynik --->" + math.KbBezPow());
                    break;

                case "W":
                    Console.WriteLine("Wynik --->" + math.WarZPow());
                    break;

                case "WB":
                    Console.WriteLine("Wynik --->" + math.WarBezPow());
                    break;
            }

            Console.ReadKey();

        }
    }

    class  Mathm//Kombinacja
    {
        public double KbBezPow()
        {
            string collection;
            string underCollection;
            Console.WriteLine("Ilość elementów zbioru -->");
            collection = Console.ReadLine();
            Console.WriteLine("Ilość elementów podzbioru -->");
            underCollection = Console.ReadLine();
            int collectionInt = Int32.Parse(collection);
            int underCollectionInt = Int32.Parse(underCollection);
            double collectionSilnia = silnia(collectionInt); //6
            double underCollectionSilnia = silnia(underCollectionInt); //3

            double tmp;
            double tmp1;
            tmp = collectionInt - underCollectionInt;
            tmp1 = underCollectionSilnia * silnia(tmp);
            tmp = collectionSilnia / tmp1;

            return tmp;
        }

        public double KbZPow()
        {
            string collection;
            string collectionCount;
            Console.WriteLine("Ilu elementowy multizbiór -->");
            collection = Console.ReadLine();
            Console.WriteLine("Ilość elementów zbioru {a,b,c...} Podać liczbę -->");
            collectionCount = Console.ReadLine();

            int collectionInt = Int32.Parse(collection);
            int collectionCountInt = Int32.Parse(collectionCount);
            double collectionSilnia = silnia(collectionInt); //6
            double collectionCountSilnia = silnia(collectionCountInt); //3

            double tmp;
            double tmp1;
            double score;

            tmp = collectionInt + collectionCountInt - 1;
            tmp1 = collectionSilnia * silnia(collectionCountInt - 1);
            score = silnia(tmp) / tmp1;

            return score;
        }

        public double WarBezPow()
        {
            string collection;
            string collectionCount;
            Console.WriteLine("Ilu elementowy multizbiór -->");
            collection = Console.ReadLine();
            Console.WriteLine("Ilość elementów w zbiorze {a,b,c...} Podać liczbę -->");
            collectionCount = Console.ReadLine();

            int collectionInt = Int32.Parse(collection);
            int collectionCountInt = Int32.Parse(collectionCount);
            double collectionSilnia = silnia(collectionInt); //6
            double collectionCountSilnia = silnia(collectionCountInt); //3

            double tmp;
            double tmp1;
            double score;

            tmp = collectionSilnia;
            tmp1 = collectionCountSilnia * silnia(collectionInt - collectionCountInt);
            score = tmp / tmp1;

            return score;
        }

        public double WarZPow()
        {
            string collection;
            string collectionCount;
            Console.WriteLine("Ilu elementowy multizbiór -->");
            collection = Console.ReadLine();
            Console.WriteLine("Ilość elementów w zbiorze {a,b,c...} Podać liczbę -->");
            collectionCount = Console.ReadLine();

            double collectionDouble = Int32.Parse(collection);
            double collectionCountDouble = Int32.Parse(collectionCount);


            
            double score = Math.Pow(collectionDouble, collectionCountDouble);

            return score;
        }

          public double silnia(double n)
            {
                if (n > 1) { return silnia(n - 1) * n; }
                else { return 1; }
            }
    }
}
