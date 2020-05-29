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
        
        public void dodawanie()//Dodawanie Autora, publikacji, umowy itd. do naszej Bazy danych
        {                       //różne konstruktory w zależności od typów parametrów?

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
    class MainClass
    {
        public static void Main()
        {
            Console.WriteLine("EPRESS i'm comming!");
        }
    }
}
