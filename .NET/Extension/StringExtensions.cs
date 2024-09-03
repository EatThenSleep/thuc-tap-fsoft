public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

    public static string ReplaceAt(this string str, int index, int length, string replace)
    {
        return str.Remove(index, length).Insert(index, replace);
    }

    public static string NullToEmpty(this object value)
    {
        if(value == null) return string.Empty;
        return value.ToString().Trim();
    }
    
}