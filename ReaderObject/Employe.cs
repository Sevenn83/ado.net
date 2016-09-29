using System;

namespace ReaderObject
{
    internal class Employe
    {
        public short NumEmp { get; set; }
        public string NomEmp { get; set; }
        public string PrenomEmp { get; set; }
        public string Poste { get; set; }
        public float Salaire { get; set; }
        public float? Prime { get; set; }
        public string CodeProjet { get; set; }
        public short? Superieur { get; set; }

        public override string ToString()
        {
            return NumEmp + " " + NomEmp + " " + Poste + " " + Salaire + " " + Prime + " " + CodeProjet + " " +
                   Superieur;
        }
    }
}
