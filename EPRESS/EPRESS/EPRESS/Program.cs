/*Wydawnictwo ePress wydaje pozycje: książki różnego rodzaju (sensacyjne, romanse, albumy, ...) oraz 2 rodzaje czasopism: tygodniki oraz miesięczniki. Współpracuje z autorami, których zatrudnia na umowę o pracę lub o dzieło (zajmuje się tym dział programowy wydawnictwa). Drukowaniem zarządza dział druku - odbywa się to w jednej z 3 własnych drukarni, z tym że tylko 1 z nich zapewnia wystarczającą jakość druku dla albumów.
Minimalny zakres funkcjonalności:

    -zarządzanie autorami (dodawanie, usuwanie, przegląd)

    -zarządzanie umowami i pozycjami (zawieranie umowy o pracę, zawieranie umowy o dzieło na konkretną pozycję, zlecanie w ramach umowy o pracę przygotowania konkretnej pozycji , rozwiązywanie, przegląd)

    -zarządzanie procesem drukowania: dział handlowy przygotowuje zlecenie druku i przesyła je do działu programowego, dział programowy wybiera pasującą drukarnię i przesyła jej zlecenie, drukarnia po wykonaniu druku powiadamia działy druku i handlowy, a ten ostatni wprowadza egzemplarze do swojej oferty

    -bardzo prosty sklep prowadzony przez dział handlowy (funkcjonalności: przyjmowanie zleceń zakupu pozycji zmniejszającej stan magazynowy i pokazywanie katalogu dostępnych pozycji)

    -zapis i odczyt stanu systemu na dysk*/
using System;
using System.Collections.Generic;
namespace EPRESS
{  
    class ePress
    {
        private int wybor;
        
        public void dodawanie(Umowa umowa)  //Dodawanie Autora, publikacji, umowy itd. do naszej Bazy danych
        {                                   //różne konstruktory w zależności od typów parametrów?

        }
        public void usuwanie()//usuwanie autorów, publikacji, umówi itd. z naszej bazy danych
        {                   //trzeba będzie dodać różne konstruktory w zależności od typu parametrów

        }
        public void drukowanie()
        {

        }
        public void wczytaj()
        {

        }
        public void zapisz()
        {

        }
    }
    class DzialDruku
    {
        private Drukarnie drukarnie;
        public void drukuj()
        {

        }
        public void wydrukowano()
        {

        }
    }
    class Drukarnie 
    {
        private List<Drukarnia> drukarnie = new List<Drukarnia>();
        public List<Drukarnia> GetDrukarnie() { return drukarnie; }
    }
    class Drukarnia
    {
        private string nazwa;
        private bool czyMozeAlbumy;
        public string GetNazwa() { return nazwa; }
        public bool GetMozeAlbumy() { return czyMozeAlbumy; }
    }
    class DzialProgramowy
    {
        private Umowy umowy;
        private Autorzy autorzy;
        public void WybierzDrukarnie()
        {

        }
        public void Zatrudnij()
        {

        }
        public void Przeslij()
        {

        }
    }
    class Umowy
    {
        private List<Umowa> umowy=new List<Umowa>();
        public void Dodaj(Umowa umowa)
        {
            umowy.Add(umowa);
        }
        public void Usun(Umowa umowa)
        {
            umowy.Remove(umowa);
        }
        public List<Umowa> GetUmowy()
        {
            return umowy;
        }
        public void Wypisz(List<Umowa> umowy)
        {
            foreach(Umowa umowa in umowy)
            {
                Console.WriteLine("autor: "+umowa.GetAutor()+"Czas trwania: " + umowa.GetCzasTrwania() + "Wynagrodzenie: " + umowa.GetWynagrodzenie());
            }
        }
    }
    class Umowa
    {
        private int CzastrwaniaUmowy;
        private float wynagrodzenie;
        private Autor autor;
        public int GetCzasTrwania() { return CzastrwaniaUmowy; }
        public float GetWynagrodzenie() { return wynagrodzenie; }
        public Autor GetAutor() { return autor; }
    }
    class UmowaoPrace : Umowa { }
    class UmowaoDzielo : Umowa { }
    class Autorzy
    {
        private List<Autor> autorzy = new List<Autor>();
        public void Dodaj(Autor autor)
        {
            autorzy.Add(autor);
        }
        public void Usun(Autor autor)
        {
            autorzy.Add(autor);
        }
        public List<Autor> GetAutorzy()
        {
            return autorzy;
        }
        public void Wypisz (List<Autor> autorzy)
        {
            foreach(Autor autor in autorzy)
            {
                Console.WriteLine(autor.GetImie() + " " + autor.GetNazwisko());
            }
        }
    }
    class Autor
    {
        private string imie;
        private string nazwisko;
        public string GetImie() { return imie; }
        public string GetNazwisko() { return nazwisko; }
    }
    class DzialHandlowy
    {
        private Czasopisma czasopisma;
        private Ksiazki ksiazki;
        public void zlecenie()
        {

        }
        public void oferta()
        {

        }
        public void przeslij()
        {

        }
    }
    class Czasopismo
    {
        private int numer;
        private float cena;
        private string tytul;
        public string GetTytyul()
        {
            return tytul;
        }
        public float GetCena()
        {
            return cena;
        }
        public int GetNumerCzasopisma()
        {
            return numer;
        }
    }
    class Tygodnik : Czasopismo { }
    class Miesiecznik : Czasopismo { }
    class Czasopisma
    {
        private List<Czasopismo> Czasopismos =new List<Czasopismo>();
        public void Dodaj(Czasopismo czasopismo)
        {
            Czasopismos.Add(czasopismo);
        }
        public void Usun(Czasopismo czasopismo)
        {
            Czasopismos.Remove(czasopismo);
        }
        public List<Czasopismo> GetPisma()
        {
            return Czasopismos;
        }
        public void Wypisz(List<Czasopismo> czasopisma)
        {
            foreach(Czasopismo gazeta in czasopisma)
            {
                Console.WriteLine(gazeta.GetTytyul()+" nr: "+gazeta.GetNumerCzasopisma()+" cena: "+gazeta.GetCena());
            }
        }
    }
    class Ksiazki
    {
        private List<Ksiazka> ksiazki=new List<Ksiazka>();
        public void dodaj(Ksiazka ksiazka)
        {
            ksiazki.Add(ksiazka);
        }
        public void usun(Ksiazka ksiazka)
        {
            ksiazki.Remove(ksiazka);
        }
        public List<Ksiazka> GetKsiazki()
        {
            return ksiazki;
        }
        public void Wypisz(List<Ksiazka> ksiazki)
        {
            foreach(Ksiazka ksiazka in ksiazki)
            {
                Console.WriteLine(ksiazka.GetTytul() + " Autor: " + ksiazka.GetAutor() + " Rok wydania: " + ksiazka.GetRokWydania());
            }
        }
    }
    class Ksiazka
    {
        private string tytul;
        private Autor Autor;
        private int RokWydania;
        public string GetTytul()
        {
            return tytul;
        }
        public int GetRokWydania()
        {
            return RokWydania;
        }
        public Autor GetAutor()
        {
            return Autor;
        }
    }
    class Sensacyjna : Ksiazka { }
    class Album : Ksiazka { }
    class Romans : Ksiazka { }
    class MainClass
    {
        public static void Main()
        {
            Console.WriteLine("EPRESS i'm comming!");
        }
    }
}
