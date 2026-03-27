using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleComptes;

namespace ConsoleComptes
{
    public class TransactionCompte
    {
        public DateTime Date { get; set; }
        public decimal Montant { get; set; }
        public string Devise { get; set; }
        public string Categorie { get; set; }

        public TransactionCompte(DateTime date, decimal montant, string devise, string categorie)
        {
            Date = date;
            Montant = montant;
            Devise = devise;
            Categorie = categorie;
        }

    }    

}
