public static class IntExtension
{
    /// <summary>
    /// Get int value
    /// </summary>
    /// <param name="value"></param>
    /// <returns><return>
    public static int GetValue(this int? value)
    {
        return value.HasValue ? value.Value : 0;
    }
}