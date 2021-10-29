using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePC
{
    public class CDocente
    {
        private CComputer PC;
        private string dataRegistro;
        private string nome;
        private string cognome;
        private string indirizziInsegnamento;

        public CDocente()
        {
            PC = new CComputer();
            dataRegistro = "";
            nome = "";
            cognome = "";
            indirizziInsegnamento = "";

        }

        public CDocente(CComputer pC, string dataRegistro, string nome, string cognome, string indirizziInsegnamento)
        {
            PC = pC ;
            this.dataRegistro = dataRegistro;
            this.nome = nome;
            this.cognome = cognome ;
            this.indirizziInsegnamento = indirizziInsegnamento ;
        }

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
            return PC.getBarCode()+";"+PC.getModello()+";"+PC.getSpecifiche() + ";" + nome + ";" + cognome + ";" + dataRegistro + ";" + indirizziInsegnamento;
            
        }
    }
}
