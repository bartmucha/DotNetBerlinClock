using System;
using System.Globalization;

namespace BerlinClock.Classes
{
  public class TimeConverter : ITimeConverter
  {
    public string ConvertTime(string aTime)
    {
      var date = DateTime.ParseExact(aTime, "H:mm:ss", CultureInfo.InvariantCulture);

      var seconds = new TimeConverterSeconds().ConvertTime(aTime);
      var hours = new TimeConverterHours().ConvertTime(aTime);
      var minutes = new TimeConverterMinutes().ConvertTime(aTime);

      return string.Join(Environment.NewLine, seconds, hours, minutes);
    }
  }
}
