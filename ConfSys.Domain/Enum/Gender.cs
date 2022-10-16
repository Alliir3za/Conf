using System.ComponentModel;

namespace ConfSys.Domain.Enum;

public enum Gender : byte
{
    [Description("مرد")]
    Male = 1,

    [Description("زن")]
    Female = 0
}
