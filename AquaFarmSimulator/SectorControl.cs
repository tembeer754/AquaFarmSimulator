using System;
using System.Drawing;
using System.Windows.Forms;
using AquaFarmSimulator.Models;

namespace AquaFarmSimulator
{
    public partial class SectorControl : UserControl
    {
        private Sector _sector;
        public event Action<SectorControl> OnActionClick;

        public SectorControl(Sector sector)
        {
            InitializeComponent();
            _sector = sector;

            if (_sector != null)
            {
                lblName.Text = _sector.Entity.Name;
            }
        }

        public void RefreshUI()
        {
            if (_sector == null) return;

            // Оновлення значень
            prgHealth.Value = (int)_sector.Entity.Health;
            lblOxygen.Text = $"Кисень: {(int)_sector.OxygenLevel}%";
            lblHunger.Text = $"Голод: {(int)_sector.Entity.Hunger}%";

           
            lblStatus.Text = _sector.IsAeratorBroken ? "АВАРІЯ АЕРАТОРА!" : "Статус: ОК";

          
            this.BackColor = _sector.Entity.GetStatusColor();

            // Загибель
            if (!_sector.Entity.IsAlive)
            {
                lblStatus.Text = "ЗАГИБЕЛЬ";
                this.Enabled = false;
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            OnActionClick?.Invoke(this);
        }

        private void btnFeed_Click(object sender, EventArgs e)
        {
            

            if (menuFeed != null)
            {
                menuFeed.Show(btnFeed, new Point(0, btnFeed.Height));
            }
        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            if (Warehouse.TryGetRepairKit())
            {
                _sector.Repair();
                RefreshUI();
            }
            else
            {
                MessageBox.Show("Немає запчастин!");
            }   
        }

        // Вибір їжі
        private void ProcessFeeding(FoodType food)
        {
            if (_sector == null || _sector.Entity == null || !_sector.Entity.IsAlive)
            {
                return;
            }

            bool hasResource = false;

            // Перевіряємо, чи є вибраний ресурс у Warehouse
            if (food == FoodType.FishFood && Warehouse.FishFood >= 10)
            {
                Warehouse.FishFood -= 10;
                hasResource = true;
            }
            else if (food == FoodType.SharkMeat && Warehouse.SharkMeat >= 10)
            {
                Warehouse.SharkMeat -= 10;
                hasResource = true;
            }
            else if (food == FoodType.MolluskPlankton && Warehouse.MolluskFood >= 10)
            {
                Warehouse.MolluskFood -= 10;
                hasResource = true;
            }
            else if (food == FoodType.AlgaeFertilizer && Warehouse.Fertilizer >= 10)
            {
                Warehouse.Fertilizer -= 10;
                hasResource = true;
            }

            if (hasResource)
            {
                // Викликаємо наш новий перевантажений метод Eat
                string message = _sector.Entity.Eat(food);

                
                MessageBox.Show(message);

                RefreshUI();
            }
            else
            {
                MessageBox.Show("Цього ресурсу немає на складі!");
            }
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblHunger_Click(object sender, EventArgs e)
        {

        }

        private void SectorControl_Load(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }
    }
}