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
        private double _flaskLength = 70;
        private double _flaskWidth = 20;
        private double _flaskHeight = 100;
        private double _caseThickness = 1;
        private double _neckDiameter = 10;
        private double _neckHeight = 10;

        /// <summary>
        /// 
        /// </summary>
        public double FlaskLength 
        {
            get => _flaskLength;
            set
            {
                ValidateParameters("Длина фляжки", value, 70, 120);
                _flaskLength = value;
            }
        } 

        /// <summary>
        /// 
        /// </summary>
        public double FlaskWidth 
        {
            get => _flaskWidth;
            set
            {
                ValidateParameters("Ширина фляжки", value, 20, 40);
                _flaskWidth = value;
            }
        } 

        /// <summary>
        /// 
        /// </summary>
        public double FlaskHeight
        {
            get => _flaskHeight;
            set
            {
                ValidateParameters("Высота фляжки", value, 100, 150);
                _flaskHeight = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double CaseThickness
        {
            get => _caseThickness;
            set
            {
                ValidateParameters("Толщина стенки фляжки", value, 1, 3);
                _caseThickness = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double NeckDiameter
        {
            get => _neckDiameter;
            set
            {
                ValidateParameters("Диаметр горлышка", value, 10, 20);
                _neckDiameter = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double NeckHeight
        {
            get => _neckHeight;
            set
            {
                ValidateParameters("Высота горлышка", value, 10, 20);
                _neckHeight = value;
            }
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="name"></param>
       /// <param name="value"></param>
       /// <param name="min"></param>
       /// <param name="max"></param>
        public void ValidateParameters(string name, double value, double min, double max)
        {
            if (!(value < min) && !(value > max)) return;
            var errorMessage = $"{name} должна быть в диапазоне от {min} до {max} мм.";
            throw new ArgumentException(string.Join("\n", errorMessage));
        }
    }
}
