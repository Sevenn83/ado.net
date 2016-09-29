using System;
using System.Collections.Generic;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace ReaderObject
{
    internal abstract class EmployeServices
    {

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
        public static List<Employe> FindAllEmployes()
        {
            var connection = new OracleConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["oracledb"].ConnectionString
            };

            connection.Open();

            // Commande sql
            var command = new OracleCommand("SELECT * FROM EMPLOYE", connection);
            var reader = command.ExecuteReader();

            // Création de la collexion
            var employes = new List<Employe>();

            // Remplisage de la collection
            while (reader.Read())
            {
                employes.Add(HydrateEmploye(reader));
            }

            connection.Close();
            connection.Dispose();

            return employes;
        }

        public static Employe FindEmployeById(short id)
        {
            var employe = new Employe();

            var connection = new OracleConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["oracledb"].ConnectionString
            };

            // Commande sql
            var command = new OracleCommand("SELECT * FROM EMPLOYE WHERE numemp=:numemp", connection);
            var pID = new OracleParameter("numemp", OracleDbType.Int16, System.Data.ParameterDirection.Input);
            pID.Value = id;
            command.Parameters.Add(pID);

            connection.Open();
            var reader = command.ExecuteReader();

            if (reader.Read())
                employe = HydrateEmploye(reader);

            connection.Close();
            connection.Dispose();

            return employe;
        }
    }
}