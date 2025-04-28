using System;

namespace SpaceAdventure
{
    class Program
    {
        static Nomad SchiffA = new Nomad(); //Schiff des Spielers
        static object SchiffB = new Aurora(); // Gegnerschiffe. Aurora auf Standard gesetzt.

        static void Main(string[] args) //Spielablauf
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
            Console.WriteLine("Reise nach Lorville, Planet Hurston");
            Console.WriteLine("Im Arbeiterviertel von Lorville erfährst du, dass ein Alienschiff auf Microtech abgestürzt ist.");
            Console.WriteLine("Du bezahlst Geld und bekommst die Koordinaten.");
            Console.WriteLine("Reise zum Planeten Microtech...");

            Console.WriteLine("Ankunft an der Absturzstelle auf Microtech.");
            Console.WriteLine("Jemand Anderes hatte offenbar die gleiche Idee. Eine Aurora greift dich an!");
            SchiffB = new Aurora();
            Kampfhandlung();

            Console.WriteLine("Du findest ein abgestürztes Vanduul-Schiff mit intaktem Computerkern.");
            Console.WriteLine("Du musst damit ins Pyro-System flüchten!");
            Console.WriteLine("Willst du ins Pyro-System flüchten? (ja/nein)");
            antwort = Console.ReadLine();
            if (antwort != "ja") //Interaktion-Entscheidung
            {
                Console.WriteLine("Die Sicherheitskräfte von Microtech nehmen dich fest -> Game Over.");
                return;
            }

            Console.WriteLine("Während des Fluges kannst du dein Schiff reparieren. Reparieren? (ja/nein)");
            antwort = Console.ReadLine();
            if (antwort == "ja") //Interaktion-Entscheidung
            {
                Reparieren();
            }

            Console.WriteLine("Ankunft am Pyro-Gateway. Ein Kopfgeldjäger hat dich aufgespürt!");
            Console.WriteLine("Kämpfen? (ja/nein)");
            antwort = Console.ReadLine();
            if (antwort != "ja") //Interaktion-Entscheidung
            {
                Console.WriteLine("Du wirst gefangen genommen -> Game Over.");
                return;
            }

            SchiffB = new Avenger(); //Definiere neuen Gegner
            Kampfhandlung();    // rufe Kampfhandlung-Methode mit neuem Gegner auf

            Console.WriteLine("Willst du dein Schiff reparieren? (ja/nein)");
            antwort = Console.ReadLine();
            if (antwort == "ja") //Interaktion-Entscheidung
            {
                Reparieren();
            }
            else
            {
                Console.WriteLine("Dein Schiff ist nicht flugfähig -> Game Over.");
                return;
            }

            Console.WriteLine("Du bist endlich in Pyro angekommen und reist zur Checkmate Station.");
            Console.WriteLine("Ankunft: Du wirst von einem Piratenschiff (Mustang) angegriffen!");
            SchiffB = new Mustang(); // rufe neuen Gegner auf
            Kampfhandlung(); // Kampfhandlung mit neuem Gegner

            Console.WriteLine("Willst du dein Schiff reparieren? (ja/nein)");
            antwort = Console.ReadLine();
            if (antwort == "ja") //Interaktion-Entscheidung
            {
                Reparieren();
            }

            Console.WriteLine("Auf Checkmate Station erfährst du, dass jemand auf dem Planeten Terminus den Kern auslesen kann.");
            Console.WriteLine("Willst du dein Schiff reparieren und Vorräte besorgen? (ja/nein)");
            antwort = Console.ReadLine();
            if (antwort != "ja") // Interaktion-Entscheidung
            {
                Console.WriteLine("Dein Schiff ist nicht flugfähig -> Game Over.");
                return;
            }
            Reparieren(); 

            Console.WriteLine("Du findest auf Terminus einen Computer-Freak!");
            Console.WriteLine("Er sagt dir, der Kern enthält Spionagedaten: die Vanduul planen einen Angriff auf Microtech!");
            Console.WriteLine("Du könntest den Computerkern auf Ruin Station an den Banu Wikelo verkaufen.");

            Console.WriteLine("Auf dem Weg wirst du von einem Prospektor-Schiff gerufen. Annehmen? (ja/nein)");
            antwort = Console.ReadLine();
            if (antwort == "nein") //Interaktion-Entscheidung
            {
                Console.WriteLine("Du wirst angegriffen!");
                SchiffB = new Prospektor();
                Kampfhandlung();
            }
            else // Interaktion-Entscheidung: Story-Twist
            {
                Console.WriteLine("Du wirst vom Computerfreak bedroht! Er will den Computerkern. \nEr will ihn selbst verkaufen. Gibst du den Kern her? (ja/nein)");
                antwort = Console.ReadLine();
                if (antwort == "ja")
                {
                    Console.WriteLine("Du stehst mit leeren Händen da -> Game Over.");
                    return;
                }
                else
                {
                    Console.WriteLine("Du gibst dem Computerfreak Geld und fliegst weiter.");
                }
            }

            Console.WriteLine("Reise nach Ruin Station...");
            Console.WriteLine("Alarm! Du wirst von einer Arrow angegriffen!");
            SchiffB = new Arrow();
            Kampfhandlung();

            Console.WriteLine("Du hast überlebt und verkaufst den Kern an Wikelo. Glückwunsch!");
            Console.WriteLine("Spiel beendet! :)");
        }

        static void Kampfhandlung()  //Funktion Kampf
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

        static void Reparieren() // Funktion Reparieren
        {
            SchiffA.Rumpf = 100;
            Console.WriteLine("Dein Schiff wurde repariert!");
        }
    }

    // alle Schiffs-Objekte
    public class Aurora // Artefaktjägerschiff auf Microtech
    {
        public int Rumpf { get; set; } = 50;
        public int Waffen { get; set; } = 10;
    
    }

    public class Mustang // Piratenschiff bei Checkmate Statiion
    {
        public int Rumpf { get; set; } = 40;
        public int Waffen { get; set; } = 15;
     
    }

    public class Avenger //Kopfgeldjäger-Schiff am Pyro-Jumppoint
    {
        public int Rumpf { get; set; } = 60;
        public int Waffen { get; set; } = 25;
     
    }

    public class Arrow //Piratenschiff bei Ruin Station
    {
        public int Rumpf { get; set; } = 45;
        public int Waffen { get; set; } = 20;
      
    }

    public class Prospektor // Schiff des Computer-Freaks
    {
        public int Rumpf { get; set; } = 60;
        public int Waffen { get; set; } = 10;
       
    }

    public class Nomad // Spieler-Schiff
    {
        public int Rumpf { get; set; } = 100;
        public int Waffen { get; set; } = 25;
      
    }
}
