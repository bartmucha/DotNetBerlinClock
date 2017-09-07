using System;
using BerlinClock.Interfaces;
using static System.String;

namespace BerlinClock.Classes
{
  internal class TimeConverterMinutes : ITimeConverter
  {
    private readonly IATimeParser _timeParser;
    private readonly ILampRowParser _rowOneParser;
    private readonly ILampRowParser _rowTwoParser;

    public TimeConverterMinutes(IATimeParser timeParser, ILampRowParser rowOneParser, ILampRowParser rowTwoParser)
    {
      _timeParser = timeParser;
      _rowOneParser = rowOneParser;
      _rowTwoParser = rowTwoParser;
    }

    public string ConvertTime(string aTime)
    {
      var minutes = _timeParser.Parse(aTime);
      return Join(Environment.NewLine,
        _rowOneParser.Parse(int.Parse(minutes) / 5),
        _rowTwoParser.Parse(int.Parse(minutes) % 5));
    }
  }
}