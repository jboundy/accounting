open terminal to database folder

docker-compose up -d

generate api client for react
terminal into frontend folder

install nswag tool
npm install nswag -g

run .net api in debug mode

nswag openapi2tsclient /input:http://localhost:5250/swagger/v1/swagger.json /output:src/api/apiClient.ts /template:fetch

localhost:port set in your launchsettings
