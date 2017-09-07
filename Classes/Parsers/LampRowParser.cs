using System;
using System.Text;
using BerlinClock.Classes.Validators;
using BerlinClock.Enums;
using BerlinClock.Interfaces;

namespace BerlinClock.Classes.Parsers
{
  internal abstract class LampRowParser : ILampRowParser
  {
    private readonly LampRowValidator _lampRowValidator;
    private readonly int _lampCount;

    protected LampRowParser(int lampCount)
    {
      _lampRowValidator = new LampRowValidator(lampCount);
      _lampCount = lampCount;
    }

    public abstract Func<int, LampState> LampSelector();

    public string Parse(int lampOnCount)
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

  class HoursRowParser : LampRowParser
  {
    private const int LampsRowCount = 4;

    public HoursRowParser() : base(LampsRowCount) { }

    public override Func<int, LampState> LampSelector()
    {
      return any => LampState.Red;
    }
  }

  class SecondsRowParser : LampRowParser
  {
    private const int LampsRowCount = 1;

    public SecondsRowParser() : base(LampsRowCount)
    {
    }

    public override Func<int, LampState> LampSelector()
    {
      return any => LampState.Yellow;
    }
  }
}