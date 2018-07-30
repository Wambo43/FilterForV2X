using System;
using System.Collections.Generic;

using ProjektMArbeit.Messages.BasicContainer;
using ProjektMArbeit.Messages.CAM;


namespace ProjektMArbeit.Filter.MyStack
{
    class MessagesSort : MyQueue<IMessage>
    {
        public uint traffic;
        private uint trafficPerCAM;
        private uint trafficPerDENM;
        private int deltaTime;

        public MessagesSort()
        {
            this.traffic = 0;
            this.trafficPerCAM = 7000;
            this.trafficPerDENM = 5000;
        }

        public void sortMessages(List<IMessage> _Messages)
        {
            setDeltaTime();
            foreach (var Message in _Messages)
            {
                addMessage(Message);
            }
        }

        public void addMessage(IMessage _Message)
        {
            Node tmp = Head;
            if (notEmpty(_Message))
            {
                if (_Message.GetType().Name.Equals("DENM"))
                {
                    addDENM(_Message);
                    return;
                }

                while (tmp.Next != null)
                {

                    if (tmp.Data.GetType().Name.Equals("CAM"))
                    {

                        CAM message = (CAM)_Message;
                        CAM data = (CAM)tmp.Data;

                        if (equilsTime(message.gernerationDeltaTime, data.gernerationDeltaTime))
                        {
                            addCAM(_Message, tmp);
                            return;
                        }
                    }
                    tmp = tmp.Next;
                }

                if (tmp.Next == null)
                {
                    if (tmp.Data.GetType().Name.Equals("DENM") &&
                        _Message.GetType().Name.Equals("CAM"))
                    {
                        addLastCAM(_Message);
                    }
                    else if (tmp.Data.GetType().Name.Equals("CAM") &&
                        _Message.GetType().Name.Equals("CAM"))
                    {
                        CAM message = (CAM)_Message;
                        CAM data = (CAM)tmp.Data;

                        if (equilsTime(message.gernerationDeltaTime, data.gernerationDeltaTime))
                        {
                            addFirstCAM(_Message);
                        }
                        else
                        {
                            addLastCAM(_Message);
                        }
                    }
                }

            }
        }

        //Methode für Nachrichten versenden an die ICS
        public List<IMessage> getQueue(uint _traffic)
        {
            uint traffic = 0;
            List<IMessage> MessageList = new List<IMessage>();

            while (traffic <= _traffic && notEmpty())
            {
                IMessage Message = getFirstNode();
                deliteFirst();
                MessageList.Add(Message);
                if (Message.GetType().Name.Equals("CAM"))
                {
                    traffic += trafficPerCAM;
                }
                else if (Message.GetType().Name.Equals("DENM"))
                {
                    traffic += trafficPerDENM;
                }
            }
            delteList();
            return MessageList;
        }

        private void addCAM(IMessage _Message, Node _Current)
        {
            if (_Current.Next == null)
                addLastCAM(_Message);
            else if (_Current.Prev == null)
                addFirstCAM(_Message);
            else
                addMiddleCAM(_Message, _Current);
        }

        private void addMiddleCAM(IMessage _Message, Node _Current)
        {
            addMiddle(_Message, _Current);
            traffic += trafficPerCAM;
            Console.WriteLine("add CAM \t ");
        }

        private void addLastCAM(IMessage _Message)
        {
            addLast(_Message);
            traffic += trafficPerCAM;
            Console.WriteLine("add CAM \t ");
        }

        private void addFirstCAM(IMessage _Message)
        {
            addFirst(_Message);
            traffic += trafficPerCAM;
            Console.WriteLine("add CAM \t ");
        }

        private void addDENM(IMessage _Message)
        {
            addFirst(_Message);
            traffic += trafficPerDENM;
            Console.WriteLine("add DENM \t ");
        }

        private void setDeltaTime()
        {
            DateTime currentDate = DateTime.Now;

            deltaTime = (int)currentDate.Ticks % 65536;

        }

        private bool equilsTime(int _message, int _data)
        {
            if (_message > deltaTime)
            {
                _message = _message - 65536;
            }
            if (_data > deltaTime)
            {
                _data = _message - 65536;
            }
            if (_data <= _message)
            {
                return true;
            }
            return false;
        }

        public void delteList()
        {
            while (notEmpty())
            {
                deliteFirst();
            }

            this.traffic = 0;
            this.trafficPerCAM = 7000;
            this.trafficPerDENM = 5000;
        }
    }
}
