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
    
    /// <summary>
    /// Extension function convert string type to nullable integer type
    /// </summary>
    /// <param name="str"></param>
    /// <returns>Nullable integer<returns>
    public static int? ConvertStringToNullInteger(this string str)
    {
        return int.TryParse(str, out var validateInteger) ? validateInteger : default(int?)
    }

    /// <summary>
    /// Extension function convert string type to nullable decimal type
    /// </summary>
    /// <param name="str"></param>
    /// <returns>Nullable decimal<returns>
    public static decimal? ConvertStringToNullDecimal(this string str)
    {
        return int.TryParse(str, out var validateDecimal) ? validateDecimal : default(decimal?)
    }

    /// <summary>
    /// Extension function convert string type to nullable byte type
    /// </summary>
    /// <param name="str"></param>
    /// <returns>Nullable byte<returns>
    public static decimal? ConvertStringToNullByte(this string str)
    {
        return int.TryParse(str, out var validateByte) ? validateByte : default(decimal?)
    }

    /// <summary>
    /// Try Parse double
    /// </summary>
    /// <param name="value"></param>
    /// <returns><returns>
    /// <exception cref="Exception"><returns>
    public static double? TryParseDouble(this string value)
    {
        if(value.IsNullOrEmpty()){
            return null;
        }
        if(double.TryParse(value, out double result)){
            return result;
        }

        throw new Exception(message: "Can't convert to double");
    }

    /// <summary>
    /// Try Parse int
    /// </summary>
    /// <param name="value"></param>
    /// <returns><returns>
    /// <exception cref="Exception"><returns>
    public static int? TryParseInt(this string value)
    {
        if(value.IsNullOrEmpty()){
            return null;
        }
        if(int.TryParse(value, out int result)){
            return result;
        }

        throw new Exception(message: "Can't convert to int");
    }

    /// <summary>
    /// Try Parse byte
    /// </summary>
    /// <param name="value"></param>
    /// <returns><returns>
    /// <exception cref="Exception"><returns>
    public static byte? TryParseByte(this string value)
    {
        if(value.IsNullOrEmpty()){
            return null;
        }
        if(byte.TryParse(value, out byte result)){
            return result;
        }

        throw new Exception(message: "Can't convert to byte");
    }

    /// <summary>
    /// Extension function convert string type to nullable decimal type
    /// </summary>
    /// <param name="str"></param>
    /// <returns>Nullable decimal</returns>
    public static double? ConvertStringToNullDouble(this string str)
    {
        return double.TryParse(str, out var validDouble) ? validDouble : default(double?);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns><return>
    /// <exception cref="Exception"></exception>
    public static decimal? TryParseDecimal(this string str)
    {
        if(str.IsNullOrEmpty()) return null;
        if(decimal.TryParse(str, out var validDecimal)) return validDecimal;

        throw new Exception(message: "Can't convert to nullable decimal type")
    }

    /// <summary>
    /// Set Value string to string.Empty. Empty if string is null or empty
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string SetNullIfNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str) ? null : str;
    }
}