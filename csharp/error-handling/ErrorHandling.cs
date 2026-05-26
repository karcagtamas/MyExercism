public static class ErrorHandling
{
    public static void HandleErrorByThrowingException() => throw new Exception("Exception");

    public static int? HandleErrorByReturningNullableType(string input) => int.TryParse(input, out var res) ? res : null;

    public static bool HandleErrorWithOutParam(string input, out int result) => int.TryParse(input, out result);

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        disposableObject.Dispose();
        throw new Exception("Exception");
    }
}
