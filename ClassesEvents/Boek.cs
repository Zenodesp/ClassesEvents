using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesEvents
{



    public enum Verschijningsperiode
    {
        Dagelijks,
        Wekelijks,
        Maandelijks
    }
    internal class Boek
    {
        public static int Volgnummer { get { id++; return id; } set { id = value; } }
        public int Isbn { get; set; }
        public string Naam { get; set; }
        public string Uitgever { get; set; }
        public double Prijs { get {return prijs; } set { if (value < 50.00 && value > 5.00) { prijs = value; } else {throw new ArgumentOutOfRangeException("geen geldige prijs"); } } }

        private static int id;
        private static double prijs;

        public Boek()
        {
            Isbn = Volgnummer;
        }

        public Boek(string Naam, string Uitgever, double Prijs)
        {
            Isbn = Volgnummer;
            this.Naam = Naam;
            this.Prijs = Prijs;
            this.Uitgever = Uitgever;
        }

        public void Lees(string Naam)
        {
             Console.WriteLine(Naam + " is gelezen!");
        }

        public override string ToString()
        {
            return Isbn + " - " + Naam + " - " + Uitgever + " - " + Prijs + " - ";
        }
    }

    internal class Tijdschrift : Boek
    {
        public Verschijningsperiode vp;

        public Tijdschrift( string Naam, string Uitgever, double Prijs, Verschijningsperiode vp) {
            Isbn = Volgnummer;
            this.Naam = Naam;
            this.Prijs = Prijs;
            this.Uitgever = Uitgever;
            this.vp = vp;
        }

    }

    internal class Bestelling<T>
    {
        public event EventHandler BestellingMaken;

        void AlsBestelling(string message)
        {
            if (BestellingMaken != null)
            {
                BestellingMaken(message);
            }
        }
        public static int Volgnummer { get { id++; return id; } set { id = value; } }
        public int Id { get; set; }
        public Boek Item { get; set; }
        public DateTime Datum { get; set; }
        public int Aantal { get; set; }
        public Verschijningsperiode Abonnement { get; set; }

        public static void message(string message)
        {
            Console.WriteLine("Report: " + message);
        }

        private static int id;


        public Bestelling()
        {
            BestellingMaken += message;
        }
        public Tuple<int, int, double> Bestel<T>(Boek bb)
        {
            Console.WriteLine("Hoeveel boeken wilt u aankopen?");
            Aantal = Convert.ToInt32(Console.ReadLine());


            Tuple<int, int, double> resultaat = Tuple.Create
            (
                bb.Isbn,
                 Aantal,
               (bb.Prijs * Aantal)
            );
            Item = bb;
            Datum = DateTime.Now;


            AlsBestelling("Bestelling gemaakt!");

            return resultaat;

            
        }

    }

    
}
