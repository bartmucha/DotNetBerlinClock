using System;
using BerlinClock.Classes.Validators;
using NUnit.Framework;

namespace BerlinClock.Tests.Validators
{
  [TestFixture]
  class ATimeValidatorSpecification
  {
    static readonly string[] InvalidCases =
    {
      "-00:00:00",
      "+00:00:00",
      "24:00:01",
      "12:13:60",
      "12:60:14",
      "24:13:14"
    };

    static readonly string[] ValidCases =
    {
      "00:00:00",
      "12:13:14",
      "24:00:00"
    };

    [Test, TestCaseSource(nameof(InvalidCases))]
    public void ShouldThrowFormatExceptionWhenDateIsInvalid(string aTime)
    {
      //GIVEN
      var aTimeValidator = new ATimeValidator();

      //THEN
      Assert.Throws<FormatException>(() => aTimeValidator.Validate(aTime));
    }

    [Test, TestCaseSource(nameof(ValidCases))]
    public void ShouldNotThrowFormatExceptionWhenDateIsValid(string aTime)
    {
      //GIVEN
      var aTimeValidator = new ATimeValidator();

      //THEN
      Assert.DoesNotThrow(() => aTimeValidator.Validate(aTime));
    }
  }
}
