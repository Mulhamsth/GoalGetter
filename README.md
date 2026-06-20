# GoalGetter

A project- and goal-tracking web app built with **Blazor Server (.NET 6)** and **MudBlazor**.
GoalGetter lets a team organise work into projects, break projects into tasks with
deadlines and progress states, assign tasks to people, group people into teams, and
watch overall progress on a per-project dashboard.

Originally built as a collaborative ITP coursework project at **HTL Krems**.

## Features

- **Projects** – create, edit, and remove projects; per-project progress dashboard with a chart
- **Tasks** – deadlines, status (open / in progress / done), and an assigned person per task
- **People** – a contact list with avatars, email, phone, and an address shown on an embedded map
- **Teams** – assemble people into project teams with roles
- **Search** – filter people and projects by name
- **Auth & roles** – simple session-based login with Administrator / User roles
- **Light / dark theme** toggle

## Tech stack

| Layer | Technology |
|---|---|
| UI | Blazor Server, MudBlazor 6 |
| Runtime | .NET 6 (ASP.NET Core) |
| Architecture | Clean / use-case layering (`GG.CoreBusiness`, `GG.UseCases`, plugin interfaces) |
| Storage | Pluggable repository (in-memory + JSON files under `ApplicationData/`) |

The solution is split into layers so the storage backend is swappable behind
`PluginInterfaces` — the app ships with an in-memory/JSON plugin and the business
rules live in `GG.UseCases`, independent of UI and storage.

## Run locally

```bash
git clone https://github.com/Mulhamsth/GoalGetter.git
cd GoalGetter/GG/GoalGetter
dotnet run
```

Then open the printed `https://localhost:<port>` URL.

**Demo login:** `admin` / `admin` (Administrator) or `user` / `user` (User).

> The demo credentials and all seeded contacts are placeholder data for local
> demonstration only — see note below.

## Demo data

All people, emails, phone numbers, photos, and addresses in this repository are
**fictional placeholder data** created for demonstration. Profile images are
generated identicons, not real people. Email addresses use `example.com` and the
map addresses point to public squares.

## Project structure

```
GG/
├── GoalGetter/            # Blazor Server app (Pages, Components, wwwroot, auth)
├── GG.CoreBusiness/       # Domain entities (Person, Project, Task, Team)
├── GG.UseCases/           # Application use cases + plugin interfaces
├── GG.Plugins.InMemory/   # In-memory / JSON repository implementation
├── Libraries/             # Helpers (e.g. address / distance utilities)
└── ConsoleAppPlayground/  # Scratch console project for trying library calls
```

## Authors

Built collaboratively for an HTL Krems ITP class by:

- Mulham Taylouni — [@Mulhamsth](https://github.com/Mulhamsth)
- Christian Wiesinger
- Clemens Schmid