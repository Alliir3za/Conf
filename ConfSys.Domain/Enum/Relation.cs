using System.ComponentModel;

namespace ConfSys.Domain.Enum;

public enum Relation : byte
{
    [Description("مادر")]
    Mother = 0,

    [Description("پدر")]
    Father = 1,

    [Description("برادر")]
    Brother = 2,

    [Description("خواهر")]
    Sister = 3,

    [Description("پسر")]
    Son = 4,

    [Description("دختر")]
    Daughter = 5,

    [Description("عمو")]
    Uncle = 6,

    [Description("عمه")]
    Aunt = 7,

    [Description("مادربزرگ")]
    GrandMother = 8,

    [Description("مادبزرگ")]
    Grandfather = 9
}
