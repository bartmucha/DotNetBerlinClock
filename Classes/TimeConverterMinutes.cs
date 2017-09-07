using System;
using BerlinClock.Classes.Parsers;
using BerlinClock.Interfaces;
using static System.String;

namespace BerlinClock.Classes
{
  internal class TimeConverterMinutes : ITimeConverter
  {
    private readonly IATimeParser _timeParser;
    private readonly ILampRowParser _lampRowOneParser;
    private readonly ILampRowParser _lampRowTwoParser;

    public TimeConverterMinutes()
    {
      _timeParser = new ATimeParserMinutes();
      _lampRowOneParser = new MinutesRowOneParser();
      _lampRowTwoParser = new MinutesRowTwoParser();
    }

    public string ConvertTime(string aTime)
    {
      var minutes = _timeParser.Parse(aTime);
      return Join(Environment.NewLine,
        _lampRowOneParser.Parse(int.Parse(minutes) / 5),
        _lampRowTwoParser.Parse(int.Parse(minutes) % 5));
    }
  }
}