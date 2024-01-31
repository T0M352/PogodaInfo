using PogodaInfoDesktop.DomainService;
using PogodaInfoDesktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PogodaInfoDesktop
{
    public partial class Form1 : Form
    {
        WeatherService weatherService = new WeatherService();
        int startupDelay = 0;
        bool active = false;
        public Form1()
        {
            InitializeComponent();
            bool isActive = weatherService.getSiteStatus();
            if (isActive)
            {
                label3.ForeColor = Color.Green;
                label3.Text = "Serwer pogodowy dostępny!";
                active = true;
            }
            else
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Serwer pogodowy niedostępny :(";
                active = false;
            }
            timer1.Enabled = true;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            startupDelay++;
            if (startupDelay == 30 && active == true)
            {
                Form2 form2 = new Form2();
                form2.Visible = true;
                this.Visible = false;
            }
            else if (startupDelay == 30 && active == false)
            {
                this.Close();
            }
        }
    }
}
