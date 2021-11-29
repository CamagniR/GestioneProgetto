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
    /// Logica di interazione per FinestraEliminaDefinitivo.xaml
    /// </summary>
    public partial class FinestraEliminaDefinitivo : Window
    {
        CListaComputer magazzino2;
        ListaPCinAula PCinAula2;
        ListaPCNoleggio pcNoleggio2;
        String daEliminare;

        public FinestraEliminaDefinitivo()
        {
            InitializeComponent();
        }

        public FinestraEliminaDefinitivo(CListaComputer magazzino2, ListaPCinAula aula2, string daEliminare)
        {

            InitializeComponent();
            this.magazzino2 = magazzino2;
            this.PCinAula2 = aula2;
            this.daEliminare = daEliminare;
            txtBlock.Text = "IL PC CHE VUOI ELIMINARE E' " + "\n" + PCinAula2.GetCAula(daEliminare) + "\n" + "Sei sicuro di volerlo eliminare?";
            btnEliminaLista.IsEnabled = true;
        }
        public FinestraEliminaDefinitivo(CListaComputer magazzino2,ListaPCNoleggio pcNoleggio2, string daEliminare)
        {

            InitializeComponent();
            this.magazzino2 = magazzino2;
            this.pcNoleggio2 = pcNoleggio2;
            this.daEliminare = daEliminare;
            txtBlock.Text = "IL PC CHE VUOI ELIMINARE E' " + "\n" + pcNoleggio2.GetNoleggio(daEliminare) + "\n" + "Sei sicuro di volerlo eliminare?";
            btnEliminaLista.IsEnabled = true;
        }
        public FinestraEliminaDefinitivo(CListaComputer magazzino2, string daEliminare)
        {

            InitializeComponent();
            this.magazzino2 = magazzino2;
            this.daEliminare = daEliminare;
            txtBlock.Text = "IL PC CHE VUOI ELIMINARE E' " + "\n" + magazzino2.GetPC(daEliminare) + "\n" + "Sei sicuro di volerlo eliminare?";
            btnEliminaLista.IsEnabled = false;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FinestraElimina finestra = new FinestraElimina( magazzino2, PCinAula2,  pcNoleggio2);
            finestra.Show();
            this.Hide();
        }

        private void BtnEliminaLista_Click(object sender, RoutedEventArgs e)
        {
            
            if (PCinAula2 == null)
            { 
                pcNoleggio2.eliminaConBarCode(daEliminare);
                pcNoleggio2.Salva();
                MessageBox.Show("eliminato correttamente");
                txtBlock.Text = "";
                FinestraElimina finestra = new FinestraElimina(magazzino2, PCinAula2, pcNoleggio2);
                finestra.Show();
                this.Hide();

            }
            else if (pcNoleggio2 == null)
            {       
                PCinAula2.eliminaConBarCode(daEliminare);
                PCinAula2.Salva();
                MessageBox.Show("eliminato correttamente");
                txtBlock.Text = "";
                FinestraElimina finestra = new FinestraElimina(magazzino2, PCinAula2, pcNoleggio2);
                finestra.Show();
                this.Hide();
            }
        }

        private void BtnEliminaTutto_Click(object sender, RoutedEventArgs e)
        {
            if (PCinAula2 == null && pcNoleggio2 == null)
            {
                
                magazzino2.eliminaConBarCode(daEliminare);
                magazzino2.Salva();
                txtBlock.Text = "";
                FinestraElimina finestra = new FinestraElimina(magazzino2, PCinAula2, pcNoleggio2);
                finestra.Show();
                this.Hide();
            }
            else if (pcNoleggio2 == null )
            {
                PCinAula2.eliminaConBarCode(daEliminare);
                magazzino2.eliminaConBarCode(daEliminare);
                PCinAula2.Salva();
                magazzino2.Salva();
                txtBlock.Text = "";
                FinestraElimina finestra = new FinestraElimina(magazzino2, PCinAula2, pcNoleggio2);
                finestra.Show();
                this.Hide();
            }
            else if (PCinAula2 == null)
            {
                pcNoleggio2.eliminaConBarCode(daEliminare);
                magazzino2.eliminaConBarCode(daEliminare);
                pcNoleggio2.Salva();
                magazzino2.Salva();
                txtBlock.Text = "";
                FinestraElimina finestra = new FinestraElimina(magazzino2, PCinAula2, pcNoleggio2);
                finestra.Show();
                this.Hide();
            }
        }

        private void BtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            FinestraElimina finestra = new FinestraElimina();
            finestra.Show();
            this.Hide();
        }
    }
}
