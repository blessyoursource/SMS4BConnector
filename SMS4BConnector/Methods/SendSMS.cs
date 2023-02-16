using SMS4BSoap;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS4BConnector.Methods
{
    public class SendSMS
    {
        private WSSMSoap client;
        private string login;
        private string password;
        private string source;
        private long phone;
        private string text;
        public SendSMS(WSSMSoap client, string login, string password, string source, long phone, string text)
        {
            this.client = client;
            this.login = login;
            this.password = password;
            this.source = source;
            this.phone = phone;
            this.text = text;
        }
        public string sendSMS()
        {
            var temp = client.SendSMSAsync(login, password, source, phone, text);
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
        public string getSource()
        {
            return source;
        }
        public long getPhone()
        {
            return phone;
        }
        public string getText()
        {
            return text;
        }

        public void setLogin(string login)
        {
            this.login = login;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
        public void setSource(string source)
        {
            this.source = source;
        }
        public void setPhone(long phone)
        {
            this.phone = phone;
        }
        public void setText(string text)
        {
            this.text = text;
        }

    }

}
