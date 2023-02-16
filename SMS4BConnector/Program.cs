using System;
using SMS4BSoap;
using SMS4BConnector;
using System.Threading.Tasks;
using SMS4BConnector.Methods;

namespace SMS4BConnector
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Client Creation
            SoapClient soapClient = new SoapClient(WSSMSoapClient.EndpointConfiguration.WSSMSoap12);
            var client = soapClient.createClient();

            Console.WriteLine("Current EndpointConfiguration: " + soapClient.getConf());
            soapClient.checkStatus(client);

            startSession(client);
            paramSMS(client);
            closeSession(client);
            paramSMS(client);
            //sendSMS(client);
            //sendGroupSMS(client);

            // Client Destroy
            /*Console.WriteLine("\nClosing client");
            client.Abort();
            soapClient.checkStatus(client);*/

            var client2 = soapClient.createClient();
            Console.WriteLine("Current EndpointConfiguration: " + soapClient.getConf());
            soapClient.checkStatus(client2);
            startSession(client2);
            paramSMS(client2);
            closeSession(client2);
            paramSMS(client2);

            Console.WriteLine("\nClosing client");
            client.Abort();
            client2.Abort();
            soapClient.checkStatus(client);
            soapClient.checkStatus(client2);
        }

        public static void startSession(WSSMSoap client)
        {
            codeHandler codeHandler = new codeHandler();
            // Client Start Session
            Console.WriteLine("\nStarting Session, Enter Login, Password, Gmt: ");
            StartSession startSession = new StartSession(client, Console.ReadLine(), Console.ReadLine(), short.Parse(Console.ReadLine()));
            writeProcessing();
            var result = startSession.createSession();
            Console.WriteLine(result);
            codeHandler.checkCode(result);
        }
        public static void closeSession(WSSMSoap client)
        {
            codeHandler codeHandler = new codeHandler();
            // Client Start Session
            Console.WriteLine("\nClosing Session, Enter Session Id: ");
            CloseSession closeSession = new CloseSession(client, long.Parse(Console.ReadLine()));
            writeProcessing();
            var result = closeSession.closeSession();
            Console.WriteLine(result);
            codeHandler.checkCode(result);
        }
        public static void paramSMS(WSSMSoap client)
        {
            codeHandler codeHandler = new codeHandler();
            // Client Ping Session (ParamSMS)
            Console.WriteLine("\nPing Session, Enter Session Id:");
            ParamSMS paramSMS = new ParamSMS(client, long.Parse(Console.ReadLine()));
            writeProcessing();
            string pingResult = paramSMS.pingSession();
            Console.WriteLine(pingResult);
        }
        public static void sendSMS(WSSMSoap client)
        {
            codeHandler codeHandler = new codeHandler();
            // Client Send Unique SMS
            Console.WriteLine("\nSend SMS, Enter login, password, source, phone, text:");
            SendSMS sendSMS = new SendSMS(client, Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), long.Parse(Console.ReadLine()), Console.ReadLine());
            writeProcessing();
            string smsResult = sendSMS.sendSMS();
            Console.WriteLine(smsResult);
        }

        public static async void sendGroupSMS(WSSMSoap client)
        {
            GroupSMSList[] groupSMSList = new GroupSMSList();
            GroupSMSResult groupSMSResult = new GroupSMSResult();
            GroupSMSResponse groupSMSResponse = new GroupSMSResponse();

            GroupSMSRequest groupSMSRequest = new GroupSMSRequest(long.Parse(Console.ReadLine()), long.Parse(Console.ReadLine()), 
                Console.ReadLine(), 0, Console.ReadLine(), "", "", "", groupSMSList);

            var response = groupSMSResponse.GroupSMSResult.ToString();
            var result = groupSMSResult.Result + groupSMSResult.Group + groupSMSResult.List.ToString();
            Console.WriteLine(result + response);
        }

        public static void writeProcessing()
        {
            Console.WriteLine("Processing...");
        }

    }
}
