# aspnet-docker
Docker Proof of Concept with ASP.NET


# Key Commands

## Swarm

```
docker swarm init
docker swarm join --token SWMTKN-1-5m8equ2v9ifgg54au9thnmas5z458dkpsgs9ghzwqiyyc9drwd-chc54j709s8vpe0nh6k76f8jw 192.168.65.3:2377
```

## Dockers


- Stop all containers: `docker kill $(docker ps -q)`
- Remove all containers. `docker rm $(docker ps -a -q)`
- Remove all docker images. `docker rmi $(docker images -q)`


## Compose and Run

Development:

```
docker-compose --file "D:\Repo\Github\aspnet-docker\docker-compose.yml" -f "D:\Repo\Github\aspnet-docker\docker-compose.override.yml" build
```

The output for this command should be like,


```
redis uses an image, skipping
Building vote
Step 1/17 : FROM microsoft/aspnetcore:2.0 AS base
 ---> f79840764591
Step 2/17 : WORKDIR /app
 ---> Using cache
 ---> d72effbb34e2
Step 3/17 : EXPOSE 80
 ---> Using cache
 ---> 504d6c078986
Step 4/17 : FROM microsoft/aspnetcore-build:2.0 AS build
 ---> 16c5c708c65e
Step 5/17 : WORKDIR /src
 ---> Using cache
 ---> 4d4b0a0a1750
Step 6/17 : COPY *.sln ./
 ---> Using cache
 ---> 365793550f5c
Step 7/17 : COPY vote/vote.csproj vote/
 ---> Using cache
 ---> 7c8ea0e3f2fa
Step 8/17 : RUN dotnet restore
 ---> Using cache
 ---> c0a33e238483
Step 9/17 : COPY . .
 ---> 0ab1207ee411
Step 10/17 : WORKDIR /src/vote
Removing intermediate container 7bb79d30d09d
 ---> d875b8be1efa
Step 11/17 : RUN dotnet build -c Release -o /app
 ---> Running in 54e10e832f1f
Microsoft (R) Build Engine version 15.5.180.51428 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 100.52 ms for /src/vote/vote.csproj.
  Restore completed in 24.09 ms for /src/vote/vote.csproj.
Pages/Index.cshtml.cs(18,27): warning CS1998: This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread. [/src/vote/vote.csproj]
Pages/Index.cshtml.cs(24,42): warning CS1998: This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread. [/src/vote/vote.csproj]
  vote -> /app/vote.dll

Build succeeded.

Pages/Index.cshtml.cs(18,27): warning CS1998: This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread. [/src/vote/vote.csproj]
Pages/Index.cshtml.cs(24,42): warning CS1998: This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread. [/src/vote/vote.csproj]
    2 Warning(s)
    0 Error(s)

Time Elapsed 00:00:05.88
Removing intermediate container 54e10e832f1f
 ---> 21f96590156a
Step 12/17 : FROM build AS publish
 ---> 21f96590156a
Step 13/17 : RUN dotnet publish -c Release -o /app
 ---> Running in 42d9bb7cae86
Microsoft (R) Build Engine version 15.5.180.51428 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 65.1 ms for /src/vote/vote.csproj.
  Restore completed in 20.49 ms for /src/vote/vote.csproj.
  vote -> /src/vote/bin/Release/netcoreapp2.0/vote.dll
  vote -> /app/
Removing intermediate container 42d9bb7cae86
 ---> 66d176c791b6
Step 14/17 : FROM base AS final
 ---> 504d6c078986
Step 15/17 : WORKDIR /app
 ---> Using cache
 ---> 77ab05c4b80c
Step 16/17 : COPY --from=publish /app .
 ---> 76ae10fa3898
Step 17/17 : ENTRYPOINT ["dotnet", "vote.dll"]
 ---> Running in 0014bc648733
Removing intermediate container 0014bc648733
 ---> 0a64cb2c5d5f
Successfully built 0a64cb2c5d5f
Successfully tagged vote:latest

```

# Inspect Redis Volume

```
docker volume inspect  aspnetdocker_redis-data
```

the output should be like,

```
[
    {
        "CreatedAt": "2018-02-20T01:52:12Z",
        "Driver": "local",
        "Labels": {
            "com.docker.compose.project": "aspnetdocker",
            "com.docker.compose.volume": "redis-data"
        },
        "Mountpoint": "/var/lib/docker/volumes/aspnetdocker_redis-data/_data",
        "Name": "aspnetdocker_redis-data",
        "Options": {},
        "Scope": "local"
    }
]
```

# Push to Docker Cloud

Image available at: `https://hub.docker.com/r/punitganshani/aspnet-docker-vote/`

```
docker tag vote:latest punitganshani/aspnet-docker-vote
docker push punitganshani/aspnet-docker-vote
```

