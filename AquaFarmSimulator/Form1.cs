using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AquaFarmSimulator.Models;

namespace AquaFarmSimulator
{
    public partial class Form1 : Form
    {
        private List<Sector> _sectors = new List<Sector>();
        private List<SectorControl> _uiControls = new List<SectorControl>();


        // Буфер
        private AquaticEntity _handBuffer = null;

        public Form1()
        {
            InitializeComponent();
            InitializeFarm();
            gameTimer.Start();
        }

        private void InitializeFarm()
        {
            // 12 секторів (половина спочатку порожні)
            for (int i = 1; i <= 12; i++)
            {
                _sectors.Add(new Sector(i, null));
            }

            // Заселення початк мешканців
            _sectors[0].Entity = new Fish("Лосось А1", 20);
            _sectors[1].Entity = new Shark("Акула-хижак", 24);
            _sectors[2].Entity = new Algae("Сектор Водоростей");
            _sectors[3].Entity = new Mollusk("Мідії В2", 18);

            foreach (var s in _sectors)
            {
                var control = new SectorControl(s);
                
                control.OnActionClick += HandleSectorAction;

                _uiControls.Add(control);
                flowLayoutPanel1.Controls.Add(control);
            }
            LogEvent("Систему запущено. Ферма в автономному режимі.");
        }

    
        private void HandleSectorAction(SectorControl clickedUi)
        {
            if (_handBuffer == null)
            {
                
                if (clickedUi.Sector.Entity != null)
                {
                    _handBuffer = clickedUi.Sector.Entity;
                    clickedUi.Sector.Entity = null;
                    LogEvent($"Ви забрали: {_handBuffer.Name}");
                }
            }
            else
            {
                
                if (clickedUi.Sector.Entity == null)
                {
                    clickedUi.Sector.Entity = _handBuffer;
                    LogEvent($"Випустили {_handBuffer.Name} у сектор {clickedUi.Sector.Id}");
                    _handBuffer = null;
                }
                else
                {
                    // Хижак їсть рибу
                    if (_handBuffer is Shark && clickedUi.Sector.Entity is Fish)
                    {
                        LogEvent($"ЖАХ! Акула {_handBuffer.Name} з'їла рибу {clickedUi.Sector.Entity.Name}!");
                        clickedUi.Sector.Entity = _handBuffer; // Акула займає місце
                        _handBuffer = null;
                    }
                    else
                    {
                        LogEvent("Помилка: Неможливо розмістити об'єкти в одному секторі!");
                    }
                }
            }
            clickedUi.RefreshUI();
        }

        private void LogEvent(string msg)
        {
            string time = DateTime.Now.ToLongTimeString();
            lstLog.Items.Insert(0, $"[{time}] {msg}"); 
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            foreach (var s in _sectors)
            {
                s.Update();
            }

            foreach (var c in _uiControls)
            {
                c.RefreshUI();
            }

            // Оновлення статус-панелі
            lblMoney.Text = $"Баланс: {Warehouse.Money}$";
            string inHand = (_handBuffer == null) ? "Порожньо" : _handBuffer.Name;
            this.Text = $"У руках: {inHand} | Корм: {Warehouse.FishFood}кг";
        }

        private void btnOpenShop_Click(object sender, EventArgs e)
        {
            
            LogEvent("Відкрито термінал магазину...");
            Warehouse.Money += 100; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

    }
}