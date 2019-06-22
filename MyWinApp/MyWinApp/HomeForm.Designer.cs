namespace MyWinApp
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ShowButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.itemComboBox = new System.Windows.Forms.ComboBox();
            this.showlabel = new System.Windows.Forms.Label();
            this.showTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ShowButton
            // 
            this.ShowButton.Location = new System.Drawing.Point(587, 85);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(75, 23);
            this.ShowButton.TabIndex = 0;
            this.ShowButton.Text = "Show";
            this.ShowButton.UseVisualStyleBackColor = true;
            this.ShowButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(125, 57);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // itemComboBox
            // 
            this.itemComboBox.FormattingEnabled = true;
            this.itemComboBox.Items.AddRange(new object[] {
            "Pen",
            "Pencil"});
            this.itemComboBox.Location = new System.Drawing.Point(125, 86);
            this.itemComboBox.Name = "itemComboBox";
            this.itemComboBox.Size = new System.Drawing.Size(121, 21);
            this.itemComboBox.TabIndex = 3;
            // 
            // showlabel
            // 
            this.showlabel.AutoSize = true;
            this.showlabel.Location = new System.Drawing.Point(131, 150);
            this.showlabel.Name = "showlabel";
            this.showlabel.Size = new System.Drawing.Size(0, 13);
            this.showlabel.TabIndex = 4;
            // 
            // showTextBox
            // 
            this.showTextBox.Location = new System.Drawing.Point(134, 185);
            this.showTextBox.Name = "showTextBox";
            this.showTextBox.Size = new System.Drawing.Size(100, 20);
            this.showTextBox.TabIndex = 5;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.showTextBox);
            this.Controls.Add(this.showlabel);
            this.Controls.Add(this.itemComboBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowButton);
            this.Name = "HomeForm";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox itemComboBox;
        private System.Windows.Forms.Label showlabel;
        private System.Windows.Forms.TextBox showTextBox;
    }
}

