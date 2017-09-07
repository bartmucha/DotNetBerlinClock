using System;

namespace BerlinClock.Classes
{
  interface ILampRowValidator
  {
    void Validate(int lampOn);
  }

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