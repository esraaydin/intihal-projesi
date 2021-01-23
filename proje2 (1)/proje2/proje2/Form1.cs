using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace proje2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string girilenyazi = textBox1.Text.Trim();
            string[] kelimeler, vigul, nokta, soru;
            kelimeler = girilenyazi.Split(' ');
            vigul = girilenyazi.Split(',');
            nokta = girilenyazi.Split('.');
            soru = girilenyazi.Split('?');
            label4.Text = (kelimeler.Length - 1).ToString();
            label5.Text =( kelimeler.Length - 1).ToString();
            label6.Text = (soru.Length - 1).ToString();
            label9.Text =  (nokta.Length-1).ToString();
            label10.Text = (vigul.Length - 1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dosya_yolu = textBox2.Text;
            string satirlar = System.IO.File.ReadAllText(dosya_yolu, Encoding.UTF8);
            textBox1.Text = satirlar;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dosya = textBox2.Text;

            string satirlar = System.IO.File.ReadAllText(dosya, Encoding.UTF8);

            textBox1.Text = satirlar;
            char[] charArray = satirlar.ToCharArray();
            int buyukHarfSayaci = 0 , kucukHarfSayaci=0;
            char harf;
           
            try
            {
                for (int i = 0; i < charArray.Length; i++)
                {

                    if (charArray[i].Equals('.') || charArray[i].Equals(':') || charArray[i].Equals('!') || charArray[i].Equals('?'))
                    {
                        harf = charArray[i + 1];

                        if (char.IsUpper(harf))
                        {
                            //yani noktadan sonra büyük harfle başladı . bir sonraki harfi sorgulamaya geç
                            listBox1.Items.Add(charArray[i - 2].ToString() + charArray[i - 1].ToString() + charArray[i].ToString() + charArray[i + 1].ToString() + charArray[i + 2].ToString() + " ");
                            continue;
                        }
                        else
                        {
                            listBox1.Items.Add(charArray[i - 2].ToString() + charArray[i - 1].ToString() + charArray[i].ToString() + charArray[i + 1].ToString() + charArray[i + 2].ToString() + " ");
                            //eğer devam etmezse sayacı 1 arttır yani hata var !!
                            buyukHarfSayaci++;
                            
                        }

                    }
                    else if (charArray[i].Equals(',') || charArray[i].Equals(';') || charArray[i].Equals('"') || charArray[i].Equals('-'))
                    {
                        harf = charArray[i + 1];

                        if (char.IsLower(harf))
                        {
                            listBox1.Items.Add(charArray[i - 2].ToString() + charArray[i - 1].ToString() + charArray[i].ToString() + charArray[i + 1].ToString() + charArray[i + 2].ToString() + " ");
                            //yani virgülden sonra küçük harfle başladı . hata yok
                            continue;
                        }
                        else
                        {
                            listBox1.Items.Add(charArray[i - 2].ToString() + charArray[i - 1].ToString() + charArray[i].ToString() + charArray[i + 1].ToString() + charArray[i + 2].ToString() + " ");
                            //eğer devam etmezse sayacı 1 arttır yani hata var !!
                            kucukHarfSayaci++;
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ;
            }

           // listBox1.Items.Add(buyukHarfSayaci);
           // label14.Text = kucukHarfSayaci.ToString();
        }

        public void button4_Click(object sender, EventArgs e)
        {
            int liste, girilen;
            double hesapla;
            liste = listBox1.Items.Count;
            int[] dizi = new int[liste];
            label18.Text = dizi.Length.ToString();
            int hata = Convert.ToInt32(label4.Text);
            double hata1 = Convert.ToDouble(label18.Text);
            hesapla = (((hata -hata1)/hata)*100);
            label19.Text = hesapla.ToString();
            if (hesapla>0 && hesapla <10)
            {
                label16.Text = "10";
            }
            else if (hesapla > 10 && hesapla < 20)
            {
                label16.Text = "9";
            }
            else if (hesapla > 20 && hesapla < 30)
            {
                label16.Text = "8";
            }
            else if (hesapla > 30 && hesapla < 40)
            {
                label16.Text = "7";
            }
            else if (hesapla > 40 && hesapla < 50)
            {
                label16.Text = "6";
            }
            else if (hesapla > 50 && hesapla < 60)
            {
                label16.Text = "5";
            }
            else if (hesapla > 60 && hesapla < 70)
            {
                label16.Text = "4";
            }
            else if (hesapla > 70 && hesapla < 80)
            {
                label16.Text = "3";
            }
            else if (hesapla > 80 && hesapla < 90)
            {
                label16.Text = "2";
            }
            else if (hesapla > 90 && hesapla < 100)
            {
                label16.Text = "1";
            }
            else 
            {
                label16.Text = "0";
            }


        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programda dosya uzantısı. txt olakalarak dosyanız ve tez bul butonuna tıkladığınızda tanımlayarak ulaşabilirsiniz. Hatalarınızı görmek için hata bul butonuna kısmına gerekli hatalar gösterilir.Projede kullanılan noktalama işaretlerini görmek için bul butonuna basınız.Hata yüzdesi butonu ile dokumanda oluşan hataya ulaşabilirsiniz.");



            
        }
    }
}
