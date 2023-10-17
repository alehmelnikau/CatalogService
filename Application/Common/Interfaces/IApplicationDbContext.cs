﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; }
    DbSet<CategoryItem> CategoryItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
