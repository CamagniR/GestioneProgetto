using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePC
{
    public class CComputer
    {

        private string barCode;
        private string modello;
        private string specifiche;

        public CComputer()
        {
            barCode = "";
            modello = "";
            specifiche = "";
        }

        public CComputer(string barCode, string modello, string specifiche)
        {
            this.barCode = barCode;
            this.modello = modello;
            this.specifiche = specifiche;
        }

        public string getBarCode()
        {
            return barCode;
        }

        public string getModello()
        {
            return modello;
        }
        public string getSpecifiche()
        {
            return specifiche;
        }

        public string ToCSV()
        {
            return barCode + ";" + modello + ";" + specifiche;
        }

        public override string ToString()
        {
            return barCode+" "+ modello+" "+ specifiche;
        }
    }
}
