using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_Hafiza_Oyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Image[] resimler = { Properties.Resources.r1, Properties.Resources.r2, Properties.Resources.r3, Properties.Resources.r4, Properties.Resources.r5, Properties.Resources.r6, Properties.Resources.r7, Properties.Resources.r8 };

        int[] indeksler = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        PictureBox ilkkutu;
        int ilkindeks, bulunan, deneme;

        private void Form1_Load(object sender, EventArgs e)
        {
            resimlerikaristir();
        }

        private void resimlerikaristir()
        {
            Random rnd = new Random();
            for(int i = 0; i < 16; i++)
            {
                int sayi = rnd.Next(16);
                int gecici = indeksler[i];
                indeksler[i] = indeksler[sayi];
                indeksler[sayi] = gecici;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox kutu = (PictureBox)sender;
            int kutuno = int.Parse(kutu.Name.Substring(10));
            int indeksno = indeksler[kutuno - 1];
            kutu.Image = resimler[indeksno];
            kutu.Refresh();

            if (ilkkutu == null)
            {
                ilkkutu = kutu;
                ilkindeks = indeksno;
                deneme++;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);

                ilkkutu.Image = null;
                kutu.Image = null;
                if (ilkindeks == indeksno)
                {
                    bulunan++;
                    ilkkutu.Visible = false;
                    kutu.Visible = false;

                    if (bulunan == 8)
                    {
                        MessageBox.Show("Tebrikler " + deneme + " buldunuz.");
                        bulunan = 0;
                        deneme = 0;
                        foreach(Control kontrol in Controls)
                        {
                            kontrol.Visible = true;
                        }
                        resimlerikaristir();
                    }
                }
                ilkkutu = null;
            }
        }
    }
}
