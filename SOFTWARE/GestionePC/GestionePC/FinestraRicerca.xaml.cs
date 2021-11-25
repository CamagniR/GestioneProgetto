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
            else if (PCinAula2.isInLista(barCode) == true)
            {
                CAula tmp = new CAula();
                CComputer temp = new CComputer();
                tmp = PCinAula2.oggettoGetCAula(barCode);
                temp = tmp.getPC();

             

                txtBarCode.Text = temp.getBarCode();
                txtModello.Text = temp.getModello();
                txtStato.Text = temp.getSpecifiche();
                txtData.Text = tmp.getDataRegsitro();
                txtIndirizzo.Text = tmp.getIndirizzo();
                txtClasse.Text = tmp.getClasse();
                txtAula.Text = tmp.getAula();
                txtBancode.Text = "";
                btnModifica.IsEnabled = true;
                
            }
            else if (pcNoleggio2.isInLista(barCode) == true)
            {
                CDocente tmp = new CDocente();
                CComputer temp = new CComputer();
                tmp = pcNoleggio2.oggettoGetCDocente(barCode);
                temp = tmp.getPC();

                
                txtBarCode.Text = temp.getBarCode();
                txtModello.Text = temp.getModello();
                txtStato.Text = temp.getSpecifiche();
                txtDataProf.Text = tmp.getDataRegistro();
                txtInsegna.Text = tmp.getIndirizzi();
                txtNome.Text = tmp.getNome();
                txtCognome.Text = tmp.getCognome();
                btnCerca.IsEnabled = true;
                txtBancode.Text = "";
                btnModifica.IsEnabled = true;

            }
            else if (magazzino2.isInLista(barCode) == true)
            {
                CComputer tmp = new CComputer();
                tmp = magazzino2.oggettoGetMagazzino(barCode);


                txtBarCode.Text = tmp.getBarCode();
                txtModello.Text = tmp.getModello();
                txtStato.Text = tmp.getSpecifiche();
                btnCerca.IsEnabled = true;
                txtBancode.Text = "";
                btnModifica.IsEnabled = true;

            }

        }


        private void btnModifica_Click(object sender, RoutedEventArgs e)
        {          
            txtBarCode.IsEnabled = true;
            txtModello.IsEnabled = true;
            txtStato.IsEnabled = true;
            btnSalva.IsEnabled = true;
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            if (txtData.IsEnabled)
            {
                
            }
            else if (txtDataProf.IsEnabled)
            {
                
            }
            else
            {
                
            }
        }

        private void modMag_Click(object sender, RoutedEventArgs e)
        {
            txtAula.IsEnabled = false;
            txtData.IsEnabled = false;
            txtIndirizzo.IsEnabled = false;
            txtClasse.IsEnabled = false;
            txtDataProf.IsEnabled = false;
            txtInsegna.IsEnabled = false;
            txtNome.IsEnabled = false;
            txtCognome.IsEnabled = false;
        }

        private void modCla_Click(object sender, RoutedEventArgs e)
        {
            txtAula.IsEnabled = true;
            txtData.IsEnabled = true;
            txtIndirizzo.IsEnabled = true;
            txtClasse.IsEnabled = true;
            txtDataProf.IsEnabled = false;
            txtInsegna.IsEnabled = false;
            txtNome.IsEnabled = false;
            txtCognome.IsEnabled = false;
        }

        private void ModProf_Click(object sender, RoutedEventArgs e)
        {
            txtDataProf.IsEnabled = true;
            txtInsegna.IsEnabled = true;
            txtNome.IsEnabled = true;
            txtCognome.IsEnabled = true;
            txtAula.IsEnabled = false;
            txtData.IsEnabled = false;
            txtIndirizzo.IsEnabled = false;
            txtClasse.IsEnabled = false;
        }
    }
}