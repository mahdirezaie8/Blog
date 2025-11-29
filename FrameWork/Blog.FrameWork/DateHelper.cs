using System.Globalization;

namespace Blog.FrameWork
{
    public static class DateHelper
    {
        public static string ToPersianDate(this DateTime date)
        {
            var pc = new PersianCalendar();
            return $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
        }
    }
}
