namespace MyWinApp
{
    partial class DataTypeForm
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
            this.dataTypeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataTypeButton
            // 
            this.dataTypeButton.Location = new System.Drawing.Point(533, 58);
            this.dataTypeButton.Name = "dataTypeButton";
            this.dataTypeButton.Size = new System.Drawing.Size(75, 23);
            this.dataTypeButton.TabIndex = 0;
            this.dataTypeButton.Text = "Data Type";
            this.dataTypeButton.UseVisualStyleBackColor = true;
            this.dataTypeButton.Click += new System.EventHandler(this.dataTypeButton_Click);
            // 
            // DataTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataTypeButton);
            this.Name = "DataTypeForm";
            this.Text = "Data Type ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button dataTypeButton;
    }
}