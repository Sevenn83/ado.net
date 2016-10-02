using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace ReaderObject
{
    internal class EmployeServices
    {
        private static EmployeServices _instance;
        private readonly OracleConnection _cnOracleConnection;

        public EmployeServices()
        {
            var bdd = new Bdd();
            _cnOracleConnection = bdd.CnOracle;
        }

        public static EmployeServices Instance => _instance ?? (_instance = new EmployeServices());

        /// <summary>
        /// Créer un objet hydrater grace à un datereader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Objet hydraté</returns>
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

        /// <summary>
        /// Retourne une liste de tout les employé
        /// </summary>
        /// <returns></returns>
        public List<Employe> FindAllEmployes()
        {
            using (_cnOracleConnection)
            {
                _cnOracleConnection.Open();

                // Commande sql
                var command = new OracleCommand("SELECT * FROM EMPLOYE", _cnOracleConnection);
                var reader = command.ExecuteReader();

                // Création de la collexion
                var employes = new List<Employe>();

                // Remplisage de la collection
                while (reader.Read())
                {
                    employes.Add(HydrateEmploye(reader));
                }

                _cnOracleConnection.Close();
                _cnOracleConnection.Dispose();

                return employes;
            }
        }

        public Employe FindEmployeById(short id)
        {
            using (_cnOracleConnection)
            {
                var employe = new Employe();

                // Commande sql
                var command = new OracleCommand("SELECT * FROM EMPLOYE WHERE numemp=:numemp", _cnOracleConnection);
                var pID = new OracleParameter("numemp", OracleDbType.Int16, System.Data.ParameterDirection.Input);
                pID.Value = id;
                command.Parameters.Add(pID);

                _cnOracleConnection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                    employe = HydrateEmploye(reader);

                _cnOracleConnection.Close();
                _cnOracleConnection.Dispose();

                return employe;
            }
        }
    }
}