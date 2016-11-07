using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labki0711
{
  class Program
  {
    struct Adres
    {
      string ulica;
      string nr_domu;
      string nr_mieszkania;
      string miejscowosc;
      public Adres(string m )
      {
        miejscowosc = m;
        nr_domu = default(string);
        nr_mieszkania = default(string);
        ulica = default(string);
      }
      public void ShowAdres()
      {
        Console.WriteLine($"{ulica} {nr_domu} {nr_mieszkania} , {miejscowosc}");
      }
    }
    struct Osoba
    {
      string imie;
      string nazwisko;
      Adres adres;
      string[] nazwy_dokumentów;
      int id;
      public Osoba(string i,string n, string m)
      {
        imie = i;
        nazwisko = n;
        adres = new Adres(m);
        id = default(int);
        nazwy_dokumentów = new string[] { "Dowód", "Prawko", "Paszport" };
      }

      public void Show()
      {
        Console.WriteLine($"{imie} {nazwisko}");
        adres.ShowAdres();
        Console.WriteLine("Dokumenty");
        foreach (var item in nazwy_dokumentów)
        {
          Console.WriteLine(item);
        }
      }
      public Osoba ShallowCopy()
      {
        return  (Osoba)this.MemberwiseClone();
      }
      public Osoba DeepCopy()
      {
        var temp = this.ShallowCopy();
        temp.nazwy_dokumentów = new string[this.nazwy_dokumentów.Length];
        int i = 0;
        foreach (var item in temp.nazwy_dokumentów)
        {
          temp.nazwy_dokumentów[i] = this.nazwy_dokumentów[i];
          i++;
        }
        return temp;
      }
    }
    static void Main(string[] args)
    {
      List<Osoba> osoby = new List<Osoba>();

      for (int i = 0; i < 5; i++)
      {
        Console.WriteLine($"Dodaj {i+1} osobę");
        osoby.Add(new Osoba(Console.ReadLine(), Console.ReadLine(), Console.ReadLine()));

      }

      foreach (var item in osoby)
      {
        item.Show();
        Console.WriteLine();
      }
    }
  }
}
