
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
            this.DrawInForm_checkbox = new System.Windows.Forms.CheckBox();
            this.ProjectedTime_label = new System.Windows.Forms.Label();
            this.timeProjection_button = new System.Windows.Forms.Button();
            this.GetIntervals_button = new System.Windows.Forms.Button();
            this.ContinueRendering_checkbox = new System.Windows.Forms.CheckBox();
            this.SaveImage_button = new System.Windows.Forms.Button();
            this.PossibilitiesCount_label = new System.Windows.Forms.Label();
            this.Possibilities_label = new System.Windows.Forms.Label();
            this.PauseInterval_label = new System.Windows.Forms.Label();
            this.PauseInterval_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RectangleSize_label = new System.Windows.Forms.Label();
            this.RectangleSize_textBox = new System.Windows.Forms.TextBox();
            this.EndSize_Label = new System.Windows.Forms.Label();
            this.StartSize_textBox = new System.Windows.Forms.TextBox();
            this.EndSize_textBox = new System.Windows.Forms.TextBox();
            this.StartSize_label = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.DrawInForm_checkbox);
            this.panel1.Controls.Add(this.ProjectedTime_label);
            this.panel1.Controls.Add(this.timeProjection_button);
            this.panel1.Controls.Add(this.GetIntervals_button);
            this.panel1.Controls.Add(this.ContinueRendering_checkbox);
            this.panel1.Controls.Add(this.SaveImage_button);
            this.panel1.Controls.Add(this.PossibilitiesCount_label);
            this.panel1.Controls.Add(this.Possibilities_label);
            this.panel1.Controls.Add(this.PauseInterval_label);
            this.panel1.Controls.Add(this.PauseInterval_textBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.RectangleSize_label);
            this.panel1.Controls.Add(this.RectangleSize_textBox);
            this.panel1.Controls.Add(this.EndSize_Label);
            this.panel1.Controls.Add(this.StartSize_textBox);
            this.panel1.Controls.Add(this.EndSize_textBox);
            this.panel1.Controls.Add(this.StartSize_label);
            this.panel1.Controls.Add(this.Start_Button);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 334);
            this.panel1.TabIndex = 1;
            // 
            // DrawInForm_checkbox
            // 
            this.DrawInForm_checkbox.AutoSize = true;
            this.DrawInForm_checkbox.Checked = true;
            this.DrawInForm_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DrawInForm_checkbox.Location = new System.Drawing.Point(6, 240);
            this.DrawInForm_checkbox.Name = "DrawInForm_checkbox";
            this.DrawInForm_checkbox.Size = new System.Drawing.Size(139, 21);
            this.DrawInForm_checkbox.TabIndex = 17;
            this.DrawInForm_checkbox.Text = "Draw in this Form";
            this.DrawInForm_checkbox.UseVisualStyleBackColor = true;
            this.DrawInForm_checkbox.CheckedChanged += new System.EventHandler(this.DrawInForm_Checkbox_CheckedChanged);
            // 
            // ProjectedTime_label
            // 
            this.ProjectedTime_label.AutoSize = true;
            this.ProjectedTime_label.Location = new System.Drawing.Point(152, 272);
            this.ProjectedTime_label.Name = "ProjectedTime_label";
            this.ProjectedTime_label.Size = new System.Drawing.Size(16, 17);
            this.ProjectedTime_label.TabIndex = 16;
            this.ProjectedTime_label.Text = "0";
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
            // SaveImage_button
            // 
            this.SaveImage_button.Location = new System.Drawing.Point(6, 171);
            this.SaveImage_button.Name = "SaveImage_button";
            this.SaveImage_button.Size = new System.Drawing.Size(106, 26);
            this.SaveImage_button.TabIndex = 12;
            this.SaveImage_button.Text = "Save Image";
            this.SaveImage_button.UseVisualStyleBackColor = true;
            this.SaveImage_button.Click += new System.EventHandler(this.SaveImageButton_Click);
            // 
            // PossibilitiesCount_label
            // 
            this.PossibilitiesCount_label.AutoSize = true;
            this.PossibilitiesCount_label.ForeColor = System.Drawing.Color.White;
            this.PossibilitiesCount_label.Location = new System.Drawing.Point(115, 145);
            this.PossibilitiesCount_label.Name = "PossibilitiesCount_label";
            this.PossibilitiesCount_label.Size = new System.Drawing.Size(31, 17);
            this.PossibilitiesCount_label.TabIndex = 11;
            this.PossibilitiesCount_label.Text = "2^0";
            // 
            // Possibilities_label
            // 
            this.Possibilities_label.AutoSize = true;
            this.Possibilities_label.ForeColor = System.Drawing.Color.White;
            this.Possibilities_label.Location = new System.Drawing.Point(3, 145);
            this.Possibilities_label.Name = "Possibilities_label";
            this.Possibilities_label.Size = new System.Drawing.Size(85, 17);
            this.Possibilities_label.TabIndex = 10;
            this.Possibilities_label.Text = "Possibilities:";
            // 
            // PauseInterval_label
            // 
            this.PauseInterval_label.AutoSize = true;
            this.PauseInterval_label.Location = new System.Drawing.Point(3, 111);
            this.PauseInterval_label.Name = "PauseInterval_label";
            this.PauseInterval_label.Size = new System.Drawing.Size(98, 17);
            this.PauseInterval_label.TabIndex = 9;
            this.PauseInterval_label.Text = "Pause Interval";
            // 
            // PauseInterval_textBox
            // 
            this.PauseInterval_textBox.Location = new System.Drawing.Point(118, 108);
            this.PauseInterval_textBox.Name = "PauseInterval_textBox";
            this.PauseInterval_textBox.Size = new System.Drawing.Size(100, 22);
            this.PauseInterval_textBox.TabIndex = 8;
            this.PauseInterval_textBox.Text = "0";
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
            // RectangleSize_label
            // 
            this.RectangleSize_label.AutoSize = true;
            this.RectangleSize_label.Location = new System.Drawing.Point(3, 83);
            this.RectangleSize_label.Name = "RectangleSize_label";
            this.RectangleSize_label.Size = new System.Drawing.Size(103, 17);
            this.RectangleSize_label.TabIndex = 6;
            this.RectangleSize_label.Text = "Rectangle Size";
            // 
            // RectangleSize_textBox
            // 
            this.RectangleSize_textBox.Location = new System.Drawing.Point(118, 80);
            this.RectangleSize_textBox.Name = "RectangleSize_textBox";
            this.RectangleSize_textBox.Size = new System.Drawing.Size(100, 22);
            this.RectangleSize_textBox.TabIndex = 3;
            this.RectangleSize_textBox.Text = "1";
            // 
            // EndSize_Label
            // 
            this.EndSize_Label.AutoSize = true;
            this.EndSize_Label.Location = new System.Drawing.Point(3, 55);
            this.EndSize_Label.Name = "EndSize_Label";
            this.EndSize_Label.Size = new System.Drawing.Size(64, 17);
            this.EndSize_Label.TabIndex = 5;
            this.EndSize_Label.Text = "End Size";
            // 
            // StartSize_textBox
            // 
            this.StartSize_textBox.Location = new System.Drawing.Point(118, 26);
            this.StartSize_textBox.Name = "StartSize_textBox";
            this.StartSize_textBox.Size = new System.Drawing.Size(100, 22);
            this.StartSize_textBox.TabIndex = 2;
            this.StartSize_textBox.Text = "1";
            // 
            // EndSize_textBox
            // 
            this.EndSize_textBox.Location = new System.Drawing.Point(118, 52);
            this.EndSize_textBox.Name = "EndSize_textBox";
            this.EndSize_textBox.Size = new System.Drawing.Size(100, 22);
            this.EndSize_textBox.TabIndex = 1;
            this.EndSize_textBox.Text = "50";
            // 
            // StartSize_label
            // 
            this.StartSize_label.AutoSize = true;
            this.StartSize_label.Location = new System.Drawing.Point(3, 29);
            this.StartSize_label.Name = "StartSize_label";
            this.StartSize_label.Size = new System.Drawing.Size(69, 17);
            this.StartSize_label.TabIndex = 4;
            this.StartSize_label.Text = "Start Size";
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
        private System.Windows.Forms.TextBox StartSize_textBox;
        private System.Windows.Forms.TextBox EndSize_textBox;
        private System.Windows.Forms.Label RectangleSize_label;
        private System.Windows.Forms.TextBox RectangleSize_textBox;
        private System.Windows.Forms.Label EndSize_Label;
        private System.Windows.Forms.Label StartSize_label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label PauseInterval_label;
        private System.Windows.Forms.TextBox PauseInterval_textBox;
        private System.Windows.Forms.Label PossibilitiesCount_label;
        private System.Windows.Forms.Label Possibilities_label;
        private System.Windows.Forms.Button SaveImage_button;
        private System.Windows.Forms.CheckBox ContinueRendering_checkbox;
        private System.Windows.Forms.Button GetIntervals_button;
        private System.Windows.Forms.Label ProjectedTime_label;
        private System.Windows.Forms.Button timeProjection_button;
        private System.Windows.Forms.CheckBox DrawInForm_checkbox;
    }
}

