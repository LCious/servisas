using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace servisas
{
    public partial class PasswordInput : Window
    {
        public string EnteredPassword { get; private set; }
        public bool OKButtonClicked { get; private set; } = false;

        public PasswordInput()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            EnteredPassword = PasswordBox.Password;
            OKButtonClicked = true;
            DialogResult = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!OKButtonClicked)
            {
                EnteredPassword = string.Empty;
            }
        }

    }
}
