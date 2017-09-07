using System;
using BerlinClock.Enums;

namespace BerlinClock.Classes
{
  internal class TimeConverterSeconds : ITimeConverter
  {
    private readonly IATimeParser _timeParser;
    private readonly ILampRowConverter _lampRowConverter;

    public TimeConverterSeconds()
    {
      _timeParser = new ATimeParserSeconds();
      _lampRowConverter = new SecondsRowConverter();
    }

    public string ConvertTime(string aTime)
    {
      var seconds = _timeParser.Parse(aTime);
      return _lampRowConverter.Convert(1 - (int.Parse(seconds) % 2));
    }
  }

  class ATimeParserSeconds : ATimeParser
  {
    public ATimeParserSeconds() : base(TimePart.Seconds) { }
  }

  class SecondsRowConverter : LampRowConverter
  {
    private const int LampsRowCount = 1;

    public SecondsRowConverter() : base(LampsRowCount)
    {
    }

    public override Func<int, LampState> LampSelector()
    {
      return any => LampState.Yellow;
    }
  }
}