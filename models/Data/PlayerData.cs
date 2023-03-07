﻿using models.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Data;

public class PlayerData
{
    private readonly IDataAcces _db;
    public PlayerData(IDataAcces db)
    {
        _db = db;
    }

    public Task<IEnumerable<PlayerModel>> GetUsers() => _db.LoadData<PlayerModel, dynamic>(storedprocedure: "dbo.getallplayers", new { });

    public async Task<PlayerModel?> GetUser(int id)
    {
        var results = await _db.LoadData<PlayerModel, dynamic>(storedprocedure: "dbo.getplayer", new {Id = id});

        return results.FirstOrDefault();
    }
}
