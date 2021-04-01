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
        public MainForm()
        {
            InitializeComponent();
        }

        private void LengthTextBox_Enter(object sender, EventArgs e)
        {
            if(LengthTextBox.Text == "(70 - 120 мм)")
            {
                LengthTextBox.Clear();
                LengthTextBox.ForeColor = Color.Black;
            }
        }

        private void LengthTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LengthTextBox.Text))
            {
                LengthTextBox.Text = "(70 - 120 мм)";
                LengthTextBox.ForeColor = Color.Gray;
            }
        }

        private void WidthTextBox_Enter(object sender, EventArgs e)
        {
            if (WidthTextBox.Text == "(20 - 40 мм)")
            {
                WidthTextBox.Clear();
                WidthTextBox.ForeColor = Color.Black;
            }
        }

        private void WidthTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(WidthTextBox.Text))
            {
                WidthTextBox.Text = "(20 - 40 мм)";
                WidthTextBox.ForeColor = Color.Gray;
            }
        }

        private void HeightTextBox_Enter(object sender, EventArgs e)
        {
            if (HeightTextBox.Text == "(100 - 150 мм)")
            {
                HeightTextBox.Clear();
                HeightTextBox.ForeColor = Color.Black;
            }
        }

        private void HeightTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(HeightTextBox.Text))
            {
                HeightTextBox.Text = "(100 - 150 мм)";
                HeightTextBox.ForeColor = Color.Gray;
            }
        }

        private void ThicknessTextBox_Enter(object sender, EventArgs e)
        {
            if (ThicknessTextBox.Text == "(1 - 3 мм)")
            {
                ThicknessTextBox.Clear();
                ThicknessTextBox.ForeColor = Color.Black;
            }
        }

        private void ThicknessTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ThicknessTextBox.Text))
            {
                ThicknessTextBox.Text = "(1 - 3 мм)";
                ThicknessTextBox.ForeColor = Color.Gray;
            }
        }

        private void NeckDiameterTextBox_Enter(object sender, EventArgs e)
        {
            if (NeckDiameterTextBox.Text == "(10 - 20 мм)")
            {
                NeckDiameterTextBox.Clear();
                NeckDiameterTextBox.ForeColor = Color.Black;
            }
        }

        private void NeckDiameterTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NeckDiameterTextBox.Text))
            {
                NeckDiameterTextBox.Text = "(10 - 20 мм)";
                NeckDiameterTextBox.ForeColor = Color.Gray;
            }
        }

        private void NeckHeightTextBox_Enter(object sender, EventArgs e)
        {
            if (NeckHeightTextBox.Text == "(10 - 20 мм)")
            {
                NeckHeightTextBox.Clear();
                NeckHeightTextBox.ForeColor = Color.Black;
            }
        }

        private void NeckHeightTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NeckHeightTextBox.Text))
            {
                NeckHeightTextBox.Text = "(10 - 20 мм)";
                NeckHeightTextBox.ForeColor = Color.Gray;
            }
        }

        private void BuildModelButton_Click(object sender, EventArgs e)
        {
            BuildFlask();
        }

        public void BuildFlask()
        {
            try
            {
                var parameters = new FlaskParameters(double.Parse(LengthTextBox.Text),
                    double.Parse(WidthTextBox.Text),
                    double.Parse(HeightTextBox.Text),
                    double.Parse(ThicknessTextBox.Text),
                    double.Parse(NeckDiameterTextBox.Text),
                    double.Parse(NeckHeightTextBox.Text)
                    );
            }
            catch (FormatException)
            {
                MessageBox.Show("Данные введены некорректно. Возможно, заполнены не все обязательные поля или введены лишние запятые.", @"Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, @"Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != 44) && (e.KeyChar != 8))
                e.Handled = true;
        }
    }
}
