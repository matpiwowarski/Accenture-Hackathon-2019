﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Memenger;

namespace Server
{
    class Message
    {
        public string text;
        public string sender;
        public string reciever;
        public bool isRead;
        // byte[] meme;
        // DateTime sentTime;
        // DateTime readTime;
        // bool isRead;

        public Message(string _text, string _sender, string _reciever)
        {
            this.text = _text;
            this.sender = _sender;
            this.reciever = _reciever;
            this.isRead = false;
        }

    }


    class Client
    {
        public string name;
        public List<Message> AllMessages = new List<Message>();
        public int Unread = 0;

        public Client(string name)
        {
            this.name = name;
        }
    }

    static class AllClients
    {
        public static int loggedIn = 0;
        public static List<Client> listOfClients = new List<Client>();



        public static void LogIn(string name)
        {
            if (listOfClients.FindIndex(client => client.name == name) == -1)
            {
                listOfClients.Add(new Client(name));
                loggedIn++;

            }

        }

        public static string SendMessage(string text, string sender, string reciever)
        {
            int index = listOfClients.FindIndex(client => client.name == reciever);

            if (index == -1)
            {
                LogIn(reciever);
                //return "no user found";
            }

            index = listOfClients.FindIndex(client => client.name == reciever);

            listOfClients[index].Unread++;
            listOfClients[index].AllMessages.Add(new Message(text, sender, reciever));

            return text;

        }



        public static string GetMessageOnlyText(string name)
        {
            int index = listOfClients.FindIndex(client => client.name == name);
            //Memecryptor memecryptor = Memecryptor.Instance;
            try
            {
                if (listOfClients[index].Unread == 0) return "";
                else
                {
                    listOfClients[index].Unread--;
                    foreach (var elem in listOfClients[index].AllMessages)
                    {
                        if (!elem.isRead)
                        {
                            elem.isRead = true;
                            return elem.text;
                        }
                    }
                    // return listOfClients[index].AllMessages[listOfClients[index].AllMessages.Count() - 1].text;
                    //return listOfClients[index].AllMessages[- 1].text;

                }
                return "";
            }
            catch
            {

                return "";

            }
        }
    }



    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie, usłudze i pliku konfiguracji.
    // UWAGA: aby uruchomić klienta testowego WCF w celu przetestowania tej usługi, wybierz plik Service1.svc lub Service1.svc.cs w eksploratorze rozwiązań i rozpocznij debugowanie.
    public class Service1 : IService1
    {


        public void Login(string name)
        {
            AllClients.LogIn(name);
        }
        public int CheckLoggedPeople()
        {
            return AllClients.loggedIn;
        }

        public string SendMessage(string text, string sender, string reciever)
        {
            return AllClients.SendMessage(text, sender, reciever);
        }

        public string GetMessage(string name)
        {
            //return AllClients.GetMessage(name);
            return AllClients.GetMessageOnlyText(name);
        }
    }
}
