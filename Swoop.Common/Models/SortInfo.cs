using System.ComponentModel;

namespace Swoop.Common.Models
{
    public class SortInfo
    {
        public ListSortDirection? SortDirection { get; set; }
        public string Property { get; set; }

        public SortInfo(ListSortDirection? sortDirection, string property)
        {
            SortDirection = sortDirection;
            Property = property;
        }
    }
}
