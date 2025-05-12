docker build -t webshop .

docker run -d -p 8080:80 --name webshopcontainer webshop

dotnet test

dotnet run --project WebShop


https://github.com/arybbe/CleanCode-Labb1