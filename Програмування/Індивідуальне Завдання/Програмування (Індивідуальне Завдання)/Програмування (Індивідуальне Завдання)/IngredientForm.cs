using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Програмування__Індивідуальне_Завдання_
{
    public partial class IngredientForm : Form
    {
        public int Index { get; set; }
        public List<Ingredient> data { get; set; }

        public IngredientForm()
        {
            InitializeComponent();
        }

        private void CancelIngredientButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveIngredientButton_Click(object sender, EventArgs e)
        {
            if (data.Count < Index + 1)
                data.Add(new Ingredient());

            data[Index] = new Ingredient()
            {
                Name = NameIng.Text, Mass = (double)MassIng.Value, 
                Calories = (double)CaloriesIng.Value, Price = (double)PriceIng.Value
            };
            this.Close();
        }
    }
}
