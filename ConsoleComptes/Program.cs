using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleComptes;
using System.IO;

namespace ConsoleComptes
{
    class Program
    {
        static void Main()
        {
            var analyseurFichier = new AnalyseurCSV();
            var service = new ServiceCalculs();

            // Récupère les données
            var donnees = analyseurFichier.LireFichier("account_20230228.csv");

            // Demande à l'utilisateur de saisir une date pour calculer le solde à cette date
            Console.Write("Veuillez saisir une date au format dd/mm/yyyy pour connaître le solde à cette date : ");

            try
            {
                decimal resultat;
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dateChoisie))
                {
                    resultat = service.CalculerSoldeADate(dateChoisie, donnees.Solde, donnees.Liste);
                    Console.WriteLine($"Solde au {dateChoisie.ToString("dd/MM/yyyy")} : {resultat.ToString()} EUR");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Format de date invalide. Veuillez saisir une date au format dd/MM/yyyy.");
            }

            // Affiche les plus grandes catégories en débits/dépenses
            Console.WriteLine("\nVoici les plus grandes catégories de débit :");
            service.AfficherTopCategoriesDebit(donnees.Liste);

        }
    }
}
