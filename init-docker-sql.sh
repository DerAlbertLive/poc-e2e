#!/bin/sh

docker run -it -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=2019#Integration"  -p 1433:1433 --name "E2ESQL2019"  -d mcr.microsoft.com/mssql/server