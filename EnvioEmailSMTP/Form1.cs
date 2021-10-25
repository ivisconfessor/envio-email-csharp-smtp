using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace EnvioEmailSMTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            // DEDO NERVOSO
            btnEnviarEmail.Enabled = false;

            // E-MAIL DESTINATÁRIO
            string emailDestinatario = txtEmailDestinatario.Text;

            // ASSUNTO
            string emailAssunto = txtEmailAssunto.Text;

            // MENSAGEM
            string emailMensagem = txtEmailMensagem.Text;

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("{e-mail do remetente}"); // DE
            mail.To.Add(emailDestinatario); // PARA
            mail.Subject = emailAssunto; // ASSUNTO
            mail.Body = emailMensagem; // MENSAGEM

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("{e-mail do remetente}", "{senha do e-mail do remetente}");

                try
                {
                    smtp.Send(mail);

                    MessageBox.Show("E-mail Enviado!");

                    txtEmailDestinatario.Text = string.Empty;
                    txtEmailAssunto.Text = string.Empty;
                    txtEmailMensagem.Text = string.Empty;
                    btnEnviarEmail.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Falha ao Enviar E-mail!");

                    btnEnviarEmail.Enabled = true;
                }
            }
        }
    }
}
