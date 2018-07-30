using System;
using System.Globalization;

using ProjektMArbeit.Messages.BasicContainer;
using ProjektMArbeit.Messages.CAM;
using ProjektMArbeit.Messages.DENM;


namespace ProjektMArbeit.Generator
{
    class MessageGenerator
    {
        private int generateCAM;
        private int generateDENM;
        private UInt16 culterNumber = 3;
        private String[] cultureNames = { "en-US", "en-GB", "fr-FR",
                                "de-DE", "ru-RU" };

        public MessageGenerator()
        {
            generateCAM = 0;
            generateDENM = 0;
        }

        public CAM generatCAM(uint _stationID)
        {
            generateCAM++;
            uint messageID = (uint)generateCAM;
            uint stationID = 0;
            uint protocolVersion = 0;

            DateTime time = DateTime.UtcNow;

            string name = "generierte CAM " + generateCAM;
            //var C = new CAM(new Header(messageID, stationID, protocolVersion), time, new CAMParameters(name));

            var C = new CAM(new Header(messageID, stationID, protocolVersion), generateTime(), new CAMParameters(name));

            CultureInfo culture = new CultureInfo(cultureNames[culterNumber]);
            Console.WriteLine("Create CAM \t {0}", time.ToString(culture));

            return C;
        }

        public DENM generatDENM(uint _stationID)
        {
            generateDENM++;
            uint messageID = (uint)generateDENM;
            uint stationID = 0;
            uint protocolVersion = 0;

            DateTime time = DateTime.Now;

            DENM D= new DENM(new Header(messageID, stationID, protocolVersion));

            CultureInfo culture = new CultureInfo(cultureNames[culterNumber]);
            Console.WriteLine("Create DENM \t {0}", time.ToString(culture));

            return D;
        }

        private int generateTime()
        {
            DateTime currentDate = DateTime.Now;

            return (int)currentDate.Ticks % 65536;
        }
    }
}
