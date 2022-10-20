## Høj korrelation
De eneste "høje" korrelationer er colorGold
```md
blueGold:
    [.87] blueChampKills
    [.71] redTowersDestroyed

redGold:
    [.87] redChampKills
    [.70] blueTowersDestroyed
```

Det vil sige, at dataen for hver farve cirka er:
```md
colorGold:
    [.87] colorChampKills
    [.71] oppositeColorTowersDestroyed
```

---

## Droppet koloner
Fra datasættet, har jeg droppet følgende kolloner:
* **Unnamed: 0** - Tom og ubruglig kollone - fortæller intet om dataen
* **matchId** - Match ids er ligegyldige, og kan alligevel ikke læses med en min=-1 & max=1
* **redDragonKills**/**blueDragonKills** - Der er ingen dragon kills i dataen, så derfor er den også unødvendig
* **redAvgLevel**/**blueAvgLevel** - Average level burde heller ikke sige noget om spillene, udover matchmaking. Men som matchId, er tallene også ubruglige

---


