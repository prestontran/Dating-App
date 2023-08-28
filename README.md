# Dating-App
1. This Dating-App project has 2 parts: API folder (C# backend) and client folder (Angular frontend)
   
2. API folder is the backend code. To run backend, we need to type in "dotnet watch --no-hot-reload" in the terminal
    Helpful backend C# terminal commands:
    dotnet tool install --global dotnet-ef --version 7.0.5 (from nuget dotnet-ef website)
    dotnet tool list -g
    dotnet tool -h
    dotnet ef database -h
    dotnet ef migrations add UsernameRequired (add new required field for database)
    dotnet ef migrations remove (remove latest change in database)

    command pallet: .net:generate assets for build and debug: creates launch.json file
    
3. client folder is the frontend code. To run frontend, we need to type in "ng serve"
    If possible, install SSL signed certificate for localhost for development. Use Chocolatey for mkcert

    To debug frontend, there are 2 ways: 1. run backend: dotnet run and run .NET Core Launch (web)
                                         2. run backend: dotnet watch --no-hot-reload and run .NET Core Attach and choose .exe file in the command pallet
