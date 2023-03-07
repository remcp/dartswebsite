namespace models.DataAcces
{
    public interface IDataAcces
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedprocedure, U parameters, string connectionId = "Default");
        Task Savedata<T>(string storedprocedure, T parameters, string connectionId = "Default");
    }
}