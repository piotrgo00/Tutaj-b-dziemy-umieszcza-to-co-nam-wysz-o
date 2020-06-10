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
        public static void dodajUmowe()
        {
            int czasTrwania, wybor;
            float pensja;
            
            Console.WriteLine("Podaj autora\n1. Nowy autor\n2. Istniejacy autor");
            wybor = Console.Read();
            Autor autor = null;
            if (wybor == 1)
            {
                autor = dodajAutora();
                Console.WriteLine("Podaj czas trwania umowy w miesiacach: ");
                czasTrwania = Console.Read();
                Console.WriteLine("Podaj Pensje autora: ");                                                         /*Potrzeba mi tutaj wyszukiwania autorow i przypisywania im konkretnych umów*/              
                 pensja = Console.Read();
                Umowa umowa = new Umowa(czasTrwania,pensja,autor);
            }
            else if (wybor == 2)
            {
                Console.WriteLine("Podaj czas trwania umowy w miesiacach: ");
                czasTrwania = Console.Read();
                Console.WriteLine("Podaj Pensje autora: ");
                pensja = Console.Read();
            }
            else
            {
                Console.WriteLine("Nie odpowiedni wybor, nie udalo sie dodac autora!");
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
