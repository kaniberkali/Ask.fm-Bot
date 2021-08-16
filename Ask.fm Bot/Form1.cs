using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Ask.fm_Bot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                if (listBox2.Items.Contains(textBox5.Text) == false)
                {
                    listBox2.Items.Add(textBox5.Text);
                    Console.Items.Add(DateTime.Now+": "+"Eleman başarıyla eklendi.");
                }
                else
                    Console.Items.Add(DateTime.Now+": "+"Eleman zaten eklenmiş.");
            }
            else { Console.Items.Add(DateTime.Now+": "+"Boş eleman eklenemez."); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(textBox5.Text);
            Console.Items.Add(DateTime.Now+": "+"Eleman başarıla silindi.");
        }


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Text = listBox2.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Console.Items.Clear();
            Console.Items.Add(DateTime.Now+": "+"Elemanlar temizle.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Console.Items.Add(DateTime.Now+": "+"Elemanlar temizlendi.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        OpenQA.Selenium.Chrome.ChromeDriver drv;
        Thread th;
        bool durdur = false;
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text=="Başlat")
            {
                if (listBox2.Items.Count > 0)
                {
                    if (başlatma == true)
                    {
                        th = new Thread(işlemler); th.Start();
                        Console.Items.Add(DateTime.Now + ": " + "İşlemler başlatıldı.");
                        button3.Text = "Durdur";
                    }
                    else
                    {
                        MessageBox.Show("Lütfen işlemlerin bitirilmesini bekleyin.","@kodzamani.tk, @kaniberkali");
                    }
                }
                else
                    Console.Items.Add(DateTime.Now+": "+"Lütfen profil ekleyin.");
            }
            else
            {
                button3.Enabled = false;
                Console.Items.Add(DateTime.Now+": "+"İşlemlerin durdurulması bekleniyor.");
                durdur = true;
                button3.Text = "Başlat";
            }
        }
        Random rnd = new Random();
        bool başlatma = false;
        private void beğenmeişlemleri()
        {

            int hatasayac = 0; progressBar1.Value = 35;
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                try
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    try
                    {
                        drv.FindElement(By.XPath("//html/body/div[1]/div")).Click(); progressBar1.Value = 36;
                        Console.Items.Add(DateTime.Now + ": " + "Ana sayfaya giriş yapıldı."); progressBar1.Value = 37;
                        Thread.Sleep(rnd.Next(1000, 2000)); progressBar1.Value = 38;
                    }
                    catch { }
                    try
                    {

                        drv.FindElement(By.XPath("//html/body/header/div[4]/p/a[2]")).Click(); progressBar1.Value = 39;
                        Console.Items.Add(DateTime.Now + ": " + "Eklentiler kapatıldı."); progressBar1.Value = 40;
                        Thread.Sleep(rnd.Next(1000, 2000)); progressBar1.Value = 41;
                    }
                    catch { }
                    try
                    {
                        drv.FindElement(By.XPath("//html/body/div[3]/div/section/div[3]/a")).Click(); progressBar1.Value = 42;
                        Thread.Sleep(rnd.Next(1000, 2500)); progressBar1.Value = 43;
                    }
                    catch { }
                    try
                    {
                        drv.FindElement(By.XPath("//html/body/div[5]/div/section/div[3]/a")).Click(); progressBar1.Value = 44;
                        Thread.Sleep(rnd.Next(1000, 2500)); progressBar1.Value = 45;
                    }
                    catch { }
                    try
                    {
                        drv.FindElement(By.XPath("//html/body/div[6]/div/section/div[3]/a")).Click(); progressBar1.Value = 46;
                        Thread.Sleep(rnd.Next(1000, 2500)); progressBar1.Value = 47;
                    }
                    catch { }
                    string urlm = ((IJavaScriptExecutor)drv).ExecuteScript("return window.location.toString()").ToString(); progressBar1.Value = 48;
                    urlm =urlm.Replace("account/discover", listBox2.Items[i].ToString()); progressBar1.Value = 49;
                    drv.Navigate().GoToUrl(urlm); progressBar1.Value = 50;
                    Console.Items.Add(DateTime.Now + ": " + "Arkadaşlar sayfasına giriş yapıldı."); progressBar1.Value = 51;
                    Thread.Sleep(rnd.Next(2000, 4000)); progressBar1.Value = 52;
                    drv.FindElement(By.XPath("//a[@class='btn btn-secondaryInverse btn-compact']")).Click(); progressBar1.Value = 53;
                    Console.Items.Add(DateTime.Now + ": " + listBox2.Items[i] + " Takip edildi."); progressBar1.Value = 54;
                    Console.Items.Add(DateTime.Now + ": " + "Profile başarıyla ulaşıldı."); progressBar1.Value = 55;
                    Console.Items.Add(DateTime.Now + ": " + "Seçilen profil :" + listBox2.Items[i]); progressBar1.Value = 56;
                    try
                    {
                        Thread.Sleep(rnd.Next(2000, 4000)); progressBar1.Value = 57;
                        drv.FindElement(By.XPath("//html/body/div[3]/div/section/a")).Click(); progressBar1.Value = 58;
                        Thread.Sleep(rnd.Next(1000, 2000)); progressBar1.Value = 59;
                    }
                    catch { }
                    try
                    {
                        Thread.Sleep(rnd.Next(2000, 4000)); progressBar1.Value = 60;
                        drv.FindElement(By.XPath("//html/body/div[4]/div/section/div[3]/a")).Click(); progressBar1.Value = 61;
                        Thread.Sleep(rnd.Next(1000, 2000)); progressBar1.Value = 62;
                    }
                    catch { }
                    takipsayisi++; progressBar1.Value = 63;
                    Thread.Sleep(rnd.Next(500, 1000)); progressBar1.Value = 64;
                    progressBar2.Maximum = Convert.ToInt32(numericUpDown3.Value);
                    watch.Stop();
                    double yuvarla = Convert.ToInt32(watch.Elapsed.TotalSeconds);
                    yuvarla = Math.Round(yuvarla, 0);
                    label8.Text = yuvarla + " S";
                    //64
                    watch.Start();
                    for (int a = 1; ; a++)
                    {
                        try
                        {
                            try
                            {
                                progressBar2.Value = a;
                            }
                            catch { }
                            drv.FindElement(By.XPath("//a[@class='icon-like']")).Click();
                            beğenisayisi++;
                            label5.Text = beğenisayisi.ToString();
                            label6.Text = takipsayisi.ToString();
                            Console.Items.Add(DateTime.Now + ": " + "Beğeni gönderildi :" + a);
                            hatasayac = 0;
                            if (a >= Convert.ToInt32(numericUpDown3.Value))
                            {
                                Console.Items.Add(DateTime.Now + ": " + "Beğeni işlemleri başarıyla bitirildi.");
                                break;
                            }
                            try
                            {
                                drv.FindElement(By.XPath("//html/body/div[4]/div/section/a[2]")).Click();
                            }
                            catch { }
                        }
                        catch
                        {
                            a--;
                            if (hatasayac >= 10)
                            {
                                Console.Items.Add(DateTime.Now + ": " + "Beğeni işlemleri başarıyla bitirildi.");
                                break;
                            }
                            else
                            {
                                hatasayac++;
                                Thread.Sleep(rnd.Next(200, 1000));
                                if (hatasayac %4 ==0)
                                {
                                    try
                                    {
                                        ((IJavaScriptExecutor)drv).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                                        Thread.Sleep(rnd.Next(1000, 2000));//?iterator=1000
                                        string urlgetir = drv.FindElement(By.XPath("//a[@class='item-page-next loader']")).GetAttribute("href");
                                        string urlson = urlgetir.Split('&')[1];//older=1596649403
                                        string urlbas = urlgetir.Split('&')[0].Split('?')[1];//iterator=1000
                                        string gelenurl = ((IJavaScriptExecutor)drv).ExecuteScript("return window.location.toString()").ToString();
                                        string url = gelenurl.Split('?')[0];//https://databridge.surf/Caner1754
                                        string urlbitis = "__" + gelenurl.Split('_')[2];//__cpo=aHR0cHM6Ly9hc2suZm0
                                        url = url + "?"+urlbas+"&"+urlson+"&"+urlbitis;
                                        drv.Navigate().GoToUrl(url);
                                    }
                                    catch {}
                                }
                            }
                        }
                    }
                    watch.Stop();
                    double yuvarla2 = Convert.ToInt32(watch.Elapsed.TotalSeconds);
                    yuvarla2 = Math.Round(yuvarla2, 0);
                    label9.Text = yuvarla2 + " S";
                }
                catch
                { }
            }
            Console.Items.Add(DateTime.Now + ": " + "Hesaptan çıkış yapıldı.");
            button3.Enabled = true;
        }
        int takipsayisi = 0;
        int beğenisayisi = 0;
        private void hesapoluştur()
        {
        enbasdon:
            try
            {
                drv.Navigate().GoToUrl("https://www.croxyproxy.com/");progressBar1.Value = 1;
                Console.Items.Add(DateTime.Now+": "+"Proxy sunucusuna bağlanıldı."); progressBar1.Value = 2;
                if (checkBox3.Checked == true)
                    Thread.Sleep(rnd.Next(Convert.ToInt32(numericUpDown1.Value)/2, Convert.ToInt32(numericUpDown1.Value)*2));
                else
                    Thread.Sleep(rnd.Next(2000, 4000)); progressBar1.Value = 3;
                drv.FindElement(By.XPath("//html/body/div[2]/div/div/div/div[2]/div[2]/form/div/div/div/div/input")).SendKeys("https://ask.fm/signup"); progressBar1.Value = 4;
                Console.Items.Add(DateTime.Now+": "+"Kayıt olma sayfası yazıldı."); progressBar1.Value = 5;
                Thread.Sleep(rnd.Next(500, 1000)); progressBar1.Value = 6;
                drv.FindElement(By.XPath("//html/body/div[2]/div/div/div/div[2]/div[2]/form/div/span/button")).Click(); progressBar1.Value = 7;

                Console.Items.Add(DateTime.Now+": "+"Kayıt olma sayfasına giriş yapıldı.."); progressBar1.Value = 8;
            basdonn:
                Thread.Sleep(rnd.Next(1000, 2000)); progressBar1.Value = 9;
                if (drv.Url.Contains("signup") == false)
                {
                    if (drv.Url.Contains("account/wall")==true)
                    {
                        drv.FindElement(By.XPath("//html/body/header/div[1]/section/nav/a[6]")).Click();
                        Console.Items.Add(DateTime.Now + ": " + "Bir hata oluştu gideriliyor.");
                        Thread.Sleep(rnd.Next(500, 1000)); 
                        drv.FindElement(By.XPath("//html/body/header/div[1]/section/nav/nav[1]/a[2]")).Click();
                        Thread.Sleep(rnd.Next(2000, 4000));
                        Console.Items.Add(DateTime.Now + ": " + "Hata giderildi.");
                        goto enbasdon;
                    }
                    goto basdonn;
                }
                int rastgele = rnd.Next(10, 25); progressBar1.Value = 10;
                string veriler = "QAZWSXEDCRFVTGBYHNUJMIKOLPqazwsxedcrfvtgbyhnujmklopi"; progressBar1.Value = 11;
                string mail = ""; progressBar1.Value = 12;
                for (int i = 0; i < rastgele; i++)
                {
                    mail += veriler[rnd.Next(veriler.Length)];
                }
                mail += "@hotmail.com"; progressBar1.Value = 13;
                drv.FindElement(By.XPath("//html/body/main/div/div[1]/form/div[2]/div[1]/input")).SendKeys(mail); progressBar1.Value = 14;
                Console.Items.Add(DateTime.Now+": "+"Mail girildi."); progressBar1.Value = 15;
                Thread.Sleep(rnd.Next(200, 400)); progressBar1.Value = 16;
                int gün = rnd.Next(2, 30); progressBar1.Value = 17;
                drv.FindElement(By.XPath("//html/body/main/div/div[1]/form/div[2]/table/tbody/tr/td[1]/select/option[" + gün + "]")).Click(); progressBar1.Value = 18;
                Console.Items.Add(DateTime.Now+": "+"Gün seçildi."); progressBar1.Value = 19;
                Thread.Sleep(rnd.Next(200, 400)); progressBar1.Value = 20;
                int ay = rnd.Next(2, 14); progressBar1.Value = 21;
                drv.FindElement(By.XPath("//html/body/main/div/div[1]/form/div[2]/table/tbody/tr/td[2]/select/option[" + ay + "]")).Click(); progressBar1.Value = 22;
                Console.Items.Add(DateTime.Now+": "+"Ay seçildi."); progressBar1.Value = 23;
                Thread.Sleep(rnd.Next(200, 400)); progressBar1.Value = 24;
                int yıl = rnd.Next(18, 25); progressBar1.Value = 25;
                drv.FindElement(By.XPath("//html/body/main/div/div[1]/form/div[2]/table/tbody/tr/td[3]/select/option[" + yıl + "]")).Click(); progressBar1.Value = 26;
                Console.Items.Add(DateTime.Now+": "+"Yıl seçildi."); progressBar1.Value = 27;
                Thread.Sleep(rnd.Next(2000, 3000)); progressBar1.Value = 28;
                try
                {
                    drv.FindElement(By.XPath("//html/body/main/div/div[1]/form/div[2]/div[3]/input")).SendKeys(mail.Split('@')[0]);
                    Console.Items.Add(DateTime.Now + ": " + "Yeni kullaniciadi oluşturuldu.");
                    Thread.Sleep(rnd.Next(2000, 3000)); progressBar1.Value = 28;
                }
                catch
                {

                }
                try
                {
                    drv.FindElement(By.XPath("//html/body/main/div/div[1]/form/div[4]/input")).Click(); progressBar1.Value = 29;
                }
            catch { goto enbasdon; }
            Console.Items.Add(DateTime.Now+": "+"Kayıt ol butonuna tıklatıldı."); progressBar1.Value = 30;
                Thread.Sleep(rnd.Next(2000, 4000)); progressBar1.Value = 31;
                if (drv.Url.Contains("signup") == true)
                    goto enbasdon;
                Console.Items.Add(DateTime.Now+": "+"Başarıyla giriş yapıldı."); progressBar1.Value = 32;
                Thread.Sleep(rnd.Next(2000, 4000)); progressBar1.Value = 33;
                beğenmeişlemleri(); progressBar1.Value = 34;
            }
            catch { goto enbasdon; }
        }
        private void girisislemi()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ChromeOptions option = new ChromeOptions(); progressBar1.Value = 5; progressBar2.Value = 5;
            Console.Items.Add(DateTime.Now+": "+"Chrome ayarları yapıldı."); progressBar1.Value = 10; progressBar2.Value = 10;
            option.AddExtension("kodzamani.weebly.com.crx"); progressBar1.Value = 15; progressBar2.Value = 15;
            option.AddExcludedArgument("enable-automation"); progressBar1.Value = 20; progressBar2.Value = 20;
            option.AddAdditionalCapability("useAutomationExtension", false); progressBar1.Value = 25; progressBar2.Value = 25;
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(); progressBar1.Value = 30; progressBar2.Value = 30;
            service.HideCommandPromptWindow = true; progressBar1.Value = 35; progressBar2.Value = 35;
            Console.Items.Add(DateTime.Now+": "+"Driver ayarları yapıldı."); progressBar1.Value = 40; progressBar2.Value = 40;
            drv = new ChromeDriver(service, option); progressBar1.Value = 45; progressBar2.Value = 45;
            Console.Items.Add(DateTime.Now+": "+"Chrome oluşturuldu."); progressBar1.Value = 50; progressBar2.Value = 50;
        badon:
            Thread.Sleep(4000); progressBar1.Value = 55; progressBar2.Value = 55;
            try
            {
                drv.SwitchTo().Window(drv.WindowHandles[1]).Close(); progressBar1.Value = 60; progressBar2.Value = 60;
                drv.SwitchTo().Window(drv.WindowHandles[0]); progressBar1.Value = 65; progressBar2.Value = 65;
            }
            catch { goto badon; }
            Console.Items.Add(DateTime.Now + ": " + "Reklam engelleyici başlatıldı."); progressBar1.Value = 70; progressBar2.Value = 70;
            Thread.Sleep(3000); progressBar1.Value = 75; progressBar1.Value = 75;
            drv.Navigate().GoToUrl("https://kodzamani.weebly.com"); progressBar1.Value = 80; progressBar2.Value = 80;
            Console.Items.Add(DateTime.Now + ": " + "Başlatma bekleniyor."); progressBar1.Value = 85; progressBar2.Value = 85;
            başlatma = true; progressBar1.Value = 100; progressBar2.Value = 100;
            watch.Stop();
            double yuvarla = Convert.ToInt32(watch.Elapsed.TotalSeconds);
            yuvarla = Math.Round(yuvarla, 0);
            label8.Text = yuvarla + " S";
            label9.Text = yuvarla + " S";
            progressBar1.Value = progressBar1.Maximum;
        }
        private void işlemler()
        {
            for (; ; )
            {
                if (durdur == false)
                {
                    progressBar2.Value = 0;
                    progressBar1.Value = 0;
                    progressBar1.Maximum = 64;
                    hesapoluştur();
                }
                else
                {
                    Console.Items.Add("İşlemler başarıyla durduruldu.");
                    break;
                }
                label5.Text = beğenisayisi.ToString();
                label6.Text = takipsayisi.ToString();
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Console.SelectedIndex = Console.Items.Count - 1;
                if (Console.Items.Count >=1000)
                {
                    Console.Items.Clear();
                    Console.Items.Add("Programın yazarı @kodzamani.tk, @kaniberkali");
                    Console.Items.Add("Website :https://kodzamani.weebly.com");
                    Console.Items.Add(DateTime.Now+ ": Konsol temizlendi.");
                }
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar2.Minimum = 0;
            progressBar2.Maximum = 100;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            Console.Items.Add("Programın yazarı @kodzamani.tk, @kaniberkali");
            Console.Items.Add("Website :https://kodzamani.weebly.com");
            timer1.Enabled = true;
            timer1.Interval = 100;
            th = new Thread(girisislemi);th.Start();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Console.Items.Add(DateTime.Now+": "+"İşlem başı bekleme süresi ayarlandı.");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://kodzamani.weebly.com");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (drv != null)
                drv.Quit();
        }
    }
}
