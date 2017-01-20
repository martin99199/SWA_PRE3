using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost fragebogenHandlerHost = new ServiceHost(typeof(FragebogenHandler));
            try
            {
                fragebogenHandlerHost.Open();
                Console.ReadLine();
                fragebogenHandlerHost.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Ein Fehler ist aufgetreten: " + e.Message);
                Console.WriteLine("Server wird geschlossen!");
            }
        }
    }
}
