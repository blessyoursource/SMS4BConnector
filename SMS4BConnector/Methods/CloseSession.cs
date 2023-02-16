using System;
using System.Collections.Generic;
using System.Text;
using SMS4BSoap;

namespace SMS4BConnector.Methods
{
    public class CloseSession
    {
        private WSSMSoap client;
        private long sessionId;

        public CloseSession(WSSMSoap client, long sessionId)
        {
            this.client = client;
            this.sessionId = sessionId;
        }
        public long closeSession()
        {
            var temp = client.CloseSessionAsync(sessionId);
            var result = temp.Result;
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
