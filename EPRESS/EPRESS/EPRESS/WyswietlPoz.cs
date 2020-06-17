using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPRESS
{
    class WyswietlPoz
    {
        public static void wysAutorow()
        {
            Console.Clear();
            Start.autorzy.Wypisz();
        }
        public static void wysUmowy()
        {
            Console.Clear();
            Start.umowy.Wypisz();
        }
        public static void wysKsiazki()
        {
            Console.Clear();
            Start.ksiazki.Wypisz();
        }
        public static void wysCzasopisma()
        {
            Console.Clear();
            Start.czasopisma.Wypisz();
        }
    }
}
