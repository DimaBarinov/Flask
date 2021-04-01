using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaskUI
{
    public class FlaskParameters
    {
        /// <summary>
        /// 
        /// </summary>
        public double FlaskLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double FlaskWidth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double FlaskHeight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double CaseThickness { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double NeckDiameter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double NeckHeight { get; set; }

        public FlaskParameters(double flaskLength, double flaskWidth, double flaskHeight, double caseThickness, double neckDiameter, double neckHeight)
        {
            FlaskLength = flaskLength;
            FlaskWidth = flaskWidth;
            FlaskHeight = flaskHeight;
            CaseThickness = caseThickness;
            NeckDiameter = neckDiameter;
            NeckHeight = neckHeight;
            ValidateParameters();
        }

        private void ValidateParameters()
        {
            var errorMessage = new List<string>();
            if (FlaskLength < 70 || FlaskLength > 120)
            {
                errorMessage.Add("Длина фляжки должна быть в диапазоне от 70 до 120 мм");
            }

            if (FlaskWidth < 20 || FlaskWidth > 40)
            {
                errorMessage.Add("Ширина фляжки должна быть в диапазоне от 20 до 40 мм");
            }

            if (FlaskHeight < 100 || FlaskHeight > 150)
            {
                errorMessage.Add("Высота фляжки должна быть в диапазоне от 100 до 150 мм");
            }

            if (CaseThickness < 1 || CaseThickness > 3)
            {
                errorMessage.Add("Толщина стенки фляжки должна быть в диапазоне от 1 до 3 мм");
            }

            if (NeckDiameter < 10 || NeckDiameter > 20)
            {
                errorMessage.Add("Диаметр горлышка фляжки должен быть в диапазоне от 10 до 20 мм");
            }

            if (NeckHeight < 10 || NeckHeight > 20)
            {
                errorMessage.Add("Высота горлышка фляжки должна быть в диапазоне от 10 до 20 мм");
            }

            if (errorMessage.Count > 0)
            {
                throw new ArgumentException(string.Join("\n", errorMessage));
            }
        }
    }
}
