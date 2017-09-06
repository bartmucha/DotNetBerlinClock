using System;
using BerlinClock.Enums;
using static System.String;

namespace BerlinClock.Classes
{
  internal class TimeConverterHours : ITimeConverter
  {
    private readonly ILampRowConverter _lampRowConverter;

    public TimeConverterHours()
    {
      _lampRowConverter = new HoursRowConverter();
    }

    public string ConvertTime(string aTime)
    {
      var hours = aTime.Split(':')[(int) TimePart.Hours];

      var firstRowString = _lampRowConverter.Convert(int.Parse(hours) / 5);
      var secondRowString = _lampRowConverter.Convert(int.Parse(hours) % 5);

      return Join(Environment.NewLine, firstRowString, secondRowString);
    }
  }
}