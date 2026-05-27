public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        database.BeginTransaction();
        try
        {
            database.Write(data);
            database.EndTransaction();
        }
        finally
        {
            database.Dispose();
        }
    }

    public bool WriteSafely(string data)
    {
        database.BeginTransaction();
        try
        {
            database.Write(data);
            database.EndTransaction();
            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            database.Dispose();
        }
    }
}
