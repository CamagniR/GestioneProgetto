using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePC
{
    public class ListaPCNoleggio //lista pc noleggiati ai docenti
    {
        private List<CDocente> listaNoleggi;
        private string nomeFile= Directory.GetCurrentDirectory() + "\\docenti.txt";

        public ListaPCNoleggio()
        {
            listaNoleggi = new List<CDocente>();
        }

        public void aggiungiInLista(CDocente oggetto)
        {
            if (controlloPresenza(oggetto) == false)
            {
                listaNoleggi.Add(oggetto);
            }
        }
        public void eliminaConBarCode(string barCode)
        {
            for (int i = 0; i < listaNoleggi.Count; i++)
            {
                if (listaNoleggi.ElementAt(i).getPC().getBarCode() == barCode)
                {
                    listaNoleggi.RemoveAt(i);
                }
            }
        }


        public void Carica()
        {
            listaNoleggi.Clear();
            CDocente pTemp;

            string linea = "";
            string tutto = File.ReadAllText(nomeFile);
            if (tutto!= null && tutto!="")
            {
                string[] Linee = tutto.Split('\n');

                for (int i = 0; i < Linee.Length; i++)
                {
                    linea = Linee[i];
                    string[] campi = linea.Split(';');

                    CComputer tmp = new CComputer(campi[0], campi[1], campi[2]);


                    pTemp = new CDocente(tmp, campi[3], campi[4], campi[5], campi[6]);
                    listaNoleggi.Add(pTemp);
                }
            }
            
        }

        public bool controlloPresenza(CDocente pcCercato)//true-->gia noleggiato   false-->non noleggiato
        {
            for (int i = 0; i < listaNoleggi.Count; i++)
            {
                if (listaNoleggi.ElementAt(i).getPC().getBarCode() == pcCercato.getPC().getBarCode())
                {
                    return true;
                }
            }
            return false;
        }

        public string GetNoleggio(string barCode)
        {
            for (int i = 0; i < listaNoleggi.Count; i++)
            {
                if (listaNoleggi.ElementAt(i).getPC().getBarCode() == barCode)
                {
                    return listaNoleggi.ElementAt(i).ToString();
                }
            }
            return null;
        }

        public CDocente oggettoGetCDocente(string barCode)
        {
            for (int i = 0; i < listaNoleggi.Count; i++)
            {
                if (listaNoleggi.ElementAt(i).getPC().getBarCode() == barCode)
                {
                    return listaNoleggi.ElementAt(i);
                }
            }
            return null;
        }


        public bool isInLista(string barCode)
        {
            for (int i = 0; i < listaNoleggi.Count; i++)
            {
                if (listaNoleggi.ElementAt(i).getPC().getBarCode() == barCode)
                {
                    return true;
                }

            }

            return false;
        }

        public string GetAllCsv()
        {
            string ritorno = "";
            for (int i = 0; i < listaNoleggi.Count(); i++)
            {
                if (i != listaNoleggi.Count() - 1) ritorno += listaNoleggi.ElementAt(i).ToCSV() + "\n";
                else ritorno += listaNoleggi.ElementAt(i).ToCSV();
            }
            return ritorno;
        }

        public void Salva()
        {
            File.WriteAllText(nomeFile, this.GetAllCsv());
        }

        public void set_nome_file(string nomeFile)
        {
            this.nomeFile = nomeFile;
        }

    }
}
