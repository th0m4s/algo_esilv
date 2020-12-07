# TD d'Algoritmique

Dans le cadre des cours d'ingénieurs à [l'ESILV](https://esilv.fr), le cours d'algoritmique nécessite, à partir du 8e TD de réaliser plusieurs exercices dans le langage de programmation C#.

En plus du code de chaque exo, ce repository et projet pour Visual Studio contient des classes permettant de gérer le lancement de chaque TD puis de chaqueexercice dans la console.


## Accéder au code source

En arrivant ici, la plus grande partie est déjà faite 😀 !
Il suffit de trouver le dossier correspondant au semestre voulu, puis d'ouvrir le fichier ``.cs`` correspondant au TD souhaité.
Chaque exercice est écrit dans sa propre méthode (ou sous-programme) appelée ``ExerciceX()``.


## Télécharger le code source

Il est possible de télécharger un fichier ZIP du repository depuis le menu *Code* sur la page "d'accueil" du repository,
mais il est aussi possible de taper ``git clone https://github.com/th0m4s/algo_esilv.git`` (si le logiciel Git est installé sur l'ordinateur) pour tout télécharger dans un dossier.


## Ajouter des exercices/TD

Pour ajouter des TD, il faut d'abord que le projet du semestre existe. Si ce n'est pas le cas, faire un clic droit sur ``Solution 'MenuAlgo`` puis
``Ajouter → Nouveau projet... → Bibliothèque de classes C#`` et lui donner comme nom ``AlgoSx`` avec x le numéro du semestre depuis la 1re année (par exemple, le semestre 1 de 3e année correspond au semestre 5).

Ensuite, il faut copier le fichier ``Sx_TDexemple.cs`` du projet ``OutilsTD`` vers le dossier du projet correspond au semestre et le renommer avec comme nom ``Sx_TDy.cs`` avec x le numéro du semestre et y le numéro du TD.
Si une popup demande s'il faut modifier les références, répondre Oui.

Dans le fichier copié, il est maintenant possible de rajouter des exercices en créant des méthodes/sous-programmes.
Il ne faut pas oublier de rajouter le nom des méthodes/sous-programmes dans la ligne avec ``gestionTD.AjouterExercices`` en séparant les noms par des virgules, par exemple ``gestionTD.AjouterExercices(Exercice1, Exercice2);``
