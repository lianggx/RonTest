FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Ron.Blogs/Ron.Blogs.csproj", "src/Ron.Blogs/"]
RUN dotnet restore "src/Ron.Blogs/Ron.Blogs.csproj"
COPY . .
WORKDIR "/src/src/Ron.Blogs"
RUN dotnet build "Ron.Blogs.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Ron.Blogs.csproj" -c Release -o /app/out

FROM base AS final
WORKDIR /app
COPY --from=publish /app/out .
ENTRYPOINT ["dotnet", "Ron.Blogs.dll"]