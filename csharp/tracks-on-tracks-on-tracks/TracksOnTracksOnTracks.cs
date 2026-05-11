public static class Languages
{
    public static List<string> NewList() => [];

    public static List<string> GetExistingLanguages() => ["C#", "Clojure", "Elm"];

    public static List<string> AddLanguage(List<string> languages, string language) => [.. languages, language];

    public static int CountLanguages(List<string> languages) => languages.Count;

    public static bool HasLanguage(List<string> languages, string language) => languages.Contains(language);

    public static List<string> ReverseList(List<string> languages)
    {
        List<string> result = [];

        for (var i = languages.Count - 1; i >= 0; i--)
        {
            result.Add(languages[i]);
        }

        return result;
    }

    public static bool IsExciting(List<string> languages)
    {
        return 
            languages.Count > 0 
            && (languages[0] == "C#" || (languages[1] == "C#" && (languages.Count == 2 || languages.Count == 3)));
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        List<string> result = [];

        foreach (var item in languages)
        {
            if (item != language)
            {
                result.Add(item);
            }
        }

        return result;
    }

    public static bool IsUnique(List<string> languages) => languages.ToHashSet().Count == languages.Count;
}
