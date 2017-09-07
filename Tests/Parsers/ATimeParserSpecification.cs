using BerlinClock.Classes.Parsers;
using NUnit.Framework;

namespace BerlinClock.Tests.Parsers
{
  [TestFixture]
  class ATimeParserSpecification
  {
    private static readonly string ParsedTime = "12:13:14";

    [Test]
    public void ShouldReturnHoursFromGivenTime()
    {
      //GIVEN
      var aTimeParser = new ATimeParserHours();

      //WHEN
      var parsedTime = aTimeParser.Parse(ParsedTime);

      //THEN
      Assert.AreEqual("12", parsedTime);
    }

    [Test]
    public void ShouldReturnMinutesFromGivenTime()
    {
      //GIVEN
      var aTimeParser = new ATimeParserMinutes();

      //WHEN
      var parsedTime = aTimeParser.Parse(ParsedTime);

      //THEN
      Assert.AreEqual("13", parsedTime);
    }

    [Test]
    public void ShouldReturnSecondsFromGivenTime()
    {
      //GIVEN
      var aTimeParser = new ATimeParserSeconds();

      //WHEN
      var parsedTime = aTimeParser.Parse(ParsedTime);

      //THEN
      Assert.AreEqual("14", parsedTime);
    }
  }
}
