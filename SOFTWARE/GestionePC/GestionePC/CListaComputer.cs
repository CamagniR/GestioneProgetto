using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePC
{
    public class CListaComputer
    {

        private List<CComputer> listaPC;
        private string nomeFile = Directory.GetCurrentDirectory() + "\\magazzino.txt";

        public CListaComputer()
        {
            listaPC = new List<CComputer>();
        }

        public void Carica()
        {
            listaPC.Clear();
            CComputer pTemp;

            string linea = "";
            string tutto = File.ReadAllText(nomeFile);
            if (tutto!=null && tutto!="")
            {
                string[] Linee = tutto.Split('\n');

                for (int i = 0; i < Linee.Length; i++)
                {
                    linea = Linee[i];
                    string[] campi = linea.Split(';');

                    pTemp = new CComputer(campi[0], campi[1], campi[2]);
                    listaPC.Add(pTemp);
                }
            }
            
        }
        public List<CComputer> getMagazzino()
        {
            return listaPC;
        }

        //aggiunge un pc solo se non è gia presente in lista
        public void registraPC(CComputer pc)
        {
            if (controlloPC(pc)==false)
            {
                listaPC.Add(pc);
            }
            
        }

        // cerca se un pc è già presente nella lista di computer registrati. 
        // true= pc presente in lista
        // false= pc non registrato nella lista

        public bool controlloPC(CComputer pcCercato)
        {
            for (int i = 0; i < listaPC.Count; i++)
            {
                if (listaPC.ElementAt(i).getBarCode() == pcCercato.getBarCode())
                {
                    return true;
                }
            }
            return false;
        }

        //elimina il pc 
        public void eliminaPC(CComputer pcDaEliminare)
        {
            for (int i = 0; i < listaPC.Count; i++)
            {
                if ((listaPC.ElementAt(i).getBarCode() == pcDaEliminare.getBarCode()) && (listaPC.ElementAt(i).getModello() == pcDaEliminare.getModello()))
                {
                    listaPC.RemoveAt(i);
                }
            }
        }

        public void eliminaConBarCode(string barCode)
        {
            for (int i = 0; i < listaPC.Count; i++)
            {
                if (listaPC.ElementAt(i).getBarCode() ==  barCode)
                {
                    listaPC.RemoveAt(i);
                }
            }
        }

        //metodo per visualizzare un pc dato il barCode
        public CComputer visualizzaPC(string barCode)
        {
            for (int i = 0; i < listaPC.Count; i++)
            {
                if (listaPC.ElementAt(i).getBarCode() == barCode)
                {
                    return listaPC.ElementAt(i);
                }
            }

            return null;
        }
        
        public void modifica(string descrizione,int i)
        {
           listaPC.ElementAt(i).setSpecifiche(descrizione);
        }


        public string GetAllCsv()
        {
            string ritorno = "";
            for (int i = 0; i < listaPC.Count(); i++)
            {
                if (i != listaPC.Count() - 1) ritorno += listaPC.ElementAt(i).ToCSV() + "\n";
                else ritorno += listaPC.ElementAt(i).ToCSV();
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
