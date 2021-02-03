using System.Collections.Generic;

namespace ExtremeCarpaccio
{
    public record Order(string CountryCode, string ReductionName, IEnumerable<Item> Items);
}
