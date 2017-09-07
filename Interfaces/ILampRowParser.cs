using System;
using BerlinClock.Enums;

namespace BerlinClock.Interfaces
{
  interface ILampRowParser
  {
    Func<int, LampState> LampSelector();
    string Parse(int lampOnCount);
  }
}