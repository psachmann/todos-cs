using System.ComponentModel;
using Nuke.Common.Tooling;

[TypeConverter(typeof(TypeConverter<Environment>))]
public class Environment : Enumeration
{
    public static Environment Dev = new Environment { Value = nameof(Dev) };
    public static Environment Test = new Environment { Value = nameof(Test) };
    public static Environment Prod = new Environment { Value = nameof(Prod) };

    public static implicit operator string(Environment environment)
    {
        return environment.Value;
    }
}
