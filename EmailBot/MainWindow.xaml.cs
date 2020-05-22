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

namespace EmailBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string content = EmailContent.Text;
            string emailAddress = "";
            var selectedEmail = ChooseRecipient.SelectedItem;
            if (selectedEmail.Equals(Personal))
            {
                emailAddress = "jtanjoshua@gmail.com";
            } else if (selectedEmail.Equals(School))
            {
                emailAddress = "joshua_tan@brown.edu";
            } else if (selectedEmail.Equals(Company))
            {
                emailAddress = "joshua_tan@brown.edu";
            }

            MessageBox.Show($"Email {content} sent to {emailAddress}");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseRecipient.SelectedIndex = -1;
            EmailContent.Clear();
        }

        private void ChooseRecipient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SendButton.IsEnabled = true;
        }
    }
}
