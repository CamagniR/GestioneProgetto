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
    /// Logica di interazione per FinestraHome.xaml
    /// </summary>
    public partial class FinestraHome : Window
    {

        CListaComputer magazzino2;
        ListaPCinAula PCinAula2;
        ListaPCNoleggio pcNoleggio2;

        public FinestraHome()
        {
            InitializeComponent();
        }

        public FinestraHome(CListaComputer magazzino2, ListaPCinAula aula2, ListaPCNoleggio docenti2)
        {

            InitializeComponent();
            this.magazzino2 = magazzino2;
            this.PCinAula2 = aula2;
            this.pcNoleggio2 = docenti2;

        }

        private void btnRegistra_Click(object sender, RoutedEventArgs e)
        {
            FinestraRegistra finestra = new FinestraRegistra(magazzino2, PCinAula2, pcNoleggio2);
            finestra.Show();
            this.Hide();
        }

        private void btnBancode_Click(object sender, RoutedEventArgs e)
        {
            FinestraRicerca finestra = new FinestraRicerca(magazzino2, PCinAula2, pcNoleggio2);
            finestra.Show();
            this.Hide();
        }

        private void btnElimina_Click(object sender, RoutedEventArgs e)
        {
            FinestraElimina finestra = new FinestraElimina(magazzino2, PCinAula2, pcNoleggio2);
            finestra.Show();
            this.Hide();
        }
    }
}
