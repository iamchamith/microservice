using System;

namespace App.SharedKernel.Model
{
    [Serializable]
    public class PageList
    {
        public Search Search { get; private set; }
        public int RecordCount { get; private set; }
        public PageList SetPageResult(int recordCount = 0, Search search = null)
        {
            RecordCount = recordCount;
            Search = search ?? new Search();
            return this;
        }
    }
}
