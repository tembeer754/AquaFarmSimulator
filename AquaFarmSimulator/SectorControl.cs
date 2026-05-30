using System;
using System.Drawing;
using System.Windows.Forms;
using AquaFarmSimulator.Models;

namespace AquaFarmSimulator
{
    public partial class SectorControl : UserControl
    {
        public event Action<SectorControl> OnActionClick;
        public Sector Sector { get; private set; }

        public SectorControl(Sector sector)
        {
            InitializeComponent();
            Sector = sector;
            SetupMenu();
            RefreshUI();
        }

        private void SetupMenu()
        {
            menuFeed.Items.Clear();
            menuFeed.Items.Add("Сухий корм", null, (s, e) => ProcessFeeding(FoodType.FishFood));
            menuFeed.Items.Add("М'ясо", null, (s, e) => ProcessFeeding(FoodType.SharkMeat));
            menuFeed.Items.Add("Планктон", null, (s, e) => ProcessFeeding(FoodType.MolluskPlankton));
            menuFeed.Items.Add("Добрива", null, (s, e) => ProcessFeeding(FoodType.AlgaeFertilizer));
            btnFeed.ContextMenuStrip = menuFeed;
        }

        public void RefreshUI()
        {
            if (Sector == null) return;

            if (Sector.Entity == null)
            {
                lblName.Text = "ВІЛЬНО";
                lblStatus.Text = "Готовий";
                lblHunger.Text = "Голод: -";
                prgHealth.Value = 0;
                BackColor = Color.LightGray;
            }
            else
            {
                lblName.Text = Sector.Entity.Name;
                int healthValue = (int)Sector.Entity.Health;
                if (healthValue < 0) healthValue = 0;
                if (healthValue > 100) healthValue = 100;
                prgHealth.Value = healthValue;

                lblHunger.Text = $"Голод: {(int)Sector.Entity.Hunger}%";
                BackColor = Sector.Entity.GetStatusColor();
                lblStatus.Text = Sector.IsAeratorBroken ? "АВАРІЯ!" : "ОК";
            }
            lblOxygen.Text = $"Кисень: {(int)Sector.OxygenLevel}%";
        }

        private void btnFeed_Click(object sender, EventArgs e) => menuFeed.Show(btnFeed, new Point(0, btnFeed.Height));
        private void btnRepair_Click(object sender, EventArgs e) { if (Warehouse.TryGetRepairKit()) Sector.Repair(); }
        private void btnAction_Click(object sender, EventArgs e) => OnActionClick?.Invoke(this);

        private void ProcessFeeding(FoodType food)
        {
            if (Sector.Entity == null) return;
            // Спрощена перевірка для надійності
            Warehouse.SpendMoney(10); // Умовно
            string msg = Sector.Entity.Eat(food);
            MessageBox.Show(msg);
            RefreshUI();
        }
    }
}