Dokumentacja Projektu MVCMovieBase<br>
Opis Projektu<br>
MVCMovieBase to projekt oparty na architekturze MVC (Model-View-Controller) w środowisku .NET. Celem projektu jest zarządzanie kolekcją recenzji filmowych. Aplikacja umożliwia dodawanie, edytowanie, usuwanie i przeglądanie recenzji filmów.

Technologie<br>
.NET Core MVC<br>
C#<br>
Entity Framework Core<br>
HTML<br>
CSS<br>
JavaScript<br>
Struktura Projektu<br>
Controllers/ - Kontrolery obsługujące żądania HTTP<br>
Models/ - Modele reprezentujące dane aplikacji<br>
Views/ - Widoki renderujące interfejs użytkownika<br>
wwwroot/ - Zasoby statyczne (CSS, JavaScript)<br>
appsettings.json - Konfiguracja aplikacji<br>
Startup.cs - Konfiguracja i konfiguracja usług aplikacji<br>
Model Danych<br>
Aplikacja wykorzystuje model danych do przechowywania recenzji filmowych. Przykładowy model MovieReview może wyglądać tak:<br>

csharp<br>
Copy code<br>
public class MovieReview<br>
{<br>
    public int Id { get; set; }<br>
    public string Title { get; set; }<br>
    public string ReviewText { get; set; }<br>
    public int Rating { get; set; }<br>
}<br>
Kontrolery<br>
HomeController - Obsługuje żądania związane z główną stroną i przeglądaniem recenzji.<br>
ReviewsController - Zarządza operacjami CRUD (Create, Read, Update, Delete) dla recenzji.<br>
Widoki<br>
Index.cshtml - Strona główna wyświetlająca listę recenzji.<br>
Create.cshtml - Strona do dodawania nowej recenzji.<br>
Edit.cshtml - Strona do edytowania istniejącej recenzji.<br>
Konfiguracja<br>
Konfiguracja aplikacji, takie jak połączenie do bazy danych, znajduje się w pliku appsettings.json.<br>
Połączenie do bazy danych jest skonfigurowane w pliku Startup.cs.<br>
Baza Danych<br>
Aplikacja korzysta z Entity Framework Core do komunikacji z bazą danych.<br>
Model danych jest mapowany na tabelę w bazie danych.<br>
Uruchamianie Projektu<br>
Skonfiguruj połączenie do bazy danych w pliku appsettings.json.<br>

Uruchom migracje, aby utworzyć bazę danych:<br>

bash<br>
Copy code<br>
dotnet ef migrations add InitialCreate<br>
dotnet ef database update<br>
Uruchom projekt:<br>

bash<br>
Copy code<br>
dotnet run<br>
Aplikacja będzie dostępna pod adresem http://localhost:5000 (lub https://localhost:5001).<br>


Autor
[Jola N.]

Uwagi
Projekt może wymagać dostosowania w zależności od specyfiki wymagań.
Znane Problemy
