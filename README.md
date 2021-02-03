# intro-dotnet
## Objectif Extreme carpaccio

Calculer le montant de la facture pour une commande


## Comment calculer ?

1. Faire la somme des montants des éléments de la commande
2. Appliquer la réduction
3. Ajouter les taxes
4. Arrondir à deux chiffres après la virgule

### Réduction

- `PayThePrice` : pas de réduction
- `HalfPrice` : 50% de réduction
- `Standard` :

| Montant avant réduction | Réduction |
| -- | -- |
|X<100|0%|
|100<=x<500|3%|
|500<=x<700|5%|
|700<=x<1000|7%|
|1000<=x<5000|10%|
|5000<=x|15%|


### Taxes

- `FR` : 20%
- `UK` : 21%
- `PT` : 23%
