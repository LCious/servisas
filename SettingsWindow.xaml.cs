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
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace servisas
{

    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SetPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            string oldPassword = OldPasswordTextBox.Text;
            string oldPasswordHash = ComputeSha256Hash(oldPassword);
            string? existingHash = JsonFileHandler.LoadHashFromJson();
            string newPassword = PasswordTextBox.Text;

            OldPasswordTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;

            if (!string.IsNullOrEmpty(newPassword) && oldPasswordHash == existingHash)
            {
                string hash = ComputeSha256Hash(newPassword);
                JsonFileHandler.SaveHashToJson(hash);
                MessageBox.Show("Slaptažodis išsaugotas..");
            }
            else
            {
                MessageBox.Show("Slaptažodis neišsaugotas..");
            }

        }

        static string ComputeSha256Hash(string string_to_hash)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(string_to_hash));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
