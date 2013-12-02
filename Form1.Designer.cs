namespace LightningBugs
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.newGameScreen1 = new LightningBugs.NewGameScreen();
            this.btnToggle = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newGameScreen1
            // 
            this.newGameScreen1.Location = new System.Drawing.Point(31, 25);
            this.newGameScreen1.Name = "newGameScreen1";
            this.newGameScreen1.Size = new System.Drawing.Size(352, 211);
            this.newGameScreen1.Start = false;
            this.newGameScreen1.TabIndex = 0;
            // 
            // btnToggle
            // 
            this.btnToggle.Location = new System.Drawing.Point(172, 414);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(75, 23);
            this.btnToggle.TabIndex = 1;
            this.btnToggle.Text = "button1";
            this.btnToggle.UseVisualStyleBackColor = true;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(12, 414);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(35, 13);
            this.lblMode.TabIndex = 2;
            this.lblMode.Text = "label1";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(348, 414);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(35, 13);
            this.lblLevel.TabIndex = 2;
            this.lblLevel.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 444);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.newGameScreen1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NewGameScreen newGameScreen1;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblLevel;
    }
}