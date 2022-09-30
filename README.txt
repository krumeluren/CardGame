
Denna applikation  bygger på EntityFramework och code-first med dataåtkomst till en SQL databas. 
Som user interface använder jag Blazor Server app men det går att bygga fler olika, t.ex webbapi
Applikationen har separerade lager enligt Clean architecture / onion architecture för framtida skalbarhet.

För att starta:
1: För att skapa en Databas behövs SQL Server. T.ex Microsoft SQL Server Managment.
2: Öppna View -> Other Windows -> Package Manager Console
3: Välj Default Project till "Presentation/CardGame"
4: Skriv in "Update-Database" i konsolen. Databasen skapas då. Se till att det finns en Migration i mappen CardGame.Migrations. Annars kör Add-Migration "namn" först.
5: Sedan välj "CardGame" som startup projekt och kör applikationen.

Core - Här finns domänmodeller och interface för dataåtkomst/services.

Repository - Här finns för dataåtkomst.

Service - Här finns implementation för services, applikationsmodeller och business logic.

Presentation - Här finns user interface. För uppgiften har jag byggt en Blazor Server applikation.

Test - Här finns unit tests sorterade för varje class. Testar främst för Service eftersom det är där den mesta logiken ligger. 
	Att testa repository i detta fallet känndes inte så relevant då det är en väldigt enkel implementation som till 99% bygger på EntityFrameworks inbyggda funktionalitet.

	
Design Patterns jag använt: 

	FactoryPattern har jag använt för IRepoManager och IServiceManager som implementerar en instans av varje repo och service vardera. 
	Detta gör det enklare att injicera eftersom man kommer åt allt ifrån en enda instans av ServiceManager
	Det kan enkelt bytas ut mot andra implementationer efter behov.

	Facade Pattern har jag använt i Service -> Table.cs och i CardGame -> Data -> MinigameTable.cs för att gömma undan logik / klasser för korthantering 
	och istället låter klienten bara anropa void metoder som styr och hämtar data från det interna kortspelet under spelets gång.

	Adapter Pattern har jag använt CardGame -> Data -> MinigameCardHolder.cs 
	Det är en adapter klass för Card.cs som innehåller en bool "IsSelected" och används i Blazor appen 
	IsSelected styrs av blazor webbanvändaren genom checkboxes och informationen utnyttjas av MinigameTable.cs för att veta vilka kort som ska bytas ut då IsSelected = true.

	