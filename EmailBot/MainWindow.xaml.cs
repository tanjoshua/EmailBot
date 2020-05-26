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
using System.Net.Mail;
using Microsoft.Win32;
using System.IO;

namespace EmailBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string filename;

        public MainWindow()
        {
            InitializeComponent();
        }

        // User clicks send button to send email
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string content = EmailContent.Text;
            string emailAddress = "";

            // recipient email is set based on which email the user chose
            var selectedEmail = ChooseRecipient.SelectedItem;
            if (selectedEmail.Equals(Personal))
            {
                emailAddress = "jtanjoshua@gmail.com";
            } else if (selectedEmail.Equals(School))
            {
                emailAddress = "joshua_tan@brown.edu";
            } else if (selectedEmail.Equals(Company))
            {
                emailAddress = "joshua.tan@themeinternationaltrading.com";
            }

            // Create email
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("joshua.tan@themeinternationaltrading.com");
            mail.To.Add(emailAddress);
            mail.Subject = "Email bot";
            mail.Body = content + "\n\nThis is an email sent from a bot";

            // Attach email if file was selected
            if (this.filename != null)
            {
                mail.Attachments.Add(new Attachment(this.filename));
            }
            
            // Set up email client and send
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("joshua.tan@themeinternationaltrading.com",
                "<REDACTED>");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            // Confirmation message
            MessageBox.Show($"Email sent to {emailAddress}");
        }

        // Close app if user cancels
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        // Resets all fields
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseRecipient.SelectedIndex = -1;
            EmailContent.Clear();
        }

        // Enable send button only after user selects a recipient
        private void ChooseRecipient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SendButton.IsEnabled = true;
        }

        // user selects file
        private void ChooseFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                this.filename = openFileDialog.FileName;
            }
        }
    }
}
