using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace somaya_mod4
{
    public partial class LCG : Form
    {
        Task4.Algorithm algo = new Task4.Algorithm();
        public LCG()
        {
            InitializeComponent();
        }

        private void generate_button_Click(object sender, EventArgs e)
        {
            bool flag = false;
            // getting the input data from text boxes:
            if (string.IsNullOrEmpty(iter_num_text.Text)){
                MessageBox.Show("#iterations must contain value.");
                flag = true;
            }
            else
                algo.NumIteration = long.Parse(iter_num_text.Text);

            if (string.IsNullOrEmpty(increment_text.Text)){
                flag = true;
                MessageBox.Show("Increment must contain value.");
            }
            else
                algo.Increment = long.Parse(increment_text.Text);

            if (string.IsNullOrEmpty(mod_text.Text)){
                flag= true;
                MessageBox.Show("Modulus must contain value.");
            }
            else
                algo.Modulus = long.Parse(mod_text.Text);

            if (string.IsNullOrEmpty(mul_text.Text)){
                flag = true;
                MessageBox.Show("Multiplier must contain value.");
            }
            else
                algo.Multiplier = long.Parse(mul_text.Text);

            if (string.IsNullOrEmpty(seed_text.Text)){
                flag = true;
                MessageBox.Show("Seed must contain value.");
            }
            else
                algo.Seed = long.Parse(seed_text.Text);

            if (!flag)
            {
                algo.CreateRandom();
                // adding output to the GUI
                display_output();
            }
            else
            {
                MessageBox.Show("Fill out the missing values then try again!!");
            }
        }
        public void display_output()
        {

            List<long> randomNumbers = algo.RandomNumber; // Replace with your actual data source

           
            // Create a new column
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
            {
                HeaderText = "Random Number", 
                DataPropertyName = "rand",    
            };

            random_num.Columns.Add(column);
            var bindingList = new BindingList<NumberItem>(
                randomNumbers.Select(n => new NumberItem { rand = n }).ToList()
            );

            random_num.DataSource = bindingList;

            random_num.Refresh();
            cycle_text.Text = algo.NumberCycle.ToString();
            
        }
    }
    public class NumberItem
    {
        public long rand { get; set; }
    }
}
