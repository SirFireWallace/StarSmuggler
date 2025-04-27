using System;

namespace SpaceAdventure
{
    class Program
    {
        static Nomad SchiffA = new Nomad();
        static object SchiffB = new Aurora();

        static void Main(string[] args)
        {
            Console.WriteLine("Du hörst auf Grimhex wie jemand über ein Artefakt spricht.");
            Console.WriteLine("Möchtest du diesem Hinweis folgen? (ja/nein)");
            string antwort = Console.ReadLine();
            if (antwort != "ja")
            {
                Console.WriteLine("Du betrinkst dich -> Game Over.");
                return;
            }

            Console.WriteLine("Du erfährst, dass auf Lorville jemand darüber Bescheid weiß.");
            Console.WriteLine("Reise nach Lorville...");
            Console.WriteLine("Im Arbeiterviertel von Lorville erfährst du, dass ein Alienschiff auf Microtech abgestürzt ist.");
            Console.WriteLine("Du bezahlst Geld und bekommst die Koordinaten.");
            Console.WriteLine("Reise nach Microtech...");

            Console.WriteLine("Ankunft an der Absturzstelle auf Microtech.");
            Console.WriteLine("Eine Aurora greift dich an!");
            SchiffB = new Aurora();
            Kampfhandlung();

            Console.WriteLine("Du findest ein zerstörtes Vanduul-Schiff mit intaktem Computerkern.");
            Console.WriteLine("Du musst damit ins Pyro-System flüchten!");
            Console.WriteLine("Willst du ins Pyro-System flüchten? (ja/nein)");
            antwort = Console.ReadLine();
            if (antwort != "ja")
            {
                Console.WriteLine("Die Sicherheitskräfte nehmen dich fest -> Game Over.");
                return;
            }

            Console.WriteLine("Während des Fluges kannst du dein Schiff reparieren. Reparieren? (ja/nein)");
            antwort = Console.ReadLine();
            if (antwort == "ja")
            {
                Reparieren();
            }

            Console.WriteLine("Ankunft am Pyro-Gateway, ein Kopfgeldjäger hat dich aufgespürt!");
            Console.WriteLine("Kämpfen? (ja/nein)");
            antwort = Console.ReadLine();
            if (antwort != "ja")
            {
                Console.WriteLine("Du wirst gefangen genommen -> Game Over.");
                return;
            }

            SchiffB = new Avenger();
            Kampfhandlung();

            Console.WriteLine("Willst du dein Schiff reparieren? (ja/nein)");
            antwort = Console.ReadLine();
            if (antwort == "ja")
            {
                Reparieren();
            }
            else
            {
                Console.WriteLine("Dein Schiff ist nicht flugfähig -> Game Over.");
                return;
            }

            Console.WriteLine("Du bist endlich in Pyro angekommen und reist zur Checkmate Station.");
            Console.WriteLine("Ankunft: Du wirst von einem Mustang angegriffen!");
            SchiffB = new Mustang();
            Kampfhandlung();

            Console.WriteLine("Willst du dein Schiff reparieren? (ja/nein)");
            antwort = Console.ReadLine();
            if (antwort == "ja")
            {
                Reparieren();
            }

            Console.WriteLine("Auf Checkmate Station erfährst du, dass jemand auf Terminus den Kern auslesen kann.");
            Console.WriteLine("Willst du dein Schiff reparieren und Vorräte besorgen? (ja/nein)");
            antwort = Console.ReadLine();
            if (antwort != "ja")
            {
                Console.WriteLine("Dein Schiff ist nicht flugfähig -> Game Over.");
                return;
            }
            Reparieren();

            Console.WriteLine("Du findest auf Terminus einen Computer-Freak!");
            Console.WriteLine("Er sagt dir, der Kern enthält Spionagedaten: die Vanduul planen einen Angriff auf Microtech!");
            Console.WriteLine("Du könntest ihn auf Ruin Station verkaufen.");

            Console.WriteLine("Auf dem Weg wirst du von einem Prospektor gerufen. Annehmen? (ja/nein)");
            antwort = Console.ReadLine();
            if (antwort == "nein")
            {
                Console.WriteLine("Du wirst angegriffen!");
                SchiffB = new Prospektor();
                Kampfhandlung();
            }
            else
            {
                Console.WriteLine("Du wirst bedroht! Gibst du den Kern her? (ja/nein)");
                antwort = Console.ReadLine();
                if (antwort == "ja")
                {
                    Console.WriteLine("Du stehst mit leeren Händen da -> Game Over.");
                    return;
                }
                else
                {
                    Console.WriteLine("Du gibst dem Prospektor Geld und fliegst weiter.");
                }
            }

            Console.WriteLine("Reise nach Ruin Station...");
            Console.WriteLine("Alarm! Du wirst von einer Arrow angegriffen!");
            SchiffB = new Arrow();
            Kampfhandlung();

            Console.WriteLine("Du hast überlebt und verkaufst den Kern an Wikelo. Glückwunsch!");
            Console.WriteLine("Spiel beendet! :)");
        }

        static void Kampfhandlung()
        {
            dynamic gegner = SchiffB;

            bool schiffADran = false;

            while (SchiffA.Rumpf > 0 && gegner.Rumpf > 0)
            {
                if (schiffADran)
                {
                    gegner.Rumpf -= SchiffA.Waffen;
                    Console.WriteLine($"Du schießt! Gegnerischer Rumpf: {gegner.Rumpf}");
                }
                else
                {
                    SchiffA.Rumpf -= gegner.Waffen;
                    Console.WriteLine($"Gegner schießt! Dein Rumpf: {SchiffA.Rumpf}");
                }
                schiffADran = !schiffADran;
            }

            if (SchiffA.Rumpf <= 0)
            {
                Console.WriteLine("Dein Schiff wurde zerstört -> Game Over.");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Du hast den Gegner besiegt!");
            }
        }

        static void Reparieren()
        {
            SchiffA.Rumpf = 100;
            Console.WriteLine("Dein Schiff wurde repariert!");
        }
    }

    public class Aurora
    {
        public int Rumpf { get; set; } = 50;
        public int Waffen { get; set; } = 10;
    
    }

    public class Mustang
    {
        public int Rumpf { get; set; } = 40;
        public int Waffen { get; set; } = 15;
     
    }

    public class Avenger
    {
        public int Rumpf { get; set; } = 60;
        public int Waffen { get; set; } = 25;
     
    }

    public class Arrow
    {
        public int Rumpf { get; set; } = 45;
        public int Waffen { get; set; } = 20;
      
    }

    public class Prospektor
    {
        public int Rumpf { get; set; } = 60;
        public int Waffen { get; set; } = 10;
       
    }

    public class Nomad
    {
        public int Rumpf { get; set; } = 100;
        public int Waffen { get; set; } = 25;
      
    }
}
