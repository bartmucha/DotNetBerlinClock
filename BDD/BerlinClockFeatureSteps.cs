using BerlinClock.Classes;
using BerlinClock.Interfaces;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BerlinClock.BDD
{
  [Binding]
  public class TheBerlinClockSteps
  {
    private readonly ITimeConverter _berlinClock = new TimeConverter();
    private string _time;

    [When(@"the time is ""(.*)""")]
    public void WhenTheTimeIs(string givenTime)
    {
      _time = givenTime;
    }

    [Then(@"the clock should look like")]
    public void ThenTheClockShouldLookLike(string expectedBerlinClockOutput)
    {
      Assert.AreEqual(expectedBerlinClockOutput, _berlinClock.ConvertTime(_time));
    }
  }
}
