FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["practiceWork3rdCourse/practiceWork3rdCourse.csproj", "practiceWork3rdCourse/"]
RUN dotnet restore "practiceWork3rdCourse/practiceWork3rdCourse.csproj"
COPY . .
WORKDIR "/src/practiceWork3rdCourse"
RUN dotnet build "practiceWork3rdCourse.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "practiceWork3rdCourse.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "practiceWork3rdCourse.dll"]
