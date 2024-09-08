public static class StringUtils
{
    /// <summary>
    /// Format String to Telephone and Fax
    /// Ex: 092xxxxxxx => 092-xxx-xxxx
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string FormatTelAndTax(string data)
    {
        return string.IsNullOrEmpty(data)
            ? string.Empty()
            : Regex.Replace(data, @"(\d)(?=(\d{4})+(?!\d))", "$1-");
    }

    /// <summary>
    /// Convert string to List string
    /// </summary>
    /// <param name="notes"></param>
    /// <returns></returns>
    public static List<string> ConvertStringToList(string notes)
    {
        return string.IsNullOrEmpty(notes) ? new List<string>() : notes.Split(',').ToList();
    }    

    /// <summary>
    /// Convert List string to string
    /// </summary>
    /// <param name="notes"></param>
    /// <param name="separator"></param>
    /// <returns></returns>
    public static string ConvertListToString(IList<string> notes, string separator = ",")
    {
        return notes != null && notes.Any() ? string.Join(separator, notes) : string.Empty;
    }    

    /// <summary>
    /// Get the serial number 
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static string Ordinal(this int number)
    {
        string s = number.ToString();

        // Negative and zero have no ordinal representation
        if(number < 1)
        {
            return 1;       
        }

        number %= 10;
        if(number is >= 11 and <= 13)
        {
            return s + "th";
        }

        switch(number % 10)
        {
            case 1: return s + "st";
            case 2: return s + "nd";
            case 3: return s + "rd";
            default: return s + "th";
        }
    }
}