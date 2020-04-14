using App.SharedKernel.Exception;
using App.SharedKernel.Extension;
using System;

namespace App.SharedKernel.Model
{
    [Serializable]
    public class Search
    {
        public int Skip { get; private set; }
        public int Take { get; private set; }
        public string SearchTerm { get; private set; }
        public string OrderBy { get; private set; }
        public bool IsAsc { get; private set; } = true;

        public string OrderByQuery { get; set; }

        public Search SetPaging(int skip, int take)
        {
            if (skip.IsNegative() || take.IsNegative())
                throw new BadRequestException($"{nameof(skip)} or {nameof(take)} cannot be negative");
            Skip = skip;
            Take = take;
            return this;
        }
        public Search SetSearchTerm(string searchTerm)
        {
            SearchTerm = searchTerm.Trim();
            return this;
        }
        public Search SetOrderBy(string orderBy, bool isAsc)
        {
            OrderBy = orderBy.Trim();
            IsAsc = isAsc;
            return this;
        }
        public Search SetOrderBy(string orderByQuery)
        {
            OrderByQuery = orderByQuery;
            return this;
        }
    }
}
