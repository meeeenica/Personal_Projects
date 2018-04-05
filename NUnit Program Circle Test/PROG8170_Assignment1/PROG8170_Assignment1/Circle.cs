using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG8170_Assignment1
{
    public class Circle
    {
        public double circleRadius { get; set; }
        public double Circumference { get; set; }
        public double Area { get; set; }

        public Circle()
        {
        }

        public Circle(double circleRadius)
        {
            if (circleRadius < 0)
            {
                throw new System.ArgumentException("Value of radius must be greater than or equal to 0.");
            }
            else
            {
                this.circleRadius = circleRadius;
            }
        }

        public void AddToRadius(double num)
        {
            if (num < 0)
            {
                throw new System.ArgumentException("Value to be added must be greater than or equal to 0.");
            }
            else
            {
                circleRadius += num;
            }
        }

        public void SubtractFromRadius(double num)
        {
            if (circleRadius < num)
            {
                throw new System.ArgumentException("Value to be subtracted must not be greater than Radius value.");
            }
            else if (num < 0)
            {
                throw new System.ArgumentException("Value to be subtracted must be greater than or equal to 0.");
            }
            else
            {
                circleRadius -= num;
            }
        }

        public void GetCircumference()
        {
            try
            {
                Circumference = 2 * Math.PI * circleRadius;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("Error on circumference computation.");
            }
        }

        public void GetArea()
        {
            try
            {
                Area = Math.PI * Math.Pow(circleRadius, 2);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("Error on area computation.");
            }
        }
    }
}