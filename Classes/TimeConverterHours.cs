using System;
using BerlinClock.Classes.Parsers;
using BerlinClock.Interfaces;
using static System.String;

namespace BerlinClock.Classes
{
  internal class TimeConverterHours : ITimeConverter
  {
    private readonly IATimeParser _timeParser;
    private readonly ILampRowParser _lampRowParser;

    public TimeConverterHours()
    {
      _timeParser = new ATimeParserHours();
      _lampRowParser = new HoursRowParser();
    }

    public string ConvertTime(string aTime)
    {
      var hours = _timeParser.Parse(aTime);
      return Join(Environment.NewLine,
        _lampRowParser.Parse(int.Parse(hours) / 5),
        _lampRowParser.Parse(int.Parse(hours) % 5));
    }
  }
}