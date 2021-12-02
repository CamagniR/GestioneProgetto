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
    /// Logica di interazione per FinestraNoleggiaProf.xaml
    /// </summary>
    public partial class FinestraNoleggiaProf : Window
    {
        CListaComputer magazzino2;
        ListaPCinAula PCinAula2;
        ListaPCNoleggio pcNoleggio2;

        public FinestraNoleggiaProf()
        {
            InitializeComponent();
        }
        public FinestraNoleggiaProf(CListaComputer magazzino2, ListaPCinAula aula2, ListaPCNoleggio docenti2)
        {

            InitializeComponent();
            this.magazzino2 = magazzino2;
            this.PCinAula2 = aula2;
            this.pcNoleggio2 = docenti2;
        }

        private void btnHome_click(object sender, RoutedEventArgs e)
        {
            FinestraHome finestra = new FinestraHome(magazzino2, PCinAula2, pcNoleggio2);
            finestra.Show();
            this.Hide();
        }

        private void btnNoleggia_Click(object sender, RoutedEventArgs e)
        {
            if (txtBar.Text != "" && txtPc.Text != "" && txtStat.Text != "" && txtData.Text != "" && txtNome.Text != "" && txtCognome.Text != "" && txtInsegnamento.Text!="")
            {
                CComputer tmpPC = new CComputer(txtBar.Text, txtPc.Text, txtStat.Text);
                CDocente tmpDocente = new CDocente(tmpPC, txtData.Text, txtNome.Text, txtCognome.Text, txtInsegnamento.Text);
                
                if(pcNoleggio2.controlloPresenza(tmpDocente))//controlla se gia assegnato ad un professore
                {
                    MessageBox.Show("computer gia assegnato ad un professore");
                    

                }
                if (PCinAula2.controlloPresenza2(tmpPC))//per assegnare un pc ad un prof deve controllare che non sia gia regisrato ad un aula 
                {
                    MessageBox.Show("computer gia assegnato ad un aula");
                    
                }
                else
                {
                    pcNoleggio2.aggiungiInLista(tmpDocente);
                    pcNoleggio2.Salva();
                    magazzino2.registraPC(tmpPC);
                    magazzino2.Salva();

                    MessageBox.Show("computer noleggiato ");
                }
  

                txtBar.Text = "";
                txtPc.Text = "";
                txtStat.Text = "";
                txtData.Text = "";
                txtNome.Text = "";
                txtCognome.Text = "";
                txtInsegnamento.Text = "";

            }
            else
            {
                MessageBox.Show("compilare tutti i campi");
            }
        }

        private void txtBar_TextChanged(object sender, TextChangedEventArgs e)
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
                btnNoleggia.IsEnabled = false;
            }
            else if (pcNoleggio2.isInLista(bar) == true)
            {
                MessageBox.Show("PC assegnato ad un docente");
                btnNoleggia.IsEnabled = false;
            }

            else {

                txtPc.IsEnabled = true;
                txtStat.IsEnabled = true;
                btnNoleggia.IsEnabled = true;
            }







        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FinestraRegistra finestra = new FinestraRegistra(magazzino2, PCinAula2, pcNoleggio2);
            finestra.Show();
            this.Hide();
        }

    }
}
