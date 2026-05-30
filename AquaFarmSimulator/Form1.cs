using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AquaFarmSimulator.Models;

namespace AquaFarmSimulator
{
    public partial class Form1 : Form
    {
        // Основні списки даних
        private List<Sector> _sectors = new List<Sector>();
        private List<SectorControl> _uiControls = new List<SectorControl>();
        
        // Буфер для перенесення об'єктів ("Руки")
        private AquaticEntity _handBuffer = null;
        private Random _randomEngine = new Random();

        public Form1()
        {
            InitializeComponent();
            InitializeFarmArchitecture();
            gameTimer.Start();
            UpdateStatusBar();
        }

        private void InitializeFarmArchitecture()
        {
            // Створюємо базову сітку з 12 секторів
            _sectors.Add(new Sector(1, new Fish("Лосось Атлантичний", 16)));
            _sectors.Add(new Sector(2, new Shark("Біла Акула", 18)));
            _sectors.Add(new Sector(3, new Algae("Ламінарія Оксигенатор")));
            _sectors.Add(new Sector(4, new Mollusk("Мідії Фільтратори", 15)));
            _sectors.Add(new Sector(5, new Fish("Тиляпія Тепла", 26)));
            _sectors.Add(new Sector(6, new Algae("Хлорела")));

            // Решта секторів залишаються в резерві (порожні)
            for (int i = 7; i <= 12; i++)
            {
                _sectors.Add(new Sector(i, null));
            }

            foreach (var s in _sectors)
            {
                SectorControl control = new SectorControl(s);
                control.OnActionClick += HandleIntervention; // Підписка на інтерактив
                _uiControls.Add(control);
                flowLayoutPanel1.Controls.Add(control);
            }

            LogEvent(">>> СИСТЕМУ КЕРУВАННЯ АКВАФЕРМОЮ ЗАПУЩЕНО.");
            LogEvent(">>> Стан біобалансу: СТАБІЛЬНИЙ.");
        }

        private void HandleIntervention(SectorControl clickedUi)
        {
            // ЛОГІКА ПЕРЕМІЩЕННЯ ОБ'ЄКТІВ
            if (_handBuffer == null)
            {
                if (clickedUi.Sector.Entity != null)
                {
                    _handBuffer = clickedUi.Sector.Entity;
                    LogEvent($"ОБ'ЄКТ {_handBuffer.Name} ВИЛУЧЕНО З СЕКТОРУ {clickedUi.Sector.Id}.");
                    clickedUi.Sector.Entity = null;
                }
            }
            else
            {
                if (clickedUi.Sector.Entity == null)
                {
                    clickedUi.Sector.Entity = _handBuffer;
                    LogEvent($"ОБ'ЄКТ {_handBuffer.Name} ВСТАНОВЛЕНО У СЕКТОР {clickedUi.Sector.Id}.");
                    _handBuffer = null;
                }
                else
                {
                    // РЕАЛІЗАЦІЯ ПАРАДИГМИ ПОЛІМОРФІЗМУ: Перевірка взаємодії
                    if (_handBuffer is Shark && clickedUi.Sector.Entity is Fish)
                    {
                        LogEvent($"УВАГА! Акула {_handBuffer.Name} знищила біомасу {clickedUi.Sector.Entity.Name}!");
                        clickedUi.Sector.Entity = _handBuffer; // Риба з'їдена
                        _handBuffer = null;
                    }
                    else
                    {
                        LogEvent("ПОМИЛКА: Сектор вже зайнятий іншим видом.");
                    }
                }
            }
            clickedUi.RefreshUI();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            double totalOxygenBonus = 0;

            // 1. ЕКОЛОГІЧНИЙ МОНІТОРИНГ (Водорості генерують кисень для всієї ферми)
            foreach (var s in _sectors)
            {
                if (s.Entity is Algae algae && algae.IsAlive)
                {
                    totalOxygenBonus += 2.5; 
                }
            }

            // 2. ЦИКЛ ОБЧИСЛЕННЯ ЖИТТЄДІЯЛЬНОСТІ
            foreach (var s in _sectors)
            {
                // Застосування зовнішніх факторів
                if (s.OxygenLevel < 100) s.OxygenLevel += totalOxygenBonus;
                
                // Випадкові коливання температури (моделювання датчиків)
                s.Temperature += _randomEngine.NextDouble() * 2 - 1.0; 

                bool wasAlive = s.Entity != null && s.Entity.IsAlive;
                s.Update(); // Виклик логіки сектора

                // Фіксація критичних подій у лог
                if (wasAlive && !s.Entity.IsAlive)
                {
                    LogEvent($"КРИТИЧНО: Загибель виду {s.Entity.Name} у секторі {s.Id}!");
                }
                
                if (s.IsAeratorBroken && _randomEngine.Next(0, 10) < 2)
                {
                    LogEvent($"ПОПЕРЕДЖЕННЯ: Аварія обладнання в секторі {s.Id}!");
                }
            }

            // 3. СИНХРОНІЗАЦІЯ ІНТЕРФЕЙСУ
            foreach (var c in _uiControls)
            {
                c.RefreshUI();
            }

            UpdateStatusBar();
        }

        private void UpdateStatusBar()
        {
            // Додаємо AutoSize, щоб текст не влазив у рамки
            lblMoney.AutoSize = true;
            lblMoney.Text = $"Фінанси: {Warehouse.Money}$";

            string inHand = (_handBuffer == null) ? "Порожньо" : _handBuffer.Name;
            this.Text = $"Керування Аквафермою | У руках: {inHand}";
        }

        public void LogEvent(string msg)
        {
            if (lstLog != null)
            {
                lstLog.Items.Insert(0, $"{DateTime.Now.ToShortTimeString()} - {msg}");
            }
        }

        private void btnOpenShop_Click(object sender, EventArgs e)
        {
            using (ShopForm1 shop = new ShopForm1())
            {
                if (shop.ShowDialog() == DialogResult.OK)
                {
                    if (shop.BoughtEntity != null)
                    {
                        _handBuffer = shop.BoughtEntity;
                        LogEvent($"МАГАЗИН: {shop.SuccessMessage}");
                    }
                    else
                    {
                        LogEvent($"МАГАЗИН: Ресурси поповнено.");
                    }
                }
            }
        }
    }
}