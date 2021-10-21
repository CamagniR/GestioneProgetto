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
    /// Logica di interazione per FinestraRegistra.xaml
    /// </summary>
    public partial class FinestraRegistra : Window
    {
       
        CListaComputer magazzino2;
        ListaPCinAula PCinAula2;
        ListaPCNoleggio pcNoleggio2;

        public FinestraRegistra()
        {
            InitializeComponent();
        }
        public FinestraRegistra(CListaComputer magazzino2, ListaPCinAula aula2, ListaPCNoleggio docenti2)
        {

            InitializeComponent();
            this.magazzino2 = magazzino2;
            this.PCinAula2 = aula2;
            this.pcNoleggio2 = docenti2;
        }

        private void btnNoleggiaProf_Click(object sender, RoutedEventArgs e)
        {
            FinestraNoleggiaProf finestra = new FinestraNoleggiaProf(magazzino2, PCinAula2, pcNoleggio2);
            finestra.Show();
            this.Hide();
        }

        private void btnRegistraAula_Click(object sender, RoutedEventArgs e)
        {
            FinestraRegistraAula finestra = new FinestraRegistraAula(magazzino2, PCinAula2, pcNoleggio2);
            finestra.Show();
            this.Hide();
        }

        private void btnRegistraMagazzino_Click(object sender, RoutedEventArgs e)
        {
            FinestraRegistraMagazzino finestra = new FinestraRegistraMagazzino(magazzino2, PCinAula2, pcNoleggio2);
            finestra.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            FinestraHome finestra = new FinestraHome(magazzino2, PCinAula2, pcNoleggio2);
            finestra.Show();
            this.Hide();
        }
    }
}
