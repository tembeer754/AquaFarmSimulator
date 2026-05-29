using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AquaFarmSimulator.Models;

namespace AquaFarmSimulator
{
    public partial class Form1 : Form
    {
       
        private List<Sector> _sectors = new List<Sector>();
        private List<SectorControl> _uiControls = new List<SectorControl>();

        public Form1()
        {
           
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
           
            _sectors.Add(new Sector(1, new Fish("Лосось", 20)));
            _sectors.Add(new Sector(2, new Shark("Акула", 24)));
            _sectors.Add(new Sector(3, new Algae("Водорості")));
            _sectors.Add(new Sector(5, new Mollusk("Мідії Холодноводні", 15)));
            _sectors.Add(new Sector(6, new Mollusk("Устриці Гігантські", 18)));

            if (flowLayoutPanel1 != null)
            {
                foreach (var s in _sectors)
                {
                    var ctrl = new SectorControl(s);
                    _uiControls.Add(ctrl);
                    flowLayoutPanel1.Controls.Add(ctrl);
                }
            }

            
            if (gameTimer != null)
            {
                gameTimer.Start();
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Кожного "тіку" таймера оновлюємо логіку
            foreach (var s in _sectors)
            {
                s.Update();
            }

            // Оновлюємо візуал 
            foreach (var c in _uiControls)
            {
                c.RefreshUI();
            }

            // Інфа про склад
            this.Text = $"Корм: {Warehouse.FishFood} | Ремкомплекти: {Warehouse.RepairKits}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}