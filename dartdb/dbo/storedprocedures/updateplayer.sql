CREATE PROCEDURE [dbo].[updateplayer]
 @playername nvarchar(255),
 @score int,
 @id int
AS
begin
update dbo.Players set playername = @playername, score = @score where Id = @id;
end