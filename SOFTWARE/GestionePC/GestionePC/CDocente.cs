using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePC
{
    class CDocente
    {
        private CComputer PC;
        private string dataRegistro;
        private string nome;
        private string cognome;
        private string indirizziInsegnamento;


        public CComputer getPC()
        {
            return PC;
        }
        public string getNome()
        {
            return nome;
        }
        public string getCognome()
        {
            return cognome;
        }
        public string getDataRegistro()
        {
            return dataRegistro;
        }
        public string getIndirizzi()
        {
            return indirizziInsegnamento;
        }

        public override string ToString()
        {
            return PC + " " + nome + " " + cognome + " " + dataRegistro + " " + indirizziInsegnamento;
        }

        public string ToCSV()
        {
            return PC + ";" + nome + ";" + cognome + ";" + dataRegistro + ";" + indirizziInsegnamento;
        }
    }
}
