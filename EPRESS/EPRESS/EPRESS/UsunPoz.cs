using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPRESS
{
    class UsunPoz
    {
        public static void usunAutora()
        {
            Autor autor;
            string imie, nazwisko;
            if (Start.autorzy.Licz() == 0)
            {
                Console.WriteLine("Brak autorow w bazie.\nAnulowano operacje.");
            }
            Console.WriteLine("Podaj imie autora do usuniecia: ");
            imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko autora do usuniecia: ");
            nazwisko = Console.ReadLine();
            autor = Start.autorzy.Znajdz(imie, nazwisko);
            if(autor == null)
            {
                Console.WriteLine("Takiego autora nie ma w bazie.");        //wyjatek - brak autora (albo w autorzy.Znajdz();
                return;
            }
            Start.autorzy.Usun(autor);
        }
        public static void usunAutora(Autor autor)
        {
            Start.autorzy.Usun(autor);
        }
        public static void usunUmowe(Umowa umowa)
        {
            Start.umowy.Usun(umowa);
        }
        public static void usunKsiazke(Ksiazka ksiazka)
        {
            Start.ksiazki.Usun(ksiazka);
        }
        public static void usunCzasopismo(Czasopismo czasop)
        {
            Start.czasopisma.Usun(czasop);
        }

    }
}
