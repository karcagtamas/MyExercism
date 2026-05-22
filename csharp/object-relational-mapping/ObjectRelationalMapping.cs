public class Orm(Database database) : IDisposable
{
    private readonly Database database = database;

    public void Begin() => database.BeginTransaction();

    public void Write(string data)
    {
        try
        {
            database.Write(data);
        }
        catch (InvalidOperationException)
        {
            Dispose();
        }
    }

    public void Commit()
    {
        try
        {
            database.EndTransaction();
        }
        catch (InvalidOperationException)
        {
            Dispose();
        }
    }

    public void Dispose() => database.Dispose();
}
