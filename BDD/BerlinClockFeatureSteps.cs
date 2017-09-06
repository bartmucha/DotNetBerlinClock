using System;
using BerlinClock.Classes;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BerlinClock.BDD
{
  [Binding]
  public class TheBerlinClockSteps
  {
    private readonly ITimeConverter _berlinClock = new TimeConverter();
    private readonly ITimeConverter _berlinClockSeconds = new TimeConverterSeconds();
    private readonly ITimeConverter _berlinClockHours = new TimeConverterHours();
    private readonly ITimeConverter _berlinClockMinutes = new TimeConverterMinutes();
    private string _time;

    [When(@"the time is ""(.*)""")]
    public void WhenTheTimeIs(string givenTime)
    {
      _time = givenTime;
    }

    [Then(@"the clock should look like")]
    public void ThenTheClockShouldLookLike(string expectedBerlinClockOutput)
    {
      StringAssert.AreEqualIgnoringCase(expectedBerlinClockOutput, _berlinClock.ConvertTime(_time));
    }

    [Then(@"seconds should look like")]
    public void ThenSecondsShouldLookLike(string expectedBerlinClockSecondsOutput)
    {
      StringAssert.AreEqualIgnoringCase(expectedBerlinClockSecondsOutput, _berlinClockSeconds.ConvertTime(_time));
    }

    [Then(@"hours should look like")]
    public void ThenHoursShouldLookLike(string expectedBerlinClockHoursOutput)
    {
      StringAssert.AreEqualIgnoringCase(expectedBerlinClockHoursOutput, _berlinClockHours.ConvertTime(_time));
    }

    [Then(@"minutes should look like")]
    public void ThenMinutesShouldLookLike(string expectedBerlinClockMinutesOutput)
    {
      StringAssert.AreEqualIgnoringCase(expectedBerlinClockMinutesOutput, _berlinClockMinutes.ConvertTime(_time));
    }

    [Then(@"throw FormatException")]
    public void ThenThrowFormatException()
    {
      Assert.Throws<FormatException>(() => _berlinClock.ConvertTime(_time));
    }
  }
}
