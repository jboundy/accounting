open terminal to database folder

docker-compose up -d

if no migration
dotnet ef migrations add InitialCreate

dotnet ef database update

generate api client for react
terminal into frontend folder

run .net api in debug mode

nswag openapi2tsclient /input:http://localhost:5250/swagger/v1/swagger.json /output:src/api/apiClient.ts /template:fetch

localhost:port set in your launchsettings
