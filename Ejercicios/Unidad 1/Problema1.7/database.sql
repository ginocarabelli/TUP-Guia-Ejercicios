create database Team
go
use Team
go
create table Positions(
position_id int identity primary key,
position varchar(20)
)
create table People(
person_id int identity primary key,
name_surname varchar(75),
birth_date datetime
)
create table Teams(
team_id int primary key,
team_name varchar(25),
coach_id int,
CONSTRAINT fk_coach_id FOREIGN KEY (coach_id) REFERENCES People(person_id)
)
create table Players(
player_id int identity primary key,
shirt_number int,
team_id int,
person_id int,
position_id int,
CONSTRAINT fk_team_id FOREIGN KEY (team_id) REFERENCES Teams(team_id),
CONSTRAINT fk_person_id FOREIGN KEY (person_id) REFERENCES People(person_id),
CONSTRAINT fk_position_id FOREIGN KEY (position_id) REFERENCES Positions(position_id)
)
GO
create procedure SP_GetAllTeams
as
begin
	SELECT *
	FROM Teams
end
GO
create procedure SP_GetAllPlayers
as
begin
	SELECT *
	FROM Players pl
	JOIN People pe ON pe.person_id = pl.person_id
end
GO
create procedure SP_GetAllPositions
as
begin
	SELECT *
	FROM Positions
end
GO
create procedure SP_GetTeamsById
	@ID int
as
begin
	SELECT *
	FROM Teams
	WHERE team_id = @ID
end
GO
create procedure SP_GetPlayersById
	@ID int
as
begin
	SELECT *
	FROM Players
	WHERE player_id = @ID
end
GO
create procedure SP_GetPositionsById
	@ID int
as
begin
	SELECT *
	FROM Positions
	WHERE position_id = @ID
end

