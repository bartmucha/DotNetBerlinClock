using System;
using BerlinClock.Enums;
using static System.String;

namespace BerlinClock.Classes
{
  internal class TimeConverterHours : ITimeConverter
  {
    private readonly IATimeParser _timeParser;
    private readonly ILampRowConverter _lampRowConverter;

    public TimeConverterHours()
    {
      _timeParser = new ATimeParserHours();
      _lampRowConverter = new HoursRowConverter();
    }

    public string ConvertTime(string aTime)
    {
      var hours = _timeParser.Parse(aTime);
      return Join(Environment.NewLine,
        _lampRowConverter.Convert(int.Parse(hours) / 5),
        _lampRowConverter.Convert(int.Parse(hours) % 5));
    }
  }

  class ATimeParserHours : ATimeParser
  {
    public ATimeParserHours() : base(TimePart.Hours) { }
  }

  class HoursRowConverter : LampRowConverter
  {
    private const int LampsRowCount = 4;

    public HoursRowConverter() : base(LampsRowCount) { }

    public override Func<int, LampState> LampSelector()
    {
      return any => LampState.Red;
    }
  }
}