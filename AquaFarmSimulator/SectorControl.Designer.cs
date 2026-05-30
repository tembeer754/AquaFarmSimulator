namespace AquaFarmSimulator
{
    partial class SectorControl
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblName = new System.Windows.Forms.Label();
            prgHealth = new System.Windows.Forms.ProgressBar();
            lblStatus = new System.Windows.Forms.Label();
            lblOxygen = new System.Windows.Forms.Label();
            lblHunger = new System.Windows.Forms.Label();
            btnFeed = new System.Windows.Forms.Button();
            btnRepair = new System.Windows.Forms.Button();
            btnAction = new System.Windows.Forms.Button();
            menuFeed = new System.Windows.Forms.ContextMenuStrip(components);
            SuspendLayout();

            // lblName
            lblName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblName.Location = new System.Drawing.Point(10, 5);
            lblName.Size = new System.Drawing.Size(180, 25);
            lblName.Text = "Вид";

            // prgHealth
            prgHealth.Location = new System.Drawing.Point(10, 35);
            prgHealth.Size = new System.Drawing.Size(180, 20);

            // lblStatus
            lblStatus.Location = new System.Drawing.Point(10, 60);
            lblStatus.Size = new System.Drawing.Size(180, 20);
            lblStatus.Text = "OK";

            // lblOxygen
            lblOxygen.Location = new System.Drawing.Point(10, 85);
            lblOxygen.Size = new System.Drawing.Size(180, 20);

            // lblHunger
            lblHunger.Location = new System.Drawing.Point(10, 110);
            lblHunger.Size = new System.Drawing.Size(180, 20);

            // btnFeed
            btnFeed.Location = new System.Drawing.Point(10, 140);
            btnFeed.Size = new System.Drawing.Size(85, 30);
            btnFeed.Text = "Годувати";
            btnFeed.Click += btnFeed_Click;

            // btnRepair
            btnRepair.Location = new System.Drawing.Point(105, 140);
            btnRepair.Size = new System.Drawing.Size(85, 30);
            btnRepair.Text = "Ремонт";
            btnRepair.Click += btnRepair_Click;

            // btnAction
            btnAction.Location = new System.Drawing.Point(10, 180);
            btnAction.Size = new System.Drawing.Size(180, 30);
            btnAction.Text = "ДІЯ";
            btnAction.Click += btnAction_Click;

            // SectorControl
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(lblName);
            Controls.Add(prgHealth);
            Controls.Add(lblStatus);
            Controls.Add(lblOxygen);
            Controls.Add(lblHunger);
            Controls.Add(btnFeed);
            Controls.Add(btnRepair);
            Controls.Add(btnAction);
            Name = "SectorControl";
            Size = new System.Drawing.Size(200, 220);

            ResumeLayout(false);
        }
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ProgressBar prgHealth;
        private System.Windows.Forms.Label lblStatus, lblOxygen, lblHunger;
        private System.Windows.Forms.Button btnFeed, btnRepair, btnAction;
        private System.Windows.Forms.ContextMenuStrip menuFeed;
    }
}