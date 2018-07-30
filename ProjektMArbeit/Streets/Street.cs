using System;
using System.Collections.Generic;

using ProjektMArbeit.Generator;
using ProjektMArbeit.Messages.BasicContainer;


namespace ProjektMArbeit.Streets
{
    class Street
    {
        public uint trafficDensity;
        private List<IMessage> MessageList = new List<IMessage>();
        private MessageGenerator MG;

        public Street(uint _trafficDensity)
        {
            this.trafficDensity = _trafficDensity;
            this.MG = new MessageGenerator();
        }

        public void createTraffic(int _Hz)
        {
            for (int i = 0; i < _Hz; ++i)
            {
                for (uint j = 0; j < trafficDensity; ++j)
                {
                    car(j);
                }
            }
        }

        public List<IMessage> getList()
        {
            return MessageList;
        }

        public int GetListCount()
        {
            return MessageList.Count;
        }

        private void car(uint _carId)
        {
            createCAMessage(_carId);
            createDENMessage(_carId);

        }

        private void createCAMessage(uint _carId)
        {
            var tmp = MG.generatCAM(_carId);
            AddMessage(tmp);
        }

        private void createDENMessage(uint _carId)
        {
			if(new Random().Next(0, 9) == 5)
			{
				var tmp = MG.generatDENM(_carId);
				AddMessage(tmp);
			}
        }

        private bool AddMessage(IMessage _IMessage)
        {
            if (_IMessage is IMessage)
            {
                MessageList.Add(_IMessage);
                return true;
            }
            return false;
        }

        public void clearList()
        {
            MessageList.Clear();
        }
    }
}
