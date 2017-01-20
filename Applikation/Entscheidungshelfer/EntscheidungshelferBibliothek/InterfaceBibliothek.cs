// InterfaceBibliothek.cs
// Stellt die Services, die vom Server zur Verfügung
// gestellt werden dar.
// Author: Martin Pachler

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace EntscheidungshelferBibliothek
{
    [ServiceContract]
    public interface RemoteFragebogen
    {
        [OperationContract]
        bool sendeFragebogen(Fragebogen bogen);
        //True, wenn der Server den Fragebogen empfangen hat

        [OperationContract]
        string pruefeVerfuegbareFrageboegen();
        //Gibt eine Liste der verfügbaren Frageboegen auf dem Server
        //zurück an den User-Client

        [OperationContract]
        Fragebogen importiereFragebogen(int id);
        //Importiert den Fragebogen vom Server
        //auf den User-Client
    }
}
