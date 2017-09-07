using System;
using BerlinClock.Enums;
using static System.String;

namespace BerlinClock.Classes
{
  internal class TimeConverterMinutes : ITimeConverter
  {
    private readonly IATimeParser _timeParser;
    private readonly ILampRowConverter _lampRowOneConverter;
    private readonly ILampRowConverter _lampRowTwoConverter;

    public TimeConverterMinutes()
    {
      _timeParser = new ATimeParserMinutes();
      _lampRowOneConverter = new MinutesRowOneConverter();
      _lampRowTwoConverter = new MinutesRowTwoConverter();
    }

    public string ConvertTime(string aTime)
    {
      var minutes = _timeParser.Parse(aTime);
      return Join(Environment.NewLine,
        _lampRowOneConverter.Convert(int.Parse(minutes) / 5),
        _lampRowTwoConverter.Convert(int.Parse(minutes) % 5));
    }
  }

  class ATimeParserMinutes : ATimeParser
  {
    public ATimeParserMinutes() : base(TimePart.Minutes) { }
  }

  abstract class MinutesRowConverter : LampRowConverter
  {
    protected MinutesRowConverter(int lampCount) : base(lampCount) { }
  }

  class MinutesRowOneConverter : MinutesRowConverter
  {
    private const int LampsRowCount = 11;

    public MinutesRowOneConverter() : base(LampsRowCount) { }

    public override Func<int, LampState> LampSelector()
    {
      return index => index % 3 == 0
        ? LampState.Red
        : LampState.Yellow;
    }
  }

  class MinutesRowTwoConverter : MinutesRowConverter
  {
    private const int LampsRowCount = 4;

    public MinutesRowTwoConverter() : base(LampsRowCount) { }

    public override Func<int, LampState> LampSelector()
    {
      return any => LampState.Yellow;
    }
  }
}