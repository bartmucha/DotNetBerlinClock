using BerlinClock.Enums;

namespace BerlinClock.Classes
{
  internal interface IATimeParser
  {
    string Parse(string aTime);
  }

  abstract class ATimeParser : IATimeParser
  {
    private readonly TimePart _timePart;

    protected ATimeParser(TimePart timePart)
    {
      _timePart = timePart;
    }
    public string Parse(string aTime)
    {
      return aTime.Split(':')[(int) _timePart];
    }
  }
}