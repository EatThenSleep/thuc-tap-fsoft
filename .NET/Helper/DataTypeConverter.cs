public static class DataTypeConverter
{
    /// <summary>
    /// Call Value to DateTime
    /// </summary>
    /// <param name="val"></param>
    /// <returns><returns>
    public static DateTime ValueToDateTime(this object val)
    {
        return val == null || string.IsNullOrEmpty(val.ToString())
                ? DateTime.MinValue.ToUniversalTime()
                : DateTime.Parse(val.ToString()).ToUniversalTime()
    }

    /// <summary>
    /// Call Value to Enum
    /// </summary>
    /// <param name="val"></param>
    /// <returns><return>
    public static TEnum ValueToEnum<TEnum>(this object value) where TEnum : Enum
    {
        if(val != null
            && !string.IsNullOrEmpty(val.ToString())
            && Enum.TryParse(typeof(TEnum), val.ToString(), true, out var eNum))
        {
            return (TEnum)enum;
        }
        return default;
    }

    /// <summary>
    /// Call Value to Int
    /// </summary>
    /// <param name="val"></param>
    /// <returns><return>
    public static int ValueToInt(this object val)
    {
        if(val == null || string.IsNullOrEmpty(val.ToString())) return 0;
        if(int.TryParse(val.ToString(), out var number)) return number;
        return 0;
    }

    /// <summary>
    /// Check value is number
    /// </summary>
    /// <param name="val"></param>
    /// <returns><return>
    public static int IsDigit(this object val)
    {
        if(val != null && !string.IsNullOrEmpty(val.ToString()) && int.TryParse(val.ToString(), out _))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Call Value to Guid
    /// </summary>
    /// <param name="val"></param>
    /// <returns><return>
    public static int ValueToGuid(this object val)
    {
        if(val == null || string.IsNullOrEmpty(val.ToString())) return Guid.Empty;
        if(Guid.TryParse(val.ToString(), out var guid)) return guid;
        return Guid.Empty;
    }

    /// <summary>
    /// Call Value to Double
    /// </summary>
    /// <param name="val"></param>
    /// <returns><return>
    public static int ValueToDouble(this object val)
    {
        return val == null || string.IsNullOrEmpty(val.ToString()) ? 0 : double.Parse(val.ToString());
    }

    /// <summary>
    /// Call Value to Decimal
    /// </summary>
    /// <param name="val"></param>
    /// <returns><return>
    public static int ValueToDecimal(this object val)
    {
        return val == null || string.IsNullOrEmpty(val.ToString()) ? 0 : decimal.Parse(val.ToString());
    }

    /// <summary>
    /// Call Value to Float
    /// </summary>
    /// <param name="val"></param>
    /// <returns><return>
    public static int ValueToFloat(this object val)
    {
        return val == null || string.IsNullOrEmpty(val.ToString()) ? 0 : float.Parse(val.ToString());
    }
}