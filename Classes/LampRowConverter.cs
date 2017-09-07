using System;
using System.Text;
using BerlinClock.Enums;

namespace BerlinClock.Classes
{
  interface ILampRowConverter
  {
    Func<int, LampState> LampSelector();
    string Convert(int lampOnCount);
  }

  internal abstract class LampRowConverter : ILampRowConverter
  {
    private readonly LampRowValidator _lampRowValidator;
    private readonly int _lampCount;

    protected LampRowConverter(int lampCount)
    {
      _lampRowValidator = new LampRowValidator(lampCount);
      _lampCount = lampCount;
    }

    public abstract Func<int, LampState> LampSelector();

    public string Convert(int lampOnCount)
    {
      _lampRowValidator.Validate(lampOnCount);

      var row = new StringBuilder(_lampCount);
      for (var i = 1; i <= lampOnCount; i++)
      {
        row.Append((char) LampSelector().Invoke(i));
      }

      return row.ToString().PadRight(_lampCount, (char) LampState.Off);
    }
  }
}