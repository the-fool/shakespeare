FROM microsoft/dotnet:latest

COPY ./entrypoint.sh /
WORKDIR /app
# RUN ["dotnet", "restore"]
RUN chmod +x /entrypoint.sh
RUN sed -i 's/\r//' /entrypoint.sh
CMD /entrypoint.sh