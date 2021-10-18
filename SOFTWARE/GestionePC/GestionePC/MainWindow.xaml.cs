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

namespace GestionePC
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string credenziali="ADMIN";
        string password = "Admin";



        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAccedi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtNome.Text == "ADMIN" && txtPassword.Text == "Admin")
            {
                FinestraHome finestra = new FinestraHome();
                finestra.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show( "Credenziali errate, riprovare");
                txtPassword.Text = "";
                txtNome.Text = "";
            }




        }
    }
}
