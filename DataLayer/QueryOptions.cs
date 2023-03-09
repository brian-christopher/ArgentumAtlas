﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataLayer;

public class QueryOptions<T>
{
    public Expression<Func<T, Object>> OrderBy { get; set; }

    public WhereClauses<T> WhereClauses { get; set; }

    public Expression<Func<T, bool>> Where
    {
        set
        {
            WhereClauses ??= new WhereClauses<T>();
            WhereClauses.Add(value);
        }
    }
    public string OrderByDirection { get; set; } = "asc";
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    private string[] _includes = Array.Empty<string>();

    public string Includes
    {
        set => _includes = value.Replace(" ", "").Split(",");
    }

    public string[] GetIncludes() => _includes;

    public bool HasWhere => WhereClauses != null;
    public bool HasOrderBy => OrderBy != null;
    public bool HasPaging => PageNumber > 0 && PageSize > 0;
}

public class WhereClauses<T> : List<Expression<Func<T, bool>>> { }
