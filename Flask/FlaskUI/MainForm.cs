using System;
using System.Windows.Forms;
using Flask;

namespace FlaskUI
{       
    public partial class MainForm : Form
    {
        /// <summary>
        /// Экземпляр класса соединения с компасом.
        /// </summary>
        public KompasConnector _kompas = new KompasConnector();

        /// <summary>
        /// Экземпляр класса параметров.
        /// </summary>
        private FlaskParameters _parameters = new FlaskParameters();

        /// <summary>
        /// Инициализация данных.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            FlaskLengthTextBox.Text = "70";
            FlaskHeightTextBox.Text = "100";
            FlaskWidthTextBox.Text = "20";
            CaseThicknessTextBox.Text = "1";
            NeckDiameterTextBox.Text = "10";
            NeckHeightTextBox.Text = "10";

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
                MessageBox.Show("Данные введены некорректно. Возможно, заполнены не все обязательные поля или введены лишние запятые.",
                    @"Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, @"Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Собитие обратки ввода с клавиатуры.
        /// </summary>
        private void LengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != 44) && (e.KeyChar != 8))
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
                if (control.Name.Contains("FlaskLengthTextBox")) _parameters.FlaskLength = double.Parse(control.Text);
                if (control.Name.Contains("FlaskWidthTextBox")) _parameters.FlaskWidth = double.Parse(control.Text);
                if (control.Name.Contains("FlaskHeightTextBox")) _parameters.FlaskHeight = double.Parse(control.Text);
                if (control.Name.Contains("CaseThicknessTextBox")) _parameters.CaseThickness = double.Parse(control.Text);
                if (control.Name.Contains("NeckDiameterTextBox")) _parameters.NeckDiameter = double.Parse(control.Text);
                if (control.Name.Contains("NeckHeightTextBox")) _parameters.NeckHeight = double.Parse(control.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Данные введены некорректно. Возможно, заполнены не все обязательные поля или введены лишние запятые.",
                    @"Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                control.Focus();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, @"Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                control.Focus();
            }
        }

        /// <summary>
        /// Событие обработки выходо из поля
        /// </summary>
        private void LengthTextBox_Leave(object sender, EventArgs e)
        {
            ValidateParameter(FlaskLengthTextBox);
        }

        /// <summary>
        /// Событие обработки выходо из поля
        /// </summary>
        private void ThicknessTextBox_Leave(object sender, EventArgs e)
        {
            ValidateParameter(CaseThicknessTextBox);
        }

        /// <summary>
        /// Событие обработки выходо из поля
        /// </summary>
        private void WidthTextBox_Leave(object sender, EventArgs e)
        {
            ValidateParameter(FlaskWidthTextBox);
        }

        /// <summary>
        /// Событие обработки выходо из поля
        /// </summary>
        private void NeckDiameterTextBox_Leave(object sender, EventArgs e)
        {
            ValidateParameter(NeckDiameterTextBox);
        }

        /// <summary>
        /// Событие обработки выходо из поля
        /// </summary>
        private void HeightTextBox_Leave(object sender, EventArgs e)
        {
            ValidateParameter(FlaskHeightTextBox);
        }

        /// <summary>
        /// Событие обработки выходо из поля
        /// </summary>
        private void NeckHeightTextBox_Leave(object sender, EventArgs e)
        {
            ValidateParameter(NeckHeightTextBox);
        }
    }
}
