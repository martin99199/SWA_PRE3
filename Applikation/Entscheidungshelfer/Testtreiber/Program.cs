using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntscheidungshelferBibliothek; //Eigene Bibliothek mit den passenden Implementierungen

namespace Testtreiber
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Testfragebogen
            Fragebogen fragen = new Fragebogen();
            fragen.fuegeFrageHinzu("Ist etwas wahr?", "Ja", "Nein");
            Console.WriteLine(fragen.vorschau());
            bool abbrechen = fragen.stelleFrage();
            if (!abbrechen)
            {
                Console.WriteLine("Antwort war Antowrt1 oder Antwort2!");
            }
            else
            {
                Console.WriteLine("Benutzer wollte abbrechen!");
            }

            //2. Testfragebogen --> Befragung durchführen
            //Testen der Eigenschaft Fortschrit und des Abbruchs
            Fragebogen fragebogen2 = new Fragebogen();
            fragebogen2.fuegeFrageHinzu("f1", "a1", "a2");
            fragebogen2.fuegeFrageHinzu("f2", "a1", "a2");
            fragebogen2.fuegeFrageHinzu("f3", "a1", "a2");
            fragebogen2.fuegeFrageHinzu("f4", "a1", "a2");
            fragebogen2.fuegeFrageHinzu("f5", "a1", "a2");
            bool abbruch=false;
            Console.Write(fragebogen2.ToString());

            while(!fragebogen2.FragebogenFertig && !abbruch)
            {
                abbruch = fragebogen2.stelleFrage();
                if(fragebogen2.FragebogenFertig)
                {
                    Console.WriteLine("Ende des Fragebogens: Ergebnis: " + fragebogen2.FinalesErgebnis);
                }
                if(abbruch)
                {
                    Console.WriteLine("Benutzer hat Befragung abgebrochen!");
                }
            }
        }
    }
}
