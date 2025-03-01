﻿using Canteen.Application.Repositories.Contracts;
using Canteen.DataAccessLayer.Data;
using Canteen.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Repositories.Implementation
{
    public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
    {
        public readonly AppDbContext _db;

        public MenuItemRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}