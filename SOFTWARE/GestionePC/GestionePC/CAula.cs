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
        private string dataRegsitro;
        private string indirizzo;
        private string classe;
        private string aula;

        public CAula()
        {
            PC = new CComputer();
            dataRegsitro = "";
            indirizzo = "";
            classe = "";
            aula = "";
        }

        public CAula(CComputer PC, string dataRegsitro, string indirizzo, string classe, string aula)
        {
            this.PC = PC;
            this.dataRegsitro = dataRegsitro;
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
            return dataRegsitro;
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
            return PC+" "+dataRegsitro+" "+ indirizzo+" "+classe+" "+aula;
        }
        public string ToCSV()
        {
            return PC + ";" + dataRegsitro + ";" + indirizzo + ";" + classe + ";" + aula;
        }
    }
}
