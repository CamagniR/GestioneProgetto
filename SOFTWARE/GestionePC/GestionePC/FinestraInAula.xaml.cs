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
    /// Logica di interazione per FinestraInAula.xaml
    /// </summary>
    public partial class FinestraInAula : Window
    {
        CListaComputer magazzino2;
        ListaPCinAula PCinAula2;
        string barCode;

        public FinestraInAula()
        {
            InitializeComponent();
        }

        public FinestraInAula(CListaComputer magazzino2, ListaPCinAula PCinAula2, string barCode )
        {
            InitializeComponent();
            this.magazzino2 = magazzino2;
            this.PCinAula2 = PCinAula2;
            this.barCode = barCode;

            CAula tmp = new CAula();
            CComputer temp = new CComputer();
            tmp=PCinAula2.oggettoGetCAula(barCode);
            temp = tmp.getPC();

            txtBarCode.Text = temp.getBarCode();
            txtModello.Text = temp.getModello();
            txtStato.Text = temp.getSpecifiche();
            txtData.Text = tmp.getDataRegsitro();
            txtIndirizzo.Text = tmp.getIndirizzo();
            txtClasse.Text = tmp.getClasse();
            txtAula.Text = tmp.getAula();

        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            FinestraHome finestra = new FinestraHome(magazzino2, PCinAula2);
            finestra.Show();
            this.Hide();
        }
    }
}
