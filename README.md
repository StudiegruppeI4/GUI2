# GUI2
I4GUI Mandatory assignment 2 - Morgenmadsbuffeten

Steps til at køre projektet:
* Åbn solution "Morgenmadsbuffeten.sln"
* Tjek at alle NuGet Packages er opdateret ved højre-klik på solution og trykke "Manage NuGet Packages for solution..", hvorefter der på pop-up vinduet gås ind på "Update" og opdatere alle de relevante pakker
* I "Package Manager Console", skriv kommandoen "Add-Migration Initial", hvorefter der skrives "Update-Database"
* Start projektet uden debugging

Der er på forhånd lagt en smule data ind i databasen, så den kan arbejdes med fra starten. Desuden er der også lagt nogle brugere ind der har adgang til staff siderne.
Email og passwords for disse er:

Waiter:
* Waiter@Localhost
* Secret7$

Receptionist:
* Reception@Localhost
* Secret8$

Kun disse har tilgang til henholdsvis "Restaurant" og "Reception" views.
Derudover er der også lavet en bruger der heder Chef, som repræsentere kokken i køkkenet. De har ikke nogen rettigheder, men det kræver dog at man er logget ind for at kunne se "Kitchen" viewet.

Chef:
* Chef@Chef
* Secret9$
