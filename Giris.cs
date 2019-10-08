using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pseudoInverse
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        Fonksiyonlar fonkGiris = new Fonksiyonlar();

        //carpim ve toplam sayıları
        public static int carpma, toplama;

        Random random = new Random();

        public static double[,] matris;
        double[,] transpoze;
        double[,] carpim;
        double[,] cofMatris;
        double[,] ekMatris;
        double[,] tersMatris;
        double[,] pseudoMatris;

        public static int m, n;
        List<TextBox> listTextBox = new List<TextBox>();

        private void M_buyuktur_N()
        {
            /*
                 random olarak matris oluşturulduktan sonra 
                 pseudo-inverse işlemi gerçekleştirilir

                        pinv(m)= ((m' * m)^-1 ) * m'

                en küçük kareler yöntemi ile kare matris haline getirilir.
                
                 m' * m -> kare matris olur.
                 ek matris yöntemi ile m' * m işleminin tersi alınmalı
                 çıkan matris sonucu ile m' çarpılınca m x n 'lik matrisn sözde tersi hesaplanmış olacak

                */
            //yapılacak ilk işlem m'nin transpozunu al
            //n ve m nin yerleri önemli 
            rich_txt_matris.Text += "MATRİSİN TRANSPOZESİ\n";
            transpoze = fonkGiris.transpozeOlustur(matris.GetLength(0), matris.GetLength(1), matris);
            fonkGiris.matrisYazdir(transpoze.GetLength(0), transpoze.GetLength(1), transpoze, rich_txt_matris);
            rich_txt_matris.Text += "\n\n";

            //m' * m
            rich_txt_matris.Text += "ÇARPIM MATRİSİ(TRANSPOZE * MATRİS)\n";
            carpim = fonkGiris.matrisCarp(transpoze, matris);
            fonkGiris.matrisYazdir(carpim.GetLength(0), carpim.GetLength(1), carpim, rich_txt_matris);
            rich_txt_matris.Text += "\n\n";

            /*
            buradan sonra (m' * m) in tersi alınacak 
            cofacktor yöntemi ile ek matris bulunup 

             m^-1=1/|m| * A
             burada |m| m nin determinanti 
             A` nın ek matris
             ek matris= kofaktör matrisin transpozesi

             ilk yapılacak işlem ek matris ve determinant hesaplanması
            */


            cofMatris = new double[carpim.GetLength(0), carpim.GetLength(0)];
            ekMatris = new double[carpim.GetLength(0), carpim.GetLength(0)];
            tersMatris = new double[carpim.GetLength(0), carpim.GetLength(0)];

            rich_txt_matris.Text += "TERSİ ALINABİLİRLİK İÇİN DETERMİNANT SONUCU\n";

            double detCarpim = fonkGiris.determinantHesapla(carpim);
            if (detCarpim == 0)
            {
                rich_txt_matris.Text += "Determinant değeri 0 -> Tersi alınamadı";
            }
            else
            {
                rich_txt_matris.Text += "Determinant değeri 0 değil";
                rich_txt_matris.Text += "\n\n";

                if (carpim.GetLength(0) == 1)
                {
                    for (int i = 0; i < carpim.GetLength(0); i++)
                    {
                        for (int j = 0; j < carpim.GetLength(0); j++)
                        {
                            tersMatris[i, j] = (1 / detCarpim) * transpoze[i, j];
                            carpma += 2;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < carpim.GetLength(0); i++)
                    {
                        for (int j = 0; j < carpim.GetLength(0); j++)
                        {
                            cofMatris[i, j] = Math.Pow(-1, (i + j + 2)) * fonkGiris.determinantHesapla(fonkGiris.minorBul(carpim, i, j));
                            carpma++;
                            toplama += 2;
                        }
                    }

                    rich_txt_matris.Text += "ÇARPIM MATRİSİNİN KOFAKTÖR MATRİSİ\n";
                    fonkGiris.matrisYazdir(cofMatris.GetLength(0), cofMatris.GetLength(1), cofMatris, rich_txt_matris);
                    rich_txt_matris.Text += "\n\n";

                    //kofaktör matrisin transpozesi alınıyor
                    rich_txt_matris.Text += "KOFAKTÖR MATRİSİNİN TRANSPOZU EK MATRİSTİR. \n";
                    ekMatris = fonkGiris.transpozeOlustur(cofMatris.GetLength(0), cofMatris.GetLength(0), cofMatris);
                    rich_txt_matris.Text += "ÇARPIM MATRİSİNİN EK MATRİSİ\n";
                    fonkGiris.matrisYazdir(ekMatris.GetLength(0), ekMatris.GetLength(1), ekMatris, rich_txt_matris);
                    rich_txt_matris.Text += "\n\n";

                    rich_txt_matris.Text += "Matrisin '1/det|çarpım matrisi|' değeri ile çarpımı Çarpım Matrisinin Tersini  verir.\n";

                    //     (1/det|m|)*EkMatris

                    for (int i = 0; i < ekMatris.GetLength(0); i++)
                    {
                        for (int j = 0; j < ekMatris.GetLength(0); j++)
                        {
                            tersMatris[i, j] = (1 / detCarpim) * ekMatris[i, j];
                            carpma += 2;
                        }
                    }
                }
                rich_txt_matris.Text += "ÇARPIM MATRİSİNİN TERSİ\n";
                fonkGiris.matrisYazdir(tersMatris.GetLength(0), tersMatris.GetLength(1), tersMatris, rich_txt_matris);
                rich_txt_matris.Text += "\n\n";

                //        pinv(m)= ((m' * m)^-1 ) hesaplandi m' ile çarpılmalı

                rich_txt_matris.Text += "Çarpım matrisinin tersi matrisin tranpozesi ile çarpılır.\n";

                rich_txt_matris.Text += "\n\n";
                rich_txt_matris.Text += "PSEUDO INVERSE MATRİS\n";
                pseudoMatris = fonkGiris.matrisCarp(tersMatris, transpoze);
                fonkGiris.matrisYazdir(pseudoMatris.GetLength(0), pseudoMatris.GetLength(0), pseudoMatris, rich_txt_matris);
            }
        }

        private void N_buyuktur_M()
        {
            // n>m olduğu için formul aşağıdaki gibi oldu
            //        pinv(m)= m'*(m*m')^-1

            //   ilk önce  m * m' hesaplanacak


            rich_txt_matris.Text += "MATRİSİN TRANSPOZESİ\n";
            transpoze = fonkGiris.transpozeOlustur(m, n, matris);
            fonkGiris.matrisYazdir(transpoze.GetLength(0), transpoze.GetLength(1), transpoze, rich_txt_matris);
            rich_txt_matris.Text += "\n\n";

            rich_txt_matris.Text += "ÇARPIM(MATRİS * TRANSPOZE) MATRİSİ\n";
            carpim = fonkGiris.matrisCarp(matris, transpoze);
            fonkGiris.matrisYazdir(carpim.GetLength(0), carpim.GetLength(1), carpim, rich_txt_matris);
            rich_txt_matris.Text += "\n\n";

            // ( m * m')^ -1 hesaplanacak

            cofMatris = new double[carpim.GetLength(0), carpim.GetLength(0)];
            ekMatris = new double[carpim.GetLength(0), carpim.GetLength(0)];
            tersMatris = new double[carpim.GetLength(0), carpim.GetLength(0)];


            rich_txt_matris.Text += "TERSİ ALINABİLİRLİK İÇİN DETERMİNANT SONUCU\n";

            double detCarpim = fonkGiris.determinantHesapla(carpim);
            if (detCarpim == 0)
            {
                rich_txt_matris.Text += "Determinant değeri 0 -> Tersi alınamadı";
            }
            else
            {
                rich_txt_matris.Text += "Determinant değeri 0 değil\n";

                if (carpim.GetLength(0) == 1)
                {
                    for (int i = 0; i < carpim.GetLength(0); i++)
                    {
                        for (int j = 0; j < carpim.GetLength(0); j++)
                        {
                            tersMatris[i, j] = (1 / detCarpim) * transpoze[i, j];
                            carpma += 2;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < carpim.GetLength(0); i++)
                    {
                        for (int j = 0; j < carpim.GetLength(0); j++)
                        {
                            cofMatris[i, j] = Math.Pow(-1, (i + j + 2)) * fonkGiris.determinantHesapla(fonkGiris.minorBul(carpim, i, j));
                            carpma++;
                            toplama += 2;
                        }
                    }
                    rich_txt_matris.Text += "\n\n";
                    rich_txt_matris.Text += "ÇARPIM MATRİSİNİN KOFAKTÖR MATRİSİ\n";
                    fonkGiris.matrisYazdir(cofMatris.GetLength(0), cofMatris.GetLength(1), cofMatris, rich_txt_matris);
                    rich_txt_matris.Text += "\n\n";


                    rich_txt_matris.Text += "KOFAKTÖR MATRİSİNİN TRANSPOZU EK MATRİSTİR. \n";
                    //kofaktör matrisin transpozesi alınıyor
                    ekMatris = fonkGiris.transpozeOlustur(cofMatris.GetLength(0), cofMatris.GetLength(0), cofMatris);
                    rich_txt_matris.Text += "ÇARPIM MATRİSİNİN EK MATRİSİ\n";
                    fonkGiris.matrisYazdir(ekMatris.GetLength(0), ekMatris.GetLength(1), ekMatris, rich_txt_matris);

                    rich_txt_matris.Text += "Matrisin '1/det|çarpım matrisi|' değeri ile çarpımı Çarpım Matrisinin Tersini  verir.\n";

                    //     (1/det|m|)*EkMatris

                    for (int i = 0; i < ekMatris.GetLength(0); i++)
                    {
                        for (int j = 0; j < ekMatris.GetLength(0); j++)
                        {
                            tersMatris[i, j] = (1 / detCarpim) * ekMatris[i, j];
                            carpma += 2;
                        }
                    }
                }


                
                rich_txt_matris.Text += "\n\n";
                rich_txt_matris.Text += "ÇARPIM MATRİSİNİN TERSİ\n";
                fonkGiris.matrisYazdir(tersMatris.GetLength(0), tersMatris.GetLength(1), tersMatris, rich_txt_matris);
                rich_txt_matris.Text += "\n\n";

                //buraya kadar (m * m')^-1 hesaplandı 
                //şimdi  m' * (m * m')^-1 hesaplanacak

                rich_txt_matris.Text += "Matrisin transpozesi ile çarpım Matrisinin tersinin çarpımı sözde tersi verir.\n";
                pseudoMatris = fonkGiris.matrisCarp(transpoze, tersMatris);
                rich_txt_matris.Text += "PSEUDO INVERSE MATRİS\n";
                fonkGiris.matrisYazdir(pseudoMatris.GetLength(0), pseudoMatris.GetLength(1), pseudoMatris, rich_txt_matris);
            }
        }

        private void btn_random_Click(object sender, EventArgs e)
        {
            carpma = 0;
            toplama = 0;
            rich_txt_matris.Clear();

            //5 dahil olması için
            m = random.Next(1, 6);
            do
            {
                n = random.Next(1, 6);
            } while (m == n);

            //m=getLength(0); satır
            //n=getLength(1); sütun

            matris = fonkGiris.randomMatrisOlustur(m, n);
            rich_txt_matris.Text += "MATRİSİN KENDİSİ\n";
            fonkGiris.matrisYazdir(matris.GetLength(0), matris.GetLength(1), matris, rich_txt_matris);
            rich_txt_matris.Text += "\n\n";

            //matis oluşturuldu
            if (m > n)
            {
                M_buyuktur_N();
            }
            else
            {
                N_buyuktur_M();
            }
            rich_txt_matris.Text += "\n\n";
            rich_txt_matris.Text += "Hesaplamalarda kullanılan toplam; \n";
            rich_txt_matris.Text += "toplama işlemi sayısı : " + toplama;
            rich_txt_matris.Text += "\nçarpma  işlemi sayısı : " + carpma + "\n";
        }

        private void btn_mxn_Click(object sender, EventArgs e)
        {
            lbl_uyari.Visible = true;
            lbl_uyari.Text = "Matrisi doldurunuz.";
            m = Convert.ToInt32(txt_M.Text);
            n = Convert.ToInt32(txt_N.Text);

            //tekrar basmalarda elemanların temizlenmesi
            foreach (TextBox item in listTextBox)
            {
                this.Controls.Remove(item);
            }
            listTextBox.Clear();

            matris = new double[m, n];
            int x = 616;
            int y = 105;
            Font fnt = new Font("Maiandra GD", 11.25f);

            for (int i = 0; i < Giris.m; i++)
            {
                x = 616;
                for (int j = 0; j < Giris.n; j++)
                {
                    TextBox t = new TextBox();
                    t.Location = new System.Drawing.Point(x, y);
                    t.Size = new System.Drawing.Size(30, 25);
                    t.Font = fnt;
                    t.KeyPress += t_KeyPress;
                    t.TextChanged += t_textChanged;
                    this.Controls.Add(t);
                    listTextBox.Add(t);
                    x += 36;
                }
                y += 31;
            }

        }
        private void t_textChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(((TextBox)sender).Text))
            {
                lbl_uyari.Text = "Lütfen boş alan bırakmayınız.";
                btn_matris_olustur.Enabled = false;
            }
            else if (Convert.ToInt32(((TextBox)sender).Text) < 10 && Convert.ToInt32(((TextBox)sender).Text) > 0)
            {
                btn_matris_olustur.Enabled = true;
                lbl_uyari.Text = "";
            }
            else
            {
                lbl_uyari.Text = "Lütfen 1-5 arasında bir değer giriniz.";
                btn_matris_olustur.Enabled = false;
            }
        }
        private void t_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            // boşluk girilmemesi için
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }

        private void txt_M_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_M.Text) || txt_M.Text == txt_N.Text || String.IsNullOrEmpty(txt_N.Text))
            {
                btn_mxn.Enabled = false;
                lbl_uyari.Visible = true;
                lbl_uyari.Text = "M ve N değerleri birbirlerinden farklı olmalıdır ya da boş bırakılmamalı!";
            }
            else if (Convert.ToInt32(txt_M.Text) > 5 || Convert.ToInt32(txt_M.Text) < 1)
            {
                btn_mxn.Enabled = false;
                lbl_uyari.Visible = true;
                lbl_uyari.Text = "1-5 arasında değer giriniz.";
            }
            else
            {
                btn_mxn.Enabled = true;
                lbl_uyari.Visible = false;
            }
        }

        private void txt_N_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_N.Text) || txt_M.Text == txt_N.Text || String.IsNullOrEmpty(txt_M.Text))
            {
                btn_mxn.Enabled = false;
                lbl_uyari.Visible = true;
                lbl_uyari.Text = "M ve N değerleri birbirlerinden farklı olmalıdır ya da boş bırakılmamalı!";
            }
            else if (Convert.ToInt32(txt_N.Text) > 5 || Convert.ToInt32(txt_N.Text) < 1)
            {
                btn_mxn.Enabled = false;
                lbl_uyari.Visible = true;
                lbl_uyari.Text = "1-5 arasında değer giriniz.";
            }
            else
            {
                btn_mxn.Enabled = true;
                lbl_uyari.Visible = false;
            }
        }

        private void txt_M_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            //boşluk girilmemesi için
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }

        private void btn_matris_olustur_Click(object sender, EventArgs e)
        {
            bool bosEleman = false; ;

            foreach (TextBox item in listTextBox)
            {
                if (String.IsNullOrEmpty(item.Text))
                {
                    bosEleman = true;
                }
                else
                {
                    bosEleman = false;
                }
            }
            if (bosEleman == false)
            {
                lbl_uyari.Text = "Matris oluşturuldu.";
                carpma = 0;
                toplama = 0;
                rich_txt_matris.Clear();
                int say = 0;
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matris[i, j] = Convert.ToInt32(listTextBox[say].Text);
                        say++;
                    }

                }
                rich_txt_matris.Text += "MATRİSİN KENDİSİ\n";
                fonkGiris.matrisYazdir(matris.GetLength(0), matris.GetLength(1), matris, rich_txt_matris);
                rich_txt_matris.Text += "\n\n";

                if (m > n)
                {
                    M_buyuktur_N();
                }
                else
                {
                    N_buyuktur_M();
                }
                rich_txt_matris.Text += "\n\n";
                rich_txt_matris.Text += "Hesaplamalarda kullanılan toplam; \n";
                rich_txt_matris.Text += "toplama işlemi sayısı : " + toplama;
                rich_txt_matris.Text += "\nçarpma  işlemi sayısı : " + carpma + "\n";
            }
            else
            {
                lbl_uyari.Text = "Önce boş alanları doldurunuz.";
            }

        }


        private void Giris_Load(object sender, EventArgs e)
        {
            lbl_uyari.Visible = false;
            btn_mxn.Enabled = false;
            btn_matris_olustur.Enabled = false;
        }
    }
}
