using System;
using BerlinClock.Enums;

namespace BerlinClock.Classes.Parsers
{
  abstract class MinutesRowParser : LampRowParser
  {
    protected MinutesRowParser(int lampCount) : base(lampCount) { }
  }

  class MinutesRowOneParser : MinutesRowParser
  {
    private const int LampsRowCount = 11;

    public MinutesRowOneParser() : base(LampsRowCount) { }

    public override Func<int, LampState> LampSelector()
    {
      return index => index % 3 == 0
        ? LampState.Red
        : LampState.Yellow;
    }
  }

  class MinutesRowTwoParser : MinutesRowParser
  {
    private const int LampsRowCount = 4;

    public MinutesRowTwoParser() : base(LampsRowCount) { }

    public override Func<int, LampState> LampSelector()
    {
      return any => LampState.Yellow;
    }
  }
}