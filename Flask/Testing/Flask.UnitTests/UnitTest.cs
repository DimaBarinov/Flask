using FlaskParameters;
using NUnit.Framework;
using System;

namespace Flask.UnitTests
{
    /// <summary>
    /// ����� ����-������ ����������.
    /// </summary>
    [TestFixture]
    public class FlaskParameterTests
    {
        [TestCase(69, 19, 99, 0.9, 21, 9, 
            TestName = "���� �� ���� ������������ ��������")]
        public void UncorrectParametrs(double flaskLength, 
            double flaskWidth, double flaskHeight, double caseThickness, 
            double neckDiameter, double neckHeight)
        {
            //Setup
            var parameters = new Parameters();

            //Assert
            Assert.Throws<ArgumentException>(
                () => {parameters.FlaskLength = flaskLength;});
            Assert.Throws<ArgumentException>(
                () => { parameters.FlaskWidth = flaskWidth; });
            Assert.Throws<ArgumentException>(
                () => { parameters.FlaskHeight = flaskHeight; });
            Assert.Throws<ArgumentException>(
                () => { parameters.CaseThickness = caseThickness; });
            Assert.Throws<ArgumentException>(
                () => { parameters.NeckDiameter = neckDiameter; });
            Assert.Throws<ArgumentException>(
                () => { parameters.NeckHeight = neckHeight; });
        }

        [TestCase(70, 40, 100, 1, 10, 10, 
            TestName = "���� �� ���� ���������� ��������")]
        public void CorrectParametrs(double flaskLength, double flaskWidth, 
            double flaskHeight, double caseThickness,
            double neckDiameter, double neckHeight)
        {
            //Setup
            var parameters = new Parameters();

            //Assert
            Assert.AreEqual(parameters.FlaskLength, 
                parameters.FlaskLength = flaskLength);
            Assert.AreEqual(parameters.FlaskWidth, 
                parameters.FlaskWidth = flaskWidth);
            Assert.AreEqual(parameters.FlaskHeight, 
                parameters.FlaskHeight = flaskHeight);
            Assert.AreEqual(parameters.CaseThickness,
                parameters.CaseThickness = caseThickness);
            Assert.AreEqual(parameters.NeckDiameter,
                parameters.NeckDiameter = neckDiameter);
            Assert.AreEqual(parameters.NeckHeight, 
                parameters.NeckHeight = neckHeight);
        }

        [TestCase(20, 1, 13, TestName = "���� �� �������� �����������:" +
            " ������� �������� < ((0.666 * ������ ������) - ������� �������).")]
        public void Dependence(double flaskWidth, 
            double caseThickness, double neckDiameter)
        {
            //Setup
            var parameters = new Parameters();

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    parameters.FlaskWidth = flaskWidth;
                    parameters.CaseThickness = caseThickness;
                    parameters.NeckDiameter = neckDiameter;
                }
            );
        }

    }
}