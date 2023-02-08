using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq.Expressions;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        string answer = String.Empty;
        public Form1(string answer)
        {
            InitializeComponent();
            this.answer = answer;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            OpenWeather.OpenWeather oW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);

            panel1.BackgroundImage = oW.weather[0].Icon;

            //label1.Text = oW.weather[0].main;

            label2.Text = oW.weather[0].description;

            label3.Text = "Средняя температура (°C): " + oW.main.temp.ToString("0.##");

            label6.Text = "Скорость (м/с): " + oW.wind.speed.ToString();

            label7.Text = "Направление (°): " + oW.wind.deg.ToString();

            label4.Text = "Влажность (%): " + oW.main.humidity.ToString();

            label5.Text = "Давление (мм): " + ((int)oW.main.pressure).ToString();

            label8.Text = oW.name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            Hide();
            form.ShowDialog();
        }
    }
}
