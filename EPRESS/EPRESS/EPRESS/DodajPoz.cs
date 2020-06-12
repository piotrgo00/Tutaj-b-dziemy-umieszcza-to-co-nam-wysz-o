using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            Start.autorzy.Dodaj(autor);

            return autor;
        }
        public static void dodajUmowe()
        {
            int czasTrwania, wybor, wybor2;
            float pensja;
            string imieTmp, nazwiskoTmp;
            
            Console.WriteLine("Podaj autora\n1. Nowy autor\n2. Istniejacy autor");
            wybor = int.Parse(Console.ReadLine());
            Autor autor = null;
            if(wybor<1 || wybor>2)
            {
                Console.WriteLine("Nie odpowiedni wybor, nie udalo sie dodac autora!");         //+ wyjatki chyba trzeba dodac
                return;
            }
            Console.WriteLine("Podaj czas trwania umowy w miesiacach: ");
            czasTrwania = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj Pensje autora: ");
            pensja = float.Parse(Console.ReadLine());
            if (wybor == 1)
            {
                autor = dodajAutora();
                Umowa umowa = new Umowa(czasTrwania,pensja,autor);
            }
            else if (wybor == 2)
            {
                Console.WriteLine("Nazwisko autora: ");
                nazwiskoTmp = Console.ReadLine();
                Console.WriteLine("Imie autora: ");
                imieTmp = Console.ReadLine();
                autor = Start.autorzy.Znajdz(imieTmp, nazwiskoTmp);
                Console.WriteLine("1. Umowa o prace.\n2. Umowa o dzielo\n");
                wybor2 = int.Parse(Console.ReadLine());
                if (wybor2 == 1)
                {
                    UmowaoPrace umowaoPrace = new UmowaoPrace(czasTrwania, pensja, autor);
                    Start.umowy.Dodaj(umowaoPrace);
                }else if (wybor2 == 2)
                {
                    UmowaoDzielo umowaoDzielo = new UmowaoDzielo(czasTrwania, pensja, autor);
                    Start.umowy.Dodaj(umowaoDzielo);
                }
                else
                {
                    Console.WriteLine("Nieodpowiedni wybor, nie udalo sie dodac autora!");         //+ wyrzucenie wyjatku
                    return;
                }
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
