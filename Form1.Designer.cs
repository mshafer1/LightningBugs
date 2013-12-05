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
            this.btnNewGame = new System.Windows.Forms.Button();
            this.newGameScreen1 = new LightningBugs.NewGameScreen();
            this.SuspendLayout();
            // 
            // btnToggle
            // 
            this.btnToggle.BackColor = System.Drawing.Color.SeaShell;
            resources.ApplyResources(this.btnToggle, "btnToggle");
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.UseVisualStyleBackColor = false;
            this.btnToggle.Click += new System.EventHandler(this.pauseGame);
            // 
            // lblMode
            // 
            resources.ApplyResources(this.lblMode, "lblMode");
            this.lblMode.Name = "lblMode";
            // 
            // lblLevel
            // 
            resources.ApplyResources(this.lblLevel, "lblLevel");
            this.lblLevel.Name = "lblLevel";
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.SeaShell;
            resources.ApplyResources(this.btnContinue, "btnContinue");
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.pauseGame);
            // 
            // lblInstructions
            // 
            resources.ApplyResources(this.lblInstructions, "lblInstructions");
            this.lblInstructions.Name = "lblInstructions";
            // 
            // lblTime
            // 
            resources.ApplyResources(this.lblTime, "lblTime");
            this.lblTime.Name = "lblTime";
            // 
            // LiveTimer
            // 
            this.LiveTimer.Tick += new System.EventHandler(this.LiveTimer_Tick);
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.SeaShell;
            resources.ApplyResources(this.btnNewGame, "btnNewGame");
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // newGameScreen1
            // 
            this.newGameScreen1.BackColor = System.Drawing.Color.Azure;
            this.newGameScreen1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.newGameScreen1, "newGameScreen1");
            this.newGameScreen1.Name = "newGameScreen1";
            this.newGameScreen1.Start = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.newGameScreen1);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnToggle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.Resize += new System.EventHandler(this.Form1_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer LiveTimer;
        private System.Windows.Forms.Button btnNewGame;
        private NewGameScreen newGameScreen1;
    }
}