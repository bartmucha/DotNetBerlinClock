using System;
using BerlinClock.Classes.Factories;
using NUnit.Framework;

namespace BerlinClock.Tests
{
  [TestFixture]
  class TimeConverterHoursSpecification
  {
    static readonly object[] HoursDevidesBy5WithoutReminderCases =
    {
      new object[] { "00:00:00", "OOOO", "OOOO" },
      new object[] { "05:00:00", "ROOO", "OOOO" },
      new object[] { "10:00:00", "RROO", "OOOO" },
      new object[] { "15:00:00", "RRRO", "OOOO" },
      new object[] { "20:00:00", "RRRR", "OOOO" }
    };

    static readonly object[] HoursDevidesBy5WithReminderCases =
    {
      new object[] { "00:00:00", "OOOO", "OOOO" },
      new object[] { "06:00:00", "ROOO", "ROOO" },
      new object[] { "12:00:00", "RROO", "RROO" },
      new object[] { "18:00:00", "RRRO", "RRRO" },
      new object[] { "24:00:00", "RRRR", "RRRR" }
    };

    [Test, TestCaseSource(nameof(HoursDevidesBy5WithoutReminderCases))]
    public void
      ShouldLitRedLampsAppropriatlyToHoursInFirstRowAndHaveAllLampsOffInSecondRowWhenHoursDevidesBy5WithoutReminder(string hours, string firstRowOutput, string secondRowOutput)
    {
      //GIVEN
      var timeConverterHours = ITimeConverterFactory.CreateTimeConverterHours();

      //WHEN
      var hoursTime = timeConverterHours.ConvertTime(hours);

      //THEN
      Assert.AreEqual(string.Join(Environment.NewLine, firstRowOutput, secondRowOutput), hoursTime);
    }

    

    [Test, TestCaseSource(nameof(HoursDevidesBy5WithReminderCases))]
    public void
      ShouldLitRedLampsAppropriatlyToHoursInBothRowsWhenHoursDevidesBy5WithReminder(string hours, string firstRowOutput, string secondRowOutput)
    {
      //GIVEN
      var timeConverterHours = ITimeConverterFactory.CreateTimeConverterHours();

      //WHEN
      var hoursTime = timeConverterHours.ConvertTime(hours);

      //THEN
      Assert.AreEqual(string.Join(Environment.NewLine, firstRowOutput, secondRowOutput), hoursTime);
    }
  }
}
