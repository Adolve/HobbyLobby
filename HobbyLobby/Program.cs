using HobbyLobby.Enum;
using HobbyLobby.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyLobby
{
    class Program
    {
        static void Main(string[] args)
        {
            Location location = new Location
            {
                Height = 24,
                Width = 48,
                Length = 52
            };

            Box box = new Box
            {
                Height = 14,
                Width = 3,
                Length = 8
            };

            BoxWay boxWay = location.FindTheBestWay(box);
            Console.WriteLine("Location: LWH");
            Console.WriteLine("Box     : "+boxWay+"\n");
            Console.WriteLine(location.ShowBestWayCalcutions(box, boxWay));

            Console.WriteLine("Number total of boxes: "+location.HowManyCanFit(box,boxWay));

            Console.WriteLine();

            Location locationLeft = location.InchesLeft(box, boxWay);
            Console.WriteLine("Inches Left");
            Console.WriteLine("L: "+ locationLeft.Length);
            Console.WriteLine("W: "+ locationLeft.Width);
            Console.WriteLine("H: "+ locationLeft.Height);
            Console.WriteLine();

            /*
            BoxWay boxWayLeft = locationLeft.FindTheBestWay(box);
            int howManyLeftCanFit = locationLeft.HowManyCanFit(box, boxWayLeft);
            if (howManyLeftCanFit > 0)
            {
                Console.WriteLine("------------ More Boxes can fit ------------");
                Console.WriteLine("\t\tBox     : " + boxWayLeft + "\n");
                Console.WriteLine("\t\tNumber total of boxes: " + howManyLeftCanFit);
            }
            */
            
        }
    }
}
