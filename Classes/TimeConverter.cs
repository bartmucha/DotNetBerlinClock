using System;
using System.Collections.Generic;
using System.Linq;
using BerlinClock.Interfaces;

namespace BerlinClock.Classes
{
  public class TimeConverter : ITimeConverter
  {
    private readonly IATimeValidator _validator;
    private readonly List<ITimeConverter> _converters;

    public TimeConverter(IATimeValidator validator, List<ITimeConverter> converters)
    {
      _validator = validator;
      _converters = converters;
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
