using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Test
{
    using NUnit.Framework;
    using NUnit.Framework.Constraints;
    using PROG8170_Assignment1;

    [TestFixture]
    class CircleTest
    {
        [Test]
        //Whole Number Test: Program should accept whole number value
        [TestCase(5)]
        //Zero Test: Program should accept 0 value
        [TestCase(0)]
        //Decimal Test: Program should accept long decimal value
        [TestCase(0.000000000001)]
        ////Expected Failure Test: Program should reject negative value
        //[TestCase(-1500)]
        ////Expected Failure Test: Program should reject string
        //[TestCase("Test")]
        public void Create_Circle_Test(double radiusvalue)
        {
            //Arrange & Act
            PROG8170_Assignment1.Circle Circle = new PROG8170_Assignment1.Circle(radiusvalue);

            //Assert
            Assert.AreEqual(radiusvalue, Circle.circleRadius);
        }

        [Test]
        //Whole Number Test: Program should accept whole number value
        [TestCase(5)]
        //Zero Test: Program should accept 0 value
        [TestCase(0)]
        //Decimal Test: Program should accept long decimal value
        [TestCase(0.000000000001)]
        ////Expected Failure Test: Program should reject string
        //[TestCase("Test")]
        public void Create_Circle_Blank_Constructor_Test(double radiusvalue)
        {
            //Arrange & Act
            PROG8170_Assignment1.Circle Circle = new PROG8170_Assignment1.Circle();
            Circle.circleRadius = radiusvalue;

            //Assert
            Assert.AreEqual(radiusvalue, Circle.circleRadius);
        }

        #region AddToRadius
        [Test]
        //Radius set as 5.05 across all tests
        //Normal Test: Radius to be added is set as 1.5 to check integrity of result by adding a double value
        [TestCase(5.05, 1.5)]
        //Long Decimal Value Test: Radius to be added is set as +0.000000000000000001 to check integrity of result emphasis on decimal
        [TestCase(5.05, +0.000000000000000001)]
        ////Expected Failure Test: Radius to be added is set as negative to check if program returns ArgumentException error & not accept value
        //[TestCase(5.05, -0.0000001)] 
        public void AddToRadius_Positive_Value_Test(double initialRadius, double addRadius)
        {
            //Arrange
            double expectedRadius = initialRadius + addRadius;
            PROG8170_Assignment1.Circle CircleTest1 = new PROG8170_Assignment1.Circle(initialRadius);

            //Act
            CircleTest1.AddToRadius(addRadius);

            //Assert
            Assert.AreEqual(expectedRadius, CircleTest1.circleRadius);
        }

        [Test]
        //Radius set as 5.05 across all tests
        //Normal Test: Radius to be added is set as negative to check if program returns ArgumentException error & not accept value
        [TestCase(5.05, -3.5)]
        //Long Decimal Value Test: Radius to be added is set as -0.000000000000000001 to check even small negative value returns ArgumentException error & program does not accept the value
        [TestCase(5.05, -0.000000000000000001)]
        ////Expected Failure Test: Radius to be added is set as -0 to check that program returns true even if given a negative sign before the value of 0
        //[TestCase(5.05, -0)]
        public void AddToRadius_Negative_Value_Test_ThrowsExcptn(double initialRadius, double addRadius)
        {
            //Arrange
            double expectedRadius = initialRadius + addRadius;
            PROG8170_Assignment1.Circle CircleTest2 = new PROG8170_Assignment1.Circle(initialRadius);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => CircleTest2.AddToRadius(addRadius));
        }

        #endregion

        #region SubtractFromRadius
        [Test]
        //Radius set as 5.05 across all tests
        //Normal Test: Radius to be subtracted is set as 2.5 to check integrity of result by subtracting a double value
        [TestCase(5.05, 2.5)]
        //Zero Test: Radius to be subtracted is equal to zero to check if value of radius remains unaltered
        [TestCase(5.05, 0)]
        ////Expected Failure Test: Radius to be subtracted is set as negative to check if program returns ArgumentException error & not accept value
        //[TestCase(5.05, -1)]
        public void SubtractFromRadius_Positive_Test(double initialRadius, double subtractRadius)
        {
            //Arrange
            double expectedRadius = initialRadius - subtractRadius;
            PROG8170_Assignment1.Circle CircleTest3 = new PROG8170_Assignment1.Circle(initialRadius);

            //Act
            CircleTest3.SubtractFromRadius(subtractRadius);

            //Assert
            Assert.AreEqual(expectedRadius, CircleTest3.circleRadius);
        }

        [Test]
        //Radius set as 5.05 across all tests
        //Normal Test: Radius to be subtracted is set as negative to check if program returns ArgumentException error & not accept value
        [TestCase(5.05, -3.5)]
        //Long Decimal Value Test: Radius to be subtracted is set as -0.0000000001 to check even small negative value returns ArgumentException error & program does not accept the value
        [TestCase(5.05, -0.0000000001)]
        ////Expected Failure Test: Radius to be subtracted is set as -0 to check that program returns true even if given a negative sign before the value of 0
        //[TestCase(5.05, -0)]
        public void SubtractFromRadius_Negative_Value_Test_ThrowsExcptn(double initialRadius, double subtractRadius)
        {
            //Arrange
            PROG8170_Assignment1.Circle CircleTest4 = new PROG8170_Assignment1.Circle(initialRadius);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => CircleTest4.SubtractFromRadius(subtractRadius));
        }

        [Test]
        //Radius set as 5.05 across all tests
        //Normal Test: Radius to be subtracted is set as 21 (higher than default radius) to check if program returns ArgumentException error & not accept value
        [TestCase(5.05, 21)]
        //Long Decimal Value Test: Radius to be subtracted is set as 5.05000000001 (higher than default radius) to check even small value difference returns ArgumentException error & program does not accept the value
        [TestCase(5.05, 5.05000000001)]
        ////Expected Failure Test: Radius to be subtracted is set as 4.04999999999 to check that program returns true even if value is smaller and only has small difference from radius
        //[TestCase(5.05, 4.04999999999)]
        public void SubtractFromRadius_Greater_Value_Test_ThrowsExcptn(double initialRadius, double subtractRadius)
        {
            //Arrange
            PROG8170_Assignment1.Circle CircleTest5 = new PROG8170_Assignment1.Circle(initialRadius);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => CircleTest5.SubtractFromRadius(subtractRadius));
        }
        #endregion

        #region GetCircumference

        [Test]
        //Zero value for Radius Test: Program should accept 0
        [TestCase(0)]
        //Positive value for Radius Test: Program should accept value
        [TestCase(1.25125)]
        ////Expected Failure Test: Negative value for Radius - Program should throw Exception of value must be equal or greater than 0
        //[TestCase(-1.25)]
        public void GetCircumference_Test(double radius)
        {
            //Arrange
            double expectedCircumference = 2 * Math.PI * radius;
            PROG8170_Assignment1.Circle Circle = new Circle(radius);

            //Act
            Circle.GetCircumference();

            //Assert
            Assert.AreEqual(expectedCircumference, Circle.Circumference);
        }

        [Test]
        //Null value test: Program will proceed to set radius to 0 even after given null
        [TestCase(null)]
        public void GetCircumference_Null_Value_Test(double radius)
        {
            //Arrange
            double expectedCircumference = radius;
            PROG8170_Assignment1.Circle Circle = new Circle(radius);

            //Act
            Circle.GetCircumference();

            //Assert
            Assert.AreEqual(expectedCircumference, Circle.Circumference);
        }

        #endregion

        #region GetArea

        [Test]
        //Zero value for Radius Test: Program should accept 0
        [TestCase(0)]
        //Positive value for Radius Test: Program should accept value
        [TestCase(1.25125)]
        ////Expected Failure Test: Negative value for Radius - Program should throw Exception of value must be equal or greater than 0
        //[TestCase(-1.25)]
        public void GetArea_Test(double radius)
        {
            //Arrange
            double expectedArea = Math.PI * Math.Pow(radius, 2);
            PROG8170_Assignment1.Circle Circle = new Circle(radius);

            //Act
            Circle.GetArea();

            //Assert
            Assert.AreEqual(expectedArea, Circle.Area);
        }

        [Test]
        //Null value test: Program will proceed to set radius to 0 even after given null
        [TestCase(null)]
        public void GetArea_Null_Value_Test(double radius)
        {
            //Arrange
            double expectedArea = radius;
            PROG8170_Assignment1.Circle Circle = new Circle(radius);

            //Act
            Circle.GetArea();

            //Assert
            Assert.AreEqual(expectedArea, Circle.Area);
        }

        #endregion
    }
}
