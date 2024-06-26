﻿namespace helpingout.Dtos
{
    public class QueryObject
    {
        public string Filter { get; set; }
        public string SortBy { get; set; }
        public int? Page { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
        public string SearchTerm { get; set; }
    }
}
