using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double? sayi1, sayi2, sonuc;

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                toolStripStatusLabel1.Text = "İlk sayı girilmeden işlem girilemez.";
                return;
            }

            Button button = sender as Button;
            textBoxIslem.Text = button.Text;
            toolStripStatusLabel1.Text = String.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (textBoxIslem.Text.Length == 0)
            {
                textBox1.Text = textBox1.Text + button.Text;
            }
            else
            {
                textBox2.Text = textBox2.Text + button.Text;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string cevrilecekSayi;

            cevrilecekSayi = textBoxIslem.Text.Length == 0 ? textBox1.Text : textBox2.Text;
            
            if (cevrilecekSayi.Length == 0)
            {
                cevrilecekSayi = "-";
            }
            else
            {
                if (cevrilecekSayi[0].ToString() == "-")
                {
                    cevrilecekSayi = cevrilecekSayi.Replace("-", "+");
                }
                else if (cevrilecekSayi[0].ToString() == "+")
                {
                    cevrilecekSayi = cevrilecekSayi.Replace("+", "-");
                }
                else
                {
                    cevrilecekSayi = cevrilecekSayi.Insert(0, "-");
                }
            }

            if (textBoxIslem.Text.Length == 0)
            {
                textBox1.Text = cevrilecekSayi;
            }
            else
            {
                textBox2.Text = cevrilecekSayi;
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                sayi1 = Double.Parse(textBox1.Text);
                sayi2 = Double.Parse(textBox2.Text);
                switch (textBoxIslem.Text)
                {
                    case "+":
                        sonuc = sayi1 + sayi2;
                        break;
                    case "-":
                        sonuc = sayi1 - sayi2;
                        break;
                    case "/":
                        sonuc = sayi1 / sayi2;
                        break;
                    case "*":
                        sonuc = sayi1 * sayi2;
                        break;
                }

                textBox1.Text = sonuc?.ToString("F3");
                textBoxIslem.Text = String.Empty;
                textBox2.Text = String.Empty;

                sayi1 = null;
                sayi2 = null;
                sonuc = null;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Hata Oluştu");
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                button5_Click(new Button {Text = e.KeyChar.ToString()}, null);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string cevrilecekSayi;

            cevrilecekSayi = textBoxIslem.Text.Length == 0 ? textBox1.Text : textBox2.Text;

            if (cevrilecekSayi.Length == 1)
            {
                cevrilecekSayi = String.Empty;
            }
            else if (cevrilecekSayi.Length > 1)
            {
                cevrilecekSayi = cevrilecekSayi.Substring(0, cevrilecekSayi.Length - 1);
            }

            if (textBoxIslem.Text.Length == 0)
            {
                textBox1.Text = cevrilecekSayi;
            }
            else
            {
                textBox2.Text = cevrilecekSayi;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string cevrilecekSayi;

            cevrilecekSayi = textBoxIslem.Text.Length == 0 ? textBox1.Text : textBox2.Text;

            if (!cevrilecekSayi.Contains(","))
            {
                cevrilecekSayi += ",";
            }

            if (textBoxIslem.Text.Length == 0)
            {
                textBox1.Text = cevrilecekSayi;
            }
            else
            {
                textBox2.Text = cevrilecekSayi;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sayi1 = null;
            sayi2 = null;
            sonuc = null;

            textBox1.Text =
                textBox2.Text =
                    textBoxIslem.Text = String.Empty;
        }
        
        public Form1()
        {
            InitializeComponent();
        }
    }
}
