public static class TimeExtension
{
    // Convert float to formatted string: Example: 150 -> 02:30
    public static string AsFormattedDuration(this float input)
    {
        var intNumber = (int)Math.Round(input);
        var hour = (intNumber / 60).ToString().PadLeft(2, '0');
        var minute = (intNumber / 60).ToString().PadLeft(2, '0');
        return $"{hour}:{minute}";
    }

    // Convert string to float as minute. Example: 02:30 -> 150
    public static float AsMinutesDuration(this string input)
    {
        var timeParts = input.Split(':');
        var hours = int.Parse(timeParts[0]);
        var minutes = int.Parse(timeParts[1]);
        return hours * 60 + minutes;
    }

    public static string AsDateStringFormat(this DateTime? dateTime, string format = @"yyyy/MM/dd")
    {
        return dateTime?.ToString(format) ?? string.Empty;
    }

    public static string  AsTimeStringFormat(this TimeSpan? timeSpan, string format = @"hh\:mm")
    {
        return timeSpan?.ToString(format);
    }
}