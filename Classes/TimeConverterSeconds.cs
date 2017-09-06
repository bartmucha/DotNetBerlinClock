using BerlinClock.Enums;

namespace BerlinClock.Classes
{
  internal class TimeConverterSeconds : ITimeConverter
  {
    private readonly SecondsRowConverter _lampRowConverter;

    public TimeConverterSeconds()
    {
      _lampRowConverter = new SecondsRowConverter();
    }

    public string ConvertTime(string aTime)
    {
      var seconds = aTime.Split(':')[(int) TimePart.Seconds];

      return _lampRowConverter.Convert(1 - (int.Parse(seconds) % 2));
    }
  }
}