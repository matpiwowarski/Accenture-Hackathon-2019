using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Server
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void Login(string name);

        [OperationContract]
        int CheckLoggedPeople();

        [OperationContract]
        void SendMessage(string text, string sender, string reciever);

        [OperationContract]
        string GetMessage(string name);


    }


    // Użyj kontraktu danych, jak pokazano w poniższym przykładzie, aby dodać typy złożone do operacji usługi.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
