#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RazorPagesLearn/RazorPagesLearn.csproj", "RazorPagesLearn/"]
COPY ["RazorPagesLearn.Services/RazorPagesLearn.Services.csproj", "RazorPagesLearn.Services/"]
COPY ["RazorPagesLearn.Models/RazorPagesLearn.Models.csproj", "RazorPagesLearn.Models/"]
RUN dotnet restore "RazorPagesLearn/RazorPagesLearn.csproj"
COPY . .
WORKDIR "/src/RazorPagesLearn"
RUN dotnet build "RazorPagesLearn.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RazorPagesLearn.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RazorPagesLearn.dll"]