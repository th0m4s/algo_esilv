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


## Ajouter des exercices/TD...

### ... en modifiant le code sur Visual Studio
Ce n'est pas la méthode la plus facile, mais permet de créer un .exe avec les exercices inclus.  
Pour ajouter des TD via cette méthode, il faut d'abord que le dossier du semestre existe. Si ce n'est pas le cas, faire un clic droit sur le projet ``MenuAlgo`` (avec la petite icône C# à sa gauche) puis
``Ajouter → Nouveau dossier`` et lui donner comme nom ``Sx`` avec x le numéro du semestre depuis la 1re année (par exemple, le semestre 1 de 3e année correspond au semestre 5).

Ensuite, il faut copier le fichier ``Sx_TDexemple.cs`` du projet ``OutilsTD`` vers le dossier du projet correspond au semestre et le renommer avec comme nom ``Sx_TDy.cs`` avec x le numéro du semestre et y le numéro du TD.
Si une popup demande s'il faut modifier les références, répondre Oui.

Dans le fichier copié, il est maintenant possible de rajouter des exercices en créant des méthodes/sous-programmes.
Il faut bien nommer le sous-programme ``ExerciceX`` avec X le numéro de l'exercice pour qu'il soit reconnu.

Il est possible de donner un nom à l'exercice en modifiant le texte entre guillemets au-dessus de la fonction.
S'il manque cette ligne, ce n'est pas grave (un exercice sans nom peut exister), mais sinon, il faut copier ``[Exercice("Nom de l'exercice")]`` au-dessus de la ligne ``static void ExerciceX()``.

Le nouveau dossier, s'il a été créé, le nouveau fichier et tous les nouveaux sous-programmes seront automatiquement détectés et proposés à l'utilisateur.

![Structure des fichiers dans Visual Studio](https://github.com/th0m4s/algo_esilv/blob/master/Images/nom_fichier_vs.png?raw=true)

### ... en placant le code à côté de l'application
Cette méthode est plus pratique et permet de modifier facilement le code d'un exercice sans avoir à recompiler toute l'application.  
Dans le dossier contenant le fichier ``AlgoEsilv.exe``, il faut créer un dossier ``AlgoEsilv`` (sans extension, c'est un dossier) et placer dedans les fichiers ``.cs``, sans avoir besoin non plus de créer un dossier par semestre.

Ceux-ci doivent être nommés de la même façon dans les 2 méthodes : ``Sx_TDy.cs`` avec x le numéro du semestre depuis la première année (le semestre 5 correspond par exemple au 1er semestre de la 3e année) et y le numéro du TD.

![Structure des fichiers côte à côté](https://github.com/th0m4s/algo_esilv/blob/master/Images/structure_coteacote.png?raw=true)
