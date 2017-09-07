using System;
using System.Globalization;
using BerlinClock.Interfaces;

namespace BerlinClock.Classes.Validators
{
  class ATimeValidator : IATimeValidator
  {
    public void Validate(string aTime)
    {
      if (aTime == "24:00:00")
        return;
      // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
      DateTime.ParseExact(aTime, "H:mm:ss", CultureInfo.InvariantCulture);
    }
  }
}