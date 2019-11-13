FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/StefaniniChallenge.Presentation/StefaniniChallenge.Presentation.csproj", "src/StefaniniChallenge.Presentation/"]
COPY ["src/StefaniniChallenge.Data/StefaniniChallenge.Data.csproj", "src/StefaniniChallenge.Data/"]
COPY ["src/StefaniniChallenge.Domain/StefaniniChallenge.Domain.csproj", "src/StefaniniChallenge.Domain/"]
COPY ["src/StefaniniChallenge.Application/StefaniniChallenge.Application.csproj", "src/StefaniniChallenge.Application/"]
COPY ["src/StefaniniChallenge.IoC/StefaniniChallenge.IoC.csproj", "src/StefaniniChallenge.IoC/"]
RUN dotnet restore "src/StefaniniChallenge.Presentation/StefaniniChallenge.Presentation.csproj"
COPY . .
WORKDIR "/src/src/StefaniniChallenge.Presentation"
RUN dotnet build "StefaniniChallenge.Presentation.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StefaniniChallenge.Presentation.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StefaniniChallenge.Presentation.dll"]