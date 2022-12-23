# Saitynai-CookFood
Projektas universitetui

1.	Sprendžiamo uždavinio aprašymas

1.1.	 Sistemos paskirtis

Projekto tikslas – paskatinti žmones dalintis jų skaniausiais receptais su visuomene.
Norint naudotis pilnai naudotis šia platforma bus reikalinga registracija prie internetinės aplikacijos.  Registruotas vartotojas galės įkelti receptą, patiekalo nuotrauką,  recepto aprašymą, įvertinti kitus receptus, ištrinti ar paredaguoti savo receptą. Taip pat sistema turės administratoriaus rolę, kuri galės patvirtinti receptus, klaidingus receptus ištrinti ir šalinti komentarus.
Sistemoje bus 3 taikomosios srities objektai tarpusavyje susieti prasminiu ir hierarchiniu ryšiu: Receptų rinkinys > Receptas > Ingredientas.

1.2.	 Funkciniai reikalavimai

Neregistruotas sistemos naudotojas galės:
1.	Peržiūrėti platformos turinį.
2.	Prisiregistruoti prie sistemos
3.	Komentuoti receptus anonimiškai

Registruotas sistemos naudotojas galės:
1.	Atsijungti nuo internetinės aplikacijos;
2.	Pridėti receptą

2.1	Įkelti patiekalo nuotrauką

2.2	Pridėti recepto aprašymą;

2.3	Pridėti gaminimo trukmę;

2.4	Paskirti receptą į patiekalo tipą

3.	Komentuoti receptus savo vardu
4.	Įvertinti receptus
5.	Redaguoti/ištrinti  savo  receptus
6.	Trinti komentarus po savo receptais
7.	Atnaujinti profilį

Administratorius galės:
1.	Patvirtinti įkeltus receptus
2.	Trinti komentarus
3.	Šalinti receptus

2.	Sistemos architektūra

Sistemos sudedamosios dalys:
• Kliento pusė (ang. Front-End) – naudojant React.js;
• Serverio pusė (angl. Back-End) – naudojant C# .NET. Duomenų bazė – MySQL.
Diegimo diagramoje pavaizduota, kad kuriama aplikacija,  aplikacijų programavimo sąsaja ir duomenų bazė bus Azure serveryje. Kiekviena sistemos dalis yra diegiama tame pačiame serveryje.
Aplikacija yra pasiekiama per HTTP protokolą. Šios sistemos duomenų gavimui 
yra reikalingas CookFood API, kuris pasiekiamas per aplikacijų programavimo sąsają. Pats CookFood API vykdo duomenų mainus su duomenų baze - tam naudojama ORM sąsaja.


![image](https://user-images.githubusercontent.com/81435847/193294314-d712a8a7-1c5f-4353-a5b7-323a1f4dbaaf.png)

# Naudotojo sąsaja

### Home page (Svečias)
![image](https://user-images.githubusercontent.com/81435847/209308689-4407a5d6-8aac-4925-a88a-ce48042727c8.png)
### Home page (Prisijungęs vartotojas)
![image](https://user-images.githubusercontent.com/81435847/209308444-e652f252-8b75-4938-84e9-220fbcb83224.png)
### Home page (Admin)
![image](https://user-images.githubusercontent.com/81435847/209309597-99053beb-498d-4a81-a391-f9280e2aa9f7.png)
### Profile (Prisijungęs vartotojas)
![image](https://user-images.githubusercontent.com/81435847/209312206-736d4765-e2cb-4860-abb1-c640bb420573.png)
### Receptų rinkinio pridėjimas (Prisijungęs vartotojas)
![image](https://user-images.githubusercontent.com/81435847/209314614-101569f8-ea79-4ff3-b265-8329c3514b03.png)
### Receptų rinkinių puslapis
![image](https://user-images.githubusercontent.com/81435847/209315710-fbd97f50-038b-4ffd-b279-e571df8b5764.png)
### Specifinio recepto rinkinio receptai (Prisijungęs vartotojas)
![image](https://user-images.githubusercontent.com/81435847/209315869-6eb04f6c-f856-47a1-9560-7c60c1fc38cf.png)
### Recepto pridėjimas (Prisijungęs vartotojas)
![image](https://user-images.githubusercontent.com/81435847/209316252-35e3c762-7490-4efb-b4e4-d64f88c3f435.png)
### Prisijungimo langas
![image](https://user-images.githubusercontent.com/81435847/209316410-1389e885-7808-42c0-8b0a-9fe961ed67d4.png)
### Registracijos langas
![image](https://user-images.githubusercontent.com/81435847/209316460-bc96d233-b0f5-4845-9d45-f8e114177369.png)

# API specifikacija

### Ingredientas

### Get

Galimi atsakymai : 

200 - OK 

https://localhost:7247/Ingredient
```json
[
    {
        "name": "Cukrus",
        "quanity": 1,
        "measurement": "delnas",
        "id": 1,
        "recepyId": 0,
        "userId": null,
        "user": null
    },
    {
        "name": "Miltai",
        "quanity": 500,
        "measurement": "g",
        "id": 5,
        "recepyId": 0,
        "userId": null,
        "user": null
    }
]
```
### Get(id)

Galimi atsakymai : 

400 - Bad Request <br>
200 - OK 

https://localhost:7247/Ingredient/1
```json

    {
        "name": "Cukrus",
        "quanity": 1,
        "measurement": "delnas",
        "id": 1,
        "recepyId": 0,
        "userId": null,
        "user": null
    }

```
### Post

Galimi atsakymai : 

400 - Bad Request <br>
401 - Unauthorized <br>
403 - Forbidden<br>
200 - OK 

https://localhost:7247/Ingredient/1

Užklausa
```json
    {
        "Name": "Miltai",
        "Quanity": 500,
        "Measurement": "g"
    }
```
Atsakymas
```json
    [
    {
        "name": "Cukrus",
        "quanity": 1,
        "measurement": "delnas",
        "id": 1,
        "recepyId": 0,
        "userId": null,
        "user": null
    },
    {
        "name": "Miltai",
        "quanity": 500,
        "measurement": "g",
        "id": 5,
        "recepyId": 0,
        "userId": null,
        "user": null
    }]
```
### Put
Galimi atsakymai : 

400 - Bad Request <br>
401 - Unauthorized <br>
403 - Forbidden <br>
200 - OK 

https://localhost:7247/Ingredient/1

Užklausa
```json
{
        "name": "Cinamonas"
}
```
Atsakymas
```json
{
        "name": "Cinamonas",
        "quanity": 1,
        "measurement": "delnas",
        "id": 1,
        "recepyId": 0,
        "userId": null,
        "user": null
    }
 ```
### Delete
Galimi atsakymai : 

400 - Bad Request <br>
401 - Unauthorized <br>
403 - Forbidden <br>
200 - OK 

https://localhost:7247/Ingredient/1

Atsakymas
```json
 {
        "name": "Cukrus",
        "quanity": 1,
        "measurement": "delnas",
        "id": 1,
        "recepyId": 0,
        "userId": null,
        "user": null
    }
 ```
 
 ### Receptas

### Get

Galimi atsakymai : 

200 - OK 

https://localhost:7247/Recepy
```json
[
    {
        "name": "Vištienos KoreguotasT",
        "description": null,
        "duration": 0,
        "uploadDate": "2022-12-05T21:42:16.4854953",
        "updateDate": "2022-12-23T17:59:19.5662652",
        "confirmed": null,
        "rating": null,
        "id": 1,
        "recepySetId": 1,
        "userId": "c4362117-00b6-4b00-9f1b-e6d9a45aeca7",
        "user": null
    },
    {
        "name": "Spagečiai",
        "description": "Greit paruošiami spagečiai su padažu",
        "duration": 60,
        "uploadDate": "2022-12-19T01:19:17.1709931",
        "updateDate": "2022-12-23T09:10:15.629414",
        "confirmed": null,
        "rating": null,
        "id": 3,
        "recepySetId": 0,
        "userId": "c4362117-00b6-4b00-9f1b-e6d9a45aeca7",
        "user": null
    },
    {
        "name": "Obuolių pyragas",
        "description": "Pyragas sudarytas iš obuolių",
        "duration": 50,
        "uploadDate": "2022-12-19T01:20:11.3769705",
        "updateDate": "2022-12-23T09:46:06.8500039",
        "confirmed": null,
        "rating": null,
        "id": 4,
        "recepySetId": 0,
        "userId": "c4362117-00b6-4b00-9f1b-e6d9a45aeca7",
        "user": null
    }
]
```
### Get(id)

Galimi atsakymai : 

400 - Bad Request <br>
200 - OK 

https://localhost:7247/Recepy/1
```json

    {
    "name": "Vištienos kotletas",
    "description": null,
    "duration": 0,
    "uploadDate": "2022-12-05T21:42:16.4854953",
    "updateDate": "2022-12-23T17:59:19.5662652",
    "confirmed": null,
    "rating": null,
    "id": 1,
    "recepySetId": 1,
    "userId": "c4362117-00b6-4b00-9f1b-e6d9a45aeca7",
    "user": null
}

```
### Post

Galimi atsakymai : 

400 - Bad Request <br>
401 - Unauthorized <br>
403 - Forbidden<br>
200 - OK 

https://localhost:7247/Recepy/1

Užklausa
```json
    {
        "Name": "Miltai",
        "Quanity": 500,
        "Measurement": "g"
    }
```
Atsakymas
```json
    [
    {
        "name": "Cukrus",
        "quanity": 1,
        "measurement": "delnas",
        "id": 1,
        "recepyId": 0,
        "userId": null,
        "user": null
    },
    {
        "name": "Miltai",
        "quanity": 500,
        "measurement": "g",
        "id": 5,
        "recepyId": 0,
        "userId": null,
        "user": null
    }]
```
### Put
Galimi atsakymai : 

400 - Bad Request <br>
401 - Unauthorized <br>
403 - Forbidden <br>
200 - OK 

https://localhost:7247/Recepy/1

Užklausa
```json
{
        "name": "Cinamonas"
}
```
Atsakymas
```json
{
        "name": "Cinamonas",
        "quanity": 1,
        "measurement": "delnas",
        "id": 1,
        "recepyId": 0,
        "userId": null,
        "user": null
    }
 ```
### Delete
Galimi atsakymai : 

400 - Bad Request <br>
401 - Unauthorized <br>
403 - Forbidden <br>
200 - OK 

https://localhost:7247/Recepy/1

Atsakymas
```json
 {
        "name": "Cukrus",
        "quanity": 1,
        "measurement": "delnas",
        "id": 1,
        "recepyId": 0,
        "userId": null,
        "user": null
    }
 ```
### Receptų rinkinys

### Get

Galimi atsakymai : 

200 - OK 

https://localhost:7247/Recepy
```json
[
    {
        "name": "skanios sriubos",
        "type": "Sriubos",
        "id": 1,
        "userId": "c4362117-00b6-4b00-9f1b-e6d9a45aeca7",
        "user": null
    }
]
```
### Get(id)

Galimi atsakymai : 

400 - Bad Request <br>
200 - OK 

https://localhost:7247/RecepySet/1
```json
    {
        "name": "skanios sriubos",
        "type": "Sriubos",
        "id": 1,
        "userId": "c4362117-00b6-4b00-9f1b-e6d9a45aeca7",
        "user": null
    }
```

### GetRecipesInSet(recepy/id)

Galimi atsakymai : 

400 - Bad Request <br>
200 - OK 

https://localhost:7247/RecepySet/recepy/1
```json
   [
    {
        "name": "Vištienos KoreguotasT",
        "description": null,
        "duration": 0,
        "uploadDate": "2022-12-05T21:42:16.4854953",
        "updateDate": "2022-12-23T17:59:19.5662652",
        "confirmed": null,
        "rating": null,
        "id": 1,
        "recepySetId": 1,
        "userId": "c4362117-00b6-4b00-9f1b-e6d9a45aeca7",
        "user": null
    }
]
```


### Post

Galimi atsakymai : 

400 - Bad Request <br>
401 - Unauthorized <br>
403 - Forbidden<br>
200 - OK 

https://localhost:7247/RecepySet/1

Užklausa
```json
  {
        "Name": "Vokiškis šniceliai",
        "Type": "Kotletai"
}
```
Atsakymas
```json
   [
    {
        "name": "Vokiškis šniceliai",
        "type": "Kotletai",
        "id": 4,
        "userId": "c4362117-00b6-4b00-9f1b-e6d9a45aeca7",
        "user": null
    }
]
```
### Put
Galimi atsakymai : 

400 - Bad Request <br>
401 - Unauthorized <br>
200 - OK 

https://localhost:7247/RecepySet/1

Užklausa
```json
{
        "name": "Kalėdiniai Kotletai"
}
```
Atsakymas
```json
{
        "name": "Kalėdiniai Kotletai"
        "type": "Kotletai",
        "id": 4,
        "userId": "c4362117-00b6-4b00-9f1b-e6d9a45aeca7",
        "user": null
    }
 ```
### Delete
Galimi atsakymai : 

400 - Bad Request <br>
401 - Unauthorized <br>
200 - OK 

https://localhost:7247/RecepySet/1

Atsakymas
```json
 {
    "name": "skanios sriubos",
    "type": "Sriubos",
    "id": 1,
    "userId": "c4362117-00b6-4b00-9f1b-e6d9a45aeca7",
    "user": null
}
 ```
 
 # Išvados
 Buvo sukurtas veikiantis projektas, tačiau trūko realizuoti ingredientų funkcionalumą. Projekto metu buvo pagilintos React žinios ir išmokta naudotis Material UI biblioteka. Realizuojant vartotojų autentifikavimą ir autoriziciją buvo išmokta JWT tokenų naudojimas ir pritaikymas.
