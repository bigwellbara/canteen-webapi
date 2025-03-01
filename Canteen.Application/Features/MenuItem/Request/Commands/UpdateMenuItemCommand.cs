﻿using Canteen.Application.DTOs.MenuItemDTO;
using Canteen.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.Features.MenuItem.Request.Commands
{
    public class UpdateMenuItemCommand : IRequest<GeneralResponse>
    {
        public int MenuItemId { get; set; }
        public UpdateMenuItemDto MenuItemDto { get; set; }
    }
}