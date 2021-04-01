
namespace FlaskUI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ThicknessTextBox = new System.Windows.Forms.TextBox();
            this.NeckDiameterTextBox = new System.Windows.Forms.TextBox();
            this.NeckHeightTextBox = new System.Windows.Forms.TextBox();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.LengthTextBox = new System.Windows.Forms.TextBox();
            this.BuildModelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ThicknessTextBox);
            this.groupBox1.Controls.Add(this.NeckDiameterTextBox);
            this.groupBox1.Controls.Add(this.NeckHeightTextBox);
            this.groupBox1.Controls.Add(this.HeightTextBox);
            this.groupBox1.Controls.Add(this.WidthTextBox);
            this.groupBox1.Controls.Add(this.LengthTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 169);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 115);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Высота горлышка: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Диаметр горлышка:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Толщина стенки фляжки:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Высота фляжки:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ширина фляжки:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Длина фляжки:";
            // 
            // ThicknessTextBox
            // 
            this.ThicknessTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ThicknessTextBox.Location = new System.Drawing.Point(203, 40);
            this.ThicknessTextBox.Name = "ThicknessTextBox";
            this.ThicknessTextBox.Size = new System.Drawing.Size(100, 20);
            this.ThicknessTextBox.TabIndex = 5;
            this.ThicknessTextBox.Text = "(1 - 3 мм)";
            this.ThicknessTextBox.Enter += new System.EventHandler(this.ThicknessTextBox_Enter);
            this.ThicknessTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LengthTextBox_KeyPress);
            this.ThicknessTextBox.Leave += new System.EventHandler(this.ThicknessTextBox_Leave);
            // 
            // NeckDiameterTextBox
            // 
            this.NeckDiameterTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.NeckDiameterTextBox.Location = new System.Drawing.Point(203, 87);
            this.NeckDiameterTextBox.Name = "NeckDiameterTextBox";
            this.NeckDiameterTextBox.Size = new System.Drawing.Size(100, 20);
            this.NeckDiameterTextBox.TabIndex = 4;
            this.NeckDiameterTextBox.Text = "(10 - 20 мм)";
            this.NeckDiameterTextBox.Enter += new System.EventHandler(this.NeckDiameterTextBox_Enter);
            this.NeckDiameterTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LengthTextBox_KeyPress);
            this.NeckDiameterTextBox.Leave += new System.EventHandler(this.NeckDiameterTextBox_Leave);
            // 
            // NeckHeightTextBox
            // 
            this.NeckHeightTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.NeckHeightTextBox.Location = new System.Drawing.Point(203, 134);
            this.NeckHeightTextBox.Name = "NeckHeightTextBox";
            this.NeckHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.NeckHeightTextBox.TabIndex = 3;
            this.NeckHeightTextBox.Text = "(10 - 20 мм)";
            this.NeckHeightTextBox.Enter += new System.EventHandler(this.NeckHeightTextBox_Enter);
            this.NeckHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LengthTextBox_KeyPress);
            this.NeckHeightTextBox.Leave += new System.EventHandler(this.NeckHeightTextBox_Leave);
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.HeightTextBox.Location = new System.Drawing.Point(9, 134);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.HeightTextBox.TabIndex = 2;
            this.HeightTextBox.Text = "(100 - 150 мм)";
            this.HeightTextBox.Enter += new System.EventHandler(this.HeightTextBox_Enter);
            this.HeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LengthTextBox_KeyPress);
            this.HeightTextBox.Leave += new System.EventHandler(this.HeightTextBox_Leave);
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.WidthTextBox.Location = new System.Drawing.Point(9, 87);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(100, 20);
            this.WidthTextBox.TabIndex = 1;
            this.WidthTextBox.Text = "(20 - 40 мм)";
            this.WidthTextBox.Enter += new System.EventHandler(this.WidthTextBox_Enter);
            this.WidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LengthTextBox_KeyPress);
            this.WidthTextBox.Leave += new System.EventHandler(this.WidthTextBox_Leave);
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LengthTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LengthTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LengthTextBox.Location = new System.Drawing.Point(9, 40);
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.Size = new System.Drawing.Size(100, 20);
            this.LengthTextBox.TabIndex = 0;
            this.LengthTextBox.Text = "(70 - 120 мм)";
            this.LengthTextBox.Enter += new System.EventHandler(this.LengthTextBox_Enter);
            this.LengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LengthTextBox_KeyPress);
            this.LengthTextBox.Leave += new System.EventHandler(this.LengthTextBox_Leave);
            // 
            // BuildModelButton
            // 
            this.BuildModelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildModelButton.Location = new System.Drawing.Point(241, 187);
            this.BuildModelButton.Name = "BuildModelButton";
            this.BuildModelButton.Size = new System.Drawing.Size(122, 23);
            this.BuildModelButton.TabIndex = 1;
            this.BuildModelButton.Text = "Построить модель";
            this.BuildModelButton.UseVisualStyleBackColor = true;
            this.BuildModelButton.Click += new System.EventHandler(this.BuildModelButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 219);
            this.Controls.Add(this.BuildModelButton);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(391, 258);
            this.MinimumSize = new System.Drawing.Size(391, 258);
            this.Name = "MainForm";
            this.Text = "FlaskPlugin";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ThicknessTextBox;
        private System.Windows.Forms.TextBox NeckDiameterTextBox;
        private System.Windows.Forms.TextBox NeckHeightTextBox;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.TextBox LengthTextBox;
        private System.Windows.Forms.Button BuildModelButton;
    }
}

