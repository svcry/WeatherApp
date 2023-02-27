using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            AutoCompleteStringCollection source = new AutoCompleteStringCollection()
        {
            "Рио-де-жанейро",
            "Санкт-Петербург",
            "Новосибирск",
            "Новокузнецк"
        };
            textBox1.AutoCompleteCustomSource = source;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public string getText()
        {
            return textBox1.Text;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create($"http://api.openweathermap.org/data/2.5/weather?q={this.getText()}&APPID=MyAPI&units=metric&lang=ru");

            request.Method = "POST";

            request.ContentType = "application/x-www-urlencoded";

            string answer = String.Empty;

            try
            {
                WebResponse response = await request.GetResponseAsync();

                using (Stream s = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(s))
                    {
                        answer = await reader.ReadToEndAsync();
                    }
                }

                response.Close();
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show("Такого города нет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
            
            if (answer != "")
            {
                Form1 form = new Form1(answer);
                Hide();
                form.ShowDialog();
            }
            else Form2_Load(this, EventArgs.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
