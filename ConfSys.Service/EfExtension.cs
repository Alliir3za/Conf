namespace ConfSys.Service;

public static class EfExtension
{
    public static bool ToSaveChangeResult(this int value) => value >= 1;
}
