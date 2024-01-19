#! /bin/bash
echo "starting sql server"
/opt/mssql/bin/sqlservr &&
sleep 30s
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "TIssen:)" -C -d master -i boilerplate-db-init.sql