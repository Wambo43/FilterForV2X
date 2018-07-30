using System;

using ProjektMArbeit.Messages.BasicContainer;


namespace ProjektMArbeit.Messages.CAM
{
    public class CAM : IMessage, IEquatable<CAM>
    {
        public int gernerationDeltaTime
        {
            get;
        }

        public CAMParameters CAMParameters
        {
            get;
        }

        public Header Header
        {
            get;
        }

        public CAM(Header _Header,
            int _gernerationDeltaTime,
            CAMParameters _CAMParameters)
        {
            this.Header = _Header;
            this.gernerationDeltaTime = _gernerationDeltaTime;
            this.CAMParameters = _CAMParameters;
        }
		
        public bool Equals(CAM _other)
        {
            if (gernerationDeltaTime <= _other.gernerationDeltaTime)
                return true;
            return false;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class CAMParameters
    {
        public string name;
        BasicContainer BasicContainer = null;
        HighFrequencyContainer HighFrequencyContainer = null;
        LowFrequencyContainer LowFrequencyContainer = null;

        public CAMParameters(string _name)
        {
            this.name = _name;
        }

    }

    public class BasicContainer
    {
        uint stationType;

        class ReferencePosition
        {
            uint latiude { get; }
            uint longitude { get; }

            public ReferencePosition(uint _latiude, uint _longitude)
            {
                this.latiude = _latiude;
                this.longitude = _longitude;
            }
        }

        public BasicContainer(uint _stationType, uint _latiude, uint _longitude)
        {
            this.stationType = _stationType;
            ReferencePosition refPosi = new ReferencePosition(_longitude, _longitude);

        }
    }
    class HighFrequencyContainer
    {
    }

    class LowFrequencyContainer
    {
    }
}

