using SMS4BSoap;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS4BConnector.Methods
{
    public class ParamSMS
    {
        private WSSMSoap client;
        private long sessionId;

        public ParamSMS(WSSMSoap client, long sessionId)
        {
            this.client = client;
            this.sessionId = sessionId;
        }
        public string pingSession()
        {
            var temp = client.ParamSMSAsync(sessionId);
            var result = "Addresses: " + temp.Result.Addresses + "\n" + "AddrMask: " + temp.Result.AddrMask + "\n" 
                + "Duration: " + temp.Result.Duration + "\n" + "Limit: " + temp.Result.Limit + "\n" + "Rest: " + temp.Result.Rest + "\n" + "UTC: " + temp.Result.UTC;
            return result;
        }

        public long getSessionId()
        {
            return sessionId;
        }

        public void setSessionId(long sessionId)
        {
            this.sessionId = sessionId;
        }

    }

}
