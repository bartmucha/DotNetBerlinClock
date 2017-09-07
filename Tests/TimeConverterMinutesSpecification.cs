using System;
using BerlinClock.Classes.Factories;
using NUnit.Framework;

namespace BerlinClock.Tests
{
  [TestFixture]
  class TimeConverterMinutesSpecification
  {
    static readonly object[] MinutesDevidesBy5WithoutReminderCases =
    {
      new object[] { "15:00:00", "OOOOOOOOOOO", "OOOO" },
      new object[] { "15:05:00", "YOOOOOOOOOO", "OOOO" },
      new object[] { "15:10:00", "YYOOOOOOOOO", "OOOO" },
      new object[] { "15:15:00", "YYROOOOOOOO", "OOOO" },
      new object[] { "15:30:00", "YYRYYROOOOO", "OOOO" },
      new object[] { "15:55:00", "YYRYYRYYRYY", "OOOO" }
    };

    static readonly object[] MinutesDevidesBy5WithReminderCases =
    {
      new object[] { "15:01:00", "OOOOOOOOOOO", "YOOO" },
      new object[] { "15:07:00", "YOOOOOOOOOO", "YYOO" },
      new object[] { "15:13:00", "YYOOOOOOOOO", "YYYO" },
      new object[] { "15:59:00", "YYRYYRYYRYY", "YYYY" },
    };

    [Test, TestCaseSource(nameof(MinutesDevidesBy5WithoutReminderCases))]
    public void ShouldLitRedAndYellowLampsAppropriatlyToMinutesInFirstRowAndHaveAllLampsOffInSecondRowWhenMinutesDevidesBy5WithoutReminder(string minutes, string firstRowOutput, string secondRowOutput)
    {
      //GIVEN
      var timeConverterMinutes = ITimeConverterFactory.CreateTimeConverterMinutes();

      //WHEN
      var minutesTime = timeConverterMinutes.ConvertTime(minutes);

      //THEN
      Assert.AreEqual(string.Join(Environment.NewLine, firstRowOutput, secondRowOutput), minutesTime);
    }

    [Test, TestCaseSource(nameof(MinutesDevidesBy5WithReminderCases))]
    public void ShouldLitRedAndYellowLampsAppropriatlyToMinutesInBothRowsWhenMinutesDevidesBy5WithReminder(string minutes, string firstRowOutput, string secondRowOutput)
    {
      //GIVEN
      var timeConverterMinutes = ITimeConverterFactory.CreateTimeConverterMinutes();

      //WHEN
      var minutesTime = timeConverterMinutes.ConvertTime(minutes);

      //THEN
      Assert.AreEqual(string.Join(Environment.NewLine, firstRowOutput, secondRowOutput), minutesTime);
    }
  }
}
