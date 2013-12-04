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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnToggle = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.LiveTimer = new System.Windows.Forms.Timer(this.components);
            this.newGameScreen1 = new LightningBugs.NewGameScreen();
            this.SuspendLayout();
            // 
            // btnToggle
            // 
            this.btnToggle.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggle.Location = new System.Drawing.Point(90, 306);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(118, 33);
            this.btnToggle.TabIndex = 1;
            this.btnToggle.Text = "Pause Game";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.pauseGame);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(21, 311);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(53, 23);
            this.lblMode.TabIndex = 2;
            this.lblMode.Text = "label1";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(236, 311);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(53, 23);
            this.lblLevel.TabIndex = 2;
            this.lblLevel.Text = "label1";
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Kristen ITC", 12F);
            this.btnContinue.Location = new System.Drawing.Point(102, 345);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(93, 32);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Visible = false;
            this.btnContinue.Click += new System.EventHandler(this.pauseGame);
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.Location = new System.Drawing.Point(201, 353);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(162, 26);
            this.lblInstructions.TabIndex = 5;
            this.lblInstructions.Text = "lblInstructions";
            this.lblInstructions.Visible = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Kristen ITC", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(295, 308);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(64, 27);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "label1";
            // 
            // LiveTimer
            // 
            this.LiveTimer.Tick += new System.EventHandler(this.LiveTimer_Tick);
            // 
            // newGameScreen1
            // 
            this.newGameScreen1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.newGameScreen1.Location = new System.Drawing.Point(12, 1);
            this.newGameScreen1.Name = "newGameScreen1";
            this.newGameScreen1.Size = new System.Drawing.Size(305, 300);
            this.newGameScreen1.Start = false;
            this.newGameScreen1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 310);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.newGameScreen1);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnToggle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblLevel;
        private NewGameScreen newGameScreen1;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer LiveTimer;
    }
}