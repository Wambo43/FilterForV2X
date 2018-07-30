using System;

using ProjektMArbeit.Messages.BasicContainer;

namespace ProjektMArbeit.Messages.DENM
{
    class DENM : IMessage
    {
        public Header Header
        {
            get;
        }

        public DENMParameters DENMParameters
        {
            get;
        }

        public DENM(Header _Header)
        {
            this.Header = _Header;
            this.DENMParameters = null;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class DENMParameters
    {
        Management Management   = null;
        Situation Situation     = null;
        Location Location       = null;
        Alacarte Alacarte       = null;
    }
}

