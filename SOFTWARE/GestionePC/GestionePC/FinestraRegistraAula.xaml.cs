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
    /// Logica di interazione per FinestraRegistraAula.xaml
    /// </summary>
    public partial class FinestraRegistraAula : Window
    {

        CListaComputer magazzino2;
        ListaPCinAula PCinAula2;
        ListaPCNoleggio pcNoleggio2;
        public FinestraRegistraAula()
        {
            InitializeComponent();
        }
        public FinestraRegistraAula(CListaComputer magazzino2, ListaPCinAula aula2, ListaPCNoleggio docenti2)
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

        private void btnRegistra_Click(object sender, RoutedEventArgs e)
        {
            if (txtBar.Text != "" && txtPc.Text != "" && txtData.Text != "" && txtIndirizzo.Text != "" && txtClasse.Text != "" && txtAula.Text != "")
            {
                CComputer tmp = new CComputer(txtBar.Text, txtPc.Text, txtStat.Text);
                CAula temp = new CAula(tmp, txtData.Text, txtIndirizzo.Text, txtClasse.Text, txtAula.Text);
                PCinAula2.aggiungiInLista(temp);//aggiunge nel file lista del pc in aula    
                magazzino2.registraPC(tmp);//deve registrare il computer assegnato anche in magazzino
                PCinAula2.Salva();
                magazzino2.Salva();
                MessageBox.Show("computer registrato correttamente");

                Clear();


            }
            else
            {
                MessageBox.Show("compilare tutti i campi");
            }
        }

        private void TxtBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string bar = txtBar.Text;

            if (magazzino2.isInLista(bar) == true && PCinAula2.isInLista(bar) == false && pcNoleggio2.isInLista(bar) == false)
            {
                CComputer tmp = new CComputer();
                tmp = magazzino2.visualizzaPC(bar);
                txtPc.Text = tmp.getModello();
                txtStat.Text = tmp.getSpecifiche();


            }
            else if (PCinAula2.isInLista(bar) == true)
            {
                MessageBox.Show("PC già aseeganto in un aula");
                btnRegistra.IsEnabled = false;
            }
            else if (pcNoleggio2.isInLista(bar) == true)
            {
                MessageBox.Show("PC assegnato ad un docente");
                btnRegistra.IsEnabled = false;
            }

            else
            {

                txtPc.IsEnabled = true;
                txtStat.IsEnabled = true;
                btnRegistra.IsEnabled = true;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FinestraRegistra finestra = new FinestraRegistra(magazzino2, PCinAula2, pcNoleggio2);
            finestra.Show();
            this.Hide();
        }
        void Clear()
        {

            txtBar.Text = "";
            txtPc.Text = "";
            txtStat.Text = "";
            txtData.Text = "";
            txtIndirizzo.Text = "";
            txtClasse.Text = "";
            txtAula.Text = "";

        }
    }
}
