using System.Collections.Generic;
using System.Linq;

namespace uHelper.Extensions
{
    public class HtmlRow
    {
        public FuzzyDictionary<string> Texts { get; set; }
        public FuzzyDictionary<string> Links { get; set; }

        public HtmlRow()
        {
            Texts = new FuzzyDictionary<string>();
            Links = new FuzzyDictionary<string>();
        }
    }

    public class FuzzyDictionary<T> : Dictionary<string, T> where T:class
    {
        public T WhereKeyContains(string pattern)
        {
            var matches = this.Where(x => x.Key.Contains(pattern)).ToList();
            if (!matches.Any())
                return default(T);
            return matches.Single().Value;
        }
    }
}
