CREATE PROCEDURE [dbo].[addplayer]
 @playername nvarchar(255),
 @score int
AS
begin
insert into dbo.Players (playername, score) values (@playername, @score);
end