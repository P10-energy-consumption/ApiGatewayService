#!/bin/bash
docker build -t petstore-gateway .

cd .. && cd pet-service-v1 && docker build -t petstore-pet .
cd .. && cd user-service-v1 && docker build -t petstore-user .
cd .. && cd store-service-v1 && docker build -t petstore-store .

docker run --rm --add-host=host.docker.internal:host-gateway --name petstore-gateway -p 8080:8080 petstore-gateway &
docker run --rm --add-host=host.docker.internal:host-gateway --name petstore-pet -p 8081:8081 petstore-pet &
docker run --rm --add-host=host.docker.internal:host-gateway --name petstore-user -p 8082:8082 petstore-user &
docker run --rm --add-host=host.docker.internal:host-gateway --name petstore-store -p 8083:8083 petstore-store &