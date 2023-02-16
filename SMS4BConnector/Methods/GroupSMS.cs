using System;
using System.Collections.Generic;
using System.Text;
using SMS4BSoap;

namespace SMS4BConnector.Methods
{
    public class GroupSMS
    {
        private WSSMSoap client;
        private long sessionId;
        private long group;
        private string source;
        private int encoding;
        private string body;
        private string off;
        private string start;
        private string period;
        private GroupSMSList[] list;

        public GroupSMS(WSSMSoap client, long sessionId, long group, string source, int encoding, string body, string off, string start, string period, GroupSMSList[] list)
        {
            this.sessionId = sessionId;
            this.group = group;
            this.source = source;
            this.encoding = encoding;
            this.body = body;
            this.off = off;
            this.start = start;
            this.period = period;
            this.list = list;
        }

        public string sendGroupSMS(GroupSMSRequest request)
        {
            var temp = client.GroupSMSAsync(request);
            var result = temp.Result.ToString();
            return result;
        }

    }

}
