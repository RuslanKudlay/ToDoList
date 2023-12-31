﻿using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IApplicationDbContext
    {
        DbSet<ToDoItem> ToDoItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
