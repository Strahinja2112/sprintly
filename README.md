# Sprintra
Sprintra — Windows desktop aplikacija za Scrum timove. Upravljajte sprintovima, pratite zadatke, logujte rad i sarađujte — sve kroz čist, nativni WinForms interfejs.

## Entity Framework Core Komande

Sve komande se izvršavaju iz terminala u korenu projekta (tamo gde se nalazi `.csproj` fajl).

### Rad sa migracijama

- **Kreiranje nove migracije** (nakon izmena u modelima):
  ```bash
  dotnet ef migrations add ImeMigracije
  ```

- **Primena migracija na bazu:**
  ```bash
  dotnet ef database update
  ```

- **Brisanje poslednje migracije** (samo ako nije već primenjena na bazu):
  ```bash
  dotnet ef migrations remove
  ```

- **Vraćanje baze na specifičnu migraciju:**
  ```bash
  dotnet ef database update ImePrethodneMigracije
  ```

### Održavanje baze

- **Brisanje cele baze podataka:**
  ```bash
  dotnet ef database drop
  ```

- **Resetovanje baze** (brisanje pa ponovno kreiranje):
  ```bash
  dotnet ef database drop && dotnet ef database update
  ```

- **Generisanje SQL skripte** (za ručno izvršavanje u SSMS):
  ```bash
  dotnet ef migrations script
  ```