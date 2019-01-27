
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
    }
}
