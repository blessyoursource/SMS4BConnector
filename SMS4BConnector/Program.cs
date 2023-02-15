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
            StartSession startSession = new StartSession("test","test",1);
            //Console.WriteLine(startSession.getResponse());
            Console.WriteLine(startSession.getLogin());
            test();
        }

        public static async void test()
        {
            var client = new WSSMSoapClient(WSSMSoapClient.EndpointConfiguration.WSSMSoap12);
            Console.WriteLine("Credentials: " + client.ClientCredentials.ClientCertificate.ToString());

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
