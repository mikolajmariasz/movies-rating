# Movies Rating App

A Blazor Server application for authenticated users to add movies (with posters and descriptions), submit and manage ratings, and import movie data in bulk from TMDB Api.

## Features implemented
- Local (email/password) and Google authentication  
- “Add New Movie” form with poster upload, description, release date and initial ratings  
- External login via Google OAuth  
- Bulk import of top-100 popular movies from TheMovieDB API  
- Scaffolded Identity UI under `/Account/*`  

## Prerequisites
- .NET 8.0
- A free API key from [TheMovieDB.org](https://www.themoviedb.org/settings/api)  
- Google OAuth Client ID/Secret

## Configuration

1. **Clone the repository**  
   ```bash
   git clone https://github.com/your-username/movies-rating.git
   cd movies-rating/movies-rating
   ```
2. Set up secrets
   ```bash
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=.;Database=MoviesDb;Trusted_Connection=True;"
   dotnet user-secrets set "TMDb:ApiKey" "<YOUR_TMDB_API_KEY>"
   dotnet user-secrets set "Authentication:Google:ClientId" "<YOUR_GOOGLE_CLIENT_ID>"
   dotnet user-secrets set "Authentication:Google:ClientSecret" "<YOUR_GOOGLE_CLIENT_SECRET>"
  (or manually enter secrets in `appsettings.json`)

## Screenshots
`Components/Pages/Movies/Index.razor` (before sign in)
![image](https://github.com/user-attachments/assets/99d95c7d-3fb8-4ce9-9450-102aaf9037b7)
`Components/Pages/Movies/Index.razor` (after sign in)
![image](https://github.com/user-attachments/assets/9d1e2341-3cf7-4180-ba7f-2d4871d4e3b9)
`Components/Accounts/Pages/Register.razor`
![image](https://github.com/user-attachments/assets/7cd5b83f-5abe-4da7-9416-5a67c74e6518)
`Components/Accounts/Pages/Login.razor`
![image](https://github.com/user-attachments/assets/69b81d01-1bd4-4229-a34a-c0a21b0b28a9)
`Components/Movies/Pages/Create.razor`
![image](https://github.com/user-attachments/assets/facdd62c-501d-4670-a865-f48ce68419df)
`Components/Movies/Pages/Edit.razor`
![image](https://github.com/user-attachments/assets/6c8382d6-be03-476b-94e8-285732f02728)
`Components/Movies/Pages/Details.razor`
![image](https://github.com/user-attachments/assets/16af136e-f7ab-4be6-b248-15fe4ffdd71b)

