using System.Collections.Generic;
using BerlinClock.Classes.Parsers;
using BerlinClock.Classes.Validators;
using BerlinClock.Interfaces;

namespace BerlinClock.Classes.Factories
{
  public static class ITimeConverterFactory
  {
    public static ITimeConverter CreateTimeConverter()
    {
      return new TimeConverter(new ATimeValidator(), new List<ITimeConverter>
      {
        CreateTimeConverterSeconds(),
        CreateTimeConverterHours(),
        CreateTimeConverterMinutes()
      });
    }

    public static ITimeConverter CreateTimeConverterSeconds()
    {
      return new TimeConverterSeconds(new ATimeParserSeconds(), new SecondsRowParser());
    }

    public static ITimeConverter CreateTimeConverterHours()
    {
      return new TimeConverterHours(new ATimeParserHours(), new HoursRowParser());
    }

    public static ITimeConverter CreateTimeConverterMinutes()
    {
      return new TimeConverterMinutes(new ATimeParserMinutes(), new MinutesRowOneParser(), new MinutesRowTwoParser());
    }
  }
}