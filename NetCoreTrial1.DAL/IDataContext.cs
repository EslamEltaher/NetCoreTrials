using Microsoft.EntityFrameworkCore;
using NetCoreTrial1.Core.Models;
using System;

namespace NetCoreTrial1.Persistence
{
    public interface IDataContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
    }
}
