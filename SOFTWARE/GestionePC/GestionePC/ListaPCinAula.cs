﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePC
{
    public class ListaPCinAula
    {

        private List<CAula> listaAula;
        private string nomeFile;

        public ListaPCinAula()
        {
            listaAula = new List<CAula>();
        }

        //aggiunge un pc alla lista delle aule solo se non è gia presente.
        public void aggiungiInLista(CAula oggetto)
        {
            if (controlloPresenza(oggetto)==false)
            {
                listaAula.Add(oggetto);
            }
        }


        public void Carica()
        {
            listaAula.Clear();
            CAula pTemp;

            string linea = "";
            string tutto = File.ReadAllText(nomeFile);
            string[] Linee = tutto.Split('\n');

            for (int i = 0; i < Linee.Length; i++)
            {
                linea = Linee[i];
                string[] campi = linea.Split(';');

                CComputer tmp = new CComputer(campi[0], campi[1], campi[2]);


                pTemp = new CAula(tmp, campi[3], campi[4],campi[5],campi[6]);
                listaAula.Add(pTemp);
            }
        }

        public bool controlloPresenza(CAula pcCercato)
        {
            for (int i = 0; i < listaAula.Count; i++)
            {
                if (listaAula.ElementAt(i).getPC().getBarCode() == pcCercato.getPC().getBarCode())
                {
                    return true;
                }
            }
            return false;
        }


        public string GetAllCsv()
        {
            string ritorno = "";
            for (int i = 0; i < listaAula.Count(); i++)
            {
                if (i != listaAula.Count() - 1) ritorno += listaAula.ElementAt(i).ToCSV() + "\n";
                else ritorno += listaAula.ElementAt(i).ToCSV();
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
