using System;
using System.Collections.Generic;

using ProjektMArbeit.Messages.BasicContainer;

namespace ProjektMArbeit.GUI
{
    class Display
    {
        int[] AnzBefor;
        int[] AnzAfter;
        int CountListBefor;
        int CountListAfter;

        public Display()
        {
            this.CountListBefor = 0;
            this.CountListAfter = 0;
        }

        public void showMessage(uint _trafficSize, uint _trafficDensity, List<IMessage> _ListBefor, List<IMessage> _ListAfter)
        {
            AnzBefor = CountMessages(_ListBefor);
            AnzAfter = CountMessages(_ListAfter);
            CountListBefor = _ListBefor.Count;
            CountListAfter = _ListAfter.Count;

            Console.WriteLine("Verkehrsdichte: " + _trafficDensity);
            Console.WriteLine("Bandbreite: " + _trafficSize);
            Console.WriteLine("Erzeugte NAchrichten: " + CountListBefor);
            Console.WriteLine("\t Anzahl CAMs: " + AnzBefor[0]);
            Console.WriteLine("\t Anzahl DENMs: " + AnzBefor[1]);

            Console.WriteLine("Versendete NAchrichten: " + CountListAfter);
            Console.WriteLine("\t Anzahl CAMs: " + AnzAfter[0]);
            Console.WriteLine("\t Anzahl DENMs: " + AnzAfter[1]);

            SystemBreak();
        }

        public bool InputConfirmation()
        {
            return (Char.ToUpper(GetKeyPress("Display another message (Y/N): ", new Char[] { 'Y', 'N' })) == 'Y');
        }

        public void SystemBreak()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        private int[] CountMessages(List<IMessage> _List)
        {
            int AnzCAM = 0;
            int AnzDENM = 0;
            foreach (var e in _List)
            {
                if (e.GetType().Name.Equals("CAM"))
                {
                    AnzCAM++;
                }
                else
                {
                    AnzDENM++;
                }
            }

            return new int[] { AnzCAM, AnzDENM };
        }

        private Char GetKeyPress(String msg, Char[] validChars)
        {
            ConsoleKeyInfo keyPressed;
            bool valid = false;

            Console.WriteLine();
            do
            {
                Console.Write(msg);
                keyPressed = Console.ReadKey();
                Console.WriteLine();
                if (Array.Exists(validChars, ch => ch.Equals(Char.ToUpper(keyPressed.KeyChar))))
                    valid = true;

            } while (!valid);
            return keyPressed.KeyChar;
        }
    }
}
