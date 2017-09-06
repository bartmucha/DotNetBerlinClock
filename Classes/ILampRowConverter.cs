using System;
using BerlinClock.Enums;

namespace BerlinClock.Classes
{
  internal interface ILampRowConverter
  {
    Func<int, LampState> LampSelector();
    string Convert(int lampOnCount);
  }

  abstract class LampRowConverter : ILampRowConverter
  {
    private readonly int _lampCount;

    protected LampRowConverter(int lampCount)
    {
      _lampCount = lampCount;
    }

    public abstract Func<int, LampState> LampSelector();

    public virtual string Convert(int lampOnCount)
    {
      var row = string.Empty;
      for (var i = 1; i <= lampOnCount; i++)
      {
        row += (char) LampSelector().Invoke(i);
      }
      return row.PadRight(_lampCount, (char)LampState.Off);
    }
  }

  class HoursRowConverter : LampRowConverter
  {
    private const int LampsRowCount = 4;

    public HoursRowConverter() : base(LampsRowCount) { }

    public override Func<int, LampState> LampSelector()
    {
      return any => LampState.Red;
    }
  }

  abstract class MinutesRowConverter : LampRowConverter
  {
    protected MinutesRowConverter(int lampCount) : base(lampCount) { }
  }

  class MinutesRowOneConverter : MinutesRowConverter
  {
    private const int LampsRowCount = 11;

    public MinutesRowOneConverter() : base(LampsRowCount) { }

    public override Func<int, LampState> LampSelector()
    {
      return index => index % 3 == 0
      ? LampState.Red
      : LampState.Yellow;
    }
  }

  class MinutesRowTwoConverter : MinutesRowConverter
  {
    private const int LampsRowCount = 4;

    public MinutesRowTwoConverter() : base(LampsRowCount) { }

    public override Func<int, LampState> LampSelector()
    {
      return any => LampState.Yellow;
    }
  }

  class SecondsRowConverter : LampRowConverter {
    public SecondsRowConverter() : base(1)
    {
    }

    public override Func<int, LampState> LampSelector()
    {
      return any => LampState.Yellow;
    }
  }
}