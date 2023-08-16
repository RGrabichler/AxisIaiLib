
# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

RUN rm -rf /root/.nuget/

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Copy the csproj files and restore any dependencies (via dotnet restore)
COPY ["BlazorHmi/BlazorHmi.csproj", "BlazorHmi/"]
COPY ["AxisIaiLibExample/AxisIaiLibExampleConnector.csproj", "AxisIaiLibExample/"]
COPY ["AxisIaiLibConnector/AxisIaiLibConnector.csproj", "AxisIaiLibConnector/"] # Add this line
RUN dotnet restore "/src/BlazorHmi/BlazorHmi.csproj"

# Publish the application
COPY . .
WORKDIR "/src/BlazorHmi"
RUN dotnet build "BlazorHmi.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/BlazorHmi"
RUN dotnet publish "BlazorHmi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorHmi.dll"]

