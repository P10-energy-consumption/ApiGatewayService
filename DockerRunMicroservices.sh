#!/bin/bash
docker build -t petstore-gateway .

cd .. && cd pet-service-v1/pet-service-v1 && docker build -t petstore-pet .

cd .. && cd user-service-v1/user-service-v1 && docker build -t petstore-user .

cd .. && cd store-service-v1/store-service-v1 && docker build -t petstore-store .

docker run --rm --add-host=host.docker.internal:host-gateway -p 8080:8080 petstore-gateway &
docker run --rm --add-host=host.docker.internal:host-gateway -p 8081:8081 petstore-pet &
docker run --rm --add-host=host.docker.internal:host-gateway -p 8082:8082 petstore-user &
docker run --rm --add-host=host.docker.internal:host-gateway -p 8083:8083 petstore-store &
wait
