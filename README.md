
# Programowanie projekt 2023

Aplikacja służy do przeprowadzania sprawdzianów/quizów powtórzeniowych w
szkołach lub uczelniach.


## Stack technologiczny

- ASP.NET Core
- React
- Next.js
- Mysql

## Funkcjonalności

- Rejestracja i logowanie
- W aplikacji dzielimy użytkowników na 2 typy - uczniów i nauczycieli(typ użytkownika wybiera się przy rejestracji). Nauczyciele mogą tworzyć klasy i dodawać do nich uczniów.
- Użytkownicy mogą tworzyć quizy jednokrotnego wyboru - mogą dodać treść pytania i dowolną ilość odpowiedzi
- worząc quiz nauczyciele mogą przypisać ten quiz do konkretnej klasy - wtedy ten quiz jest widoczny tylko dla uczniów danej klasy
- o zamknięciu quizu przez nauczyciela widzi on w statystykach ilu uczniów odpowiedziało poprawnie na dane pytania
- czniowie po udzieleniu odpowiedzi widzą na które pytania odpowiedzieli poprawnie a na które nie.
- Uczniowie też mogą tworzyć quizy ale są one zawsze publiczne

## Wymagania do uruchomienia projektu
- Docker, docker-compose
- Node.js
- .NET 6.0


## Uruchamianie projektu


```bash
  npm run install:all
  npm run dev
```
    
## Demo

[Link do demo](https://programowanie-projekt-2023.vercel.app/)


## Authors

- [@Jan Rapacz](https://github.com/Haans001)
- [@Wiktor Rzeźnicki](https://github.com/wiktohh)
- [@Jakub Wajstak](https://github.com/PolskiKozak)
