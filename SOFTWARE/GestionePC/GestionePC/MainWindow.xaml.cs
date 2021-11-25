using Microsoft.Win32;
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
        string credenziali="admin";
        string password = "admin";

        CListaComputer magazzino;
        ListaPCinAula PCinAula;
        ListaPCNoleggio pcNoleggio;

        public MainWindow()
        {

            magazzino = new CListaComputer();
            PCinAula = new ListaPCinAula();
            pcNoleggio = new ListaPCNoleggio();


            InitializeComponent();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            magazzino.Carica();
            PCinAula.Carica();
            pcNoleggio.Carica();


        }

        private void BtnAccedi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtNome.Text == credenziali && txtPassword.Password == password)
            {
                FinestraHome finestra = new FinestraHome(magazzino, PCinAula, pcNoleggio);
                finestra.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show( "Credenziali errate, riprovare");
                txtPassword.Password = "";
                txtNome.Text = "";
            }




        }

        private void txtNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtNome.Text != "")
            {

                btnAccedi.IsEnabled = true;

            }
        }
    }
}
