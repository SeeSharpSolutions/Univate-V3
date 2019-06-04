FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["AgentRepository/AgentRepository.csproj", "AgentRepository/"]
RUN dotnet restore "AgentRepository/AgentRepository.csproj"
COPY . .
WORKDIR "/src/AgentRepository"
RUN dotnet build "AgentRepository.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AgentRepository.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AgentRepository.dll"]