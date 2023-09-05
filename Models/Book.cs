﻿using System;
using System.Collections.Generic;

namespace WebApplication10.Models;

public partial class Book
{
    public int N { get; set; }

    public double? Code { get; set; }

    public bool New { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Izd { get; set; }

    public double? Pages { get; set; }

    public string? Format { get; set; }

    public DateTime? Date { get; set; }

    public double? Pressrun { get; set; }

    public string? Themes { get; set; }

    public string? Category { get; set; }
}
