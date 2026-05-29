namespace AquaFarmSimulator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gameTimer = new System.Windows.Forms.Timer(components);
            splitContainer1 = new SplitContainer();
            lstLog = new ListBox();
            btnOpenShop = new Button();
            lblMoney = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            
            // gameTimer
            
            gameTimer.Interval = 2000;
            gameTimer.Tick += gameTimer_Tick;
            
            // splitContainer1
            
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            
            // splitContainer1.Panel1
            
            splitContainer1.Panel1.Controls.Add(lblMoney);
            splitContainer1.Panel1.Controls.Add(btnOpenShop);
            splitContainer1.Panel1.Controls.Add(lstLog);
            
            // splitContainer1.Panel2
            
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel1);
            splitContainer1.Size = new Size(914, 600);
            splitContainer1.SplitterDistance = 304;
            splitContainer1.TabIndex = 0;
            
            // lstLog
            
            lstLog.Dock = DockStyle.Top;
            lstLog.FormattingEnabled = true;
            lstLog.Location = new Point(0, 0);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(304, 104);
            lstLog.TabIndex = 0;
            lstLog.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            
            // btnOpenShop
            
            btnOpenShop.Location = new Point(3, 110);
            btnOpenShop.Name = "btnOpenShop";
            btnOpenShop.Size = new Size(142, 55);
            btnOpenShop.TabIndex = 1;
            btnOpenShop.Text = "Відкрити магазин";
            btnOpenShop.UseVisualStyleBackColor = true;
            
            // lblMoney
            
            lblMoney.AutoSize = true;
            lblMoney.Location = new Point(3, 168);
            lblMoney.Name = "lblMoney";
            lblMoney.Size = new Size(112, 20);
            lblMoney.TabIndex = 2;
            lblMoney.Text = "Баланс - 1000$";
            
            // flowLayoutPanel1
            
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(606, 600);
            flowLayoutPanel1.TabIndex = 0;
            
            // Form1
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Симулятор акваферми";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Timer gameTimer;
        private SplitContainer splitContainer1;
        private ListBox lstLog;
        private Label lblMoney;
        private Button btnOpenShop;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}