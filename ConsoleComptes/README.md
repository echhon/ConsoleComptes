Gestion de Comptes Bancaires (C#)

Ce projet est une application console permettant d'analyser des relevés bancaires au format CSV.
Le programme lit et traite les données du fichier csv "account_20230228.csv" qui contient des informations sur les transactions bancaires. 
Il permet à l'utilisateur de saisir une date et de voir afficher le solde du compte à la date saisie.
Il calcule aussi les plus grandes catégories de dépenses et les affiche à l'utilisateur.
Le projet se construit en essayant d’appliquer la Clean Architecture et le TDD pour les tests.

Fonctionnalités :
- Lecture et analyse de fichiers CSV.
- Calcul du solde à une date précise dans le passé.
- Identification des 3 plus grosses catégories de débits/dépenses.

Architecture et méthodologie :
- Clean Architecture : séparation des couches Modèles, Métier, et Infrastructure.
- TDD (Test Driven Development) : utilisation de xUnit pour tester les calculs.
- C# : utilisation de LINQ, gestion des dates avec `CultureInfo`.

Comment lancer les tests ?
1. Ouvrir la solution dans Visual Studio.
2. Ouvrir l'Explorateur de tests.
3. Cliquer sur "Exécuter tout".
