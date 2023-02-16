using System;
using System.Collections.Generic;
using System.Text;
using SMS4BSoap;

namespace SMS4BConnector.Methods
{
    public class SoapClient
    {
        private WSSMSoapClient.EndpointConfiguration endConf;
        public SoapClient(WSSMSoapClient.EndpointConfiguration endConf)
        {
            this.endConf = endConf;
        }       
        public WSSMSoapClient createClient()
        {
            var client = new WSSMSoapClient(endConf);
            return client;
        }
        public WSSMSoapClient.EndpointConfiguration getConf()
        {
            return endConf;
        }
        public void checkStatus(WSSMSoapClient client)
        {
            Console.WriteLine("Client Status: " + client.State.ToString() + "\n");
        }

    }

}
