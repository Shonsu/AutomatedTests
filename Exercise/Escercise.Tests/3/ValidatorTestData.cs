using System.Collections;
using Exercise;

namespace Escercise.Tests
{
    public class ValidatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new List<DateRange>() { new DateRange(new DateTime(2000, 10, 1), new DateTime(2000, 10, 5)), new DateRange(new DateTime(2000, 10, 11), new DateTime(2000, 10, 15)) },
                                                            new DateRange(new DateTime(2000, 10, 5), new DateTime(2000, 10, 10)) };
            yield return new object[] { new List<DateRange>() { new DateRange(new DateTime(2001, 10, 1), new DateTime(2001, 10, 5)), new DateRange(new DateTime(2002, 10, 11), new DateTime(2002, 10, 15)) },
                                                            new DateRange(new DateTime(2001, 9, 6), new DateTime(2002, 12, 10)) };
            yield return new object[] { new List<DateRange>() { new DateRange(new DateTime(2005, 10, 1), new DateTime(2006, 10, 5)), new DateRange(new DateTime(2004, 10, 11), new DateTime(2005, 10, 15)) },
                                                            new DateRange(new DateTime(2005, 1, 6), new DateTime(2004, 10, 10)) };
            yield return new object[] { new List<DateRange>() { new DateRange(new DateTime(2005, 10, 1), new DateTime(2006, 10, 5)), new DateRange(new DateTime(2004, 10, 11), new DateTime(2005, 10, 15)) },
                                                            new DateRange(new DateTime(2004, 1, 6), new DateTime(2005, 10, 10)) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}