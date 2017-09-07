using BerlinClock.Classes.Factories;
using NUnit.Framework;

namespace BerlinClock.Tests
{
  [TestFixture]
  class TimeConverterSecondsSpecification
  {
    [Test]
    public void ShouldLitYellowLampWhenSecondIsEven([Values("00:00:00", "00:00:20")] string seconds)
    {
      //GIVEN
      var timeConverterSeconds = ITimeConverterFactory.CreateTimeConverterSeconds();

      //WHEN
      var secondsTime = timeConverterSeconds.ConvertTime(seconds);

      //THEN
      Assert.AreEqual("Y", secondsTime);
    }

    [Test]
    public void ShouldLitYellowLampWhenSecondIsOdd([Values("00:00:01", "00:00:15", "00:00:59")] string seconds)
    {
      //GIVEN
      var timeConverterSeconds = ITimeConverterFactory.CreateTimeConverterSeconds();

      //WHEN
      var secondsTime = timeConverterSeconds.ConvertTime(seconds);

      //THEN
      Assert.AreEqual("O", secondsTime);
    }
  }
}
