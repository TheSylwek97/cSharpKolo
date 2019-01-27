
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultsString = "00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35";
            var resultsArray = resultsString.Split(',');
            Console.WriteLine("Ilość okrązeń: " + resultsArray.Count());    //a)
            var resultsTimeSpan = resultsArray.Select(x => new TimeSpan(0, 0, GetMinutes(x), GetSeconds(x)));   //b)
            Console.WriteLine("Kolejne czasy jako IEnumerableSpan: " + string.Join(" / ", resultsTimeSpan.Select(x => x.ToString())));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var klienci = new List<Klient>();

            var izabela = new Klient();
            izabela.nazwaKlienta = "Izabela";
            izabela.zamowienia = new List<Zamowienie>() {
            new Zamowienie() { DataZamowienia = new DateTime(2018, 12, 01), Razem = 100 },
            new Zamowienie() { DataZamowienia = new DateTime(2019, 05, 01), Razem = 150 },
            };
            klienci.Add(izabela);


            var sylwia = new Klient();
            sylwia.nazwaKlienta = "Sylwia";
            sylwia.zamowienia = new List<Zamowienie>() {
            new Zamowienie() { DataZamowienia = new DateTime(2019, 06, 09), Razem = 250 },
            };
            klienci.Add(sylwia);

            var klaudia = new Klient();
            klaudia.nazwaKlienta = "Klaudia";
            klaudia.zamowienia = new List<Zamowienie>() {
            new Zamowienie() { DataZamowienia = new DateTime(2018, 05, 09), Razem = 250 },
            };
            klienci.Add(klaudia);

            var klienciKupujacyW2018NotacjaKropkowa = klienci.Where(x => x.zamowienia.Any(y => y.DataZamowienia.Year == 2018));
            Console.WriteLine("klienci kupujacy w 2018 notacja kropkowa: " + string.Join(" / ", klienciKupujacyW2018NotacjaKropkowa.Select(x => x.nazwaKlienta)));
            //var klienciKupujacyW2018NotacjaQuery = from klient in klienci where 
            //Console.WriteLine("klienci kupujacy w 2018 notacja kropkowa: " + string.Join(" / ", from klient in klienciKupujacyW2018NotacjaQuery select klient.nazwaKlienta));


        }

        public static int GetMinutes(string resultString)
        {
            var minutes = 0;
            if (int.TryParse(resultString.Split(':')[0], out minutes))
                return minutes;
            return 0;
        }

        public static int GetSeconds(string resultsString)
        {
            var seconds = 0;
            if (int.TryParse(resultsString.Split(':')[1], out seconds))
                return seconds;
            return 0;
        }

        public class Klient
        {
            public int idKlienta;
            public string nazwaKlienta;
            public List<Zamowienie> zamowienia { get; set; }

            public override string ToString()
            {
                string s = idKlienta + " " + nazwaKlienta;
                foreach (var x in zamowienia)
                {
                    s += x;
                }
                return s;
            }
        }
        public class Zamowienie
        {
            public DateTime DataZamowienia { get; set; }

            public decimal Razem { get; set; }

            public override string ToString()
            {
                return $"({DataZamowienia.ToString("yyyy-mm-dd")}, {Razem}) ";
            }
        }
    }
}
