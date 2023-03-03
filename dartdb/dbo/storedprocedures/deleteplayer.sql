CREATE PROCEDURE [dbo].[deleteplayer]
 @id int
AS
begin
delete from dbo.[Players] where Id = @id;
end