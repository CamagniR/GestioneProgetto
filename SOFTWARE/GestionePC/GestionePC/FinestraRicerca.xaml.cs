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
                CAula tmp = new CAula();
                CComputer temp = new CComputer();
                tmp = PCinAula2.oggettoGetCAula(barCode);
                temp = tmp.getPC();

                enable();

                txtBarCode.Text = temp.getBarCode();
                txtModello.Text = temp.getModello();
                txtStato.Text = temp.getSpecifiche();
                txtData.Text = tmp.getDataRegsitro();
                txtIndirizzo.Text = tmp.getIndirizzo();
                txtClasse.Text = tmp.getClasse();
                txtAula.Text = tmp.getAula();
                txtBancode.Text = "";
                
            }
            else if (pcNoleggio2.isInLista(barCode) == true)
            {
                CDocente tmp = new CDocente();
                CComputer temp = new CComputer();
                tmp = pcNoleggio2.oggettoGetCDocente(barCode);
                temp = tmp.getPC();

                enable();

                txtBarCode.Text = temp.getBarCode();
                txtModello.Text = temp.getModello();
                txtStato.Text = temp.getSpecifiche();
                txtInsegna.Text = tmp.getIndirizzi();
                txtNome.Text = tmp.getNome();
                txtCognome.Text = tmp.getCognome();
                txtBancode.Text = "";
            }
            else if (magazzino2.isInLista(barCode) == true)
            {
                enable();
                txtBancode.Text = "";
            }

        }

        public void enable()
        {
            txtAula.IsEnabled = true;
            txtBarCode.IsEnabled = true;
            txtModello.IsEnabled = true;
            txtStato.IsEnabled = true;
            txtData.IsEnabled = true;
            txtIndirizzo.IsEnabled = true;
            txtClasse.IsEnabled = true;
        }

        private void btnModifica_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}