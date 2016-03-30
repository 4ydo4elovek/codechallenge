create database Graph;
go
use Graph
go
create table Nodes
(
	Id int not null identity constraint PK_Nodes primary key,
	Label nvarchar(max)
)
go
create table Lines
(
	Id int not null identity constraint PK_Lines primary key,
	NodeIdFrom int not null constraint FK_NodesIdFrom foreign key references Nodes(Id),
	NodeIdTo int not null constraint FK_NodesIdTo foreign key references Nodes(Id)
)