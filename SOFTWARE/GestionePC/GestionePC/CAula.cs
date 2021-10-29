using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePC
{
    public class CAula
    {
        private CComputer PC;
        private string dataRegistro;
        private string indirizzo;
        private string classe;
        private string aula;

        public CAula()
        {
            PC = new CComputer();
            dataRegistro = "";
            indirizzo = "";
            classe = "";
            aula = "";
        }

        public CAula(CComputer PC, string dataRegistro, string indirizzo, string classe, string aula)
        {
            this.PC = PC;
            this.dataRegistro = dataRegistro;
            this.indirizzo = indirizzo;
            this.classe = classe;
            this.aula = aula;
        }

        public CComputer getPC()
        {
            return PC;
        }

        public string getDataRegsitro()
        {
            return dataRegistro;
        }
        public string getIndirizzo()
        {
            return indirizzo;
        }
        public string getClasse()
        {
            return classe;
        }
        public string getAula()
        {
            return aula;
        }

        public override string ToString()
        {
            return PC+" "+dataRegistro+" "+ indirizzo+" "+classe+" "+aula;
        }
        public string ToCSV()
        {
            return PC.getBarCode()+";"+PC.getModello()+";"+PC.getSpecifiche() + ";" + dataRegistro + ";" + indirizzo + ";" + classe + ";" + aula;
        }
    }
}
