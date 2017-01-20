// Fragebogen.cs
// Author: Martin Pachler
// Implementierung der Klassen
// Fragebogen und Frage

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //Datei IO
using System.Windows;
using System.Windows.Forms;

namespace EntscheidungshelferBibliothek
{
    public class Fragebogen
    {
        #region Membervariablen
        private string titel_; //Titel der Befragung z.B. Soll ich die Aktie kaufen? --> immer ein Ja-Nein- Titel
        private List<Frage> fragen_; //Liste der Fragen, die zu stellen sind
        private List<bool> antworten_; //Liste der Antworten auf die jeweiligen Fragen, wenn alle Fragen unbeantwortet sind ist die Liste leer
        private int aktuelleFrageNr_; //Stelle, an der die Befragung zur Zeit ist
        private bool fragebogenIstFertig_; //True, wenn die letzte Frage beantwortet wurde
        private bool finalesErgebnis_; //Nachdem die Letzte Antwort gegeben wurde wird das Ergebnis ermittelt --> Ja oder Nein --> Antwort auf "titel"
        #endregion

        #region Konstruktoren
        /// <summary>
        /// Defaultkonstruktor ohne Parameter.
        /// Initialisiert alle Werte auf Standard Parameter
        /// </summary>
        public Fragebogen()
        {
            this.fragen_ = new List<Frage>();
            this.antworten_ = new List<bool>();
            this.aktuelleFrageNr_ = 0;
            this.fragebogenIstFertig_ = false;
            this.finalesErgebnis_ = true;
        }

        /// <summary>
        /// Konstruktor, der einen Fragebogen aus einem gültigen
        /// Dateipfad erstellt
        /// </summary>
        /// <param name="dateiPfad">string, der einen Pfad zu einem Fragebogen-CSV-File enthält</param>
        public Fragebogen (string dateiPfad)
        {
            this.fragen_ = new List<Frage>();
            this.antworten_ = new List<bool>();
            this.aktuelleFrageNr_ = 0;
            this.fragebogenIstFertig_ = false;
            this.finalesErgebnis_ = true;
            StreamReader datei = new StreamReader(dateiPfad);
            string zeile;
            while (datei.Peek() > -1)
            {
                zeile = datei.ReadLine();
                fragen_.Add(Frage.parseFrage(zeile));
            }
        }
        #endregion

        #region Methoden
        /// <summary>
        /// Stellt dem Benutzer eine Frage über
        /// eine Messagebox und trägt die Antwort 
        /// in die Antwortenliste ein.
        /// Ist die Antwort die unerwünschte Antwort wird das
        /// ergebnis des Fragebogens auf false gesetzt. Das 
        /// Ergebnis kann sich danach nicht mehr ändern.
        /// </summary>
        /// <returns>True, wenn der Benutzer abbrechen will</returns>
        public bool stelleFrage()
        {
            bool abbruch = false;
            FragenSteller frmFragensteller = new FragenSteller(aktuelleFrageNr_,
                                                               fragen_[aktuelleFrageNr_].FrageText,
                                                               fragen_[aktuelleFrageNr_].Antwort1,
                                                               fragen_[aktuelleFrageNr_].Antwort2);
            DialogResult res = frmFragensteller.ShowDialog();
            if (res == DialogResult.Yes)
            {
                this.antworten_.Add(true);
                this.aktuelleFrageNr_++;
            }
            if(res == DialogResult.No)
            {
                this.antworten_.Add(false);
                this.aktuelleFrageNr_++;
                this.finalesErgebnis_ = false;
            }
            if(res ==DialogResult.Cancel)
            {
                abbruch = true;
            }
            if (this.antworten_.Count == this.fragen_.Count)
            {
                //Fragebogen ist fertig!
                this.fragebogenIstFertig_ = true;
            }
            return abbruch;
        }


        /// <summary>
        /// Manuelles Hinzufügen einer einzelnen Frage
        /// </summary>
        /// <param name="frage">string, der die Frage enthält</param>
        /// <param name="antwort1">string, der die gewünschte Antwort enthält</param>
        /// <param name="antwort2">string, der die unerwünschte Antwort enthält</param>
        public void fuegeFrageHinzu(string frage, string antwort1, string antwort2)
        {
            this.fragen_.Add(Frage.parseFrage(frage + ';' + antwort1 + ';' + antwort2));
        }

        /// <summary>
        /// Überschreibung der ToString-Methode:
        /// Stellt einen Fragebogen übersichtlich dar mit seinen 
        /// Entscheidungsmöglichkeiten-->
        /// Frage1 --------Antwort2--------
        ///   |                           |
        ///   | Antwort1                  |
        ///   |                           |
        /// Frage2 --------Antwort1--------
        ///   |                           |
        ///   | Antwort1                  |
        ///   |
        ///   ......
        ///   Wenn eine Frage über eine gewisse Zeichenanzahl
        ///   hinausgeht wird sie durch '....' abgekürzt
        ///   Wenn eine Frage über eine gewisse Zeichenanzahl
        ///   hinausgeht wird sie durch '....' abgekürzt
        /// </summary>
        /// <returns>String in obigem Format</returns>
        public override string ToString()
        {
            //Muss noch implementiert werden
            return base.ToString();
        }

        /// <summary>
        /// Vorschau des Fragebogens mit dem Titel
        /// und den Eckdaten
        /// </summary>
        /// <returns>String, der die Informationen enthält</returns>
        public string vorschau()
        {
            return this.titel_ + String.Format(" Anzahl der Fragen: {0}", this.fragen_.Count);
        }
        #endregion

        #region Eigenschaften
        public double Fortschritt
        {
            get { return (Convert.ToDouble(this.antworten_.Count) / this.fragen_.Count); }
        }
        public bool FragebogenFertig
        {
            get { return this.fragebogenIstFertig_; }
        }
        public bool FinalesErgebnis
        {
            get { return this.finalesErgebnis_; }
        }
        #endregion
    }

    /// <summary>
    /// Die Klasse Frage stellt ein Konstrukt zur Verfügung, dass
    /// die eigentliche Frage, sowie eine gewünschte Antwort und eine 
    /// ungewünschte Antwort enthält (Anwort1 = true, Antwort2 = false)
    /// </summary>
    public class Frage
    {
        #region Konstruktoren
        /// <summary>
        /// Konstruktor für eine Frage, der die Parameter als string
        /// unkontrolliert übernimmt --> es wird davon ausgegangen, dass
        /// der User sinnvolle Eingaben tätigt.
        /// Leere Eingaben werden nicht akzeptiert und führen zu einer 
        /// Exception.
        /// </summary>
        /// <param name="frageText">Text für die Frage</param>
        /// <param name="antwort1">Text für die gewünschte Antwort</param>
        /// <param name="antwort2">Text für die ungewünschte Antwort</param>
        public Frage(string frageText, string antwort1, string antwort2)
        {
            this.FrageText = frageText;
            this.Antwort1 = antwort1;
            this.Antwort2 = antwort2;
        }
        #endregion

        #region Membervariablen
        private string frageText_;
        private string textAntwort1_;
        private string textAntwort2_;
        #endregion

        #region Eigenschaften
        public string FrageText
        {
            get { return this.frageText_; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.frageText_ = value;
                }
                else
                {
                    throw new ArgumentException("Fragetext darf nicht null oder leer sein!");
                }                 
            }
        }

        public string Antwort1
        {
            get { return this.textAntwort1_; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.textAntwort1_ = value;
                }
                else
                {
                    throw new ArgumentException("Antowrt darf nicht null oder leer sein!");
                }
            }
        }

        public string Antwort2
        {
            get { return this.textAntwort2_; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.textAntwort2_ = value;
                }
                else
                {
                    throw new ArgumentException("Antwort darf nicht null oder leer sein!");
                }
            }
        }
        #endregion

        #region Statische Methoden
        /// <summary>
        /// Erstellt aus einem String in einem speziellen Format (CSV) ein Objekt
        /// vom Typ Frage (= Frage & Antwortmöglichkeiten
        /// </summary>
        /// <param name="frageSpeicherString">Eine Zeile aus einem CSV (';') File, dass die Frage und die Antworten, getrennt durch ';' enthält</param>
        /// <returns>Frage-Objekt, mit der Frage und den Antwortmöglichkeiten</returns>
        public static Frage parseFrage(string frageSpeicherString)
        {
            string[] felder;
            felder = frageSpeicherString.Split(';');
            return new Frage(felder[0], felder[1], felder[2]);
        }
        #endregion
    }
}
