using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPRESS
{
    class DodajPoz
    {
        public static Autor dodajAutora()
        {
            string imie, nazwisko;
            Console.WriteLine("Imie autora: ");
            imie = Console.ReadLine();
            Console.WriteLine("Nazwisko autora: ");
            nazwisko = Console.ReadLine();

            Autor autor = new Autor(imie, nazwisko);

            return autor;
        }
        public static void dodajUmowe(int typ)
        {
            int czasTrwania, wybor;
            float pensja;
            string nazwisko;
            Console.WriteLine("Podaj autora\n1. Nowy autor\n2. Istniejacy autor");
            wybor = Console.Read();
            Autor autor = null;
            if (wybor == 1)
            {
                autor = dodajAutora();
            }
            return;
        }
        public static void dodajKsiazke()
        {

        }
        public static void dodajCzasopismo()
        {

        }
    }
}
