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

namespace MultiQueueSimulation
{
    public partial class Form2 : Form
    {
        SimulationSystem system;
        public Form2(SimulationSystem sys)
        {
            InitializeComponent();
            system = sys;
        }

        private void Form2_Load(object sender, EventArgs e)
        {   
            for(int i=0;i<system.NumberOfServers;i++)
            {
                comboBox1.Items.Add(i + 1);
            }
            chart1.Series["Server Busy Time"].Points.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_value = comboBox1.SelectedItem.ToString();
            int server = int.Parse(selected_value);
            int finish_time = system.Servers[server - 1].FinishTime;
            for (int j = 0; j < finish_time; j++)
            {
                for (int i = 0; i < system.StoppingNumber; i++)
                {
                    if (system.SimulationTable[i].AssignedServer.ID == server)
                    {
                        for (int k = system.SimulationTable[i].StartTime; k < system.SimulationTable[i].EndTime; k++)
                        {
                            chart1.Series["Server Busy Time"].Points.AddXY(k, 1);
                        }
                    }
                }
            }
        }
    }
}
