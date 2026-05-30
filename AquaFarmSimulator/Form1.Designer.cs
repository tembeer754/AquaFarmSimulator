namespace AquaFarmSimulator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lstLog = new ListBox();
            btnOpenShop = new Button();
            lblMoney = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            gameTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lstLog
            // 
            lstLog.Location = new Point(12, 40);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(250, 444);
            lstLog.TabIndex = 0;
            // 
            // btnOpenShop
            // 
            btnOpenShop.Location = new Point(12, 530);
            btnOpenShop.Name = "btnOpenShop";
            btnOpenShop.Size = new Size(250, 40);
            btnOpenShop.TabIndex = 1;
            btnOpenShop.Text = "МАГАЗИН";
            btnOpenShop.Click += btnOpenShop_Click;
            // 
            // lblMoney
            // 
            lblMoney.Location = new Point(12, 500);
            lblMoney.Name = "lblMoney";
            lblMoney.Size = new Size(100, 23);
            lblMoney.TabIndex = 2;
            lblMoney.Text = "Баланс: $1000";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(280, 10);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(800, 580);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 4000;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // Form1
            // 
            ClientSize = new Size(1100, 600);
            Controls.Add(lstLog);
            Controls.Add(btnOpenShop);
            Controls.Add(lblMoney);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            Text = "Симулятор Акваферми v1.2";
            ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button btnOpenShop;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer gameTimer;
    }
}