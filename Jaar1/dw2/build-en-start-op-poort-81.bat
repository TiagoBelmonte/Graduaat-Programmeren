docker build . -t image-apache
docker run -d --name opdracht-container -p 81:80 image-apache
docker container start opdracht-container

