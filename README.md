# kemcowiki
To start web api:
```
dotnet run --project ./api
```
To start vue app:
```
npm --prefix ./vueapp run serve
```
If you see this error on linux:<br>
- Error: ENOSPC: System limit for number of file watchers reached 

Do this:<br>
```
echo fs.inotify.max_user_watches=16384 | sudo tee -a /etc/sysctl.conf && sudo sysctl -p
```
Information on azure cosmosDB security and keys:<br>
https://docs.microsoft.com/en-us/azure/cosmos-db/database-security?tabs=sql-api<br>