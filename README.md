# webatrio_api

Commencé à 16h, terminé à 18h10.

J'ai ajouté un fichier de collection Postman pour vous faciliter les tests si besoin :-)

## Auto-évaluation

C'est une API classique en .NET, pas de difficultés particulières. 
En raison du temps limité j'ai préféré aller au plus simple et certaines requêtes en base de données depuis les repositories pourraient être optimisées.
J'aurais également ajouté un ExceptionHandlerMiddleware pour intercepter les exceptions de l'application e renvoyer les codes HTTP adéquats.

J'ai décidé d'externaliser certains éléments que je juge réutilisable comme la BaseEntity ou le BaseRepository dans un projet Common pour mieux appréhender
d'éventuelles évolutions de l'application.

## Mise en place

Pour tester l'application, il faut une base de données PostgreSQL et modifier la connection string dans le fichier appsettings.json.
Pour mettre à jour le schéma de la base de données. Ouvrir le Package Manager Console dans Visual Studio, sélectionner le projet Infrastructure comme cible et saisir la commande 'Update-Database'. La base de données référencée dans la connection string sera mise à jour avec le schéma de données de l'application.

