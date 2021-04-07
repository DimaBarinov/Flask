using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flask;

namespace FlaskUI
{       
    public partial class MainForm : Form
    {
        public ConnectingKompas _kompas;
        private FlaskParameters _parameters = new FlaskParameters();
        public MainForm()
        {
            InitializeComponent();

        }
                    
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

        private void LengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != 44) && (e.KeyChar != 8))
                e.Handled = true;
        }

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
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, @"Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LengthTextBox_Leave(object sender, EventArgs e)
        {
            ValidateParameter(FlaskLengthTextBox);
        }

        private void ThicknessTextBox_Leave(object sender, EventArgs e)
        {
            ValidateParameter(CaseThicknessTextBox);
        }

        private void WidthTextBox_Leave(object sender, EventArgs e)
        {
            ValidateParameter(FlaskWidthTextBox);
        }

        private void NeckDiameterTextBox_Leave(object sender, EventArgs e)
        {
            ValidateParameter(NeckDiameterTextBox);
        }

        private void HeightTextBox_Leave(object sender, EventArgs e)
        {
            ValidateParameter(FlaskHeightTextBox);
        }

        private void NeckHeightTextBox_Leave(object sender, EventArgs e)
        {
            ValidateParameter(NeckHeightTextBox);
        }
    }
}
