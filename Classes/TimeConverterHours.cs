using System;
using BerlinClock.Interfaces;
using static System.String;

namespace BerlinClock.Classes
{
  internal class TimeConverterHours : ITimeConverter
  {
    private readonly IATimeParser _timeParser;
    private readonly ILampRowParser _rowParser;

    public TimeConverterHours(IATimeParser timeParser, ILampRowParser rowParser)
    {
      _timeParser = timeParser;
      _rowParser = rowParser;
    }

    public string ConvertTime(string aTime)
    {
      var hours = _timeParser.Parse(aTime);
      return Join(Environment.NewLine,
        _rowParser.Parse(int.Parse(hours) / 5),
        _rowParser.Parse(int.Parse(hours) % 5));
    }
  }
}