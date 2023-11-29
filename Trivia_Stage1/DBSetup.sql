use master 
drop database TriviaDB
Go

create database TriviaDB
Go

use [TriviaDB]
Go

create table Ranking
(
[RankName] nvarchar (10) not null,
[RankId] int not null, primary key,
);

create table Player
(
[Email] nvarchar(50) not null, primary key,
[Name] nvarchar(10) not null,
[Rank] int not null, foreign key references Ranking(RankId),
[Points] int not null,
);

create table StatusQuestions
(
[StatusId] int not null, primary key,
[StatusDescription] nvarchar (10) not null
);

create table SubjectQuestions
(
[SubjectId] int identity(1,1) not null, primary key,
[SubjectName] nvarchar (10) not null
);


create table Questions
(
[Subject] nvarchar (30) not null, 
[Text] nvarchar (100) not null,
[QuestionId] int identity(1,1) not null, primary key,
[Ranswer] nvarchar (50) not null,
[Wanswer1] nvarchar (50) not null,
[Wanswer2] nvarchar (50) not null,
[Wanswer3] nvarchar (50) not null,
[CreatedBy] int not null, foreign key references Player(PlayerId),
[StatusId] int not null, foreign key references StatusQuestions(StatusId),
[SubjectId] int not null, foreign key references SubjectQuestions(SubjectId)
);

