FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Sets the working directory
WORKDIR /app
EXPOSE 80
EXPOSE 443


ENV ASPNETCORE_URLS=http://*:5000
# Copy Projects
#COPY *.sln .
COPY Application/Application.csproj ./Application/
COPY Domain/Domain.csproj ./Domain/
COPY Service/Service.csproj ./Service/
COPY CrossCutting/CrossCutting.csproj ./CrossCutting/
COPY Data/Data.csproj ./Data/

# .NET Core Restore
RUN dotnet restore ./Application/Application.csproj

# Copy All Files
COPY . .

# .NET Core Build and Publish
RUN dotnet publish ./Application/Application.csproj -c Release -o /publish

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS runtime
WORKDIR /app
COPY --from=build /publish ./

#EXPOSE 443
ENTRYPOINT ["dotnet", "Application.dll"]