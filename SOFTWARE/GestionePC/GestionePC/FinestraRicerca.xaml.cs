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

namespace GestionePC
{
    /// <summary>
    /// Logica di interazione per FinestraRicerca.xaml
    /// </summary>
    public partial class FinestraRicerca : Window
    {
        CListaComputer magazzino2;
        ListaPCinAula PCinAula2;
        ListaPCNoleggio pcNoleggio2;

        public FinestraRicerca()
        {
            InitializeComponent();
        }
        public FinestraRicerca(CListaComputer magazzino2, ListaPCinAula aula2, ListaPCNoleggio docenti2)
        {

            InitializeComponent();
            this.magazzino2 = magazzino2;
            this.PCinAula2 = aula2;
            this.pcNoleggio2 = docenti2;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            FinestraHome finestra = new FinestraHome(magazzino2, PCinAula2, pcNoleggio2);
            finestra.Show();
            this.Hide();
        }

        private void btnCerca_Click(object sender, RoutedEventArgs e)
        {
            string barCode = "";
            barCode = txtBancode.Text;
            if (txtBancode.Text == "")
            {
                MessageBox.Show("inserisci un barcode");
                
            }

            if (PCinAula2.isInLista(barCode) == true)
            {
                txtBancode.Text = "";
                FinestraInAula finestra = new FinestraInAula(magazzino2, PCinAula2,barCode);
                finestra.Show();
                this.Hide();
            }
            else if (pcNoleggio2.isInLista(barCode) == true)
            {
                txtBancode.Text = "";
            }
            else if (magazzino2.isInLista(barCode) == true)
            {
                txtBancode.Text = "";
            }

        }

      
    }
}