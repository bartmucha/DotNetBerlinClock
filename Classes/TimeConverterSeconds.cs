using BerlinClock.Classes.Parsers;
using BerlinClock.Interfaces;

namespace BerlinClock.Classes
{
  internal class TimeConverterSeconds : ITimeConverter
  {
    private readonly IATimeParser _timeParser;
    private readonly ILampRowParser _lampRowParser;

    public TimeConverterSeconds()
    {
      _timeParser = new ATimeParserSeconds();
      _lampRowParser = new SecondsRowParser();
    }

    public string ConvertTime(string aTime)
    {
      var seconds = _timeParser.Parse(aTime);
      return _lampRowParser.Parse(1 - (int.Parse(seconds) % 2));
    }
  }
}