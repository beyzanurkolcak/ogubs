namespace ogubsapp
{
    partial class Form4
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
            this.tanimliogrenci = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tanimliogrenci
            // 
            this.tanimliogrenci.FormattingEnabled = true;
            this.tanimliogrenci.ItemHeight = 16;
            this.tanimliogrenci.Location = new System.Drawing.Point(33, 12);
            this.tanimliogrenci.Name = "tanimliogrenci";
            this.tanimliogrenci.Size = new System.Drawing.Size(245, 244);
            this.tanimliogrenci.TabIndex = 0;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 697);
            this.Controls.Add(this.tanimliogrenci);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox tanimliogrenci;
    }
}