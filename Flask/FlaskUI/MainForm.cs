using System;
using System.Windows.Forms;
using Flask;
using FlaskParameters;

namespace FlaskUI
{       
    //TODO: XML комментарии?
    /// <summary>
    /// Класс главной формы программы.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Экземпляр класса соединения с компасом.
        /// </summary>
        public KompasConnector _kompas = new KompasConnector();

        /// <summary>
        /// Экземпляр класса параметров.
        /// </summary>
        private Parameters _parameters = new Parameters();

        /// <summary>
        /// Инициализация данных.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            //TODO:
            FlaskLengthTextBox.Text = Convert.ToString(_parameters.FlaskLength);
            FlaskHeightTextBox.Text = Convert.ToString(_parameters.FlaskHeight);
            FlaskWidthTextBox.Text = Convert.ToString(_parameters.FlaskWidth);
            CaseThicknessTextBox.Text = Convert.ToString(_parameters.CaseThickness);
            NeckDiameterTextBox.Text = Convert.ToString(_parameters.NeckDiameter);
            NeckHeightTextBox.Text = Convert.ToString(_parameters.NeckHeight);

        }
        
        /// <summary>
        /// Событие обработки нажатия на кнопку "Построить модель"
        /// </summary>
        private void BuildModelButton_Click(object sender, EventArgs e)
        {
            try
            {
                _parameters.FlaskLength = double.Parse(FlaskLengthTextBox.Text);
                _parameters.FlaskWidth = double.Parse(FlaskWidthTextBox.Text);
                _parameters.FlaskHeight = double.Parse(FlaskHeightTextBox.Text);
                _parameters.CaseThickness = double.Parse(CaseThicknessTextBox.Text);  
                _parameters.NeckDiameter = double.Parse(NeckDiameterTextBox.Text);
                _parameters.NeckHeight = double.Parse(NeckHeightTextBox.Text);

                _kompas.OpenKompas();
                var model = new ModelBuilder();
                model.BuildFlask(_parameters, _kompas.Kompas);
            }
            catch (FormatException)
            {
                 //TODO: RSDN
                MessageBox.Show("Данные введены некорректно. Возможно, заполнены не все" +
                    " обязательные поля или введены лишние запятые.",
                    @"Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentException ex)
            {
                 //TODO: RSDN
                MessageBox.Show(ex.Message, @"Предупреждение", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Собитие обратки ввода с клавиатуры.
        /// </summary>
        private void LengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //TODO:
            var keysBack = Convert.ToChar(Keys.Back); 
            if ((e.KeyChar < '0' || e.KeyChar > '9') 
                && (e.KeyChar != ',')
                && (e.KeyChar != keysBack))
                e.Handled = true;
        }

        /// <summary>
        /// Метод валидации введеных параметров.
        /// </summary>
        /// <param name="control">Заполненный TextBox.</param>
        private void ValidateParameter(Control control)
        {
            try
            {
                //TODO: RSDN
                if (control.Equals(FlaskLengthTextBox))
                {
                    _parameters.FlaskLength = double.Parse(control.Text);
                }
                if (control.Equals(FlaskWidthTextBox))
                {
                    _parameters.FlaskWidth = double.Parse(control.Text);
                }
                if (control.Equals(FlaskHeightTextBox))
                {
                    _parameters.FlaskHeight = double.Parse(control.Text);
                }
                if (control.Equals(CaseThicknessTextBox))
                {
                    _parameters.CaseThickness = double.Parse(control.Text);
                }
                if (control.Equals(NeckDiameterTextBox))
                {
                    _parameters.NeckDiameter = double.Parse(control.Text);
                }
                if (control.Equals(NeckHeightTextBox))
                {
                    _parameters.NeckHeight = double.Parse(control.Text);
                }
            }
            catch (FormatException)
            {
                 //TODO: RSDN
                MessageBox.Show("Данные введены некорректно. " +
                    "Возможно, заполнены не все обязательные поля или введены лишние запятые.",
                    @"Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                control.Focus();
            }
            catch (ArgumentException ex)
            {
                 //TODO: RSDN
                MessageBox.Show(ex.Message, @"Предупреждение", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                control.Focus();
            }
        }

        //TODO: Duplication
        /// <summary>
        /// Событие обработки выхода из поля.
        /// </summary>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            ValidateParameter((TextBox)sender);
        }
    }
}
