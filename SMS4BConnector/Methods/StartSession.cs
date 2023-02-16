using System;
using System.Collections.Generic;
using System.Text;
using SMS4BSoap;

namespace SMS4BConnector.Methods
{
    public class StartSession
    {
        private WSSMSoap client;
        private string login;
        private string password;
        private short gmt;
        public StartSession(WSSMSoap client, string login, string password, short gmt)
        {
            this.client = client;
            this.login = login;
            this.password = password;
            this.gmt = gmt;
        }

        public long createSession()
        {
            var temp = client.StartSessionAsync(login, password, gmt);
            var result = temp.Result;
            return result;
        }

        public string getLogin()
        {
            return login;
        }
        public string getPassword()
        {
            return password;
        }
        public short getGmt()
        {
            return gmt;
        }

        public void setLogin(string login)
        {
            this.login = login;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
        public void setGmt(short gmt)
        {
            this.gmt = gmt;
        }


    }

}
