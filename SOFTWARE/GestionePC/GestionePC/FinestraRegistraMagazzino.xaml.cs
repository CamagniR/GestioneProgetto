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
    /// Logica di interazione per FinestraRegistraMagazzino.xaml
    /// </summary>
    public partial class FinestraRegistraMagazzino : Window
    {

        CListaComputer magazzino2;
        ListaPCinAula PCinAula2;
        ListaPCNoleggio pcNoleggio2;
        public FinestraRegistraMagazzino()
        {
            InitializeComponent();
        }
        public FinestraRegistraMagazzino(CListaComputer magazzino2, ListaPCinAula aula2, ListaPCNoleggio docenti2)
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
            if (txtBar.Text != "" && txtPc.Text != "")
            {
                CComputer tmp = new CComputer(txtBar.Text, txtPc.Text, txtStat.Text);
                if (magazzino2.controlloPC(tmp))
                {
                    MessageBox.Show("pc gia registrato in magazzino");
                }
                else
                {
                    MessageBox.Show("pc registrato in magazzino");
                    magazzino2.registraPC(tmp);
                    magazzino2.Salva();
                }
            }
            else
            {
                MessageBox.Show("compilare tutti i campi");
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FinestraRegistra finestra = new FinestraRegistra(magazzino2, PCinAula2, pcNoleggio2);
            finestra.Show();
            this.Hide();
        }

        private void txtBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBar.Text != "" && txtStat.Text != "" && txtPc.Text != "")
            {
                btnRegistra.IsEnabled = true;

            }
        }

        private void txtPc_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBar.Text != "" && txtStat.Text != "" && txtPc.Text != "")
            {
                btnRegistra.IsEnabled = true;

            }
        }

        private void txtStat_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBar.Text != "" && txtStat.Text != "" && txtPc.Text != "")
            {
                btnRegistra.IsEnabled = true;

            }
        }
    }
}
