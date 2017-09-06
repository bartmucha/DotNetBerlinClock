using System;
using BerlinClock.Enums;
using static System.String;

namespace BerlinClock.Classes
{
  internal class TimeConverterMinutes : ITimeConverter
  {
    private readonly ILampRowConverter _lampRowOneConverter;
    private readonly ILampRowConverter _lampRowTwoConverter;

    public TimeConverterMinutes()
    {
      _lampRowOneConverter = new MinutesRowOneConverter();
      _lampRowTwoConverter = new MinutesRowTwoConverter();
    }

    public string ConvertTime(string aTime)
    {
      var minutes = aTime.Split(':')[(int)TimePart.Minutes];

      var firstRowLamps = _lampRowOneConverter.Convert(int.Parse(minutes) / 5);
      var secondRowLamps = _lampRowTwoConverter.Convert(int.Parse(minutes) % 5);

      return Join(Environment.NewLine, firstRowLamps, secondRowLamps);
    }
  }
}