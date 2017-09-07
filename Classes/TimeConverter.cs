using System;
using System.Collections.Generic;
using System.Linq;

namespace BerlinClock.Classes
{
  public class TimeConverter : ITimeConverter
  {
    private readonly List<ITimeConverter> _converters;

    public TimeConverter()
    {
      _converters = new List<ITimeConverter>
      {
        new TimeConverterSeconds(),
        new TimeConverterHours(),
        new TimeConverterMinutes()
      };
    }

    public string ConvertTime(string aTime)
    {
      return string.Join(Environment.NewLine,
        _converters
        .Select(conv => conv.ConvertTime(aTime)));
    }
  }
}
