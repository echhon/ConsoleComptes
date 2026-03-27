
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsoleComptes;

namespace ConsoleComptes
{
    public class AnalyseurCSV
    {
        public (decimal Solde, DateTime DateRef, List<TransactionCompte> Liste) LireFichier(string chemin)
        {
            var lignes = File.ReadAllLines(chemin);

            // Lecture de la première ligne (Solde)
            var entete = lignes[0].Split(':');
            decimal solde = decimal.Parse(entete[1].Trim().Split(' ')[0], CultureInfo.InvariantCulture);
            DateTime dateRef = DateTime.ParseExact(entete[0].Trim().Split(' ')[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            // Lecture des tauxVersEuro (Lignes 2 et 3)  
            //JPY/EUR:0.482
            //USD/EUR:1.445
            var tauxVersEuro = new Dictionary<string, decimal>();
            tauxVersEuro.Add("EUR", decimal.Parse("1.0", CultureInfo.InvariantCulture));
            tauxVersEuro.Add("JPY ", decimal.Parse("0.482", CultureInfo.InvariantCulture));
            tauxVersEuro.Add("USD ", decimal.Parse("1.445", CultureInfo.InvariantCulture));

            // Lecture des transactions (à partir de la ligne 4)
            // 06/10/2022;-504.61;EUR;Loisir
            var listeTransactionComptes = new List<TransactionCompte>();
            for (int i = 4; i < lignes.Length; i++)
            {
                var colonnes = lignes[i].Split(';');
                if (colonnes.Length < 4) continue;

                string devise = colonnes[2].Trim();
                decimal montantOrigine = decimal.Parse(colonnes[1], CultureInfo.InvariantCulture);

                // On convertit tout de suite en Euros
                decimal montantEuros = montantOrigine * tauxVersEuro[devise];

                listeTransactionComptes.Add(new TransactionCompte(
                    DateTime.ParseExact(colonnes[0], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    montantEuros, devise, colonnes[3].Trim()
                ));
            }

            return (solde, dateRef, listeTransactionComptes);
        }
    }
}
