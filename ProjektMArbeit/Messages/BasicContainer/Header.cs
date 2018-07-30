namespace ProjektMArbeit.Messages.BasicContainer
{
    public class Header
    {
        uint protocolVersion
        {
            get;
        }

        public uint messageID
        {
            get;
        }

        public uint stationID
        {
            get;
        }

        public Header(uint _messageID, uint _stationID, uint _protocolVersion)
        {
            this.messageID = _messageID;
            this.stationID = _stationID;
            this.protocolVersion = _protocolVersion;
        }

        public Header(uint _messageID, uint _stationID)
        {
            this.messageID = _messageID;
            this.stationID = _stationID;
            this.protocolVersion = 1;
        }
    }
}
