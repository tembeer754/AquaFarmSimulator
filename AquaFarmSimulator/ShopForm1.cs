using AquaFarmSimulator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AquaFarmSimulator
{
    public partial class ShopForm1 : Form
    {

        public AquaticEntity BoughtEntity { get; set; }
        public string SuccessMessage { get; set; }
        public ShopForm1()
        {
            InitializeComponent();
        }

        private void Buy(AquaticEntity entity, double cost)
        {
            if (Warehouse.SpendMoney(cost))
            {
                this.BoughtEntity = entity; // Зберігаємо об'єкт
                this.SuccessMessage = $"Куплено: {entity.Name}"; // Зберігаємо текст
                this.DialogResult = DialogResult.OK; // Кажемо, що все успішно
            }
            else
            {
                MessageBox.Show("Немає грошей!");
            }
        }
    }
}
