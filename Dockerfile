FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy project files first for better restore-layer caching.
COPY GG/GoalGetter/GoalGetter.csproj GG/GoalGetter/
COPY GG/GG.CoreBusiness/GG.CoreBusiness.csproj GG/GG.CoreBusiness/
COPY GG/GG.Plugins.InMemory/GG.Plugins.InMemory.csproj GG/GG.Plugins.InMemory/
COPY GG/GG.UseCases/GG.UseCases.csproj GG/GG.UseCases/
COPY GG/Libraries/Libraries.csproj GG/Libraries/

RUN dotnet restore GG/GoalGetter/GoalGetter.csproj

# Copy the rest of the source and publish the web app.
COPY GG/ GG/
WORKDIR /src/GG/GoalGetter
RUN dotnet publish GoalGetter.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish ./

# The app reads/writes these files via Directory.GetCurrentDirectory().
COPY --from=build /src/GG/GoalGetter/ApplicationData ./ApplicationData

ENTRYPOINT ["dotnet", "GoalGetter.dll"]