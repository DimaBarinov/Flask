using NUnit.Framework;
using System;

namespace Flask.UnitTests
{
    [TestFixture]
    public class FlaskParameterTests
    {
        [TestCase(TestName = "����� ������ ������ ������������ (70).")]
        public void FlaskLenght_LessMin_ThrowsException()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 69;

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    parameters.FlaskLength = sourceValue;
                }
            );
        }

        [TestCase(TestName = "������ ������ ������ ������������ (20).")]
        public void FlaskWidth_LessMin_ThrowsException()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 19;

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    parameters.FlaskWidth = sourceValue;
                }
            );
        }

        [TestCase(TestName = "������ ������ ������ ������������ (100).")]
        public void FlaskHeight_LessMin_ThrowsException()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 99;

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    parameters.FlaskHeight = sourceValue;
                }
            );
        }

        [TestCase(TestName = "������� ������ ������ ������ ������������ (1).")]
        public void CaseThickness_LessMin_ThrowsException()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 0.9;

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    parameters.CaseThickness = sourceValue;
                }
            );
        }

        [TestCase(TestName = "������� �������� ������ ������������ (10).")]
        public void NeckDiameter_LessMin_ThrowsException()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 9;

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    parameters.NeckDiameter = sourceValue;
                }
            );
        }

        [TestCase(TestName = "������ �������� ������ ������������ (10).")]
        public void NeckHeight_LessMin_ThrowsException()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 9;

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    parameters.NeckHeight = sourceValue;
                }
            );
        }

        [TestCase(TestName = "������� �������� ������ ������������� ((0.666 * ������ ������) - ������� �������).")]
        public void NeckDiameter_MoreMaxByCondition_ThrowsException()
        {
            //Setup
            var parameters = new FlaskParameters();
            parameters.FlaskWidth = 20;
            parameters.CaseThickness = 1;
            var sourceValue = 13;

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    parameters.NeckDiameter = sourceValue;
                }
            );
        }

        //[TestCase(TestName = "������� �������� ������ ������������� (20).")]
        //public void NeckDiameter_MoreMax_ThrowsException()
        //{
        //    //Setup
        //    var parameters = new FlaskParameters();
        //    parameters.FlaskWidth = 40;
        //    parameters.CaseThickness = 1;
        //    var sourceValue = 21;

        //    //Assert
        //    NUnit.Framework.Assert.Throws<ArgumentException>
        //    (
        //        () =>
        //        {
        //            //Act
        //            parameters.NeckDiameter = sourceValue;
        //        }
        //    );
        //}

        [TestCase(TestName = "����� ������ ������ ������������� (120).")]
        public void FlaskLenght_MoreMax_ThrowsException()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 69;

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    parameters.FlaskLength = sourceValue;
                }
            );
        }

        [TestCase(TestName = "������ ������ ������ ������������� (40).")]
        public void FlaskWidth_MoreMax_ThrowsException()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 19;

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    parameters.FlaskWidth = sourceValue;
                }
            );
        }

        [TestCase(TestName = "������ ������ ������ ������������� (150).")]
        public void FlaskHeight_MoreMax_ThrowsException()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 99;

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    parameters.FlaskHeight = sourceValue;
                }
            );
        }

        [TestCase(TestName = "������� ������ ������ ������ ������������� (3).")]
        public void CaseThickness_MoreMax_ThrowsException()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 0.9;

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    parameters.CaseThickness = sourceValue;
                }
            );
        }

        [TestCase(TestName = "������� �������� ������ ������������� (20).")]
        public void NeckDiameter_MoreMax_ThrowsException()
        {
            //Setup
            var parameters = new FlaskParameters();
            parameters.FlaskWidth = 40;
            parameters.CaseThickness = 1;
            var sourceValue = 21;

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    parameters.NeckDiameter = sourceValue;
                }
            );
        }

        [TestCase(TestName = "������ �������� ������ ������������� (20).")]
        public void NeckHeight_MoreMax_ThrowsException()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 21;

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    parameters.NeckHeight = sourceValue;
                }
            );
        }

        [TestCase(TestName = "���������� �������� ����� ������")]
        public void FlaskLength_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 70;
            var expectedValue = sourceValue;

            //Act
            parameters.FlaskLength = sourceValue;
            var actualValue = parameters.FlaskLength;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(TestName = "���������� �������� ������ ������")]
        public void FlaskWidth_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 20;
            var expectedValue = sourceValue;

            //Act
            parameters.FlaskWidth = sourceValue;
            var actualValue = parameters.FlaskWidth;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(TestName = "���������� �������� ������ ������")]
        public void FlaskHeight_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 100;
            var expectedValue = sourceValue;

            //Act
            parameters.FlaskHeight = sourceValue;
            var actualValue = parameters.FlaskHeight;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(TestName = "���������� �������� ������� ������ ������")]
        public void �aseThickness_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 1;
            var expectedValue = sourceValue;

            //Act
            parameters.CaseThickness = sourceValue;
            var actualValue = parameters.CaseThickness;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(TestName = "���������� �������� �������� ��������")]
        public void NeckDiameter_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var parameters = new FlaskParameters();
            parameters.CaseThickness = 1;
            parameters.FlaskWidth = 20;
            var sourceValue = 10;
            var expectedValue = sourceValue;

            //Act
            parameters.NeckDiameter = sourceValue;
            var actualValue = parameters.NeckDiameter;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(TestName = "���������� �������� ������ ��������")]
        public void NeckHeight_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var parameters = new FlaskParameters();
            var sourceValue = 10;
            var expectedValue = sourceValue;

            //Act
            parameters.NeckHeight = sourceValue;
            var actualValue = parameters.NeckHeight;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedValue, actualValue);
        }
    }
}