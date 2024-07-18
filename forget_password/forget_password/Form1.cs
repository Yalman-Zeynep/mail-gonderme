using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
namespace forget_password
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlbaglantisi bgln = new sqlbaglantisi();
            SqlCommand komut = new SqlCommand(" select * from person Where person_name='" + textBox1.Text.ToString() + "'and person_mail= '" + textBox2.Text.ToString() + "'", bgln.baglanti());

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                try
                {
                    if (bgln.baglanti().State == ConnectionState.Closed)
                    {
                        bgln.baglanti().Open();
                    }
                    SmtpClient smtpserver = new SmtpClient();
                    MailMessage mail = new MailMessage();
                    string tarih = DateTime.Now.ToLongDateString();
                    string mailadresin = "zynpylmnzynpylmn@outlook.com";
                    string şifre = "Mail.proje";
                    string smptsrvr = "smtp.office365.com";
                    string kime = (oku["eposta"].ToString());
                    string konu = ("sifre hatirlatma maili");
                    string yaz = ("Sayın, " + oku["person_name"].ToString() + "\n" + "Bizden" + tarih + "tarihinde şifre hatırlatma talebinde bulundunuz" + '\n' +
                    "parolanız:" + oku["person_password"].ToString() + "\n İyi Günler");

                    smtpserver.Credentials = new NetworkCredential(mailadresin, şifre);
                    smtpserver.Port = 587;
                    smtpserver.Host = smptsrvr;
                    smtpserver.EnableSsl = true;
                    mail.From = new MailAddress(mailadresin);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body = yaz;
                    smtpserver.Send(mail);
                    DialogResult bilgi = new DialogResult();
                    bilgi = MessageBox.Show("Girmiş oldugunuz bilgiler uyuşuyor. Şifreniz mail adresinize gönderilmiştir.");
                    this.Hide();
                }
                catch (Exception Hata)
                {
                    MessageBox.Show("mail gönderme hatası", Hata.Message);
                }
            }
        }
    }
}
