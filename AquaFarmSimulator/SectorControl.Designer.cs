namespace AquaFarmSimulator
{
    partial class SectorControl
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
            lblName = new Label();
            prgHealth = new ProgressBar();
            lblStatus = new Label();
            btnFeed = new Button();
            btnRepair = new Button();
            lblOxygen = new Label();
            lblHunger = new Label();
            SuspendLayout();
            
            // lblName
           
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName.Location = new Point(10, 10);
            lblName.Name = "lblName";
            lblName.Size = new Size(180, 25);
            lblName.TabIndex = 0;
            lblName.Text = "Вид";
            lblName.Click += lblName_Click;
            
            // prgHealth
           
            prgHealth.Location = new Point(10, 40);
            prgHealth.Name = "prgHealth";
            prgHealth.Size = new Size(180, 23);
            prgHealth.TabIndex = 1;
            prgHealth.Value = 100;
            
            // lblStatus
            
            lblStatus.Location = new Point(10, 70);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(180, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Статус: ОК";
            lblStatus.Click += lblStatus_Click;
            
            // btnFeed
            
            btnFeed.Location = new Point(10, 150);
            btnFeed.Name = "btnFeed";
            btnFeed.Size = new Size(85, 30);
            btnFeed.TabIndex = 5;
            btnFeed.Text = "Годувати";
            btnFeed.Click += btnFeed_Click;
            
            // btnRepair
            
            btnRepair.Location = new Point(105, 150);
            btnRepair.Name = "btnRepair";
            btnRepair.Size = new Size(85, 30);
            btnRepair.TabIndex = 6;
            btnRepair.Text = "Ремонт";
            btnRepair.Click += btnRepair_Click;
            
            // lblOxygen
            
            lblOxygen.Location = new Point(10, 95);
            lblOxygen.Name = "lblOxygen";
            lblOxygen.Size = new Size(180, 20);
            lblOxygen.TabIndex = 3;
            lblOxygen.Text = "Кисень: 100%";
            
            // lblHunger
            
            lblHunger.Location = new Point(10, 120);
            lblHunger.Name = "lblHunger";
            lblHunger.Size = new Size(180, 20);
            lblHunger.TabIndex = 4;
            lblHunger.Text = "Голод: 0%";
            lblHunger.Click += lblHunger_Click;
            
            // SectorControl
            
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblName);
            Controls.Add(prgHealth);
            Controls.Add(lblStatus);
            Controls.Add(lblOxygen);
            Controls.Add(lblHunger);
            Controls.Add(btnFeed);
            Controls.Add(btnRepair);
            Name = "SectorControl";
            Size = new Size(200, 200);
            Load += SectorControl_Load;
            ResumeLayout(false);

            // У файлі SectorControl.Designer.cs (InitializeComponent)
            this.btnAction = new System.Windows.Forms.Button();
            this.btnAction.Location = new System.Drawing.Point(10, 185); 
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(180, 30);
            this.btnAction.Text = "Забрати / Помістити";
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            this.Controls.Add(this.btnAction);



    }

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ProgressBar prgHealth;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnFeed;
        private System.Windows.Forms.Button btnRepair;
        private System.Windows.Forms.Label lblOxygen;
        private System.Windows.Forms.Label lblHunger;
        private System.Windows.Forms.Button btnAction;
    }
}