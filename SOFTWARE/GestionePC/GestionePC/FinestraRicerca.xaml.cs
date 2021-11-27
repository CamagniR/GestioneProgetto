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
        int selezionato = 0;
        int destinazione = 0;
        string barCode="";

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
            barCode = txtBancode.Text;
            if (txtBancode.Text == "")
            {
                MessageBox.Show("inserisci un barcode");

            }
            else
            {
                CComputer temp = new CComputer();
                if (PCinAula2.isInLista(barCode) == true)
                {
                    CAula tmp = new CAula();
                    
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
                    selezionato = 2;

                }
                else if (pcNoleggio2.isInLista(barCode) == true)
                {
                    CDocente tmp = new CDocente();
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
                    selezionato = 3;
                }
                else if (magazzino2.isInLista(barCode) == true)
                {
                    temp = magazzino2.oggettoGetMagazzino(barCode);

                    txtBarCode.Text = temp.getBarCode();
                    txtModello.Text = temp.getModello();
                    txtStato.Text = temp.getSpecifiche();
                    btnCerca.IsEnabled = true;
                    txtBancode.Text = "";
                    btnModifica.IsEnabled = true;
                    selezionato = 1;
                }

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
            if (selezionato == 1)
            {
                magazzino2.eliminaConBarCode(barCode);
            }
            else if (selezionato == 2)
            {
                PCinAula2.eliminaConBarCode(barCode);
            }
            else
            {
                pcNoleggio2.eliminaConBarCode(barCode);
            }

            CComputer temp = new CComputer(barCode, txtModello.Text, txtStato.Text);
            if (destinazione == 1)
            {
                magazzino2.registraPC(temp);
                magazzino2.Salva();
            }
            else if (destinazione == 2)
            {
                CAula tmp = new CAula(temp,txtData.Text,txtIndirizzo.Text,txtClasse.Text,txtAula.Text);
                PCinAula2.aggiungiInLista(tmp);
                PCinAula2.Salva();
            }
            else
            {
                CDocente tmp = new CDocente(temp,txtDataProf.Text,txtNome.Text,txtCognome.Text,txtInsegna.Text);
                pcNoleggio2.aggiungiInLista(tmp);
                pcNoleggio2.Salva();
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
            destinazione = 1;
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
            destinazione = 2;
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
            destinazione = 3;
        }
    }
}