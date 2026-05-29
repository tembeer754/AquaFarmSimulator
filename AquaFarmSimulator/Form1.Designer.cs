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
            flowLayoutPanel1 = new FlowLayoutPanel();
            gameTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            
            // flowLayoutPanel1
            
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(914, 600);
            flowLayoutPanel1.TabIndex = 0;
            
            // gameTimer
            
            gameTimer.Interval = 2000;
            gameTimer.Tick += gameTimer_Tick;
            
            // Form1
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Симулятор акваферми";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer gameTimer;
    }
}