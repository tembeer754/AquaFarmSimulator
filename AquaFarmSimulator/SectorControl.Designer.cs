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
            btnAction = new Button();
            SuspendLayout();
            
            // lblName
            
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName.Location = new Point(10, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(180, 25);
            lblName.TabIndex = 0;
            lblName.Text = "Вид";
            lblName.Click += lblName_Click;
            
            // prgHealth
            
            prgHealth.Location = new Point(10, 28);
            prgHealth.Name = "prgHealth";
            prgHealth.Size = new Size(180, 23);
            prgHealth.TabIndex = 1;
            prgHealth.Value = 100;
            
            // lblStatus
            
            lblStatus.Location = new Point(10, 63);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(180, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Статус: ОК";
            lblStatus.Click += lblStatus_Click;
            
            // btnFeed
            
            btnFeed.Location = new Point(14, 126);
            btnFeed.Name = "btnFeed";
            btnFeed.Size = new Size(85, 30);
            btnFeed.TabIndex = 5;
            btnFeed.Text = "Годувати";
            btnFeed.Click += btnFeed_Click;
            
            // btnRepair
            
            btnRepair.Location = new Point(105, 126);
            btnRepair.Name = "btnRepair";
            btnRepair.Size = new Size(85, 30);
            btnRepair.TabIndex = 6;
            btnRepair.Text = "Ремонт";
            btnRepair.Click += btnRepair_Click;
            
            // lblOxygen
            
            lblOxygen.Location = new Point(10, 83);
            lblOxygen.Name = "lblOxygen";
            lblOxygen.Size = new Size(180, 20);
            lblOxygen.TabIndex = 3;
            lblOxygen.Text = "Кисень: 100%";
            
            // lblHunger
            
            lblHunger.Location = new Point(10, 103);
            lblHunger.Name = "lblHunger";
            lblHunger.Size = new Size(180, 20);
            lblHunger.TabIndex = 4;
            lblHunger.Text = "Голод: 0%";
            lblHunger.Click += lblHunger_Click;
            
            // btnAction
           
            btnAction.Location = new Point(10, 167);
            btnAction.Name = "btnAction";
            btnAction.Size = new Size(180, 30);
            btnAction.TabIndex = 7;
            btnAction.Text = "Забрати / Помістити";
            btnAction.Click += btnAction_Click;
           
            // SectorControl
            
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblName);
            Controls.Add(prgHealth);
            Controls.Add(lblStatus);
            Controls.Add(lblOxygen);
            Controls.Add(lblHunger);
            Controls.Add(btnFeed);
            Controls.Add(btnRepair);
            Controls.Add(btnAction);
            Name = "SectorControl";
            Size = new Size(200, 200);
            Load += SectorControl_Load;
            ResumeLayout(false);

            this.menuFeed = new System.Windows.Forms.ContextMenuStrip(this.components);

      
            var itemFishFood = new System.Windows.Forms.ToolStripMenuItem("Сухий корм (для риб)", null, (s, e) => ProcessFeeding(Models.FoodType.FishFood));
            var itemMeat = new System.Windows.Forms.ToolStripMenuItem("М'ясо (для акул)", null, (s, e) => ProcessFeeding(Models.FoodType.SharkMeat));
            var itemPlankton = new System.Windows.Forms.ToolStripMenuItem("Планктон (для молюсків)", null, (s, e) => ProcessFeeding(Models.FoodType.MolluskPlankton));
            var itemFertilizer = new System.Windows.Forms.ToolStripMenuItem("Добрива (для водоростей)", null, (s, e) => ProcessFeeding(Models.FoodType.AlgaeFertilizer));

   
            this.menuFeed.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { itemFishFood, itemMeat, itemPlankton, itemFertilizer });
            this.btnFeed.ContextMenuStrip = this.menuFeed;
        }

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ProgressBar prgHealth;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnFeed;
        private System.Windows.Forms.Button btnRepair;
        private System.Windows.Forms.Label lblOxygen;
        private System.Windows.Forms.Label lblHunger;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.ContextMenuStrip menuFeed;
    }
}