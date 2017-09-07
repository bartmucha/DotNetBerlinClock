using BerlinClock.Interfaces;

namespace BerlinClock.Classes
{
  internal class TimeConverterSeconds : ITimeConverter
  {
    private readonly IATimeParser _timeParser;
    private readonly ILampRowParser _rowParser;

    public TimeConverterSeconds(IATimeParser timeParser, ILampRowParser rowParser)
    {
      _timeParser = timeParser;
      _rowParser = rowParser;
    }

    public string ConvertTime(string aTime)
    {
      var seconds = _timeParser.Parse(aTime);
      return _rowParser.Parse(1 - (int.Parse(seconds) % 2));
    }
  }
}