using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace appbankomat
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        object lock1=new object();
        Banknoty banknoty=new Banknoty();

        int srodki=550;
        int p500 = 0;
        int p50 = 0;
        int p100 = 0;
        int p200 = 0;
        int p10 = 0;
        int p20 = 0;
        int lastvar500;
        int lastvar200;
        int lastvar100;
        int lastvar50;
        int lastvar20;
        int lastvar10;
        int cashwyp=0;

        public MainWindow()
        {
            InitializeComponent();
            lastvar500 = int.Parse(tx500.Text);
            lastvar200 = int.Parse(tx200.Text);
            lastvar100 = int.Parse(tx100.Text);
            lastvar50 = int.Parse(tx50.Text);
            lastvar20 = int.Parse(tx20.Text);
            lastvar10 = int.Parse(tx10.Text);
            kontostan.Content = "Stan konta: " + srodki.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lock (lock1)
            {
                string pieniadze = t1.Text;
                int ilosc = int.Parse(pieniadze);
                if(banknoty.cash() < ilosc)
                {
                    errormessage.Visibility = Visibility.Visible;
                    errormessage.Content = "Brak wystarczajacej ilosc banknotow do zrealizowania tej operacji";
                }
                else
                {
                    errormessage.Visibility= Visibility.Hidden;
                }
                int iterationcount = 0;
                int checkiteration = banknoty.ilebanknotow();
                if (ilosc > srodki)
                {
                    brakpien.Visibility = Visibility.Visible;
                }
                else
                {
                    brakpien.Visibility= Visibility.Hidden;
                }
                while (ilosc >= 10&&banknoty.cash()>=ilosc&&srodki>=ilosc&&iterationcount<banknoty.ilebanknotow())
                {
                    if (ilosc >= 500&&int.Parse(tx500.Text)>0)
                    {
                        p500++;
                        int poom = int.Parse(tx500.Text);
                        int poom12 = poom - 1;
                        tx500.Text=poom12.ToString();
                        ilosc = ilosc - 500;
                        srodki=srodki- 500;
                    }
                    else
                    {
                        if (ilosc >= 200 && int.Parse(tx200.Text) > 0)
                        {

                            p200++;
                            int poom = int.Parse(tx200.Text);
                            int poom12 = poom - 1;
                            tx200.Text = poom12.ToString();
                            ilosc = ilosc - 200;
                            srodki = srodki - 200;
                        }
                        else
                        {
                            if (ilosc >= 100 && int.Parse(tx100.Text) > 0)
                            {
                                p100++;
                                int poom = int.Parse(tx100.Text);
                                int poom12 = poom - 1;
                                tx100.Text = poom12.ToString();
                                ilosc = ilosc - 100;
                                srodki = srodki - 100;
                            }
                            else
                            {
                                if (ilosc >= 50 && int.Parse(tx50.Text) > 0)
                                {

                                    p50++;
                                    int poom = int.Parse(tx50.Text);
                                    int poom12 = poom - 1;
                                    tx50.Text = poom12.ToString();
                                    ilosc = ilosc - 50;
                                    srodki = srodki - 50;
                                }
                                else
                                {
                                    if (ilosc >= 20 && int.Parse(tx20.Text) > 0)
                                    {
                                        p20++;
                                        int poom = int.Parse(tx20.Text);
                                        int poom12 = poom - 1;
                                        tx20.Text = poom12.ToString();
                                        ilosc = ilosc - 20;
                                        srodki = srodki - 20;
                                    }
                                    else
                                    {
                                        if (int.Parse(tx10.Text) > 0)
                                        {
                                            if (ilosc >= 10)
                                            {
                                                p10++;
                                                int poom = int.Parse(tx10.Text);
                                                int poom12 = poom - 1;
                                                tx10.Text = poom12.ToString();
                                                ilosc = ilosc - 10;
                                                srodki = srodki - 10;
                                            }
                                        }
                                        else
                                        {
                                            errorbrak.Visibility = Visibility.Visible;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                    iterationcount++;

                    kontostan.Content = "Stan konta: " + srodki.ToString();
                }
                if (iterationcount == checkiteration)
                {
                    errorbrak.Visibility = Visibility.Visible;
                }
                else
                {
                    errorbrak.Visibility = Visibility.Hidden;
                }
                iterationcount = 0;
                kontostan.Content = "Stan konta: " + srodki.ToString();

                pieniadzeWyp.Content = "Wypłacono: \n" + p500 + " banknotow 500 \n" + p200 + " banknotow 200 \n" + p100 + " banknotow 100 \n" + p50 + " banknotow 50 \n" + p20 + " banknotow 20 \n" + p10 + " banknotow 10 \n";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lock (lock1)
            {
                int wplata = int.Parse(t2.Text);
                srodki = srodki+ wplata;
                kontostan.Content = "Stan konta " + srodki.ToString() ;
            }
        }

        

       

        private void tx500_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(tx500.Text, out _) == true)
            {
                lastvar500 = int.Parse(tx500.Text);
                banknoty.b500add(lastvar500);
            }
            else
            {
                tx500.Text = lastvar500.ToString();
            }
        }

        private void tx200_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(tx200.Text, out _) == true)
            {
                lastvar200 = int.Parse(tx200.Text);
                banknoty.b200add(lastvar200);
            }
            else
            {
                tx200.Text = lastvar200.ToString();
            }
        }

        private void tx100_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(tx100.Text, out _) == true)
            {
                lastvar100 = int.Parse(tx100.Text);
                banknoty.b100add(lastvar100);
            }
            else
            {
                tx100.Text = lastvar100.ToString();
            }
        }

        private void tx50_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(tx50.Text, out _) == true)
            {
                lastvar50 = int.Parse(tx50.Text);
                banknoty.b50add(lastvar50);
            }
            else
            {
                tx50.Text = lastvar50.ToString();
            }
        }

        private void tx20_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(tx20.Text, out _) == true)
            {
                lastvar20 = int.Parse(tx20.Text);
                banknoty.b20add(lastvar20);
            }
            else
            {
                tx20.Text = lastvar20.ToString();
            }
        }

        private void tx10_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(tx10.Text, out _) == true)
            {
                lastvar10 = int.Parse(tx10.Text);
                banknoty.b10add(lastvar10);
            }
            else
            {
                tx10.Text = lastvar10.ToString();
            }
        }

        private void t1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (t1.Text != "")
            {
                if (int.TryParse(t1.Text, out _) == true)
                {
                    cashwyp = int.Parse(t1.Text);
                }
                else
                {
                    t1.Text = cashwyp.ToString();
                }
            }
        }
    }
}
