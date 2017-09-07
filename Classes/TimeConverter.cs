using System;
using System.Collections.Generic;
using System.Linq;
using BerlinClock.Classes.Validators;
using BerlinClock.Interfaces;

namespace BerlinClock.Classes
{
  public class TimeConverter : ITimeConverter
  {
    private readonly IATimeValidator _validator;
    private readonly List<ITimeConverter> _converters;

    public TimeConverter()
    {
      _validator = new ATimeValidator();
      _converters = new List<ITimeConverter>
      {
        new TimeConverterSeconds(),
        new TimeConverterHours(),
        new TimeConverterMinutes()
      };
    }

    public string ConvertTime(string aTime)
    {
      _validator.Validate(aTime);

      return string.Join(Environment.NewLine,
        _converters
        .Select(conv => conv.ConvertTime(aTime)));
    }
  }
}
