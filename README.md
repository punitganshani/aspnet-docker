# aspnet-docker
Docker Proof of Concept with ASP.NET


# Key Commands

## Swarm

```
docker swarm init
docker swarm join --token SWMTKN-1-5m8equ2v9ifgg54au9thnmas5z458dkpsgs9ghzwqiyyc9drwd-chc54j709s8vpe0nh6k76f8jw 192.168.65.3:2377
```

## Dockers

```
stop all containers: docker kill $(docker ps -q)
remove all containers. docker rm $(docker ps -a -q)
remove all docker images. docker rmi $(docker images -q)
```

## Compose and Run

Development:
```
docker-compose --file "D:\Repo\Github\aspnet-docker\docker-compose.yml" -f "D:\Repo\Github\aspnet-docker\docker-compose.override.yml" up
```

Production:
```
docker-compose --file "D:\Repo\Github\aspnet-docker\docker-compose.yml" -f "D:\Repo\Github\aspnet-docker\docker-compose.prod.yml" up
```

# Compuse Build and Run

Development:
```
docker-compose --file "D:\Repo\Github\aspnet-docker\docker-compose.yml" -f "D:\Repo\Github\aspnet-docker\docker-compose.override.yml" build
docker-compose --file "D:\Repo\Github\aspnet-docker\docker-compose.yml" -f "D:\Repo\Github\aspnet-docker\docker-compose.override.yml" up

```

# Inspect Redis Volume

```
docker volume inspect  aspnetdocker_redis-data
```