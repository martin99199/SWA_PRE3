using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EntscheidungshelferBibliothek;
using System.Threading;

namespace Server
{
    //Singeltonbetrieb --> alle Clients haben
    //Zugang zu den gleichen Fragen
    [ServiceBehavior(InstanceContextMode= InstanceContextMode.Single)]
    class FragebogenHandler : RemoteFragebogen
    {
        #region Membervariablen
        private List<Fragebogen> frageboegen_; //Liste der im Chat verfuegbaren Frageboegen
        private object verriegelungsObjekt_; //handelt den Zugriff auf die Liste
        #endregion

        #region Konstruktoren
        public FragebogenHandler()
        {
            this.frageboegen_ = new List<Fragebogen>();
            this.verriegelungsObjekt_ = new object();
            Console.WriteLine("Server gestartet!");
        }
        #endregion

        #region Interface
        /// <summary>
        /// Implementierung der Interfacemethode
        /// mit der der Admin-Client einen Fragebogen
        /// auf den Server stellen kann.
        /// Der Name ist vom Admin-Client aus
        /// zu sehen.
        /// </summary>
        /// <param name="bogen">Fragebogen, den der Admin-Client senden möchte</param>
        /// <returns>true, wenn der Fragebogen erfolgreich in die Liste eingetragen wurde</returns>
        public bool sendeFragebogen(Fragebogen bogen)
        {
            bool fragebogenEmpfangen = false;
            if (Monitor.TryEnter(this.verriegelungsObjekt_, 100))
            {
                if (bogen != null)
                {
                    this.frageboegen_.Add(bogen);
                    fragebogenEmpfangen = true;
                }
                Monitor.Exit(this.verriegelungsObjekt_);
            }
            return fragebogenEmpfangen;
        }


        /// <summary>
        /// Implementierung des Interfaces mit dem der User-Client
        /// die verfuegbaren Fragebögen abfragt.
        /// </summary>
        /// <returns>string, der eine Liste von Vorschauen der 
        /// Frageboegen (inkl. id) enthält (getrennt durch \r\n)</returns>
        public string pruefeVerfuegbareFrageboegen()
        {
            string verfuegbareBoegen = "";
            if(Monitor.TryEnter(this.verriegelungsObjekt_, 100))
            {
                if(this.frageboegen_.Count >0)
                {
                    int ii = 0;
                    foreach(Fragebogen frageBogen in this.frageboegen_)
                    {
                        verfuegbareBoegen += string.Format("{0}: {1}", ii, frageBogen.vorschau());
                        ++ii;
                    }
                }
                Monitor.Exit(this.verriegelungsObjekt_);
            }
            return verfuegbareBoegen;
        }

        /// <summary>
        /// Implementierung des Interfaces mit dem
        /// der User-Client einen Fragebogen importieren 
        /// kann. (100ms Timeout!)
        /// </summary>
        /// <param name="id">ID bzw. Listenstelle, des 
        ///                  Fragebogens den der User gerne möchte</param>
        /// <returns>Fragebogen, wenn keine Fehler auftreten. Sonst null!</returns>
        public Fragebogen importiereFragebogen (int id)
        {
            Fragebogen bogen;
            if(Monitor.TryEnter(this.verriegelungsObjekt_,100))
            {
                try
                {
                    bogen = this.frageboegen_[id];
                }
                catch
                {
                    bogen = null;
                }
                finally
                {
                    Monitor.Exit(this.verriegelungsObjekt_);
                }
            }
            else
            {
                bogen = null;
            }
            return bogen;
        }
        #endregion
    }
}
