using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Server
{
    static class PrzechowywaneDane
    {
        public static int iloscZalogOsob = 0;
        public static List<string> zalogowaneOsoby = new List<string>();

        public static void Login(string name)
        {
            iloscZalogOsob++;
            zalogowaneOsoby.Add(name);
        }

        static public string CheckLoggedPeople()
        {
            string zwracanie;
            zwracanie="ilosc osob: " + iloscZalogOsob;
            foreach (var osoby in zalogowaneOsoby)
            {
                zwracanie+=osoby;
            }
            return zwracanie;
        }
    }


    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie, usłudze i pliku konfiguracji.
    // UWAGA: aby uruchomić klienta testowego WCF w celu przetestowania tej usługi, wybierz plik Service1.svc lub Service1.svc.cs w eksploratorze rozwiązań i rozpocznij debugowanie.
    public class Service1 : IService1
    {
        public void Login(string name)
        {
            PrzechowywaneDane.Login(name);
        }
        public string CheckLoggedPeople()
        {
            return PrzechowywaneDane.CheckLoggedPeople();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string XD(int value)
        {

            return (value * 2).ToString();
        }


        public byte[] GetByte(byte[] data)
        {
            return data;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
