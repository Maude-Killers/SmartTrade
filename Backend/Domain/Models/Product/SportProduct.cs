﻿namespace Backend.Models;

public partial class SportProduct : Product
{
    public SportProduct() : base()
    {
        Category = Category.Sport;
    }
}