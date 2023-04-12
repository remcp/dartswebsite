using System.Data;

namespace IDAL.Context;

public interface IContext
{
    public IDbConnection CreateConnection();
}