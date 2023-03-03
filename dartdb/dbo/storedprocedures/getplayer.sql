CREATE PROCEDURE [dbo].[getplayers]
 @id int
AS
begin
select playername from dbo.[Players] where Id = @id;
end