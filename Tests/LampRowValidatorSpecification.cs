using System;
using BerlinClock.Classes;
using NUnit.Framework;

namespace BerlinClock.Tests
{
  [TestFixture]
  class LampRowValidatorSpecification
  {
    [Test]
    public void ShouldThrowArgumentOutOfRangeExceptionWhenLampOnCountIsGreaterThenLampCount([Random(0, 5, 1)] int lampCount, [Random(6, 10, 1)] int lampOnCount)
    {
      //GIVEN
      var lampRowValidator = new LampRowValidator(lampCount);

      //THEN
      Assert.Throws<ArgumentOutOfRangeException>(() => lampRowValidator.Validate(lampOnCount));
    }

    [Test]
    public void ShouldNotThrowArgumentOutOfRangeExceptionWhenLampOnCountIsLowerOrEqualLampCount([Random(5, 10, 1)] int lampCount, [Random(0, 5, 1)] int lampOnCount)
    {
      //GIVEN
      var lampRowValidator = new LampRowValidator(lampCount);

      //THEN
      Assert.DoesNotThrow(() => lampRowValidator.Validate(lampOnCount));
    }
  }
}
