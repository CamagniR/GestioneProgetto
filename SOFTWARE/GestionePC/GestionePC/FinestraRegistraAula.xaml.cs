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
            if (txtBar.Text != "" && txtPc.Text != "" && txtData.Text != "" && txtIndirizzo.Text != "" && txtClasse.Text != "" && txtAula.Text !="")
            {
                CComputer tmp = new CComputer(txtBar.Text, txtPc.Text, txtStat.Text);
                CAula temp = new CAula(tmp, txtData.Text, txtIndirizzo.Text, txtClasse.Text, txtAula.Text);
                PCinAula2.aggiungiInLista(temp);
                magazzino2.registraPC(tmp);
                PCinAula2.Salva();
            }
            else
            {
                MessageBox.Show("compilare tutti i campi");
            }
        }
    }
}
