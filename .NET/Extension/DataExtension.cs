public static class DataExtension
{
    public static TValue TryGetValueOrDefault<TValue>(this IDictionary<string, TValue> dic, string key)
    {
        return dic.ContainsKey(key) ? dic[key] : default;
    }

    public static string ToJson<T>(this T obj)
    {
        return JsonCovert.SerializeObject(obj);
    }

    public static T FromJson<T>(this string jsonStr)
    {
        return JsonCovert.DeserializeObject<T>(jsonStr);
    }

    public static List<string> SplitToList(this string input, string delimiter = ",")
    {
        var items = new List<string>();
        {
            if(!string.IsNullOrEmpty(input))
            {
                items.AddRange(input.Split(delimiter));
            }
        }
        return items;
    }

    public static string ToMoneyFormat(this decimal? input)
    {
        return input?.ToString("#,###");
    }    

    public static string ToMoneyFormat(this double? input)
    {
        return input?.ToString("#,###");
    }  

    public static TimeSpan? ToTimeSpan(this string input)
    {
        return input != null ? TimeSpan.Parse(input) : null;
    }

    public static bool Skipped(this string input)
    {
        return string.IsNullOrEmpty(input) || input.Trim().Length == 0;
    }

    public static bool Skipped<T>(this ICollection<T> collection)
    {
        return collection == null || !collection.Any();
    }

    public static bool Skipped(this decimal? dt)
    {
        return dt == null || !dt.HasValue;
    }

    public static bool Skipped(this byte? dt)
    {
        return dt == 1;
    }

    public static bool Skipped(this bool? dt)
    {
        return dt == null || !dt.HasValue || !dt.Value;
    }

    public static int CountDigital(int number)
    {
        int count = 0;
        while(number > 0)
        {
            number = number / 10;
            count++;
        }
        return count;
    }
}