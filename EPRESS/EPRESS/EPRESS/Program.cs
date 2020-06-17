/*Wydawnictwo ePress wydaje pozycje: książki różnego rodzaju (sensacyjne, romanse, albumy, ...) oraz 2 rodzaje czasopism: tygodniki oraz miesięczniki. Współpracuje z autorami, których zatrudnia na umowę o pracę lub o dzieło (zajmuje się tym dział programowy wydawnictwa). Drukowaniem zarządza dział druku - odbywa się to w jednej z 3 własnych drukarni, z tym że tylko 1 z nich zapewnia wystarczającą jakość druku dla albumów.
Minimalny zakres funkcjonalności:

    -zarządzanie autorami (dodawanie, usuwanie, przegląd)

    -zarządzanie umowami i pozycjami (zawieranie umowy o pracę, zawieranie umowy o dzieło na konkretną pozycję, zlecanie w ramach umowy o pracę przygotowania konkretnej pozycji , rozwiązywanie, przegląd)

    -zarządzanie procesem drukowania: dział handlowy przygotowuje zlecenie druku i przesyła je do działu programowego, dział programowy wybiera pasującą drukarnię i przesyła jej zlecenie, drukarnia po wykonaniu druku powiadamia działy druku i handlowy, a ten ostatni wprowadza egzemplarze do swojej oferty

    -bardzo prosty sklep prowadzony przez dział handlowy (funkcjonalności: przyjmowanie zleceń zakupu pozycji zmniejszającej stan magazynowy i pokazywanie katalogu dostępnych pozycji)

    -zapis i odczyt stanu systemu na dysk*/
using System;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace EPRESS
{  
    class ePress
    {

        public int init()
        {
            int m;
            Console.WriteLine("1. Dodaj element\n2. Usun element\n3. Drukuj element\n4. Wczytaj baze z pliku\n5. Zapisz baze do pliku\n6. Wyjscie\nWybor: ");
            m = int.Parse(Console.ReadLine());
            switch (m)
            {
                case 1:
                    dodawanie();
                    break;
                case 2:
                    usuwanie();
                    break;
                case 3:
                    drukowanie();
                    break;
                case 4:
                    wczytaj();
                    break;
                case 5:
                    zapisz();
                    break;
                case 6:
                    return 1;
                default:
                    Console.Clear();
                    Console.WriteLine("Podano nieprawidlowa wartosc.");
                    return 0;
            }
            //Console.Clear();
            return 0;
        }
        private void dodawanie()  //Dodawanie Autora, publikacji, umowy itd. do naszej Bazy danych
        {                                   //różne konstruktory w zależności od typów parametrów?
            int m;
            Console.WriteLine("Dodaj\n1. Autora\n2. Umowe\n3. Ksiazka\n4. Czasopismo\n");
            m = int.Parse(Console.ReadLine());
            switch (m)
            {
                case 1:
                    DodajPoz.dodajAutora();
                    break;
                case 2:
                    DodajPoz.dodajUmowe();
                    break;
                case 3:
                    DodajPoz.dodajKsiazke();
                    break;
                case 4:
                    DodajPoz.dodajCzasopismo();
                    break;
                default:
                    Console.WriteLine("Podano nieprawidlowa wartosc.");
                    break;
            }

        }
        private void usuwanie()//usuwanie autorów, publikacji, umówi itd. z naszej bazy danych
        {
            string imie="";
            string nazwisko="";
            string[] autorzy;
            int liczbaElementow;
            string umowa1;
            string umowa2;
            string umowa3;
            Console.WriteLine("To jest lista autorow: ");                                              //trzeba będzie dodać różne konstruktory w zależności od typu parametrów
            using (StreamReader file = new StreamReader("autorzy.txt"))
            {
                int iterator = 0;
                liczbaElementow=0;

                autorzy = file.ReadToEnd().Split(' ');
                foreach (string autor in autorzy)
                {
                    if(iterator == 0)
                    { imie = autor; Console.WriteLine("Imie to: " + imie);liczbaElementow++; }
                    if (iterator == 1)
                    { nazwisko = autor; Console.WriteLine("Nazwisko to: " + nazwisko);liczbaElementow++; }

                    iterator++;
                    if (iterator == 2)
                    {
                        
                        iterator = 0;
                    }
                }
                
                Console.WriteLine("Ktorego chcialbys usunac?\n Podaj jego Imie: ");
                imie = Console.ReadLine();
                Console.WriteLine("Podaj jego nazwisko: ");
                nazwisko = Console.ReadLine();

               for(int i = 0; i<= liczbaElementow/2; i+=2)
                {
                    if (autorzy[i] == imie && autorzy[i + 1] == nazwisko)
                    {
                        for (int j = 0; j < liczbaElementow / 2; j += 2)
                        {
                            autorzy[i] = autorzy[i + 2];
                            autorzy[i + 1] = autorzy[i + 3];
                        }
                    }
                }
                file.Close();
            }
            using(StreamWriter file=new StreamWriter("autorzy1.txt"))
            {
                for(int i = 0; i < liczbaElementow - 2; i++)
                {
                    file.Write(autorzy[i] + " ");
                }
                file.Close();
            }
            
        }
        private void drukowanie()
        {

        }
        private void wczytaj()
        {
            
            using (StreamReader file = new StreamReader("autorzy.txt"))
            {
                int iterator = 0;
                string imie = "";
                string nazwisko = "";

                string[] autorzy = file.ReadToEnd().Split(' ');
                foreach (string autor in autorzy)
                {
                    
                    if (iterator == 0) 
                    {imie = autor; Console.WriteLine("Imie to: " + imie);}
                    if (iterator == 1) 
                    { nazwisko = autor; Console.WriteLine("Nazwisko to: " + nazwisko); }
                  
                    iterator++;
                    if (iterator == 2)
                    {
                        DodajPoz.dodajAutora(imie, nazwisko);
                        iterator = 0;
                    }
                }
                file.Close();
            }
            using (StreamReader file = new StreamReader("umowy.txt"))
            {
                int iterator = 0; 
                int czastrwania=0;
                float zarobki=0;
                string imieAutora="";
                string nazwiskoAutora="";
                string[] umowy =  file.ReadToEnd().Split(' ');

                
                foreach (string umowa in umowy)
                {

                    
                    if (iterator == 0)
                    { czastrwania = int.Parse(umowa); Console.WriteLine("Czas trwania umowy to: " + czastrwania); }
                    if (iterator == 1)
                    {
                        zarobki = float.Parse(umowa);Console.WriteLine("Zarobki na umowie to: " + zarobki);
                    }
                    if (iterator == 2)
                    {
                        imieAutora = umowa;Console.WriteLine("Imie autora to: " + imieAutora);
                    }
                    if (iterator == 3)
                    {
                        nazwiskoAutora = umowa;Console.WriteLine("Nazwisko autora to: " + nazwiskoAutora);
                    }
                    iterator++;
                    if (iterator == 4)
                    {
                        DodajPoz.dodajUmowe(czastrwania,zarobki,imieAutora,nazwiskoAutora);
                        iterator = 0;
                    }
                }
                file.Close();
            }




        }
        private void zapisz()
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
        private List<Drukarnia> drukarnie;
        public Drukarnie()
        {
            drukarnie = new List<Drukarnia>();
        }
        public List<Drukarnia> GetDrukarnie() { return drukarnie; }
        public Drukarnia DajDrukarnie(bool CzyAlbum)
        {
            foreach(Drukarnia druk in drukarnie)
            {
                if (druk.GetMozeAlbumy() == CzyAlbum) { return druk; }
                
            }
            return null;
        }
    }
    class Drukarnia
    {
        private string nazwa;
        private bool czyMozeAlbumy;
        public Drukarnia(string nazwaa, bool czymoze)
        {
            nazwa = nazwaa;
            czyMozeAlbumy = czymoze;
        }
        public string GetNazwa() { return nazwa; }
        public bool GetMozeAlbumy() { return czyMozeAlbumy; }
    }
    class DzialProgramowy
    {
        private Umowy umowy;
        private Autorzy autorzy;
        public Drukarnie druk = new Drukarnie();
        public Drukarnia WybierzDrukarnie(bool DrukujeAlbumy)
        {
           
               return druk.DajDrukarnie(DrukujeAlbumy);

        }
        public void Zatrudnij()
        {

        }
        public void Przeslij()
        {

        }
    }
    public class Umowy
    {
        private List<Umowa> umowy;
        public Umowy()
        {
            umowy = new List<Umowa>();
        }
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
    public class Umowa
    {
        public int CzastrwaniaUmowy { private get; set; }
        public float wynagrodzenie { private get; set; }
        public Autor autor { private get; set; }
        public Umowa(int CzasTrwania,float wynag, Autor Autor)
        {
            CzastrwaniaUmowy = CzasTrwania;
            wynagrodzenie = wynag;
            autor = Autor;
        }

        public int GetCzasTrwania() { return CzastrwaniaUmowy; }
        public float GetWynagrodzenie() { return wynagrodzenie; }
        public Autor GetAutor() { return autor; }
    }
    class UmowaoPrace : Umowa 
    {
        public UmowaoPrace(int czasTrwania, float wynag, Autor autor):base(czasTrwania,wynag,autor)
                                                                  
        {
            this.CzastrwaniaUmowy = czasTrwania;
            this.wynagrodzenie = wynag;
            this.autor = autor;
        }
    }
    class UmowaoDzielo : Umowa 
    {
        public UmowaoDzielo(int czasTrwania, float wynag, Autor autor) : base(czasTrwania,wynag,autor)
        { 
            this.CzastrwaniaUmowy = czasTrwania;
            this.wynagrodzenie = wynag;
            this.autor = autor;
        }
    }
    public class Autorzy
    {
        private List<Autor> autorzy;

        public Autorzy()
        {
            autorzy = new List<Autor>();
        }
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
        public Autor Znajdz(string imie, string nazwisko)
        {
            foreach(Autor autor in autorzy)
            {
                if ((String.Compare(autor.GetNazwisko(), nazwisko)==0)&&(String.Compare(autor.GetImie(), imie) == 0))
                    return autor;

            }
            return null;
        }
    }
    public class Autor
    {
        private string imie;
        private string nazwisko;
        Autor() { }
        public Autor(string im, string naz)
        {
            imie = im;
            nazwisko = naz;
        }
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
    public class Czasopismo
    {
        private int numer;
        private float cena;
        private string tytul;
        public Czasopismo(int nr,float Cen,string tyt)
        {
            numer = nr;
            cena = Cen;
            tytul = tyt;
        }
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
    class Tygodnik : Czasopismo 
    {
    public Tygodnik(int nr, float Cen, string tyt) : base(nr, Cen, tyt) { }
    }
    class Miesiecznik : Czasopismo 
    {
        public Miesiecznik(int nr, float Cen, string tyt) : base(nr, Cen, tyt) { }
    }
    public class Czasopisma
    {
        private List<Czasopismo> czasopisma;
        public Czasopisma()
        {
            czasopisma = new List<Czasopismo>();
        }
        public void Dodaj(Czasopismo czasopismo)
        {
            czasopisma.Add(czasopismo);
        }
        public void Usun(Czasopismo czasopismo)
        {
            czasopisma.Remove(czasopismo);
        }
        public List<Czasopismo> GetPisma()
        {
            return czasopisma;
        }
        public void Wypisz(List<Czasopismo> czasopisma)
        {
            foreach(Czasopismo gazeta in czasopisma)
            {
                Console.WriteLine(gazeta.GetTytyul()+" nr: "+gazeta.GetNumerCzasopisma()+" cena: "+gazeta.GetCena());
            }
        }
    }
    public class Ksiazki
    {
        private List<Ksiazka> ksiazki;
        public Ksiazki()
        {
            ksiazki = new List<Ksiazka>();
        }
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
    public class Ksiazka
    {
       
        private string tytul;
        private Autor Autor;
        private int RokWydania;
        public Ksiazka(string tyt,Autor autor, int rokWyd)
        {
            tytul = tyt;
            Autor = autor;
            RokWydania = rokWyd;
        }
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
    class Sensacyjna : Ksiazka 
    {
        public Sensacyjna(string tyt, Autor autor, int rokWyd) : base(tyt, autor, rokWyd){}
    }
    class Album : Ksiazka 
    {
        public Album(string tyt, Autor autor, int rokWyd) : base(tyt, autor, rokWyd) { }
    }
    class Romans : Ksiazka {
        public Romans(string tyt, Autor autor, int rokWyd) : base(tyt, autor, rokWyd) { }
    }
    class MainClass
    {
        public static void Main()
        {
            int m;
            Console.WriteLine("Kurwa!");
            ePress wydawnictowo = new ePress();
            do
            {
                m = wydawnictowo.init();
                
            } while (m == 0);
            
        }
    }
}
