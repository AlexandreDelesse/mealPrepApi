# ====== Build stage ======
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie le projet et restaure
COPY *.sln . 2>/dev/null || true
COPY . .
# Astuce : si tu as plusieurs csproj, ajuste ou cible directement le bon .csproj ci-dessous
RUN dotnet restore

# Compile et publie en Release
RUN dotnet publish -c Release -o /app /p:UseAppHost=false

# ====== Runtime stage ======
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# (Option) Réduit l'image
ENV DOTNET_EnableDiagnostics=0 \
    ASPNETCORE_URLS=http://+:8080

COPY --from=build /app ./

EXPOSE 8080

# ⬇️ Remplace par le nom de ta DLL publiées (ex: MealPrep.Api.dll)
ENTRYPOINT ["dotnet", "YourProject.Api.dll"]
