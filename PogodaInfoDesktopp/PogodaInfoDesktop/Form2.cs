using PogodaInfoDesktop.DomainService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PogodaInfoDesktop
{
    public partial class Form2 : Form
    {
        WeatherService weatherService = new WeatherService();
        
        public Form2()
        {
            InitializeComponent();
            textBox1.Dock = DockStyle.Bottom;
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var forecastList = weatherService.getAllWeather();
            if(forecastList != null)
            {
                textBox1.Text = "";
                textBox1.Text = "Data aktualizacji: " + DateTime.Now;
                foreach (var weather in forecastList)
                {
                    textBox1.Text += Environment.NewLine;
                    textBox1.Text += weather.toString();
                }
            }
            else
            {
                showConnectionError();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var requestedForecast = weatherService.getWeatherForTown(comboBox1.SelectedItem.ToString());
            if(requestedForecast != null)
            {
                textBox2.Text = requestedForecast.toString();
            }
            else
            {
                showConnectionError();
            }
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = tabControl1.SelectedIndex;
            if(index == 1)
            {
                var listOfTowns = weatherService.getTownNames();
                if (listOfTowns != null)
                    comboBox1.Items.AddRange(listOfTowns.ToArray());
                else
                    showConnectionError();
            }
        }

        private void oAutorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autorem aplikacji jest Tomasz Morgaś");
        }

        public void showConnectionError()
        {
            MessageBox.Show("Serwer niedostępny, spróboj ponownie później");
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var forecastList = weatherService.getAllWeather();
            if(forecastList != null)
            {
                foreach (var weather in forecastList)
                {
                    for (int i = 3; i <= 35; i++)
                    {
                        if (i != 9)
                        {
                            string labelName = "label" + i.ToString();
                            Label townLabel = this.Controls.Find(labelName, true).FirstOrDefault() as Label;
                            if (weather.Stacja == townLabel.Text)
                            {
                                labelName = "label" + (i - 1).ToString();
                                Label dataLabel = this.Controls.Find(labelName, true).FirstOrDefault() as Label;
                                if (weather.Temperatura != null)
                                {
                                    dataLabel.Text = weather.Temperatura.ToString();
   
                                    if(double.TryParse(weather.Temperatura.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double liczba))
                                    {
                                        if (liczba > 0)
                                            dataLabel.ForeColor = Color.Red;
                                        else
                                            dataLabel.ForeColor = Color.Aqua;
                                    }
                                    

                                }
                                else
                                {
                                    dataLabel.Text = "brak danych";
                                    
                                }
                                break;
                                    
                            }
                        }

                    }
                }

                label37.Text = "Zaktualizowano dane, godzina pomiaru: " + forecastList[0].GodzinaPomiaru + " \n(data aktualizacji danych: " + DateTime.Now;

            }
            else
            {
                showConnectionError();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var forecastList = weatherService.getAllWeather();
            if (forecastList != null)
            {
                foreach (var weather in forecastList)
                {
                    for (int i = 3; i <= 35; i++)
                    {
                        if (i != 9)
                        {
                            string labelName = "label" + i.ToString();
                            Label townLabel = this.Controls.Find(labelName, true).FirstOrDefault() as Label;
                            if (weather.Stacja == townLabel.Text)
                            {
                                labelName = "label" + (i - 1).ToString();
                                Label dataLabel = this.Controls.Find(labelName, true).FirstOrDefault() as Label;
                                dataLabel.ForeColor = Color.DarkRed;
                                if (weather.Cisnienie != null)
                                {
                                    dataLabel.Text = weather.Cisnienie.ToString();
                                }
                                else
                                {
                                    dataLabel.Text = "brak danych";
                                }
                                break;

                            }
                        }

                    }
                }

                label37.Text = "Zaktualizowano dane, godzina pomiaru: " + forecastList[0].GodzinaPomiaru + " \n(data aktualizacji danych: " + DateTime.Now;

            }
            else
            {
                showConnectionError();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var forecastList = weatherService.getAllWeather();
            if (forecastList != null)
            {
                foreach (var weather in forecastList)
                {
                    for (int i = 3; i <= 35; i++)
                    {
                        if (i != 9)
                        {
                            string labelName = "label" + i.ToString();
                            Label townLabel = this.Controls.Find(labelName, true).FirstOrDefault() as Label;
                            if (weather.Stacja == townLabel.Text)
                            {
                                labelName = "label" + (i - 1).ToString();
                                Label dataLabel = this.Controls.Find(labelName, true).FirstOrDefault() as Label;
                                dataLabel.ForeColor = Color.DarkRed;
                                if (weather.WilgotnoscWzgledna != null)
                                {
                                    dataLabel.Text = weather.WilgotnoscWzgledna.ToString();
                                }
                                else
                                {
                                    dataLabel.Text = "brak danych";
                                }
                                break;

                            }
                        }

                    }
                }

                label37.Text = "Zaktualizowano dane, godzina pomiaru: " + forecastList[0].GodzinaPomiaru + " \n(data aktualizacji danych: " + DateTime.Now;

            }
            else
            {
                showConnectionError();
            }
        }
    }
}
