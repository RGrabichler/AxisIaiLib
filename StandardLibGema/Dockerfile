
# Use the official Windows-based SDK image as a build image
FROM mcr.microsoft.com/dotnet/sdk:5.0-windowsservercore-ltsc2022 AS build
WORKDIR /src

# Copy the csproj files and restore any dependencies (via dotnet restore)
COPY ["BlazorHmi/BlazorHmi.csproj", "BlazorHmi/"]
COPY ["AxisIaiLibExample/AxisIaiLibExampleConnector.csproj", "AxisIaiLibExampleConnector/"]
COPY ["AxisIaiLibConnector/AxisIaiLibConnector.csproj", "AxisIaiLibConnector/"]

# Copy the rest of the files and build the application
COPY . .
WORKDIR "/src/BlazorHmi"

COPY local_nuget/ /src/BlazorHmi/.nuget/
COPY NuGet.Config .
RUN dotnet restore "BlazorHmi.csproj"
RUN dotnet restore -r win-x64
RUN dotnet build "BlazorHmi.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/BlazorHmi"

# Copy the publish profile
COPY ["BlazorHmi/Properties/PublishProfiles/FolderProfile.pubxml", "BlazorHmi/"]

RUN dotnet publish "BlazorHmi.csproj" -c Release -r win-x64  -p:PublishProfile=FolderProfile -o /app/publish

# Use the official Windows-based runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:5.0-windowsservercore-ltsc2022 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["BlazorHmi.exe"]

