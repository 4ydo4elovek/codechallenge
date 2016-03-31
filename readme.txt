Hello.
-------------------------
Solution contains 7 projects:
1) "Client" - ASP.NET MVC 4 application, shows the graph, connects to the service "WebNodeService" and "AlgorithmService" (if you change services port on IIS, please change "web.config" file);
2) "Client.Tests" - empty (didn't have time);
3) "DataAccessLayer" - work with database (file "script.sql" to create database and tables) through EntityFramework;
4) "Wcf Services" - contains 3 services, it should be placed on IIS server (i added it to the localhost:8081). In "app.config" you should specify your connection string to database;
5) "DataLoader" - console application to load nodes to database, connects to the service DataNodeService (if you change services port on IIS, please change "app.config" file)
6) Entities
7) DijkstrasAlgorithm - realization of Dijkstra's Algorithm (because undirected not weighted graph).
-------------------------
When you publicated "WcfServices" on IIS run solution. Projects "Client" and "DataLoader" will be run. After you specify folder with nodes in the console (example "C:\Work\Some\") text "Host started" appears. Then reload site page in the browser.
-------------------------
If required, the code can be optimized and can be added the backlight of nodes on visualisation.