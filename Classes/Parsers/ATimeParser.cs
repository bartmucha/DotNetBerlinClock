using BerlinClock.Enums;
using BerlinClock.Interfaces;

namespace BerlinClock.Classes.Parsers
{
  abstract class ATimeParser : IATimeParser
  {
    private const char TimeSplitSeparator = ':';
    private readonly TimePart _timePart;

    protected ATimeParser(TimePart timePart)
    {
      _timePart = timePart;
    }
    public string Parse(string aTime)
    {
      return aTime.Split(TimeSplitSeparator)[(int) _timePart];
    }
  }

  class ATimeParserHours : ATimeParser
  {
    public ATimeParserHours() : base(TimePart.Hours) { }
  }

  class ATimeParserMinutes : ATimeParser
  {
    public ATimeParserMinutes() : base(TimePart.Minutes) { }
  }

  class ATimeParserSeconds : ATimeParser
  {
    public ATimeParserSeconds() : base(TimePart.Seconds) { }
  }
}