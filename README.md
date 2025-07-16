## Run Docker file
docker build -f Shopee.API/Dockerfile -t myapp:latest .

## Create docker-compose
Project > Add > Container Orchestrator Support > Docker Compose
- Check: `docker ps`

## Docker compose:
- Build image: `docker-compose build`
- Start: `docker-compose up -d`
- Stop: `docker-compose down`
- Check: `docker ps`
- Log: `docker-compose logs`
- Run prod: `docker-compose -f docker-compose.yml up -d`s

## Connect DB docker
`docker exec -it Shopee.Db mariadb -uroot -p`
nhập mật khẩu: Password@1234
- Gán quyền root
GRANT ALL PRIVILEGES ON shopee.* TO 'root'@'%' IDENTIFIED BY 'Password@1234';
FLUSH PRIVILEGES;
- Restart 
`docker restart Shopee.Db`

/*

version: '3.4'

services:
  Shopee.API:
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_HTTP_PORTS=8080
      - ASPNETCORE_HTTPS_PORTS=8081
      - ConnectionStrings__MyDatabase=server=Shopee.Db;port=3306;database=shopee;user id=root;password=Password@1234
    ports:
      - "8088:8080"
      - "8089:8081"
    volumes:
      - ${APPDATA}/Microsoft/UserSecrets:/home/app/.microsoft/usersecrets:ro
      - ${APPDATA}/ASP.NET/Https:/home/app/.aspnet/https:ro
*/

