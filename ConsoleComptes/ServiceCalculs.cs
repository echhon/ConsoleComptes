using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleComptes;

namespace ConsoleComptes
{
    public class ServiceCalculs
    {
        // Calcule le solde à une date passée
        public decimal CalculerSoldeADate(DateTime dateCible, decimal soldeFinal, List<TransactionCompte> historiqueTransaction)
        {
            // Fait la somme de tout ce qui s'est passé après la date voulue
            decimal montantAAnnuler = 0;
            foreach (var t in historiqueTransaction)
            {
                if (t.Date > dateCible)
                {
                    montantAAnnuler = montantAAnnuler + t.Montant;
                }
            }
            return soldeFinal - montantAAnnuler;
        }

        // Trouve les catégories où il y a les plus grands débits/dépenses
        public void AfficherTopCategoriesDebit(List<TransactionCompte> historiqueTransaction)
        {
            var top = historiqueTransaction
                .Where(t => t.Montant < 0)
                .GroupBy(t => t.Categorie)
                .Select(g => new { Nom = g.Key, Total = g.Sum(t => t.Montant) })
                .OrderBy(res => res.Total) 
                .Take(3); // prend les 3 premiers (les plus grands débits)

            foreach (var item in top)
            {
                Console.WriteLine($"- {item.Nom} : {item.Total} EUR");
            }
        }
    }
}
