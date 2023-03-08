CREATE PROCEDURE [dbo].[getplayer]
 @id int
AS
begin
select playername from dbo.[Players] where Id = @id;
end