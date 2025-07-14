using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;
using System.IO;

namespace MultiQueueSimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SimulationSystem system;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string test_name = label2.Text = comboBox1.SelectedItem.ToString();
            system = new SimulationSystem();
            system.Read_File(test_name);
            
            for (int i = 0; i < system.StoppingNumber; i++)
            {
                string[] row = {system.SimulationTable[i].CustomerNumber.ToString() ,system.SimulationTable[i].RandomInterArrival.ToString(),
                               system.SimulationTable[i].InterArrival.ToString(),system.SimulationTable[i].ArrivalTime.ToString(),
                               system.SimulationTable[i].RandomService.ToString(),system.SimulationTable[i].StartTime.ToString(),
                               system.SimulationTable[i].ServiceTime.ToString(), system.SimulationTable[i].EndTime.ToString(),
                               system.SimulationTable[i].AssignedServer.ID.ToString(),system.SimulationTable[i].TimeInQueue.ToString()};
                dataGridView1.Rows.Add(row);
            }

            label6.Text = system.PerformanceMeasures.AverageWaitingTime.ToString();
            label7.Text = system.PerformanceMeasures.WaitingProbability.ToString();
            label8.Text = system.PerformanceMeasures.MaxQueueLength.ToString();

            for (int i = 0; i < system.NumberOfServers; i++)
                comboBox2.Items.Add(i + 1);

            string result = TestingManager.Test(system, test_name+".txt");
            MessageBox.Show(result);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int server_num = Int32.Parse(comboBox2.SelectedItem.ToString());
            label12.Text = system.Servers[server_num - 1].IdleProbability.ToString();
            label13.Text = system.Servers[server_num - 1].AverageServiceTime.ToString();
            label14.Text = system.Servers[server_num - 1].Utilization.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(system);
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
