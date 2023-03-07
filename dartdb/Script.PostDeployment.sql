if not exists (select 1 from dbo.[Players])
begin
    insert into dbo.[Players] (playername, score)
    values ('remco', 301),
    ('leon', 301),
    ('anton', 301),
    ('thomas', 301),
    ('jesper', 301),
    ('onno', 301)
end