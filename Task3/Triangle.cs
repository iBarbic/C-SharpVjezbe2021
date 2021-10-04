using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    class Triangle:Shape

    {
        private double side;
        
        public Triangle(double a)
        {
            side = a;
            xPos = DataModel.getNewXPos();
            yPos = DataModel.getNewYPos();
        }

        public override double getArea()
        {
            return ((Math.Sqrt(3) / 4) * (side * side));
        }
        public override double getPerimeter()
        {
            return 3 * side;
        }

        public override void printData()
        {
            Console.WriteLine();
            Console.WriteLine("My type: " + this.GetType());
            Console.WriteLine("Side of triangle = " + side);
            Console.WriteLine("X position = " + xPos);
            Console.WriteLine("Y position = " + yPos);
        }


    }

   
}
