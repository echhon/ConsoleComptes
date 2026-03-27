using Xunit; 
using ConsoleComptes;
using System;
using System.Collections.Generic;

namespace ConsoleComptes.Tests
{
    public class ServiceCalculsTests
    {
        [Fact]
        public void CalculerSoldeADate_DevraitRetournerLeBonSolde_QuandOnRemonteLeTemps()
        {
            // ARRANGE : Crée des données de test
            var service = new ServiceCalculs();
            decimal soldeAu28Fevrier = 1000m;

            var historiqueTransaction = new List<TransactionCompte>
            {
                // Une transaction le 15 février de -100€
                new TransactionCompte(new DateTime(2023, 02, 15), -100m, "EUR", "Loisir"),
                // Une Ttransaction le 10 février de -50€
                new TransactionCompte(new DateTime(2023, 02, 10), -50m, "EUR", "Alimentation")
            };

            // ACT : Veut le solde au 12 février 
            // (La transaction du 15 doit être annulée, celle du 10 doit rester)
            DateTime dateCible = new DateTime(2023, 02, 12);
            decimal resultat = service.CalculerSoldeADate(dateCible, soldeAu28Fevrier, historiqueTransaction);

            // ASSERT : 
            // Formule : SoldeFinal (1000) - Somme des transactions après le 12 février (-100)
            // 1000 - (-100) = 1100
            Assert.Equal(1100m, resultat);
        }

        [Fact]
        public void ObtenirTopDepenses_DevraitRetournerLesTroisPlusGrossesCategories()
        {
            // ARRANGE
            var service = new ServiceCalculs();
            var historiqueTransaction = new List<TransactionCompte>
            {
                new TransactionCompte(DateTime.Now, -500m, "EUR", "Loyer"),
                new TransactionCompte(DateTime.Now, -100m, "EUR", "Courses"),
                new TransactionCompte(DateTime.Now, -200m, "EUR", "Loisir"),
                new TransactionCompte(DateTime.Now, -50m, "EUR", "Transport"),
                new TransactionCompte(DateTime.Now, 5000m, "EUR", "Salaire") 
            };

            // ACT
            // Récupère les 3 plus grandes catégories en débits/dépenses         
            var top = service.AfficherTopCategoriesDebit(historiqueTransaction);

            // ASSERT
            Assert.Equal("Loyer", top[0].Nom);    // Le plus gros débit (-500)
            Assert.Equal("Loisir", top[1].Nom);   // Le 2ème (-200)
            Assert.Equal("Courses", top[2].Nom);  // Le 3ème (-100)
        }
    }
}
