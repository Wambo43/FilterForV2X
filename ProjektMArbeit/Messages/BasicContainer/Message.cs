using System;

namespace ProjektMArbeit.Messages.BasicContainer
{
    interface IMessage : ICloneable
    {
        Header Header
        {
            get;
        }
    }
}
