using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MB_Dosya_Adı_Değiştir
{
    public partial class Form1 : Form
    {
        #region Metodlar

        #endregion

        #region Tanımlamalar

        FileInfo[] klasöradı2;
        string[] kelimeler, kelimeler2;

        #endregion

        #region Değişkenler

        string dosyayolu;

        string  ilkharf, tümkelime, kelime1;

        int a;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    dosyayolu = textBox1.Text;
                    DirectoryInfo Dosyalar = new DirectoryInfo(dosyayolu);
                    klasöradı2 = Dosyalar.GetFiles();
                    a = 1;

                    for (int k = 0; k < klasöradı2.Length; k++)
                    {

                        kelimeler2 = klasöradı2[k].ToString().Split(' ');

                        tümkelime = "";

                        for (int l = 0; l < kelimeler2.Length; l++)
                        {
                            kelime1 = kelimeler2[l].ToLower();

                            ilkharf = kelime1[0].ToString().ToUpper();

                            if (tümkelime == "")
                            {
                                tümkelime = ilkharf;
                            }

                            else
                            {
                                tümkelime += " " + ilkharf;
                            }

                            for (int d = 1; d < kelime1.Length; d++)
                            {
                                tümkelime = tümkelime + kelime1[d];
                            }

                        }

                        Directory.Move(klasöradı2[k].FullName, dosyayolu + "\\" + a + " " + tümkelime);

                        a++;
                    }

                    button3.BackgroundImage = Image.FromFile("2.png");
                    textBox1.Clear();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text!="" && textBox1.Text!=dosyayolu)
            {
                button3.BackgroundImage = Image.FromFile("1.png");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    dosyayolu = textBox2.Text;
                    DirectoryInfo Dosyalar = new DirectoryInfo(dosyayolu);
                    klasöradı2 = Dosyalar.GetFiles();
                    a = 1;

                    for (int i = 0; i < klasöradı2.Length; i++)
                    {
                        kelimeler = klasöradı2[i].ToString().Split(' ');

                        tümkelime = kelimeler[1].ToString();

                        for (int j = 2; j < kelimeler.Length; j++)
                        {
                            tümkelime += " " + kelimeler[j];

                        }

                        Directory.Move(klasöradı2[i].FullName, dosyayolu + "\\" + tümkelime);
                    }

                    button2.BackgroundImage = Image.FromFile("2.png");
                    textBox2.Clear();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata");
            }

         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox2.Text != dosyayolu)
            {
                button3.BackgroundImage = Image.FromFile("1.png");
            }
        }
    }
}
