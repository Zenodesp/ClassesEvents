using ClassesEvents;

delegate void EventHandler(string message);
internal class Program
{

    public static void message(string message)
    {
        Console.WriteLine("Report: " + message);
    }

    private static void Main(string[] args)
    {
        char keuze = '0';

        string naam, uitgever;
        double prijs;
        Verschijningsperiode per;

        Boek b1 = new Boek();

        do
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1 Geef een boek in");
            Console.WriteLine("2 Geef een tijdschrift in");
            Console.WriteLine("3 Bestel een boek of tijdschrift");
            keuze = Console.ReadLine()[0];
            Console.WriteLine();

            switch (keuze) { 
                case '0':
                    break;
                case '1':
                    Console.WriteLine("Geef de naam van het boek in.");
                    naam = Console.ReadLine();
                    Console.WriteLine("geef de uitgever van het boek in.");
                    uitgever = Console.ReadLine();
                    Console.WriteLine("geef de prijs van het boek in.");
                    prijs = Convert.ToDouble(Console.ReadLine());
                    b1 = new Boek(naam, uitgever, prijs);
                    break;
                case '2':
                    Console.WriteLine("Geef de naam van het tijdschrift in.");
                    naam = Console.ReadLine();
                    Console.WriteLine("geef de uitgever van het tijdschrift in.");
                    uitgever = Console.ReadLine();
                    Console.WriteLine("geef de prijs van het tijdschrift in.");
                    prijs = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("hoe vaak wordt dit tijdschrift uitgegeven?");
                    Console.WriteLine("1. Dagelijks");
                    Console.WriteLine("2. Wekelijks");
                    Console.WriteLine("3. Maandelijks");
                    char k2 = Console.ReadLine()[0];
                    if(k2 == '1')
                    {
                        per = Verschijningsperiode.Dagelijks;
                    } else if (k2 == '2')
                    {
                        per = Verschijningsperiode.Wekelijks;
                    } else
                    {
                        per = Verschijningsperiode.Maandelijks;
                    }
                    Tijdschrift t1 = new Tijdschrift(naam, uitgever, prijs, per);
                    break;
                case '3':

                    Bestelling<Boek> bestellingboek = new Bestelling<Boek>();
                    bestellingboek.Bestel<Boek>(b1);
                   break;
            }

        } while (keuze != '0');
    }
}