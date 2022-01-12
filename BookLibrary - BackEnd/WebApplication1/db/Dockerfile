FROM mysql:8.0.27
EXPOSE 3306
COPY ./WebApplication1/db/migrations/ /home/database
COPY ./WebApplication1/db/dataset/ /home/database
COPY ./WebApplication1/db/ci/init_database.sh /docker-entrypoint-initdb.d/init_database