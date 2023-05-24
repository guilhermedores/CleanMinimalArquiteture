﻿using Microsoft.EntityFrameworkCore;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions<BaseDbContext> options)
    : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
}