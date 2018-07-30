using ProjektMArbeit.Filter;
using ProjektMArbeit.GUI;
using ProjektMArbeit.Streets;

namespace ProjektMArbeit
{
    class Program
    {
        static void Main(string[] args)
        {
            uint trafficSize = 1100000;
            uint trafficDensity = 40;

            Program a = new Program();
            RoadSideStation RSS = new RoadSideStation(trafficSize);
            Street S = new Street(trafficDensity);
            Display Display = new Display();


            do
            {
                S.createTraffic(10);
                var List = RSS.getSendToList(S.getList());
                Display.showMessage(trafficSize, trafficDensity, S.getList(), List);
                S.clearList();

            } while (Display.InputConfirmation());

            Display.SystemBreak();
        }
    }
}
