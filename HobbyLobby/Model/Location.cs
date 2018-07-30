using HobbyLobby.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyLobby.Model
{
    public class Location
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public BoxWay FindTheBestWay(Box box)
        {
            int[] lengthDivision = new int[3];
            int[] widthDivision = new int[3];
            int[] heightDivision = new int[3];
            int[] cases = new int[6];

            //Dividing the Length of the location by all the sides of the box
            lengthDivision[0] = (int)(Length / box.Length);
            lengthDivision[1] = (int)(Length / box.Width);
            lengthDivision[2] = (int)(Length / box.Height);
            //Dividing the Width of the location by all the sides of the box
            widthDivision[0] = (int)(Width / box.Length);
            widthDivision[1] = (int)(Width / box.Width);
            widthDivision[2] = (int)(Width / box.Height);
            //Dividing the Height of the location by all the sides of the box
            heightDivision[0] = (int)(Height / box.Length);
            heightDivision[1] = (int)(Height / box.Width);
            heightDivision[2] = (int)(Height / box.Height);

            //Calculating the the number of boxes for each case
            // LWH
            cases[0] = lengthDivision[0] * widthDivision[1] * heightDivision[2];
            // LHW
            cases[1] = lengthDivision[0] * widthDivision[2] * heightDivision[1];
            // WLH
            cases[2] = lengthDivision[1] * widthDivision[0] * heightDivision[2];
            // WHL
            cases[3] = lengthDivision[1] * widthDivision[2] * heightDivision[0];
            // HLW
            cases[4] = lengthDivision[2] * widthDivision[0] * heightDivision[1];
            // HWL
            cases[5] = lengthDivision[2] * widthDivision[1] * heightDivision[0];

            //Finding the index of the BestWay
            int indexBestWay = Array.IndexOf(cases, cases.Max());
            return (BoxWay)indexBestWay;
        }

        public string ShowBestWayCalcutions(Box box, BoxWay boxWay)
        {
            string calculations = "";
            switch (boxWay)
            {
                case BoxWay.LWH:
                    calculations = CalculationSteps(box.Length, box.Width, box.Height);
                    break;
                case BoxWay.LHW:
                    calculations = CalculationSteps(box.Length, box.Height, box.Width);
                    break;
                case BoxWay.WLH:
                    calculations = CalculationSteps(box.Width, box.Length, box.Height);
                    break;
                case BoxWay.WHL:
                    calculations = CalculationSteps(box.Width, box.Height, box.Length);
                    break;
                case BoxWay.HLW:
                    calculations = CalculationSteps(box.Height, box.Length, box.Width);
                    break;
                case BoxWay.HWL:
                    calculations = CalculationSteps(box.Height, box.Width, box.Length);
                    break;
            }

            return calculations;
        }

        private string CalculationSteps(double side1, double side2, double side3)
        {
            string calculationSteps = "";
            calculationSteps += string.Format("{0} ÷ {1} = {2} go back\n", Length, side1, (int)(Length / side1));
            calculationSteps += string.Format("{0} ÷ {1} = {2} go across\n", Width, side2, (int)(Width / side2));
            calculationSteps += string.Format("{0} ÷ {1} = {2} go up\n", Height, side3, (int)(Height / side3));
            return calculationSteps;
        }

        public int HowManyCanFit(Box box, BoxWay boxWay)
        {
            int howMany = 0;
            switch (boxWay)
            {
                case BoxWay.LWH:
                    howMany = CalculationNumber(box.Length, box.Width, box.Height);
                    break;
                case BoxWay.LHW:
                    howMany = CalculationNumber(box.Length, box.Height, box.Width);
                    break;
                case BoxWay.WLH:
                    howMany = CalculationNumber(box.Width, box.Length, box.Height);
                    break;
                case BoxWay.WHL:
                    howMany = CalculationNumber(box.Width, box.Height, box.Length);
                    break;
                case BoxWay.HLW:
                    howMany = CalculationNumber(box.Height, box.Length, box.Width);
                    break;
                case BoxWay.HWL:
                    howMany = CalculationNumber(box.Height, box.Width, box.Length);
                    break;
            }
            return howMany;
        }

        private int CalculationNumber(double side1, double side2, double side3)
        {
            int temp = 0;
            temp = (int)(Length / side1) * (int)(Width / side2) * (int)(Height / side3);
            return temp;
        }

        public Location InchesLeft(Box box, BoxWay boxWay)
        {
            Location temp = new Location();
            switch (boxWay)
            {
                case BoxWay.LWH:
                    temp.Length = Length - (int)(Length / box.Length)* box.Length;
                    temp.Width = Width - (int)(Width / box.Width) * box.Width;
                    temp.Height = Height - (int)(Height / box.Height) * box.Height;
                    break;
                case BoxWay.LHW:
                    temp.Length = Length - (int)(Length / box.Length) * box.Length;
                    temp.Width = Width - (int)(Width / box.Height) * box.Height;
                    temp.Height = Height - (int)(Height / box.Width) * box.Width;
                    break;
                case BoxWay.WLH:
                    temp.Length = Length - (int)(Length / box.Width) * box.Width;
                    temp.Width = Width - (int)(Width / box.Length) * box.Length;
                    temp.Height = Height - (int)(Height / box.Height) * box.Height;
                    break;
                case BoxWay.WHL:
                    temp.Length = Length - (int)(Length / box.Width) * box.Width;
                    temp.Width = Width - (int)(Width / box.Height) * box.Height;
                    temp.Height = Height - (int)(Height / box.Length) * box.Length;
                    break;
                case BoxWay.HLW:
                    temp.Length = Length - (int)(Length / box.Height) * box.Height;
                    temp.Width = Width - (int)(Width / box.Length) * box.Length;
                    temp.Height = Height - (int)(Height / box.Width) * box.Width;
                    break;
                case BoxWay.HWL:
                    temp.Length = Length - (int)(Length / box.Height) * box.Height;
                    temp.Width = Width - (int)(Width / box.Width) * box.Width;
                    temp.Height = Height - (int)(Height / box.Length) * box.Length;
                    break;
            }
            return temp;
        }
    }


}
