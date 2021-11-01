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
    /// Logica di interazione per FinestraElimina.xaml
    /// </summary>
    public partial class FinestraElimina : Window
    {
        CListaComputer magazzino2;
        ListaPCinAula PCinAula2;
        ListaPCNoleggio pcNoleggio2;

        public FinestraElimina()
        {
            InitializeComponent();
        }
        public FinestraElimina(CListaComputer magazzino2, ListaPCinAula aula2, ListaPCNoleggio docenti2)
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

        private void BtnElimina_Click(object sender, RoutedEventArgs e)
        {

            string daEliminare = "";
            daEliminare = txtBarCode.Text;

            if (pcNoleggio2.isInLista(daEliminare)==true)
            {
                FinestraEliminaDefinitivo finestra = new FinestraEliminaDefinitivo(magazzino2, pcNoleggio2, daEliminare);
                finestra.Show();
            }
            else if (PCinAula2.isInLista(daEliminare)==true)
            {
                FinestraEliminaDefinitivo finestra = new FinestraEliminaDefinitivo(magazzino2, PCinAula2, daEliminare);
                finestra.Show();
            }
            else if (magazzino2.isInLista(daEliminare)==true)
            {
                FinestraEliminaDefinitivo finestra = new FinestraEliminaDefinitivo(magazzino2, daEliminare);
                finestra.Show();
            }


        }
    }
}
