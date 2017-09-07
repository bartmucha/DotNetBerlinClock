using System;
using BerlinClock.Interfaces;

namespace BerlinClock.Classes.Validators
{
  class LampRowValidator : ILampRowValidator
  {
    private readonly int _lampCount;

    public LampRowValidator(int lampCount)
    {
      _lampCount = lampCount;
    }
    public void Validate(int lampOnCount)
    {
      if (_lampCount < lampOnCount)
        throw new ArgumentOutOfRangeException(nameof(lampOnCount), lampOnCount, $"Number of on lamps:{lampOnCount} is greater than number of all lamps: {_lampCount}");
    }
  }
}