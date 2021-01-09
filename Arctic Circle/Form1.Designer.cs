
namespace Arctic_Circle
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.Start_Button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DrawInForm_Checkbox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.timeProjection_button = new System.Windows.Forms.Button();
            this.GetIntervals_button = new System.Windows.Forms.Button();
            this.ContinueRendering_checkbox = new System.Windows.Forms.CheckBox();
            this.SaveImageButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start_Button
            // 
            this.Start_Button.Location = new System.Drawing.Point(3, 3);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(75, 23);
            this.Start_Button.TabIndex = 0;
            this.Start_Button.Text = "Start";
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_button_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.DrawInForm_Checkbox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.timeProjection_button);
            this.panel1.Controls.Add(this.GetIntervals_button);
            this.panel1.Controls.Add(this.ContinueRendering_checkbox);
            this.panel1.Controls.Add(this.SaveImageButton);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Start_Button);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 334);
            this.panel1.TabIndex = 1;
            // 
            // DrawInForm_Checkbox
            // 
            this.DrawInForm_Checkbox.AutoSize = true;
            this.DrawInForm_Checkbox.Checked = true;
            this.DrawInForm_Checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DrawInForm_Checkbox.Location = new System.Drawing.Point(6, 240);
            this.DrawInForm_Checkbox.Name = "DrawInForm_Checkbox";
            this.DrawInForm_Checkbox.Size = new System.Drawing.Size(139, 21);
            this.DrawInForm_Checkbox.TabIndex = 17;
            this.DrawInForm_Checkbox.Text = "Draw in this Form";
            this.DrawInForm_Checkbox.UseVisualStyleBackColor = true;
            this.DrawInForm_Checkbox.CheckedChanged += new System.EventHandler(this.DrawInForm_Checkbox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(152, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "0";
            // 
            // timeProjection_button
            // 
            this.timeProjection_button.Location = new System.Drawing.Point(6, 267);
            this.timeProjection_button.Name = "timeProjection_button";
            this.timeProjection_button.Size = new System.Drawing.Size(140, 26);
            this.timeProjection_button.TabIndex = 15;
            this.timeProjection_button.Text = "Projected Time";
            this.timeProjection_button.UseVisualStyleBackColor = true;
            this.timeProjection_button.Click += new System.EventHandler(this.timeProjection_button_Click);
            // 
            // GetIntervals_button
            // 
            this.GetIntervals_button.Location = new System.Drawing.Point(6, 203);
            this.GetIntervals_button.Name = "GetIntervals_button";
            this.GetIntervals_button.Size = new System.Drawing.Size(106, 26);
            this.GetIntervals_button.TabIndex = 14;
            this.GetIntervals_button.Text = "Get Intervals";
            this.GetIntervals_button.UseVisualStyleBackColor = true;
            this.GetIntervals_button.Click += new System.EventHandler(this.GetIntervals_button_Click);
            // 
            // ContinueRendering_checkbox
            // 
            this.ContinueRendering_checkbox.AutoSize = true;
            this.ContinueRendering_checkbox.Location = new System.Drawing.Point(6, 299);
            this.ContinueRendering_checkbox.Name = "ContinueRendering_checkbox";
            this.ContinueRendering_checkbox.Size = new System.Drawing.Size(86, 21);
            this.ContinueRendering_checkbox.TabIndex = 13;
            this.ContinueRendering_checkbox.Text = "Continue";
            this.ContinueRendering_checkbox.UseVisualStyleBackColor = true;
            this.ContinueRendering_checkbox.CheckedChanged += new System.EventHandler(this.ContinueRendering_checkbox_CheckedChanged);
            // 
            // SaveImageButton
            // 
            this.SaveImageButton.Location = new System.Drawing.Point(6, 171);
            this.SaveImageButton.Name = "SaveImageButton";
            this.SaveImageButton.Size = new System.Drawing.Size(106, 26);
            this.SaveImageButton.TabIndex = 12;
            this.SaveImageButton.Text = "Save Image";
            this.SaveImageButton.UseVisualStyleBackColor = true;
            this.SaveImageButton.Click += new System.EventHandler(this.SaveImageButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(115, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "2^0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Possibilities:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Pause Interval";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(118, 108);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Rectangle Size";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(118, 80);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "End Size";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(118, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "50";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Start Size";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "MainWindow";
            this.Text = "Possibilities";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start_Button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SaveImageButton;
        private System.Windows.Forms.CheckBox ContinueRendering_checkbox;
        private System.Windows.Forms.Button GetIntervals_button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button timeProjection_button;
        private System.Windows.Forms.CheckBox DrawInForm_Checkbox;
    }
}

