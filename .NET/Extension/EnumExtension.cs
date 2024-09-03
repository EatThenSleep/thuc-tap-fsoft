using System;

public static class EnumExtension{
    public static T GetAttribute<T>(this Enum value) where T : Attribute
    {
        var type = value?.getType();
        var memberInfo = type?.getMember(value.toString());
        var attributes = memberInfo?[0].getCustomAttributes(typeof(T), false);
        return (T)attributes?[0];
    }

    public static string GetValue(this Enum value){
        var attribute = value.GetAttribute<ValueAttribute>();
        return attribute == null ? value.toString() : attribute.Value;
    }

    public static string GetVariable(this Enum value){
        var attribute = value.GetAttribute<VariableAttribute>();
        return attribute == null ? value.toString() : attribute.Variable;
    }
}