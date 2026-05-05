static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var main = $"{name} - {department?.ToUpper() ?? "OWNER"}";

        return id == null ? main : $"[{id}] - {main}";
    }
}
