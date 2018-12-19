#!/bin/bash

set -e
run_cmd="dotnet run -p ShakespeareAPI"

until dotnet -p ShakespeareAPI ef database update; do
>&2 echo "DB is starting up"
sleep 1
done

>&2 echo "SQL Server is up - executing command"
exec $run_cmd