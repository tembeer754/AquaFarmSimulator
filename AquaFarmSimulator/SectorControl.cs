using System;
using System.Drawing;
using System.Windows.Forms;
using AquaFarmSimulator.Models;

namespace AquaFarmSimulator
{
    public partial class SectorControl : UserControl
    {
        private Sector _sector;

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

            // Текст статусу
            lblStatus.Text = _sector.IsAeratorBroken ? "АВАРІЯ АЕРАТОРА!" : "Статус: ОК";

            // Колір фону
            this.BackColor = _sector.Entity.GetStatusColor();

            // Загибель
            if (!_sector.Entity.IsAlive)
            {
                lblStatus.Text = "ЗАГИБЕЛЬ";
                this.Enabled = false;
            }
        }

        private void btnFeed_Click(object sender, EventArgs e)
        {
            if (Warehouse.TryGetFood(10))
            {
                _sector.Entity.Eat(20);
                RefreshUI();
            }
            else
            {
                MessageBox.Show("Немає корму на складі!");
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