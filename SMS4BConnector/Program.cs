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

            // Client Destroy
            Console.WriteLine("\nClosing client");
            client.Abort();
            soapClient.checkStatus(client);
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

        public static void writeProcessing()
        {
            Console.WriteLine("Processing...");
        }

        public static async void test()
        {
            var client = new WSSMSoapClient(WSSMSoapClient.EndpointConfiguration.WSSMSoap12);

            Console.WriteLine("Login: ");
            string login = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Gmt: ");
            short gmt = short.Parse(Console.ReadLine());

            var result = await client.StartSessionAsync(login, password, gmt);
            Console.WriteLine("Response: " + result);

            Console.WriteLine("Id: ");
            long id = long.Parse(Console.ReadLine());
            var result2 = await client.ParamSMSAsync(id);

            Console.WriteLine("Result: " + result2.Result + " Rest: " + result2.Rest + " AddrMask: " + result2.AddrMask + " Duration: " + result2.Duration + " Limit: " + result2.Limit);

            Console.WriteLine("Id: ");
            long id2 = long.Parse(Console.ReadLine());
            var result3 = await client.CloseSessionAsync(id2);
            Console.WriteLine("Response: " + result3);

            Console.WriteLine("Id :");
            long id3 = long.Parse(Console.ReadLine());
            Console.WriteLine("Ammount");
            int i = int.Parse(Console.ReadLine());
            string[] guids = new string[10];
            for (int j = 0; j < i; j++)
            {
                Console.WriteLine("Guid: ");
                guids[j] = Console.ReadLine();
            }
            var result4 = await client.CheckSMSAsync(id3, guids);
            Console.WriteLine("Result: " + result4.Result + " List: " + result4.List);

            var ping = await client.GetInfoAsync();
            Console.WriteLine("Ping: " + ping);
        }
    }
}
