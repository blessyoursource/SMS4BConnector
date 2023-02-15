using SMS4BSoap;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS4BConnector.Methods
{
    public class StartSession
    {
        private string login;
        private string password;
        private short gmt;
        public StartSession(string login, string password, short gmt)
        {
            this.login = login;
            this.password = password;
            this.gmt = gmt;
        }   
        public string getResponse(WSSMSoapClient client)
        {
            
            var response = client.StartSessionAsync(login, password, gmt);
            return response.ToString();
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
