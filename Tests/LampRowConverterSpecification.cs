using BerlinClock.Classes;
using BerlinClock.Enums;
using Moq;
using NUnit.Framework;

namespace BerlinClock.Tests
{
  [TestFixture]
  class LampRowConverterSpecification
  {
    static readonly object[] ConvertCases =
    {
      new object[] {5, 0, "OOOOO" },
      new object[] {5, 2, "YYOOO" },
      new object[] {5, 5, "YYYYY" },
    };

    [Test]
    public void ShouldReturnStringEmptyWhenLampCountIsZero([Values(0)] int lampCount, [Values(0)] int lampOnCount)
    {
      //GIVEN
      var lampRowConverter = new Mock<LampRowConverter>(lampCount);
      lampRowConverter.Setup(f => f.LampSelector()).Returns(any => LampState.Yellow);

      //WHEN
      var row = lampRowConverter.Object.Convert(lampOnCount);

      //THEN
      Assert.AreEqual(string.Empty, row);
    }

    [Test, TestCaseSource(nameof(ConvertCases))]
    public void ShouldReturnStringEmptyWhenLampCountIsZero1(int lampCount, int lampOnCount, string convertOutput)
    {
      //GIVEN
      var lampRowConverter = new Mock<LampRowConverter>(lampCount);
      lampRowConverter.Setup(f => f.LampSelector()).Returns(any => LampState.Yellow);

      //WHEN
      var row = lampRowConverter.Object.Convert(lampOnCount);

      //THEN
      Assert.AreEqual(convertOutput, row);
    }
  }
}
