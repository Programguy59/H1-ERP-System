# Indholdsfortegnelse

- [Om](#om)
- [Licens](https://github.com/Programguy59/H1-ERP-System/blob/92c767be6b2bcc899e34a260cf589b9b74ff3fd7/LICENSE)
- [Diagrammer](#diagrammer)
- [Teori](#teori)
- [Eksempler](#eksempler)

## Om

- Dette er et ERP system, som er lavet i forbindelse med et skole projekt.
- Projektet er udviklet
  af [Magnus](https://github.com/Programguy59), [Laurits](https://github.com/Lauritslund1), [Casper](https://github.com/consoleBeep)
  og [Bastian](https://github.com/BastianAsmussen) i C# med Microsoft SQL Server.
- ERP systemet er lavet til LNE Security A/S som er en fiktiv virksomhed.
- ERP systemet er lavet til at kunne håndtere følgende:
    - Kunder
    - Firmaer
    - Produkter
    - Ordrer
    - Adresser
- Programmet understøtter [CRUD](https://en.wikipedia.org/wiki/Create,_read,_update_and_delete) på alle ovenstående
  punkter og bruger [TECHCOOL](https://github.com/sinb-dev/TECHCOOL) til håndtering af UI.
- For mere information om hvordan man administrere programmet, se
  vores [bruger manual](https://github.com/Programguy59/H1-ERP-System/blob/2c99cde7f8135de779231d7d93473f36ae2b68ac/Brugermanual.pdf)!

## Diagrammer

- [Klasse Diagram](https://github.com/Programguy59/H1-ERP-System/blob/a9e738434ca1602b6fdc930c9e22285f57711b8d/H1%20ERP-System/diagrams/UMLClassDiagram.png)
- [Database Diagram](https://github.com/Programguy59/H1-ERP-System/blob/829deef5df237dddacb13d898f78af2b3fcc76fd/H1%20ERP-System/diagrams/Database%20Diagram%20v1.png)

## Teori

- Vi bruger [design mønstre](https://en.wikipedia.org/wiki/Software_design_pattern)
  som [indkapsling](https://en.wikipedia.org/wiki/Encapsulation_(computer_programming))
  og [nedarvning](https://en.wikipedia.org/wiki/Inheritance_(object-oriented_programming)) til at gøre vores kode mere
  overskuelig og nemmere at vedligeholde.
- Vores Database arbejder på 2 planer,
  bruger siden og server siden. På bruger siden tager den dataen fra databasen
  og [mapper](https://en.wikipedia.org/wiki/Data_mapping) det til de respektive lokale klasser, det er lidt som
  et [caching lag](https://en.wikipedia.org/wiki/Cache_(computing)) fordi den holder en version af dataen.
  På server siden tager den dataen fra de lokale klasser og [mapper](https://en.wikipedia.org/wiki/Data_mapping) det til
  databasen, det er for at gøre det nemmere at arbejde med dataen og for at gøre det nemmere at arbejde med databasen.
- Vores [GUI](https://en.wikipedia.org/wiki/Graphical_user_interface) er lavet
  med [TECHCOOL](https://github.com/sinb-dev/TECHCOOL) som er
  et [GUI](https://en.wikipedia.org/wiki/Graphical_user_interface) framework lavet
  af [Simon (Underviser)](https://github.com/sinb-dev) til konsol applikationer.
- Det første vores program gør er at prøve at forbinde til databasen, hvis forbindelsen lykkeds beder den om alt data
  fra hver enkelt tabel, den [mapper](https://en.wikipedia.org/wiki/Data_mapping) så dataen for hver række til en klasse
  og tilføjer den til en liste af klasser, den gør dette for hver tabel.
- Efter [mapping](https://en.wikipedia.org/wiki/Data_mapping) af data skal det nu præsenteres til brugeren hvilket
  bliver gjort i et konsol vidue med [TECHCOOL](https://github.com/sinb-dev/TECHCOOL). Brugeren kan så vælge at oprette,
  redigere eller slette data, hvilket bliver gjort ved at
  bruge [CRUD](https://en.wikipedia.org/wiki/Create,_read,_update_and_delete) på databasen og opdatere den lokale liste
  af klasser, og skrive det til databasen hvis dataen er korrekt.

## Eksempler

- Vi bruger [nedarvning](https://en.wikipedia.org/wiki/Inheritance_(object-oriented_programming))
  i [Customer](https://github.com/Programguy59/H1-ERP-System/blob/92c767be6b2bcc899e34a260cf589b9b74ff3fd7/H1%20ERP-System/src/customer/Customer.cs)
  hvor kunden nedarver
  fra [Person](https://github.com/Programguy59/H1-ERP-System/blob/92c767be6b2bcc899e34a260cf589b9b74ff3fd7/H1%20ERP-System/src/customer/Person.cs).
- [Indkapsling](https://en.wikipedia.org/wiki/Encapsulation_(computer_programming)) eksistere i nærmest alle klasser,
  f.eks.
  i [Person](https://github.com/Programguy59/H1-ERP-System/blob/92c767be6b2bcc899e34a260cf589b9b74ff3fd7/H1%20ERP-System/src/customer/Person.cs)
  hvor en person har
  en [Address](https://github.com/Programguy59/H1-ERP-System/blob/92c767be6b2bcc899e34a260cf589b9b74ff3fd7/H1%20ERP-System/src/util/Address.cs).
- Der er et par [hjælper](https://en.wikipedia.org/wiki/Helper_class) klasser i programmet, den største
  er [Database Manageren](https://github.com/Programguy59/H1-ERP-System/blob/92c767be6b2bcc899e34a260cf589b9b74ff3fd7/H1%20ERP-System/src/util/DatabaseServer.cs)
  til at lave [CRUD](https://en.wikipedia.org/wiki/Create,_read,_update_and_delete) operationer på databasen.
