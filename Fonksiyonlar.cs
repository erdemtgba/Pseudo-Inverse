using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pseudoInverse
{
    class Fonksiyonlar
    {
        
        Random random = new Random();


        public double[,] randomMatrisOlustur(int m, int n)
        {
            double[,] matris = new double[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matris[i, j] = random.Next(1, 10);
                    
                }
            }
            return matris; 
        }

        public void matrisYazdir(int m, int n, double[,] matris,object sender)
        {
            for (int i = 0; i < m ; i++)
            {
                for (int j = 0; j < n ; j++)
                {
                    //t= "[" + i.ToString() + "," + j.ToString() + "] = ";
                    //((RichTextBox)sender).Text += t;
                    ((RichTextBox)sender).Text += String.Format("{0:0.00}", matris[i, j]);
                    ((RichTextBox)sender).Text += "   ";
                }
               ((RichTextBox)sender).Text += "\n";
            }
        }

        public double[,] transpozeOlustur(int m,int n, double[,] matris)
        {
            double[,] transpoze = new double[n, m];

            for (int i = 0; i < m; i++)
            { 
                for (int j = 0; j < n; j++)
                {
                    transpoze[j, i] = matris[i, j]; // satır ve sutunları yer değiştir
                }
            }

            return transpoze;
        }
        
        public double[,] matrisCarp(double[,] m1, double[,] m2)
        {
            double[,] carpim = new double[m1.GetLength(0),m2.GetLength(1)];
            //int toplam = 0;

            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m2.GetLength(1); j++)
                {
                    for (int k = 0; k < m1.GetLength(1); k++)
                    {
                        carpim[i, j] += m1[i, k] * m2[k, j];
                        Giris.carpma++;
                        Giris.toplama++;
                    }
                }
            }

            return carpim;
        }

        public double[,] minorBul(double[,] matris, int x, int y)
        {
            if (matris.GetLength(0) == 1)
            {
                return matris;
            }
            double[,] minor = new double[matris.GetLength(0) - 1,matris.GetLength(0) - 1];
            int a = 0, b = 0;
            for (int i = 0; i < matris.GetLength(0); i++)
            {
                for (int j = 0; j < matris.GetLength(0); j++)
                {
                    if (i == x || j == y)
                    {
                        continue;
                    }
                    else
                    {
                        minor[a,b] = matris[i,j];
                        b++;
                        if (b == matris.GetLength(0) - 1)
                        {
                            a++;
                            b = 0;
                        }
                    }
                }
            }

            return minor;
            
        }

        //https://www.delimuhendis.com/matris-determinanti/

        public double determinantHesapla(double[,] matris)
        {
            int boyut = matris.GetLength(0); 
            int isaret = 1;
            double toplam = 0;
            if (boyut == 1)
                return matris[0, 0];
            for (int i = 0; i < boyut; i++)
            {
                double[,] altMatris = new double[boyut - 1, boyut - 1];
                for (int satir = 1; satir < boyut; satir++)
                {
                    for (int sutun = 0; sutun < boyut; sutun++)
                    {
                        if (sutun < i)
                            altMatris[satir - 1, sutun] = matris[satir, sutun];
                        else if (sutun > i)
                            altMatris[satir - 1, sutun - 1] = matris[satir, sutun];
                    }
                }
                if (i % 2 == 0)
                    isaret = 1;
                else
                    isaret = -1;

                toplam += isaret * matris[0, i] * (determinantHesapla(altMatris));
                Giris.carpma += 2;
                Giris.toplama++;

            }

            return toplam;

        }
    }



}
