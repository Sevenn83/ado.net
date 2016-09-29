using System;
using Oracle.ManagedDataAccess.Client;

namespace ReaderObject
{
    internal abstract class EmployeServices
    {
        public static Employe HydrateEmploye(OracleDataReader reader)
        {
            var employe = new Employe();

            employe.NumEmp = Convert.ToInt16(reader["NUMEMP"]);
            employe.NomEmp = reader["NOMEMP"] as string;
            employe.PrenomEmp = reader["PRENOMEMP"] as string;
            employe.Poste = reader["POSTE"] as string;
            employe.Salaire = Convert.ToSingle(reader["SALAIRE"]);
            if (reader["PRIME"] == DBNull.Value)
                employe.Prime = null;
            else
                employe.Prime = Convert.ToInt16(reader["PRIME"]);
            employe.CodeProjet = reader["CODEPROJET"] as string;
            if (reader["SUPERIEUR"] == DBNull.Value)
                employe.Prime = null;
            else
                employe.Prime = Convert.ToInt16(reader["SUPERIEUR"]);


            return employe;
        }

    }
}
