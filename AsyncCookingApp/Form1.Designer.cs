namespace AsyncCookingApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnAsync = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.lbActionLogs = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblRadio = new System.Windows.Forms.Label();
            this.rtxtRadio = new System.Windows.Forms.RichTextBox();
            this.btnTurnOffTheRadio = new System.Windows.Forms.Button();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(678, 363);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(185, 55);
            this.btnSync.TabIndex = 0;
            this.btnSync.Text = "Start Cooking Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(881, 363);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(185, 57);
            this.btnAsync.TabIndex = 1;
            this.btnAsync.Text = "Start Cooking Async";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTimer.Location = new System.Drawing.Point(821, 12);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(63, 25);
            this.lblTimer.TabIndex = 11;
            this.lblTimer.Text = "Timer";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btn3);
            this.pnlButtons.Controls.Add(this.btn9);
            this.pnlButtons.Controls.Add(this.btn8);
            this.pnlButtons.Controls.Add(this.btn7);
            this.pnlButtons.Controls.Add(this.btn4);
            this.pnlButtons.Controls.Add(this.btn5);
            this.pnlButtons.Controls.Add(this.btn2);
            this.pnlButtons.Controls.Add(this.btn6);
            this.pnlButtons.Controls.Add(this.btn1);
            this.pnlButtons.Controls.Add(this.btn0);
            this.pnlButtons.Location = new System.Drawing.Point(12, 12);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(238, 410);
            this.pnlButtons.TabIndex = 12;
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(0, 126);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(235, 35);
            this.btn3.TabIndex = 9;
            this.btn3.Text = "Turn On The Stove";
            this.btn3.UseVisualStyleBackColor = true;
            // 
            // btn9
            // 
            this.btn9.Location = new System.Drawing.Point(0, 372);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(235, 35);
            this.btn9.TabIndex = 8;
            this.btn9.Text = "Serve";
            this.btn9.UseVisualStyleBackColor = true;
            // 
            // btn8
            // 
            this.btn8.Location = new System.Drawing.Point(0, 331);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(235, 35);
            this.btn8.TabIndex = 7;
            this.btn8.Text = "Cook";
            this.btn8.UseVisualStyleBackColor = true;
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(0, 290);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(235, 35);
            this.btn7.TabIndex = 6;
            this.btn7.Text = "Pour The Beaten Eggs";
            this.btn7.UseVisualStyleBackColor = true;
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(0, 167);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(235, 35);
            this.btn4.TabIndex = 5;
            this.btn4.Text = "Pour The Oil";
            this.btn4.UseVisualStyleBackColor = true;
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(0, 208);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(235, 35);
            this.btn5.TabIndex = 4;
            this.btn5.Text = "Heat The Pan";
            this.btn5.UseVisualStyleBackColor = true;
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(0, 85);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(235, 35);
            this.btn2.TabIndex = 3;
            this.btn2.Text = "Put The Pan";
            this.btn2.UseVisualStyleBackColor = true;
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(0, 249);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(235, 35);
            this.btn6.TabIndex = 1;
            this.btn6.Text = "Beat The Eggs";
            this.btn6.UseVisualStyleBackColor = true;
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(0, 44);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(235, 35);
            this.btn1.TabIndex = 2;
            this.btn1.Text = "Add The Salt";
            this.btn1.UseVisualStyleBackColor = true;
            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(0, 3);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(235, 35);
            this.btn0.TabIndex = 0;
            this.btn0.Text = "Crack The Eggs";
            this.btn0.UseVisualStyleBackColor = true;
            // 
            // lbActionLogs
            // 
            this.lbActionLogs.FormattingEnabled = true;
            this.lbActionLogs.ItemHeight = 15;
            this.lbActionLogs.Location = new System.Drawing.Point(274, 15);
            this.lbActionLogs.Name = "lbActionLogs";
            this.lbActionLogs.Size = new System.Drawing.Size(380, 409);
            this.lbActionLogs.TabIndex = 13;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRadio.Location = new System.Drawing.Point(821, 58);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(120, 25);
            this.lblRadio.TabIndex = 14;
            this.lblRadio.Text = "Recipe Radio";
            // 
            // rtxtRadio
            // 
            this.rtxtRadio.Location = new System.Drawing.Point(678, 97);
            this.rtxtRadio.Name = "rtxtRadio";
            this.rtxtRadio.Size = new System.Drawing.Size(388, 176);
            this.rtxtRadio.TabIndex = 15;
            this.rtxtRadio.Text = "";
            // 
            // btnTurnOffTheRadio
            // 
            this.btnTurnOffTheRadio.Location = new System.Drawing.Point(789, 290);
            this.btnTurnOffTheRadio.Name = "btnTurnOffTheRadio";
            this.btnTurnOffTheRadio.Size = new System.Drawing.Size(185, 55);
            this.btnTurnOffTheRadio.TabIndex = 16;
            this.btnTurnOffTheRadio.Text = "Turn Off The Radio";
            this.btnTurnOffTheRadio.UseVisualStyleBackColor = true;
            this.btnTurnOffTheRadio.Click += new System.EventHandler(this.btnTurnOffTheRadio_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 442);
            this.Controls.Add(this.btnTurnOffTheRadio);
            this.Controls.Add(this.rtxtRadio);
            this.Controls.Add(this.lblRadio);
            this.Controls.Add(this.lbActionLogs);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnAsync);
            this.Controls.Add(this.btnSync);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSync;
        private Button btnAsync;
        private Label lblTimer;
        private Panel pnlButtons;
        private Button btn9;
        private Button btn8;
        private Button btn7;
        private Button btn4;
        private Button btn5;
        private Button btn2;
        private Button btn1;
        private Button btn6;
        private Button btn0;
        private ListBox lbActionLogs;
        private Button btn3;
        private System.Windows.Forms.Timer timer1;
        private Label lblRadio;
        private RichTextBox rtxtRadio;
        private Button btnTurnOffTheRadio;
    }
}