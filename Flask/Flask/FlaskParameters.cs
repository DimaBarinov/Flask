using System;

namespace Flask
{
    //TODO: XML комментарии?
    public class FlaskParameters
    {
        /// <summary>
        /// Длина фляжки.
        /// </summary>
        private double _flaskLength;

        /// <summary>
        /// Ширина фляжки.
        /// </summary>
        private double _flaskWidth;

        /// <summary>
        /// Высота фляжки.
        /// </summary>
        private double _flaskHeight;

        /// <summary>
        /// Толщина стенки фляжки.
        /// </summary>
        private double _caseThickness;

        /// <summary>
        /// Диаметр горлышка.
        /// </summary>
        private double _neckDiameter;

        /// <summary>
        /// Высота горлышка.
        /// </summary>
        private double _neckHeight;

        /// <summary>
        /// Свойство длины фляжки.
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
        /// Свойство ширины фляжки.
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
        /// Свойство высоты фляжки.
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
        /// Свойство толщины стенки фляжки.
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
        /// Свойство диаметра горлышка.
        /// </summary>
        public double NeckDiameter
        {
            get => _neckDiameter;
            set
            {
                var parameter = (0.666 * FlaskWidth) - CaseThickness;
                //TODO:
                if (parameter > 20) ValidateParameters("Диаметр горлышка", value, 10, 20);
                
                else
                {
                    ValidateParameters("Диаметр горлышка", value, 10, parameter);
                }
                _neckDiameter = value;
            }
        }

        /// <summary>
        /// Свойство высоты горлышка.
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
       /// Валидация параметров.
       /// </summary>
       /// <param name="name">Наименование параметра.</param>
       /// <param name="value">Значение параметра.</param>
       /// <param name="min">Минимальное допустимое значение.</param>
       /// <param name="max">Максимальное допустимое значение.</param>
        public void ValidateParameters(string name, double value, double min, double max)
        {
            if (min <= value && value <= max) return;

            var errorMessage = $"{name} должна быть в диапазоне от {min} до {max} мм.";
            throw new ArgumentException(string.Join("\n", errorMessage));
        }
    }
}
