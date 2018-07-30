using System.Collections.Generic;

using ProjektMArbeit.Messages.BasicContainer;
using ProjektMArbeit.Filter.MyStack;


namespace ProjektMArbeit.Filter
{
    class RoadSideStation
    {
        private uint traffic;
        private MessagesSort MS;

        public RoadSideStation(uint _traffic)
        {
            this.traffic = _traffic;
            MS = new MessagesSort();
        }

        public void setTraffic(uint _traffic)
        {
            this.traffic = _traffic;
        }

        public List<IMessage> getSendToList(List<IMessage> _MessageList)
        {
            MS.sortMessages(_MessageList);
            return MS.getQueue(traffic);
        }

    }
}
