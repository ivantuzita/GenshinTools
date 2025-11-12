namespace GenshinTools.Domain.Common.Helpers; 
public static class DateHelper {
    public static int GetCurrentDayOfWeek() {
        return ((int)DateTime.Now.DayOfWeek + 6) % 7;
    }
}
